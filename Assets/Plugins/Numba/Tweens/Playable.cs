using Coroutines;
using Coroutines.Exceptions;
using System;
using System.Collections;
using Tweens.Formulas;
using UnityEngine;
using Coroutine = Coroutines.Coroutine;

namespace Tweens
{
    public interface IPlayable
    {
        #region State
        Type Type { get; }

        string Name { get; }

        float LoopDuration { get; }

        float Duration { get; }

        FormulaBase Formula { get; set; }

        int LoopsCount { get; set; }

        LoopType LoopType { get; set; }

        float PlayedTime { get; }

        State State { get; }

        bool IsReseted { get; }

        bool IsPlaying { get; }

        bool IsPaused { get; }

        bool IsCompleted { get; }

        Direction Direction { get; set; }
        #endregion

        IPlayable SetDirection(Direction direction);

        #region Rewinds
        Playable RewindTo(float time, bool emitEvents);

        Playable RewindToStart(bool emitEvents);

        Playable RewindToEnd(bool emitEvents);
        #endregion

        #region Skips
        Playable SkipTo(float time);

        Playable SkipToStart();

        Playable SkipToEnd();
        #endregion

        #region Playing
        Playable PlayForward(bool resetIfCompleted = true);

        Playable PlayBackward(bool resetIfCompleted = true);

        Playable Play(bool resetIfCompleted = true);

        Playable Pause();

        Playable Reset();
        #endregion

        #region Repeat
        Playable.IRepeater<Playable> GetRepeater();

        Playable.IRepeater<Playable> Repeat();

        Playable.IRepeater<Playable> RepeatBackward();
        #endregion

        #region Awaiters
        YieldAwaiter WaitForComplete();

        YieldAwaiter WaitForPause();
        YieldAwaiter WaitForPlay();
        #endregion
    }

    public abstract class Playable : IPlayable
    {
        public interface IRepeater<out T> where T : Playable
        {
            T Target { get; }

            bool IsPlaying { get; }

            Direction Direction { get; set; }

            IRepeater<T> SetDirection(Direction direction);

            IRepeater<T> PlayForward();

            IRepeater<T> PlayBackward();

            IRepeater<T> Play();

            IRepeater<T> Stop();

            YieldAwaiter WaitForStop();

            YieldAwaiter WaitForPlay();
        }

        public class Repeater<T> : IRepeater<T> where T : Playable
        {
            #region Awaiter classes
            public abstract class WaitAwaiter : YieldAwaiter
            {
                protected Repeater<T> _repeater;

                protected int _stateCode;

                public WaitAwaiter(Repeater<T> repeater)
                {
                    _repeater = repeater;
                    _stateCode = _repeater._stateCode;
                }
            }

            public class StopAwaiter : WaitAwaiter
            {
                public StopAwaiter(Repeater<T> repeater) : base(repeater) { }

                public override bool KeepWaiting => _stateCode == _repeater._stateCode && _repeater.IsPlaying;
            }

            public class PlayAwaiter : WaitAwaiter
            {
                public PlayAwaiter(Repeater<T> repeater) : base(repeater) { }

                public override bool KeepWaiting => _stateCode == _repeater._stateCode && !_repeater.IsPlaying;
            }
            #endregion

            private Coroutine _playingCoroutine;

            public T Target { get; private set; }

            public bool IsPlaying { get; private set; }

            public Direction Direction { get; set; }

            private int _stateCode;

            public Repeater(T playable) : this(CoroutinesOwner.Instance.gameObject, playable) { }

            public Repeater(GameObject owner, T playable)
            {
                _playingCoroutine = Coroutine.Create(owner, PlayRoutine());

                Target = playable;
            }

            public IRepeater<T> SetDirection(Direction direction)
            {
                Direction = direction;
                return this;
            }

            public IRepeater<T> PlayForward() => Play(Direction.Forward);

            public IRepeater<T> PlayBackward() => Play(Direction.Backward);

            public IRepeater<T> Play() => Play(Direction);


            private IRepeater<T> Play(Direction direction)
            {
                Direction = direction;

                if (IsPlaying)
                {
                    if (Target.Direction == direction)
                        throw new PlayControlException($"Repeater for {Target.Type} \"{Target.Name}\" is already playing in {direction} direction");
                }
                else
                {
                    IsPlaying = true;
                    _playingCoroutine.Run();

                    _stateCode++;
                }

                Target.Play(true, Direction);
                return this;
            }

            private IEnumerable PlayRoutine()
            {
                while (true)
                {
                    yield return Target.WaitForComplete();
                    Target.Play(true, Direction);
                }
            }

            public IRepeater<T> Stop()
            {
                if (!IsPlaying)
                    throw new PlayControlException($"Repeater for {Target.Type} \"{Target.Name}\" is already stoped");

                IsPlaying = false;
                _stateCode++;

                _playingCoroutine.Reset();
                Target.Pause();

                return this;
            }

            public YieldAwaiter WaitForStop() => new StopAwaiter(this);

            public YieldAwaiter WaitForPlay() => new PlayAwaiter(this);
        }

        #region State
        public abstract Type Type { get; }

        public string Name { get; protected set; }

        private float _loopDuration;

        public float LoopDuration
        {
            get => _loopDuration;
            protected set
            {
                if (value < 0f)
                    throw new ArgumentException($"{Type} \"{Name}\": Loop duration can't be less than 0 ({value} passed)");

                _loopDuration = value;
                RecalculateDuration();
            }
        }

        public float Duration { get; private set; }

        private FormulaBase _formula;

        public FormulaBase Formula
        {
            get => _formula;
            set => _formula = value ?? Tweens.Formula.Linear;
        }

        private int _loopsCount;

        public int LoopsCount
        {
            get => _loopsCount;
            set
            {
                if (value < 1)
                    throw new ArgumentException($"{Type} \"{Name}\": Loops count can't be less than 1 ({value} passed)");

                _loopsCount = value;
                RecalculateDuration();
            }
        }

        public LoopType LoopType { get; set; }

        public float PlayedTime { get; protected set; }

        private State _state;

        public State State
        {
            get => _state;
            private set
            {
                _state = value;

                Action stateEvent = _state switch
                {
                    State.Reseted => CallReseted,
                    State.Playing => CallPlaying,
                    State.Paused => CallPaused,
                    State.Completed => CallCompleted,
                    _ => throw new Exception($"{Type} \"{Name}\": Wrong playable state.")
                };

                stateEvent?.Invoke();
            }
        }

        public bool IsReseted => _state == State.Reseted;

        public bool IsPlaying => _state == State.Playing;

        public bool IsPaused => _state == State.Paused;

        public bool IsCompleted => _state == State.Completed;

        // TODO: need fix later
        public bool IsPlayingByParent => IsPlaying;

        protected Direction _direction;

        public Direction Direction
        {
            get => _direction;
            set
            {
                if (_direction == value)
                    return;

                _direction = value;
                RecalculatePlayTimes();
            }
        }
        #endregion

        #region Routines
        private Coroutine _playingCoroutine;

        private float _startTime;

        private float _endTime;
        #endregion

        protected Playable(GameObject owner, string name, float loopDuration, FormulaBase formula, int loopsCount, LoopType loopType, Direction direction)
        {
            Name = name;
            LoopDuration = loopDuration;
            Formula = formula ?? Tweens.Formula.Linear;
            LoopsCount = loopsCount;
            LoopType = loopType;
            Direction = direction;

            _playingCoroutine = Coroutine.Create(owner, PlayRoutine());
        }

        protected void RecalculateDuration()
        {
            Duration = LoopDuration * LoopsCount;
            PlayedTime = Mathf.Clamp(PlayedTime, 0f, Duration);

            RecalculatePlayTimes();
        }

        protected void RecalculatePlayTimes()
        {
            _startTime = Direction == Direction.Forward ? Time.time - PlayedTime : Time.time - (Duration - PlayedTime);
            _endTime = _startTime + Duration;
        }

        public IPlayable SetDirection(Direction direction)
        {
            Direction = direction;
            return this;
        }

        #region Loops
        protected float LoopTime(float time)
        {
            if (time == 0f)
                return 0f;

            time %= LoopDuration;
            return time == 0f ? LoopDuration : time;
        }

        protected int LoopIndex(float time)
        {
            if (time == 0f)
                return 0;

            var loopIndex = (int)(time / LoopDuration);
            time %= LoopDuration;

            return time == 0f ? loopIndex - 1 : loopIndex;
        }

        protected (int loopIndex, float loopedTime) LoopIndexTime(float time)
        {
            if (time == 0f)
                return (0, 0f);

            var loopIndex = (int)(time / LoopDuration);
            time %= LoopDuration;

            return time == 0f ? (loopIndex - 1, LoopDuration) : (loopIndex, time);
        }
        #endregion

        #region Phase events calls
        protected abstract void CallPhaseStarting(Direction direction);

        protected abstract void CallPhaseStarted(Direction direction);

        protected abstract void CallPhaseLoopStarting(int loop, Direction direction);

        protected abstract void CallPhaseLoopStarted(int loop, Direction direction);

        protected abstract void CallPhaseLoopCompleting(int loop, Direction direction);

        protected abstract void CallPhaseLoopCompleted(int loop, Direction direction);

        protected abstract void CallPhaseUpdating(float time, Direction direction);

        protected abstract void CallPhaseUpdated(float time, Direction direction);

        protected abstract void CallPhaseLoopUpdating(int loop, float time, Direction direction);

        protected abstract void CallPhaseLoopUpdated(int loop, float time, Direction direction);

        protected abstract void CallPhaseCompleting(Direction direction);

        protected abstract void CallPhaseCompleted(Direction direction);
        #endregion

        #region Routine calls
        protected abstract void CallReseted();

        protected abstract void CallPlaying();

        protected abstract void CallPaused();

        protected abstract void CallCompleted();
        #endregion

        protected virtual void BeforeStarting(Direction direction) { }

        #region Phase partial handlers
        #region Zero duration
        internal void HandlePhaseStartEventZero(Direction direction)
        {
            BeforeStarting(direction);
            CallPhaseStarting(direction);
            RewindZeroHandler(0, 0f, direction);
            CallPhaseStarted(direction);
        }

        internal void HandlePhaseFirstLoopStartEventZero(Direction direction)
        {
            CallPhaseLoopStarting(0, direction);
            RewindZeroHandler(0, 0f, direction);
            CallPhaseLoopStarted(0, direction);
        }

        internal void HandlePhaseLoopCompleteEventZero(int loop, Direction direction)
        {
            CallPhaseLoopCompleting(loop, direction);
            RewindZeroHandler(loop, 1f, direction);
            CallPhaseLoopCompleted(loop, direction);
        }

        internal void HandlePhaseLoopStartEventZero(int loop, Direction direction)
        {
            BeforeStarting(direction);
            CallPhaseLoopStarting(loop, direction);
            RewindZeroHandler(loop, 0f, direction);
            CallPhaseLoopStarted(loop, direction);
        }

        internal void HandlePhaseCompleteEventZero(Direction direction)
        {
            CallPhaseCompleting(direction);
            RewindZeroHandler(_loopsCount - 1, 1f, direction);
            CallPhaseCompleted(direction);
        }
        #endregion

        #region Non zero duration
        internal void HandlePhaseStartEvent(Direction direction)
        {
            BeforeStarting(direction);
            CallPhaseStarting(direction);
            RewindHandler(0, 0f, direction);
            CallPhaseStarted(direction);
        }

        internal void HandlePhaseFirstLoopStartEvent(Direction direction)
        {
            CallPhaseLoopStarting(0, direction);
            RewindHandler(0, 0f, direction);
            CallPhaseLoopStarted(0, direction);
        }

        internal void HandlePhaseLoopCompleteEvent(int loop, Direction direction)
        {
            CallPhaseLoopCompleting(loop, direction);
            RewindHandler(loop, _loopDuration, direction);
            PlayedTime = loop * _loopDuration + _loopDuration;
            CallPhaseLoopCompleted(loop, direction);
        }

        internal void HandlePhaseLoopStartEvent(int loop, Direction direction)
        {
            BeforeStarting(direction);
            CallPhaseLoopStarting(loop, direction);
            RewindHandler(loop, 0f, direction);
            CallPhaseLoopStarted(loop, direction);
        }

        internal void HandlePhaseLoopUpdateEvent(float endTime, int loop, float loopedTime, Direction direction)
        {
            CallPhaseUpdating(endTime, direction);
            CallPhaseLoopUpdating(loop, loopedTime, direction);
            RewindHandler(loop, loopedTime, direction);
            PlayedTime = endTime;
            CallPhaseLoopUpdated(loop, loopedTime, direction);
            CallPhaseUpdated(endTime, direction);
        }

        internal void HandlePhaseCompleteEvent(Direction direction)
        {
            CallPhaseCompleting(direction);
            RewindHandler(_loopsCount - 1, _loopDuration, direction);
            CallPhaseCompleted(direction);
        }
        #endregion
        #endregion

        #region Rewinds
        public Playable RewindToStart(bool emitEvents = true) => RewindTo(0f, emitEvents);

        public Playable RewindToEnd(bool emitEvents = true) => RewindTo(Duration, emitEvents);

        public Playable RewindTo(float time, bool emitEvents = true)
        {
            if (_loopDuration == 0f)
            {
                if (time == 0f)
                    return this;

                var direction = time > 0f ? Direction.Forward : Direction.Backward;

                if (emitEvents)
                    RewindZeroDurationWithEvents(direction);
                else
                    RewindZeroDurationWithoutEvents(direction);
            }
            else
            {
                time = Mathf.Clamp(time, 0f, Duration);

                if (time == PlayedTime)
                    return this;

                if (time > PlayedTime)
                {
                    if (emitEvents)
                        RewindWithEvents(PlayedTime, time, Direction.Forward);
                    else
                        RewindWithoutEvents(PlayedTime, time, Direction.Forward);
                }
                else
                {
                    if (emitEvents)
                        RewindWithEvents(Duration - PlayedTime, Duration - time, Direction.Backward);
                    else
                        RewindWithoutEvents(Duration - PlayedTime, Duration - time, Direction.Backward);
                }
            }

            return this;
        }

        private void RewindZeroDurationWithEvents(Direction direction)
        {
            // Started events.
            HandlePhaseStartEventZero(direction);
            HandlePhaseFirstLoopStartEventZero(direction);
            
            // Intermediate events
            for (int i = 1; i < _loopsCount; i++)
            {
                HandlePhaseLoopCompleteEventZero(i - 1, direction);
                HandlePhaseLoopStartEventZero(i, direction);
            }

            // Loop completed event.
            HandlePhaseLoopCompleteEventZero(_loopsCount - 1, direction);

            // Completed event
            HandlePhaseCompleteEventZero(direction);
        }

        private void RewindZeroDurationWithoutEvents(Direction direction)
        {
            // Started event.
            BeforeStarting(direction);
            RewindZeroHandler(0, 0f, direction);

            // Loop started event.
            RewindZeroHandler(0, 0f, direction);

            // Intermediate events
            for (int i = 1; i < _loopsCount; i++)
            {
                RewindZeroHandler(i - 1, 1f, direction);

                BeforeStarting(direction);
                RewindZeroHandler(i, 0f, direction);
            }

            // Loop completed event.
            RewindZeroHandler(_loopsCount - 1, 1f, direction);

            // Completed event
            RewindZeroHandler(_loopsCount - 1, 1f, direction);
        }

        private void RewindWithEvents(float startTime, float endTime, Direction direction)
        {
            // Global started phase
            if (startTime == 0f)
                HandlePhaseStartEvent(direction);

            var playedLoop = (int)(startTime / _loopDuration);
            var timeLoop = (int)(endTime / _loopDuration);

            // Loop started phase.
            if (startTime == playedLoop * _loopDuration)
            {
                // If all elements already handled in global start phase (BeforeStarting method was called previously),
                // than we don't need handle elements.
                if (startTime == 0f)
                    HandlePhaseFirstLoopStartEvent(direction);
                else
                    HandlePhaseLoopStartEvent(playedLoop, direction);
            }

            // Intermediate phase.
            for (int i = playedLoop + 1; i <= timeLoop - 1; i++)
            {
                var loopIndex = LoopIndex(LoopDuration * i);

                HandlePhaseLoopCompleteEvent(loopIndex, direction);
                HandlePhaseLoopStartEvent(loopIndex + 1, direction);
            }

            // Loop completed phase.
            if (endTime == timeLoop * _loopDuration)
                HandlePhaseLoopCompleteEvent(timeLoop - 1, direction);
            else // Global and loop update phases.
            {
                // Last intermediate loop phase. For example, when we start from
                // middle looped position and ended on other middle looped position.
                if (timeLoop - playedLoop > 0)
                {
                    HandlePhaseLoopCompleteEvent(timeLoop - 1, direction);
                    HandlePhaseLoopStartEvent(timeLoop, direction);
                }

                // Update phase.
                var loopedTime = LoopTime(endTime);
                HandlePhaseLoopUpdateEvent(endTime, timeLoop, loopedTime, direction);
            }

            // Global complete phase.
            if (endTime == Duration)
                HandlePhaseCompleteEvent(direction);
        }

        private void RewindWithoutEvents(float startTime, float endTime, Direction direction)
        {
            // Global started phase.
            if (startTime == 0f)
            {
                BeforeStarting(direction);
                RewindHandler(0, 0f, direction);
            }

            var playedLoop = (int)(startTime / _loopDuration);
            var timeLoop = (int)(endTime / _loopDuration);

            // Loop started phase
            if (startTime == playedLoop * _loopDuration)
            {
                // If all elements already handled in global start phase,
                // than we don't need handle elements.
                if (startTime != 0f)
                    BeforeStarting(direction);

                RewindHandler(playedLoop, 0f, direction);
            }

            // Intermediate phase.
            for (int i = playedLoop + 1; i <= timeLoop - 1; i++)
            {
                var loopIndex = LoopIndex(_loopDuration * i);

                RewindHandler(loopIndex, _loopDuration, direction);
                PlayedTime = loopIndex * _loopDuration + _loopDuration;

                BeforeStarting(direction);
                RewindHandler(loopIndex + 1, 0f, direction);
            }

            // Loop completed phase.
            if (endTime == timeLoop * _loopDuration)
            {
                RewindHandler(timeLoop - 1, _loopDuration, direction);
                PlayedTime = endTime;
            }
            else // Global and loop update phases.
            {
                // Last intermediate loop phase.
                if (timeLoop - playedLoop > 0)
                {
                    RewindHandler(timeLoop - 1, _loopDuration, direction);
                    PlayedTime = (timeLoop - 1) * _loopDuration + _loopDuration;

                    BeforeStarting(direction);
                    RewindHandler(timeLoop, 0f, direction);
                }

                // Update phase.
                var loopedTime = LoopTime(endTime);

                RewindHandler(timeLoop, loopedTime, direction);
                PlayedTime = endTime;
            }

            // Global complete phase.
            if (endTime == Duration)
                RewindHandler(timeLoop - 1, _loopDuration, direction);
        }

        protected abstract void RewindZeroHandler(int loop, float loopedNormalizedTime, Direction direction);

        protected abstract void RewindHandler(int loop, float loopedTime, Direction direction);
        #endregion

        #region Skips

        /// <summary>
        /// This method is needed to allow overriding in the final descendant. 
        /// Clamp and sets the passed time to the PlayedTime property.
        /// </summary>
        /// <param name="time">Time until which events will be skipped</param>
        /// <returns>This object.</returns>
        protected virtual Playable SkipTimeTo(float time)
        {
            // if loop duration is zero, then played time will also always be zero,
            // so there is no point in assigning to it.
            if (time == PlayedTime || LoopDuration == 0f)
                return this;

            PlayedTime = Mathf.Clamp(time, 0f, Duration);
            return this;
        }

        public Playable SkipTo(float time) => SkipTimeTo(time);

        public Playable SkipToStart() => SkipTo(0f);

        public Playable SkipToEnd() => SkipTo(Duration);
        #endregion

        #region Playing
        public Playable PlayForward(bool resetIfCompleted = true) => Play(resetIfCompleted, Direction.Forward);

        public Playable PlayBackward(bool resetIfCompleted = true) => Play(resetIfCompleted, Direction.Backward);

        public Playable Play(bool resetIfCompleted = true) => Play(resetIfCompleted, Direction);

        private Playable Play(bool resetIfCompleted, Direction direction)
        {
            if (IsPlaying && Direction == direction)
                throw new PlayControlException($"{Type} \"{Name}\": Already playing in {direction} direction");

            Direction = direction;

            if (IsCompleted)
            {
                if (!resetIfCompleted)
                    throw new PlayControlException($"{Type} \"{Name}\": Already completed");

                Reset(Direction == Direction.Backward);
            }

            RecalculatePlayTimes();

            if (!IsPlaying)
            {
                State = State.Playing;
                _playingCoroutine.Run();

                // It is needed to listen coroutine reseted event,
                // because someone can turn off or destroy owner object.
                // In this case Playable need correct handling of self state.
                _playingCoroutine.Reseted += CoroutineResetObserver;
            }

            return this;
        }

        private void CoroutineResetObserver(Coroutine coroutine) => Reset(false);

        private IEnumerable PlayRoutine()
        {
            if (Duration == 0f)
            {
                RewindTo(Direction == Direction.Forward ? 1f : -1f);
                State = State.Completed;

                yield break;
            }

            while (Time.time < _endTime)
            {
                var timePassed = Direction == Direction.Forward ? Time.time - _startTime : _endTime - Time.time;
                RewindTo(timePassed);
                yield return null;
            }

            RewindTo(Direction == Direction.Forward ? Duration : 0f);
            State = State.Completed;
        }

        public Playable Pause()
        {
            if (!IsPlaying)
                throw new PlayControlException($"{Type} \"{Name}\": Can't be paused while not playing");

            // Unsubscribe coroutine reseted observer, because it not needed when paused.
            _playingCoroutine.Reseted -= CoroutineResetObserver;

            _playingCoroutine.Stop();
            State = State.Paused;

            return this;
        }

        public Playable Reset() => Reset(true);

        private Playable Reset(bool resetCoroutine)
        {
            if (IsReseted)
                throw new PlayControlException($"{Type} \"{Name}\": Already reseted");

            // Check playing state and remove coroutine reseted observer.
            // If Playable in pause state, then it means that observer already unsubscribed.
            // Otherwise we unsubscribe observer.
            if (IsPlaying || IsCompleted)
                _playingCoroutine.Reseted -= CoroutineResetObserver;

            if (resetCoroutine)
                _playingCoroutine.Reset();

            PlayedTime = Direction == Direction.Forward ? 0f : Duration;
            State = State.Reseted;

            return this;
        }
        #endregion

        #region Repeat
        protected abstract IRepeater<Playable> CreateRepeater();

        public IRepeater<Playable> GetRepeater() => CreateRepeater();

        public IRepeater<Playable> Repeat() => GetRepeater().PlayForward();

        public IRepeater<Playable> RepeatBackward() => GetRepeater().PlayBackward();
        #endregion

        #region Awaiters
        public YieldAwaiter WaitForComplete() => _playingCoroutine.WaitForComplete();

        public YieldAwaiter WaitForPause() => _playingCoroutine.WaitForStop();

        public YieldAwaiter WaitForPlay() => _playingCoroutine.WaitForRun();
        #endregion
    }

    public interface IPlayable<out T> : IPlayable where T : Playable
    {
        #region Phase events
        event Action<T, Direction> PhaseStarting;

        event Action<T, Direction> PhaseStarted;

        event Action<T, int, Direction> PhaseLoopStarting;

        event Action<T, int, Direction> PhaseLoopStarted;

        event Action<T, int, float, Direction> PhaseLoopUpdating;

        event Action<T, int, float, Direction> PhaseLoopUpdated;

        event Action<T, float, Direction> PhaseUpdating;

        event Action<T, float, Direction> PhaseUpdated;

        event Action<T, int, Direction> PhaseLoopCompleting;

        event Action<T, int, Direction> PhaseLoopCompleted;

        event Action<T, Direction> PhaseCompleting;

        event Action<T, Direction> PhaseCompleted;
        #endregion

        #region Routine events
        event Action<T> Reseted;

        event Action<T> Playing;

        event Action<T> Paused;

        event Action<T> Completed;
        #endregion

        #region Subscribes
        public T OnPhaseStarting(Action action);

        public T OnPhaseStarting(Action<T, Direction> action);

        public T OnPhaseStarted(Action action);

        public T OnPhaseStarted(Action<T, Direction> action);

        public T OnPhaseLoopStarting(Action action);

        public T OnPhaseLoopStarting(Action<T, int, Direction> action);

        public T OnPhaseLoopStarted(Action action);

        public T OnPhaseLoopStarted(Action<T, int, Direction> action);

        public T OnPhaseLoopUpdating(Action action);

        public T OnPhaseLoopUpdating(Action<T, int, float, Direction> action);

        public T OnPhaseLoopUpdated(Action action);

        public T OnPhaseLoopUpdated(Action<T, int, float, Direction> action);

        public T OnPhaseUpdating(Action action);

        public T OnPhaseUpdating(Action<T, float, Direction> action);

        public T OnPhaseUpdated(Action action);

        public T OnPhaseUpdated(Action<T, float, Direction> action);

        public T OnPhaseLoopCompleting(Action action);

        public T OnPhaseLoopCompleting(Action<T, int, Direction> action);

        public T OnPhaseLoopCompleted(Action action);

        public T OnPhaseLoopCompleted(Action<T, int, Direction> action);

        public T OnPhaseCompleting(Action action);

        public T OnPhaseCompleting(Action<T, Direction> action);

        public T OnPhaseCompleted(Action action);

        public T OnPhaseCompleted(Action<T, Direction> action);

        public T OnReseted(Action action);

        public T OnReseted(Action<T> action);

        public T OnPlaying(Action action);

        public T OnPlaying(Action<T> action);

        public T OnPaused(Action action);

        public T OnPaused(Action<T> action);

        public T OnCompleted(Action action);

        public T OnCompleted(Action<T> action);
        #endregion

        new T SetDirection(Direction direction);

        #region Rewinds
        new T RewindTo(float time, bool emitEvents);


        new T RewindToStart(bool emitEvents);

        new T RewindToEnd(bool emitEvents);
        #endregion

        #region Skips
        new T SkipTo(float time);

        new T SkipToStart();

        new T SkipToEnd();
        #endregion

        #region Playing
        new T PlayForward(bool resetIfCompleted = true);

        new T PlayBackward(bool resetIfCompleted = true);

        new T Play(bool resetIfCompleted = true);

        new T Pause();

        new T Reset();
        #endregion

        #region Repeat
        new Playable.IRepeater<T> GetRepeater();

        new Playable.IRepeater<T> Repeat();


        new Playable.IRepeater<T> RepeatBackward();
        #endregion
    }

    public abstract class Playable<T> : Playable, IPlayable<T> where T : Playable
    {
        #region Phase events
        public event Action<T, Direction> PhaseStarting;

        public event Action<T, Direction> PhaseStarted;

        public event Action<T, int, Direction> PhaseLoopStarting;

        public event Action<T, int, Direction> PhaseLoopStarted;

        public event Action<T, int, float, Direction> PhaseLoopUpdating;

        public event Action<T, int, float, Direction> PhaseLoopUpdated;

        public event Action<T, float, Direction> PhaseUpdating;

        public event Action<T, float, Direction> PhaseUpdated;

        public event Action<T, int, Direction> PhaseLoopCompleting;

        public event Action<T, int, Direction> PhaseLoopCompleted;

        public event Action<T, Direction> PhaseCompleting;

        public event Action<T, Direction> PhaseCompleted;
        #endregion

        #region Routine events
        public event Action<T> Reseted;

        public event Action<T> Playing;

        public event Action<T> Paused;

        public event Action<T> Completed;
        #endregion

        protected Playable(GameObject owner, string name, float loopDuration, FormulaBase formula, int loopsCount, LoopType loopType, Direction direction) : base(owner, name, loopDuration, formula, loopsCount, loopType, direction) { }

        #region Phase calls
        protected override void CallPhaseStarting(Direction direction) => PhaseStarting?.Invoke((T)(Playable)this, direction);

        protected override void CallPhaseStarted(Direction direction) => PhaseStarted?.Invoke((T)(Playable)this, direction);

        protected override void CallPhaseLoopStarting(int loop, Direction direction) => PhaseLoopStarting?.Invoke((T)(Playable)this, loop, direction);

        protected override void CallPhaseLoopStarted(int loop, Direction direction) => PhaseLoopStarted?.Invoke((T)(Playable)this, loop, direction);

        protected override void CallPhaseLoopCompleting(int loop, Direction direction) => PhaseLoopCompleting?.Invoke((T)(Playable)this, loop, direction);

        protected override void CallPhaseLoopCompleted(int loop, Direction direction) => PhaseLoopCompleted?.Invoke((T)(Playable)this, loop, direction);

        protected override void CallPhaseUpdating(float time, Direction direction) => PhaseUpdating?.Invoke((T)(Playable)this, time, direction);

        protected override void CallPhaseUpdated(float time, Direction direction) => PhaseUpdated?.Invoke((T)(Playable)this, time, direction);

        protected override void CallPhaseLoopUpdating(int loop, float time, Direction direction) => PhaseLoopUpdating?.Invoke((T)(Playable)this, loop, time, direction);

        protected override void CallPhaseLoopUpdated(int loop, float time, Direction direction) => PhaseLoopUpdated?.Invoke((T)(Playable)this, loop, time, direction);

        protected override void CallPhaseCompleting(Direction direction) => PhaseCompleting?.Invoke((T)(Playable)this, direction);

        protected override void CallPhaseCompleted(Direction direction) => PhaseCompleted?.Invoke((T)(Playable)this, direction);
        #endregion

        #region Routine calls
        protected override void CallReseted() => Reseted?.Invoke((T)(Playable)this);

        protected override void CallPlaying() => Playing?.Invoke((T)(Playable)this);

        protected override void CallPaused() => Paused?.Invoke((T)(Playable)this);

        protected override void CallCompleted() => Completed?.Invoke((T)(Playable)this);
        #endregion

        #region Subscribes
        public T OnPhaseStarting(Action action) => OnPhaseStarting((p, d) => action());

        public T OnPhaseStarting(Action<T, Direction> action)
        {
            PhaseStarting += action;
            return (T)(Playable)this;
        }

        public T OnPhaseStarted(Action action) => OnPhaseStarted((p, d) => action());

        public T OnPhaseStarted(Action<T, Direction> action)
        {
            PhaseStarted += action;
            return (T)(Playable)this;
        }

        public T OnPhaseLoopStarting(Action action) => OnPhaseLoopStarting((p, l, d) => action());

        public T OnPhaseLoopStarting(Action<T, int, Direction> action)
        {
            PhaseLoopStarting += action;
            return (T)(Playable)this;
        }

        public T OnPhaseLoopStarted(Action action) => OnPhaseLoopStarted((p, l, d) => action());

        public T OnPhaseLoopStarted(Action<T, int, Direction> action)
        {
            PhaseLoopStarted += action;
            return (T)(Playable)this;
        }

        public T OnPhaseLoopUpdating(Action action) => OnPhaseLoopUpdating((p, l, lt, d) => action());

        public T OnPhaseLoopUpdating(Action<T, int, float, Direction> action)
        {
            PhaseLoopUpdating += action;
            return (T)(Playable)this;
        }

        public T OnPhaseLoopUpdated(Action action) => OnPhaseLoopUpdated((p, l, lt, d) => action());

        public T OnPhaseLoopUpdated(Action<T, int, float, Direction> action)
        {
            PhaseLoopUpdated += action;
            return (T)(Playable)this;
        }

        public T OnPhaseUpdating(Action action) => OnPhaseUpdating((p, t, d) => action());

        public T OnPhaseUpdating(Action<T, float, Direction> action)
        {
            PhaseUpdating += action;
            return (T)(Playable)this;
        }

        public T OnPhaseUpdated(Action action) => OnPhaseUpdated((p, t, d) => action());

        public T OnPhaseUpdated(Action<T, float, Direction> action)
        {
            PhaseUpdated += action;
            return (T)(Playable)this;
        }

        public T OnPhaseLoopCompleting(Action action) => OnPhaseLoopCompleting((p, l, d) => action());

        public T OnPhaseLoopCompleting(Action<T, int, Direction> action)
        {
            PhaseLoopCompleting += action;
            return (T)(Playable)this;
        }

        public T OnPhaseLoopCompleted(Action action) => OnPhaseLoopCompleted((p, l, d) => action());

        public T OnPhaseLoopCompleted(Action<T, int, Direction> action)
        {
            PhaseLoopCompleted += action;
            return (T)(Playable)this;
        }

        public T OnPhaseCompleting(Action action) => OnPhaseCompleting((p, d) => action());

        public T OnPhaseCompleting(Action<T, Direction> action)
        {
            PhaseCompleting += action;
            return (T)(Playable)this;
        }

        public T OnPhaseCompleted(Action action) => OnPhaseCompleted((p, d) => action());

        public T OnPhaseCompleted(Action<T, Direction> action)
        {
            PhaseCompleted += action;
            return (T)(Playable)this;
        }

        public T OnReseted(Action action) => OnReseted(p => action());

        public T OnReseted(Action<T> action)
        {
            Reseted += action;
            return (T)(Playable)this;
        }

        public T OnPlaying(Action action) => OnPlaying(p => action());

        public T OnPlaying(Action<T> action)
        {
            Playing += action;
            return (T)(Playable)this;
        }

        public T OnPaused(Action action) => OnPaused(p => action());

        public T OnPaused(Action<T> action)
        {
            Paused += action;
            return (T)(Playable)this;
        }

        public T OnCompleted(Action action) => OnCompleted(p => action());

        public T OnCompleted(Action<T> action)
        {
            Completed += action;
            return (T)(Playable)this;
        }
        #endregion

        public new T SetDirection(Direction direction) => (T)base.SetDirection(direction);

        protected override IRepeater<Playable> CreateRepeater() => new Repeater<T>((T)(Playable)this);

        #region Overlaps
        #region Rewinds
        public new T RewindTo(float time, bool emitEvents = true) => (T)base.RewindTo(time, emitEvents);

        public new T RewindToStart(bool emitEvents = true) => (T)base.RewindToStart(emitEvents);

        public new T RewindToEnd(bool emitEvents = true) => (T)base.RewindToEnd(emitEvents);
        #endregion

        #region Skips
        public new T SkipTo(float time) => (T)base.SkipTo(time);

        public new T SkipToStart() => (T)base.SkipToStart();

        public new T SkipToEnd() => (T)base.SkipToEnd();
        #endregion

        #region Playing
        public new T PlayForward(bool resetIfCompleted = true) => (T)base.PlayForward(resetIfCompleted);

        public new T PlayBackward(bool resetIfCompleted = true) => (T)base.PlayBackward(resetIfCompleted);

        public new T Play(bool resetIfCompleted = true) => (T)base.Play(resetIfCompleted);

        public new T Pause() => (T)base.Pause();

        public new T Reset() => (T)base.Reset();
        #endregion

        #region Repeat
        public new IRepeater<T> GetRepeater() => (IRepeater<T>)CreateRepeater();

        public new IRepeater<T> Repeat() => GetRepeater().PlayForward();

        public new IRepeater<T> RepeatBackward() => GetRepeater().PlayBackward();
        #endregion
        #endregion
    }
}