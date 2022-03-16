using Redcode.Extensions;
using Redcode.Moroutines;
using Redcode.Moroutines.Exceptions;
using System;
using System.Collections;
using UnityEngine;

namespace Redcode.Tweens
{
    /// <summary>
    /// Represent interface to work with any <see cref="Playable"/>.
    /// </summary>
    public interface IPlayable
    {
        #region State
        /// <summary>
        /// The object that owns this playable.
        /// </summary>
        GameObject Owner { get; }

        /// <summary>
        /// Type of the playable.
        /// </summary>
        Type Type { get; }

        /// <summary>
        /// Name of the playable (useful for debugging and in sequences).
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Loop duration of the playable. Can't be a negative value.
        /// </summary>
        float LoopDuration { get; }

        /// <summary>
        /// Whole duration (LoopDuration * LoopsCount) of the playable.
        /// </summary>
        float Duration { get; }

        /// <summary>
        /// Easing formula which used in the playable when interpolate values.
        /// </summary>
        Ease Ease { get; set; }

        /// <summary>
        /// Loops count of the playable. Can't be less than 1
        /// </summary>
        int LoopsCount { get; set; }

        /// <summary>
        /// Loop type of the playable.
        /// </summary>
        LoopType LoopType { get; set; }

        /// <summary>
        /// Already played time of the playable. Can't be setted directly. If you need to set played time, than you shoud use <see cref="RewindTo(float, bool)"/> or <see cref="SkipTo(float)"/> methods.
        /// </summary>
        float PlayedTime { get; }

        /// <summary>
        /// State of the playable.
        /// </summary>
        State State { get; }

        /// <summary>
        /// Is playable reseted? Any playable which was created and not played yet (or after call <see cref="Reset"/> method directly) has reseted state.
        /// <para>Also reseted state can be reached by call <c>Reset</c> method on the playable.</para>
        /// </summary>
        bool IsReseted { get; }

        /// <summary>
        /// Is playable playing right now?
        /// </summary>
        bool IsPlaying { get; }

        /// <summary>
        /// Is playable paused? Paused state can be reached when call <c>Pause</c> method on playable while it playing.
        /// </summary>
        bool IsPaused { get; }

        /// <summary>
        /// Is playable completed? Completed state reached when playable finishes its playing.
        /// </summary>
        bool IsCompleted { get; }

        /// <summary>
        /// Direction which used when playable starts play by default.
        /// </summary>
        Direction Direction { get; set; }

        /// <summary>
        /// <inheritdoc cref="Tweens.TimeType"/>
        /// </summary>
        TimeType TimeType { get; set; }
        #endregion

        /// <summary>
        /// Sets easing formula.
        /// </summary>
        /// <param name="ease">Easing formula for playing.</param>
        /// <returns>The playable.</returns>
        IPlayable SetEase(Ease ease);

        /// <summary>
        /// Sets loops count.
        /// </summary>
        /// <param name="loopsCount">Loops count.</param>
        /// <returns>The playable.</returns>
        IPlayable SetLoopCount(int loopsCount);

        /// <summary>
        /// Sets loop type.
        /// </summary>
        /// <param name="loopType">Loop type.</param>
        /// <returns>The playable.</returns>
        IPlayable SetLoopType(LoopType loopType);

        /// <summary>
        /// Set direction.
        /// </summary>
        /// <param name="direction">Direction for playing.</param>
        /// <returns>The playable.</returns>
        IPlayable SetDirection(Direction direction);

        #region Rewinds
        /// <summary>
        /// Rewind to start time (0).
        /// </summary>
        /// <param name="emitEvents">Shoud events be emitted?</param>
        /// <returns>The playable.</returns>
        Playable RewindToStart(bool emitEvents = true);

        /// <summary>
        /// Rewind to end time (Duration).
        /// </summary>
        /// <param name="emitEvents">Shoud events be emitted?</param>
        /// <returns>The playable.</returns>
        Playable RewindToEnd(bool emitEvents = true);

        /// <summary>
        /// Rewind to the <paramref name="time"/>.
        /// </summary>
        /// <param name="time">The time up to which you need to rewind.</param>
        /// <param name="emitEvents">Shoud events be emitted?</param>
        /// <returns>The playable.</returns>
        Playable RewindTo(float time, bool emitEvents = true);
        #endregion

        #region Skips
        /// <summary>
        /// Skip playing to start time (0). The method will ignore any events and callbacks.
        /// </summary>
        /// <returns>The playable.</returns>
        Playable SkipToStart();

        /// <summary>
        /// Skip playing to the end (Duration). The method will ignore any events and callbacks.
        /// <para/>Usefull when create playable and need to play in backward direction. Example:
        /// <code>
        /// playable.SkipToEnd().PlayBackward();
        /// </code>
        /// </summary>
        /// <returns>The playable.</returns>
        Playable SkipToEnd();

        /// <summary>
        /// Skip playing to <paramref name="time"/>. The method will ignore any events and callbacks.
        /// </summary>
        /// <param name="time">The time up to which you need to skip.</param>
        /// <returns>The playable.</returns>
        Playable SkipTo(float time);
        #endregion

        #region Playing
        /// <summary>
        /// Sets time type for playing methods. <br/>If you want to play the animation independently
        /// of the <see cref="Time.timeScale"/> multiplier, use <see cref="TimeType.Unscaled"/>.        
        /// </summary>
        /// <param name="type">The type of time used in the playback methods.</param>
        /// <returns>The playable.</returns>
        Playable SetTimeType(TimeType type);

        /// <summary>
        /// Starts playing in forward direction.
        /// </summary>
        /// <param name="resetIfCompleted">Should we reset playable if it in complete state?</param>
        /// <returns>The playable.</returns>
        Playable PlayForward(bool resetIfCompleted = true);

        /// <summary>
        /// Starts playing in backward direction.
        /// </summary>
        /// <param name="resetIfCompleted"><inheritdoc cref="IPlayable.PlayForward(bool)" path="/param[@name='resetIfCompleted']"/></param>
        /// <returns><inheritdoc cref="IPlayable.PlayForward(bool)"/></returns>
        Playable PlayBackward(bool resetIfCompleted = true);

        /// <summary>
        /// Starts playing in <see cref="Direction"/> direction.
        /// </summary>
        /// <param name="resetIfCompleted"><inheritdoc cref="IPlayable.PlayBackward(bool)" path="/param[@name='resetIfCompleted']"/></param>
        /// <returns><inheritdoc cref="IPlayable.PlayBackward(bool)"/></returns>
        Playable Play(bool resetIfCompleted = true);

        /// <summary>
        /// Pause the playable. Can be continued later with <see cref="Play(bool)"/> method.
        /// </summary>
        /// <returns>The playble.</returns>
        Playable Pause();

        /// <summary>
        /// Reset the playable if it in non reset state.
        /// </summary>
        /// <returns></returns>
        Playable Reset();
        #endregion

        #region Repeat
        /// <summary>
        /// Create repeater for the playable. 
        /// <br/>Example:
        /// <code>
        /// playable.GetRepeater().Play();
        /// </code>
        /// </summary>
        /// <returns>Repeater.</returns>
        Playable.IRepeater<Playable> GetRepeater();

        /// <summary>
        /// Create repeater for the playable and starts repeating playable's playing in <see cref="Playable.IRepeater{T}.Direction"/> property.
        /// <br/>Example:
        /// <code>
        /// playable.Repeat();
        /// </code>
        /// </summary>
        /// <returns>Repeater.</returns>
        Playable.IRepeater<Playable> Repeat();

        /// <summary>
        /// Create repeater for the playable and starts repeating playable's playing in forward direction.
        /// <br/>Example:
        /// <code>
        /// playable.RepeatForward();
        /// </code>
        /// </summary>
        /// <returns>Repeater.</returns>
        Playable.IRepeater<Playable> RepeatForward();

        /// <summary>
        /// Create repeater for the playable and starts repeating playable's playing in backward direction.
        /// <br/>Example:
        /// <code>
        /// playable.RepeatBackward();
        /// </code>
        /// </summary>
        /// <returns>Repeater.</returns>
        Playable.IRepeater<Playable> RepeatBackward();
        #endregion

        #region Awaiters
        /// <summary>
        /// Creates a special object that knows how to wait until playable is completed. Pausing playable will not stop awaiting.
        /// <br/>You can use the method in coroutines. Example:
        /// <example>
        /// <code>
        /// <see langword="yield return"/> playable.WaitForComplete();
        /// </code>
        /// </example>
        /// </summary>
        /// <returns>Awaiter object.</returns>
        YieldAwaiter WaitForComplete();

        /// <summary>
        /// Creates a special object that knows how to wait until playable is paused. Reseting playable will stop awaiting too.
        /// <br/>You can use the method in coroutines. Example:
        /// <example>
        /// <code>
        /// <see langword="yield return"/> playable.WaitForPause();
        /// </code>
        /// </example>
        /// </summary>
        /// <returns>Awaiter object.</returns>
        YieldAwaiter WaitForPause();

        /// <summary>
        /// Creates a special object that knows how to wait until playable is playing.
        /// <br/>You can use the method in coroutines. Example:
        /// <example>
        /// <code>
        /// <see langword="yield return"/> playable.WaitForPlay();
        /// </code>
        /// </example>
        /// </summary>
        /// <returns>Awaiter object.</returns>
        YieldAwaiter WaitForPlay();
        #endregion
    }

    /// <summary>
    /// Base class for all <see cref="Playable{T}"/>.
    /// </summary>
    public abstract class Playable : IPlayable
    {
        #region Repeater
        /// <summary>
        /// Represent repeater for any playable.
        /// </summary>
        /// <typeparam name="T">Playable type.</typeparam>
        public interface IRepeater<out T> where T : Playable
        {
            /// <summary>
            /// Playable which will be repeated.
            /// </summary>
            T Target { get; }

            /// <summary>
            /// Is it repeater in playing state?
            /// </summary>
            bool IsPlaying { get; }

            /// <summary>
            /// Direction which used when repeater playing by default.
            /// </summary>
            Direction Direction { get; set; }

            /// <summary>
            /// Sets direction.
            /// </summary>
            /// <param name="direction">Direction to use when <see cref="Play"/> method used.</param>
            /// <returns>The repeater.</returns>
            IRepeater<T> SetDirection(Direction direction);

            /// <summary>
            /// Starts repeating in forward direction.
            /// </summary>
            /// <returns>The repeater.</returns>
            IRepeater<T> PlayForward();

            /// <summary>
            /// Starts repeating in backward direction.
            /// </summary>
            /// <returns>The repeater.</returns>
            IRepeater<T> PlayBackward();

            /// <summary>
            /// Starts repeating in <see cref="Direction"/> direction.
            /// </summary>
            /// <returns>The repeater.</returns>
            IRepeater<T> Play();

            /// <summary>
            /// Stops repeating. <see cref="Target"/> also will be paused.
            /// </summary>
            /// <returns></returns>
            IRepeater<T> Stop();

            /// <summary>
            /// Creates a special object that knows how to wait until the repeater is stopped.
            /// <para>You can use the method in coroutines. Example:</para>
            /// <example>
            /// <code>
            /// var repeater = playable.Repeat();
            /// <br/><see langword="yield return"/> repeater.WaitForStop();
            /// </code>
            /// </example>
            /// </summary>
            /// <returns>Awaiter object.</returns>
            YieldAwaiter WaitForStop();

            /// <summary>
            /// Creates a special object that knows how to wait until the repeater is playing.
            /// <para>You can use the method in coroutines. Example:</para>
            /// <example>
            /// <code>
            /// var repeater = playable.GetRepeater();
            /// <br/><see langword="yield return"/> repeater.WaitForPlay();
            /// </code>
            /// </example>
            /// </summary>
            /// <returns>Awaiter object.</returns>
            YieldAwaiter WaitForPlay();
        }

        /// <summary>
        /// <inheritdoc cref="Playable.IRepeater{T}"/>
        /// </summary>
        /// <typeparam name="T"><inheritdoc cref="Playable.IRepeater{T}"/></typeparam>
        public class Repeater<T> : IRepeater<T> where T : Playable
        {
            #region Awaiter classes
            /// <summary>
            /// Base class for awaiting some state.
            /// </summary>
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

            /// <summary>
            /// Represent class which can await stop state of repeater.
            /// </summary>
            public class StopAwaiter : WaitAwaiter
            {
                public StopAwaiter(Repeater<T> repeater) : base(repeater) { }

                public override bool KeepWaiting => _stateCode == _repeater._stateCode && _repeater.IsPlaying;
            }

            /// <summary>
            /// Represent class which can await playing state of repeater.
            /// </summary>
            public class PlayAwaiter : WaitAwaiter
            {
                public PlayAwaiter(Repeater<T> repeater) : base(repeater) { }

                public override bool KeepWaiting => _stateCode == _repeater._stateCode && !_repeater.IsPlaying;
            }
            #endregion

            private Moroutine _playingMoroutine;

            public T Target { get; private set; }

            public bool IsPlaying { get; private set; }

            public Direction Direction { get; set; }

            private int _stateCode;

            /// <summary>
            /// Create repeater.
            /// </summary>
            /// <param name="playable">Target playable.</param>
            public Repeater(T playable) : this(MoroutinesOwner.Instance.gameObject, playable) { }

            /// <summary>
            /// <inheritdoc cref="Repeater{T}.Repeater(T)"/>
            /// </summary>
            /// <param name="owner">Game object to which this repeater will be attached.</param>
            /// <param name="playable"><inheritdoc cref="Repeater{T}.Repeater(T)" path="/param[@name='playable']"/></param>
            public Repeater(GameObject owner, T playable)
            {
                _playingMoroutine = Moroutine.Create(owner, PlayRoutine());

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
                    _playingMoroutine.Run();

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

                _playingMoroutine.Reset();
                Target.Pause();

                return this;
            }

            public YieldAwaiter WaitForStop() => new StopAwaiter(this);

            public YieldAwaiter WaitForPlay() => new PlayAwaiter(this);
        }
        #endregion

        #region State
        public GameObject Owner => _playingMoroutine.Owner;

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

                // TODO: Maybe need replace to NearlyEquals again.
                if (value.Approximately(_loopDuration))
                    return;

                _loopDuration = value;
                RecalculateDuration();

                StateChanged?.Invoke(this);
            }
        }

        public float Duration { get; private set; }

        private Ease _ease;

        public Ease Ease
        {
            get => _ease;
            set => _ease = value ?? Ease.Linear;
        }

        private int _loopsCount;

        public int LoopsCount
        {
            get => _loopsCount;
            set
            {
                if (value < 1)
                    throw new ArgumentException($"{Type} \"{Name}\": Loops count can't be less than 1 ({value} passed)");

                if (value == _loopsCount)
                    return;

                _loopsCount = value;
                RecalculateDuration();

                StateChanged?.Invoke(this);
            }
        }

        private LoopType _loopType;

        public LoopType LoopType
        {
            get => _loopType;
            set
            {
                if (value == _loopType)
                    return;

                var wasMirror = _loopType == LoopType.Mirror;
                _loopType = value;

                if (wasMirror || _loopType == LoopType.Mirror)
                    StateChanged?.Invoke(this);
            }
        }

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

        private Func<float> _timeSelector = () => Time.time;

        private TimeType _timeType;

        public TimeType TimeType
        {
            get => _timeType;
            set
            {
                if (_timeType == value)
                    return;

                _timeType = value;

                if (_timeType == TimeType.Scaled)
                    _timeSelector = () => Time.time;
                else
                    _timeSelector = () => Time.unscaledTime;

                RecalculatePlayTimes();
            }
        }

        /// <summary>
        /// Used in sequences for rebuilding its phase events state.
        /// Will be called after <see cref="LoopDuration"/>, <see cref="LoopsCount"/> or <see cref="LoopType"/> changed.
        /// </summary>
        internal event Action<Playable> StateChanged;

        /// <summary>
        /// Flag for block recursive invoking <see cref="RewindHandler(int, float, Direction, bool, int, int)"/> or <see cref="RewindZeroHandler(int, float, Direction, bool, int, int)"/> methods.
        /// </summary>
        private bool _locked;
        #endregion

        #region Routines
        private Moroutine _playingMoroutine;

        private float _startTime;

        private float _endTime;
        #endregion

        /// <summary>
        /// Create <see cref="Playable"/> object.
        /// </summary>
        /// <param name="owner">Game object to which this playable will be attached.</param>
        /// <param name="name">Name of the playable.</param>
        /// <param name="loopDuration">Loop duration of the playable.</param>
        /// <param name="ease">Easing formula which used when playable animate values.</param>
        /// <param name="loopsCount">Loops count of the playable.</param>
        /// <param name="loopType">Loop type which used between loops in the playable.</param>
        /// <param name="direction">Direction in which the playable starts playing animation.</param>
        protected Playable(GameObject owner, string name, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            Name = name;
            LoopDuration = loopDuration;
            Ease = ease ?? Ease.Linear;
            LoopsCount = loopsCount;
            LoopType = loopType;
            Direction = direction;

            _playingMoroutine = Moroutine.Create(owner, PlayRoutine());
        }

        protected void RecalculateDuration()
        {
            Duration = LoopDuration * LoopsCount;
            PlayedTime = Mathf.Clamp(PlayedTime, 0f, Duration);

            RecalculatePlayTimes();
        }

        protected void RecalculatePlayTimes()
        {
            _startTime = Direction == Direction.Forward ? _timeSelector() - PlayedTime : _timeSelector() - (Duration - PlayedTime);
            _endTime = _startTime + Duration;
        }

        public IPlayable SetEase(Ease ease)
        {
            _ease = ease;
            return this;
        }

        public IPlayable SetLoopCount(int loopsCount)
        {
            LoopsCount = loopsCount;
            return this;
        }

        public IPlayable SetLoopType(LoopType loopType)
        {
            LoopType = loopType;
            return this;
        }

        public IPlayable SetDirection(Direction direction)
        {
            Direction = direction;
            return this;
        }

        #region Loops
        protected float LoopTime(float time)
        {
            if (time.Approximately(0f))
                return 0f;

            time %= LoopDuration;
            return time.Approximately(0f) ? LoopDuration : time;
        }

        protected int LoopIndex(float time)
        {
            if (time.Approximately(0f))
                return 0;

            var loopIndex = (int)(time / LoopDuration);
            time %= LoopDuration;

            return time.Approximately(0f) ? loopIndex - 1 : loopIndex;
        }

        protected (int loopIndex, float loopedTime) LoopIndexTime(float time)
        {
            if (time.Approximately(0f))
                return (0, 0f);

            var loopIndex = (int)(time / LoopDuration);
            time %= LoopDuration;

            return time.Approximately(0f) ? (loopIndex - 1, LoopDuration) : (loopIndex, time);
        }
        #endregion

        #region Phase events emitting
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

        #region Lock
        private void CheckLock()
        {
            if (_locked)
                throw new Exception($"{Type} {Name} trying to recursively call rewinding.");
        }

        private void TryLock()
        {
            CheckLock();
            _locked = true;
        }
        #endregion

        protected virtual void BeforeStarting(Direction direction, int loop, int parentContinueLoopIndex, int continueMaxLoopsCount) { }

        #region Rewinds
        public Playable RewindToStart(bool emitEvents = true) => RewindToStart(0, 1, emitEvents);

        internal Playable RewindToStart(int parentContinueLoopIndex, int continueMaxLoopsCount, bool emitEvents) => Duration.Approximately(0f) ? RewindTo(-1f, parentContinueLoopIndex, continueMaxLoopsCount, emitEvents) : RewindTo(0f, parentContinueLoopIndex, continueMaxLoopsCount, emitEvents);

        public Playable RewindToEnd(bool emitEvents = true) => RewindToEnd(0, 1, emitEvents);

        internal Playable RewindToEnd(int parentContinueLoopIndex, int continueMaxLoopsCount, bool emitEvents) => Duration.Approximately(0f) ? RewindTo(1f, parentContinueLoopIndex, continueMaxLoopsCount, emitEvents) : RewindTo(Duration, parentContinueLoopIndex, continueMaxLoopsCount, emitEvents);

        public Playable RewindTo(float time, bool emitEvents = true) => RewindTo(time, 0, 1, emitEvents);

        internal Playable RewindTo(float time, int parentContinueLoopIndex, int continueMaxLoopsCount, bool emitEvents)
        {
            if (LoopDuration.Approximately(0f))
            {
                if (time.Approximately(0f))
                    return this;

                var direction = time > 0f ? Direction.Forward : Direction.Backward;

                if (emitEvents)
                    RewindZeroDurationWithEvents(direction, parentContinueLoopIndex, continueMaxLoopsCount);
                else
                    RewindZeroDurationWithoutEvents(direction, parentContinueLoopIndex, continueMaxLoopsCount);
            }
            else
            {
                time = Mathf.Clamp(time, 0f, Duration);

                if (time.Approximately(PlayedTime))
                    return this;

                if (LoopType != LoopType.Mirror)
                {
                    if (time > PlayedTime)
                    {
                        if (emitEvents)
                            RewindWithEvents(PlayedTime, time, Direction.Forward, parentContinueLoopIndex, continueMaxLoopsCount);
                        else
                            RewindWithoutEvents(PlayedTime, time, Direction.Forward, parentContinueLoopIndex, continueMaxLoopsCount);
                    }
                    else
                    {
                        if (emitEvents)
                            RewindWithEvents(Duration - PlayedTime, Duration - time, Direction.Backward, parentContinueLoopIndex, continueMaxLoopsCount);
                        else
                            RewindWithoutEvents(Duration - PlayedTime, Duration - time, Direction.Backward, parentContinueLoopIndex, continueMaxLoopsCount);
                    }
                }
                else
                {
                    var halfLoopDuration = LoopDuration / 2f;

                    if (time > PlayedTime)
                    {
                        var playedLoop = (int)(PlayedTime / LoopDuration);
                        var timeLoop = (int)(time / LoopDuration);

                        if ((time % LoopDuration).Approximately(0f))
                            --timeLoop;

                        if (emitEvents)
                        {
                            for (int i = playedLoop; i <= timeLoop; i++)
                            {
                                var halfPoint = i * LoopDuration + halfLoopDuration;

                                if (halfPoint > PlayedTime && halfPoint < time)
                                    RewindWithEvents(PlayedTime, halfPoint, Direction.Forward, parentContinueLoopIndex, continueMaxLoopsCount);
                            }

                            RewindWithEvents(PlayedTime, time, Direction.Forward, parentContinueLoopIndex, continueMaxLoopsCount);
                        }
                        else
                        {
                            for (int i = playedLoop; i <= timeLoop; i++)
                            {
                                var halfPoint = i * LoopDuration + halfLoopDuration;

                                if (halfPoint > PlayedTime && halfPoint < time)
                                    RewindWithoutEvents(PlayedTime, halfPoint, Direction.Forward, parentContinueLoopIndex, continueMaxLoopsCount);
                            }

                            RewindWithoutEvents(PlayedTime, time, Direction.Forward, parentContinueLoopIndex, continueMaxLoopsCount);
                        }
                    }
                    else
                    {
                        var playedLoop = (int)(PlayedTime / LoopDuration);
                        var timeLoop = (int)(time / LoopDuration);

                        if ((PlayedTime % LoopDuration).Approximately(0f))
                            --playedLoop;

                        if (emitEvents)
                        {
                            for (int i = playedLoop; i >= timeLoop; i--)
                            {
                                var halfPoint = i * LoopDuration + halfLoopDuration;

                                if (halfPoint < PlayedTime && halfPoint > time)
                                    RewindWithEvents(Duration - PlayedTime, Duration - halfPoint, Direction.Backward, parentContinueLoopIndex, continueMaxLoopsCount);
                            }

                            RewindWithEvents(Duration - PlayedTime, Duration - time, Direction.Backward, parentContinueLoopIndex, continueMaxLoopsCount);
                        }
                        else
                        {
                            for (int i = playedLoop; i >= timeLoop; i--)
                            {
                                var halfPoint = i * LoopDuration + halfLoopDuration;

                                if (halfPoint < PlayedTime && halfPoint > time)
                                    RewindWithoutEvents(Duration - PlayedTime, Duration - halfPoint, Direction.Backward, parentContinueLoopIndex, continueMaxLoopsCount);
                            }

                            RewindWithoutEvents(Duration - PlayedTime, Duration - time, Direction.Backward, parentContinueLoopIndex, continueMaxLoopsCount);
                        }
                    }
                }
            }

            return this;
        }

        private void RewindZeroDurationWithEvents(Direction direction, int parentContinueLoopIndex, int continueMaxLoopsCount)
        {
            // Start events.
            HandlePhaseStartZeroed(direction, parentContinueLoopIndex, continueMaxLoopsCount);
            HandlePhaseFirstLoopStartZeroed(direction, parentContinueLoopIndex, continueMaxLoopsCount);

            if (LoopType == LoopType.Mirror)
            {
                // Intermediate events
                for (int i = 1; i < LoopsCount; i++)
                {
                    HandlePhaseLoopUpdateZeroed(i - 1, direction, parentContinueLoopIndex, continueMaxLoopsCount);
                    HandlePhaseLoopCompleteZeroed(i - 1, direction, parentContinueLoopIndex, continueMaxLoopsCount);
                    HandlePhaseLoopStartZeroed(i, direction, parentContinueLoopIndex, continueMaxLoopsCount);
                }
            }
            else
            {
                // Intermediate events
                for (int i = 1; i < LoopsCount; i++)
                {
                    HandlePhaseLoopCompleteZeroed(i - 1, direction, parentContinueLoopIndex, continueMaxLoopsCount);
                    HandlePhaseLoopStartZeroed(i, direction, parentContinueLoopIndex, continueMaxLoopsCount);
                }
            }

            // Mirror's update event on last loop.
            if (LoopType == LoopType.Mirror)
                HandlePhaseLoopUpdateZeroed(LoopsCount - 1, direction, parentContinueLoopIndex, continueMaxLoopsCount);

            // Completed events.
            HandlePhaseLoopCompleteZeroed(LoopsCount - 1, direction, parentContinueLoopIndex, continueMaxLoopsCount);
            HandlePhaseCompleteZeroed(direction, parentContinueLoopIndex, continueMaxLoopsCount);
        }

        private void RewindZeroDurationWithoutEvents(Direction direction, int parentContinueLoopIndex, int continueMaxLoopsCount)
        {
            // Started events.
            HandlePhaseStartZeroedNoEvents(direction, parentContinueLoopIndex, continueMaxLoopsCount);
            HandlePhaseFirstLoopStartZeroedNoEvents(direction, parentContinueLoopIndex, continueMaxLoopsCount);

            if (LoopType == LoopType.Mirror)
            {
                // Intermediate events
                for (int i = 1; i < LoopsCount; i++)
                {
                    HandlePhaseLoopUpdateZeroedNoEvents(i - 1, direction, parentContinueLoopIndex, continueMaxLoopsCount);
                    HandlePhaseLoopCompleteZeroedNoEvents(i - 1, direction, parentContinueLoopIndex, continueMaxLoopsCount);
                    HandlePhaseLoopStartZeroedNoEvents(i, direction, parentContinueLoopIndex, continueMaxLoopsCount);
                }
            }
            else
            {
                // Intermediate events
                for (int i = 1; i < LoopsCount; i++)
                {
                    HandlePhaseLoopCompleteZeroedNoEvents(i - 1, direction, parentContinueLoopIndex, continueMaxLoopsCount);
                    HandlePhaseLoopStartZeroedNoEvents(i, direction, parentContinueLoopIndex, continueMaxLoopsCount);
                }
            }

            // Mirror's update event on last loop.
            if (LoopType == LoopType.Mirror)
                HandlePhaseLoopUpdateZeroedNoEvents(LoopsCount - 1, direction, parentContinueLoopIndex, continueMaxLoopsCount);

            // Completed events.
            HandlePhaseLoopCompleteZeroedNoEvents(LoopsCount - 1, direction, parentContinueLoopIndex, continueMaxLoopsCount);
            HandlePhaseCompleteZeroedNoEvents(direction, parentContinueLoopIndex, continueMaxLoopsCount);
        }

        private void RewindWithEvents(float startTime, float endTime, Direction direction, int parentContinueLoopIndex, int continueMaxLoopsCount)
        {
            // Global started phase
            if (startTime.Approximately(0f))
                HandlePhaseStart(direction, parentContinueLoopIndex, continueMaxLoopsCount);

            var playedLoop = (int)(startTime / LoopDuration);
            var timeLoop = (int)(endTime / LoopDuration);

            // Loop started phase.
            if (startTime.Approximately(playedLoop * LoopDuration))
            {
                // If all elements already handled in global start phase (BeforeStarting method was called previously),
                // than we don't need handle elements.
                if (startTime.Approximately(0f))
                    HandlePhaseFirstLoopStart(direction, parentContinueLoopIndex, continueMaxLoopsCount);
                else
                    HandlePhaseLoopStart(playedLoop, direction, parentContinueLoopIndex, continueMaxLoopsCount);
            }

            // Intermediate phase.
            for (int i = playedLoop + 1; i <= timeLoop - 1; i++)
            {
                var loopIndex = LoopIndex(LoopDuration * i);

                HandlePhaseLoopComplete(loopIndex, direction, parentContinueLoopIndex, continueMaxLoopsCount);
                HandlePhaseLoopStart(loopIndex + 1, direction, parentContinueLoopIndex, continueMaxLoopsCount);
            }

            // Loop completed phase.
            if (endTime.Approximately(timeLoop * LoopDuration))
                HandlePhaseLoopComplete(timeLoop - 1, direction, parentContinueLoopIndex, continueMaxLoopsCount);
            else // Global and loop update phases.
            {
                // Last intermediate loop phase. For example, when we start from
                // middle looped position and ended on other middle looped position.
                if (timeLoop - playedLoop > 0)
                {
                    HandlePhaseLoopComplete(timeLoop - 1, direction, parentContinueLoopIndex, continueMaxLoopsCount);
                    HandlePhaseLoopStart(timeLoop, direction, parentContinueLoopIndex, continueMaxLoopsCount);
                }

                // Update phase.
                var loopedTime = LoopTime(endTime);
                HandlePhaseLoopUpdate(endTime, timeLoop, loopedTime, direction, parentContinueLoopIndex, continueMaxLoopsCount);
            }

            // Global complete phase.
            if (endTime.Approximately(Duration))
                HandlePhaseComplete(direction, parentContinueLoopIndex, continueMaxLoopsCount);
        }

        private void RewindWithoutEvents(float startTime, float endTime, Direction direction, int parentContinueLoopIndex, int continueMaxLoopsCount)
        {
            // Global started phase
            if (startTime.Approximately(0f))
                HandlePhaseStartNoEvents(direction, parentContinueLoopIndex, continueMaxLoopsCount);

            var playedLoop = (int)(startTime / LoopDuration);
            var timeLoop = (int)(endTime / LoopDuration);

            // Loop started phase.
            if (startTime.Approximately(playedLoop * LoopDuration))
            {
                // If all elements already handled in global start phase (BeforeStarting method was called previously),
                // than we don't need handle elements.
                if (startTime.Approximately(0f))
                    HandlePhaseFirstLoopStartNoEvents(direction, parentContinueLoopIndex, continueMaxLoopsCount);
                else
                    HandlePhaseLoopStartNoEvents(playedLoop, direction, parentContinueLoopIndex, continueMaxLoopsCount);
            }

            // Intermediate phase.
            for (int i = playedLoop + 1; i <= timeLoop - 1; i++)
            {
                var loopIndex = LoopIndex(LoopDuration * i);

                HandlePhaseLoopCompleteNoEvents(loopIndex, direction, parentContinueLoopIndex, continueMaxLoopsCount);
                HandlePhaseLoopStartNoEvents(loopIndex + 1, direction, parentContinueLoopIndex, continueMaxLoopsCount);
            }

            // Loop completed phase.
            if (endTime.Approximately(timeLoop * LoopDuration))
                HandlePhaseLoopCompleteNoEvents(timeLoop - 1, direction, parentContinueLoopIndex, continueMaxLoopsCount);
            else // Global and loop update phases.
            {
                // Last intermediate loop phase. For example, when we start from
                // middle looped position and ended on other middle looped position.
                if (timeLoop - playedLoop > 0)
                {
                    HandlePhaseLoopCompleteNoEvents(timeLoop - 1, direction, parentContinueLoopIndex, continueMaxLoopsCount);
                    HandlePhaseLoopStartNoEvents(timeLoop, direction, parentContinueLoopIndex, continueMaxLoopsCount);
                }

                // Update phase.
                var loopedTime = LoopTime(endTime);

                HandlePhaseLoopUpdateNoEvents(endTime, timeLoop, loopedTime, direction, parentContinueLoopIndex, continueMaxLoopsCount);
            }

            // Global complete phase.
            if (endTime.Approximately(Duration))
                HandlePhaseCompleteNoEvents(direction, parentContinueLoopIndex, continueMaxLoopsCount);
        }

        protected virtual void RewindZeroHandler(int loop, float loopedNormalizedTime, Direction direction, bool emitEvents, int parentContinueLoopIndex, int continueMaxLoopsCount) { }

        protected virtual void RewindHandler(int loop, float loopedTime, Direction direction, bool emitEvents, int parentContinueLoopIndex, int continueMaxLoopsCount) { }
        #endregion

        #region Phase events partial handlers
        private void RewindZeroHandlerAndUnlock(int loop, float loopedNormalizedTime, Direction direction, bool emitEvents, int parentContinueLoopIndex, int continueMaxLoopsCount)
        {
            RewindZeroHandler(loop, loopedNormalizedTime, direction, emitEvents, parentContinueLoopIndex, continueMaxLoopsCount);
            _locked = false;
        }

        private void RewindHandlerAndUnlock(int loop, float loopedNormalizedTime, Direction direction, bool emitEvents, int parentContinueLoopIndex, int continueMaxLoopsCount)
        {
            RewindHandler(loop, loopedNormalizedTime, direction, emitEvents, parentContinueLoopIndex, continueMaxLoopsCount);
            _locked = false;
        }

        #region Zero duration
        internal void HandlePhaseStartZeroed(Direction direction, int parentContinueLoopIndex, int continueMaxLoopsCount)
        {
            TryLock();
            BeforeStarting(direction, 0, parentContinueLoopIndex, continueMaxLoopsCount);
            CallPhaseStarting(direction);
            RewindZeroHandlerAndUnlock(0, 0f, direction, true, parentContinueLoopIndex, continueMaxLoopsCount);
            CallPhaseStarted(direction);
        }

        internal void HandlePhaseFirstLoopStartZeroed(Direction direction, int parentContinueLoopIndex, int continueMaxLoopsCount)
        {
            TryLock();
            CallPhaseLoopStarting(0, direction);
            RewindZeroHandlerAndUnlock(0, 0f, direction, true, parentContinueLoopIndex, continueMaxLoopsCount);
            CallPhaseLoopStarted(0, direction);
        }

        internal void HandlePhaseLoopCompleteZeroed(int loop, Direction direction, int parentContinueLoopIndex, int continueMaxLoopsCount)
        {
            TryLock();
            CallPhaseLoopCompleting(loop, direction);
            RewindZeroHandlerAndUnlock(loop, 1f, direction, true, parentContinueLoopIndex, continueMaxLoopsCount);
            CallPhaseLoopCompleted(loop, direction);
        }

        internal void HandlePhaseLoopStartZeroed(int loop, Direction direction, int parentContinueLoopIndex, int continueMaxLoopsCount)
        {
            TryLock();
            BeforeStarting(direction, loop, parentContinueLoopIndex, continueMaxLoopsCount);
            CallPhaseLoopStarting(loop, direction);
            RewindZeroHandlerAndUnlock(loop, 0f, direction, true, parentContinueLoopIndex, continueMaxLoopsCount);
            CallPhaseLoopStarted(loop, direction);
        }

        internal void HandlePhaseLoopUpdateZeroed(int loop, Direction direction, int parentContinueLoopIndex, int continueMaxLoopsCount)
        {
            TryLock();
            CallPhaseUpdating(loop + 0.5f, direction);
            CallPhaseLoopUpdating(loop, 0.5f, direction);
            RewindZeroHandlerAndUnlock(loop, 0.5f, direction, true, parentContinueLoopIndex, continueMaxLoopsCount);
            CallPhaseLoopUpdated(loop, 0.5f, direction);
            CallPhaseUpdated(loop + 0.5f, direction);
        }

        internal void HandlePhaseCompleteZeroed(Direction direction, int parentContinueLoopIndex, int continueMaxLoopsCount)
        {
            TryLock();
            CallPhaseCompleting(direction);
            RewindZeroHandlerAndUnlock(LoopsCount - 1, 1f, direction, true, parentContinueLoopIndex, continueMaxLoopsCount);
            CallPhaseCompleted(direction);
        }
        #endregion

        #region Zero duration, no events
        internal void HandlePhaseStartZeroedNoEvents(Direction direction, int parentContinueLoopIndex, int continueMaxLoopsCount)
        {
            TryLock();
            BeforeStarting(direction, 0, parentContinueLoopIndex, continueMaxLoopsCount);
            RewindZeroHandlerAndUnlock(0, 0f, direction, false, parentContinueLoopIndex, continueMaxLoopsCount);
        }

        internal void HandlePhaseFirstLoopStartZeroedNoEvents(Direction direction, int parentContinueLoopIndex, int continueMaxLoopsCount)
        {
            TryLock();
            RewindZeroHandlerAndUnlock(0, 0f, direction, false, parentContinueLoopIndex, continueMaxLoopsCount);
        }

        internal void HandlePhaseLoopCompleteZeroedNoEvents(int loop, Direction direction, int parentContinueLoopIndex, int continueMaxLoopsCount)
        {
            TryLock();
            RewindZeroHandlerAndUnlock(loop, 1f, direction, false, parentContinueLoopIndex, continueMaxLoopsCount);
        }

        internal void HandlePhaseLoopStartZeroedNoEvents(int loop, Direction direction, int parentContinueLoopIndex, int continueMaxLoopsCount)
        {
            TryLock();
            BeforeStarting(direction, loop, parentContinueLoopIndex, continueMaxLoopsCount);
            RewindZeroHandlerAndUnlock(loop, 0f, direction, false, parentContinueLoopIndex, continueMaxLoopsCount);
        }

        internal void HandlePhaseLoopUpdateZeroedNoEvents(int loop, Direction direction, int parentContinueLoopIndex, int continueMaxLoopsCount)
        {
            TryLock();
            RewindZeroHandlerAndUnlock(loop, 0.5f, direction, false, parentContinueLoopIndex, continueMaxLoopsCount);
        }

        internal void HandlePhaseCompleteZeroedNoEvents(Direction direction, int parentContinueLoopIndex, int continueMaxLoopsCount)
        {
            TryLock();
            RewindZeroHandlerAndUnlock(LoopsCount - 1, 1f, direction, false, parentContinueLoopIndex, continueMaxLoopsCount);
        }
        #endregion

        #region Non zero duration
        internal void HandlePhaseStart(Direction direction, int parentContinueLoopIndex, int continueMaxLoopsCount)
        {
            TryLock();
            BeforeStarting(direction, 0, parentContinueLoopIndex, continueMaxLoopsCount);
            CallPhaseStarting(direction);
            RewindHandlerAndUnlock(0, 0f, direction, true, parentContinueLoopIndex, continueMaxLoopsCount);
            CallPhaseStarted(direction);
        }

        internal void HandlePhaseFirstLoopStart(Direction direction, int parentContinueLoopIndex, int continueMaxLoopsCount)
        {
            TryLock();
            CallPhaseLoopStarting(0, direction);
            RewindHandlerAndUnlock(0, 0f, direction, true, parentContinueLoopIndex, continueMaxLoopsCount);
            CallPhaseLoopStarted(0, direction);
        }

        internal void HandlePhaseLoopComplete(int loop, Direction direction, int parentContinueLoopIndex, int continueMaxLoopsCount)
        {
            TryLock();
            CallPhaseLoopCompleting(loop, direction);
            RewindHandlerAndUnlock(loop, LoopDuration, direction, true, parentContinueLoopIndex, continueMaxLoopsCount);

            PlayedTime = loop * LoopDuration + LoopDuration;
            if (direction == Direction.Backward)
                PlayedTime = Duration - PlayedTime;

            CallPhaseLoopCompleted(loop, direction);
        }

        internal void HandlePhaseLoopStart(int loop, Direction direction, int parentContinueLoopIndex, int continueMaxLoopsCount)
        {
            TryLock();
            BeforeStarting(direction, loop, parentContinueLoopIndex, continueMaxLoopsCount);
            CallPhaseLoopStarting(loop, direction);
            RewindHandlerAndUnlock(loop, 0f, direction, true, parentContinueLoopIndex, continueMaxLoopsCount);
            CallPhaseLoopStarted(loop, direction);
        }

        internal void HandlePhaseLoopUpdate(float endTime, int loop, float loopedTime, Direction direction, int parentContinueLoopIndex, int continueMaxLoopsCount)
        {
            TryLock();
            CallPhaseUpdating(endTime, direction);
            CallPhaseLoopUpdating(loop, loopedTime, direction);
            RewindHandlerAndUnlock(loop, loopedTime, direction, true, parentContinueLoopIndex, continueMaxLoopsCount);
            PlayedTime = direction == Direction.Forward ? endTime : Duration - endTime;
            CallPhaseLoopUpdated(loop, loopedTime, direction);
            CallPhaseUpdated(endTime, direction);
        }

        internal void HandlePhaseComplete(Direction direction, int parentContinueLoopIndex, int continueMaxLoopsCount)
        {
            TryLock();
            CallPhaseCompleting(direction);
            RewindHandlerAndUnlock(LoopsCount - 1, LoopDuration, direction, true, parentContinueLoopIndex, continueMaxLoopsCount);
            CallPhaseCompleted(direction);
        }
        #endregion

        #region Non zero duration, no events
        internal void HandlePhaseStartNoEvents(Direction direction, int parentContinueLoopIndex, int continueMaxLoopsCount)
        {
            TryLock();
            BeforeStarting(direction, 0, parentContinueLoopIndex, continueMaxLoopsCount);
            RewindHandlerAndUnlock(0, 0f, direction, false, parentContinueLoopIndex, continueMaxLoopsCount);
        }

        internal void HandlePhaseFirstLoopStartNoEvents(Direction direction, int parentContinueLoopIndex, int continueMaxLoopsCount)
        {
            TryLock();
            RewindHandlerAndUnlock(0, 0f, direction, false, parentContinueLoopIndex, continueMaxLoopsCount);
        }

        internal void HandlePhaseLoopCompleteNoEvents(int loop, Direction direction, int parentContinueLoopIndex, int continueMaxLoopsCount)
        {
            TryLock();
            RewindHandlerAndUnlock(loop, LoopDuration, direction, false, parentContinueLoopIndex, continueMaxLoopsCount);

            PlayedTime = loop * LoopDuration + LoopDuration;
            if (direction == Direction.Backward)
                PlayedTime = Duration - PlayedTime;
        }

        internal void HandlePhaseLoopStartNoEvents(int loop, Direction direction, int parentContinueLoopIndex, int continueMaxLoopsCount)
        {
            TryLock();
            BeforeStarting(direction, loop, parentContinueLoopIndex, continueMaxLoopsCount);
            RewindHandlerAndUnlock(loop, 0f, direction, false, parentContinueLoopIndex, continueMaxLoopsCount);
        }

        internal void HandlePhaseLoopUpdateNoEvents(float endTime, int loop, float loopedTime, Direction direction, int parentContinueLoopIndex, int continueMaxLoopsCount)
        {
            TryLock();
            RewindHandlerAndUnlock(loop, loopedTime, direction, false, parentContinueLoopIndex, continueMaxLoopsCount);
            PlayedTime = direction == Direction.Forward ? endTime : Duration - endTime;
        }

        internal void HandlePhaseCompleteNoEvents(Direction direction, int parentContinueLoopIndex, int continueMaxLoopsCount)
        {
            TryLock();
            RewindHandlerAndUnlock(LoopsCount - 1, LoopDuration, direction, false, parentContinueLoopIndex, continueMaxLoopsCount);
        }
        #endregion
        #endregion

        #region Skips
        public Playable SkipToStart() => SkipTo(0f);

        public Playable SkipToEnd() => SkipTo(Duration);

        public Playable SkipTo(float time)
        {
            CheckLock();
            return SkipTimeTo(time);
        }

        /// <summary>
        /// This method is needed to allow overriding in the final descendant. 
        /// <para>Clamp and sets the passed time to the PlayedTime property.</para>
        /// </summary>
        /// <param name="time">Time until which events will be skipped</param>
        /// <returns>The playable.</returns>
        protected virtual Playable SkipTimeTo(float time)
        {
            // if loop duration is zero, then played time will also always be zero,
            // so there is no point in assigning to it.
            if (time.Approximately(PlayedTime) || LoopDuration.Approximately(0f))
                return this;

            PlayedTime = Mathf.Clamp(time, 0f, Duration);
            return this;
        }
        #endregion

        private PlayControlException WrapMoroutineException(PlayControlException exception)
        {
            return new PlayControlException($"{Type} \"{Name}\": {exception.Message}");
        }

        #region Playing
        public Playable SetTimeType(TimeType type)
        {
            TimeType = type;
            return this;
        }

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

                try
                {
                    _playingMoroutine.Run();
                }
                catch (PlayControlException ex)
                {
                    throw WrapMoroutineException(ex);
                }

                // It is needed to listen moroutine reseted event,
                // because someone can turn off or destroy owner object.
                // In this case Playable need correct handling of self state.
                _playingMoroutine.Stopped += MoroutineStopObserver;
            }

            return this;
        }

        private void MoroutineStopObserver(Moroutine coroutine) => Pause(false);

        private IEnumerable PlayRoutine()
        {
            if (Duration.Approximately(0f))
            {
                RewindTo(Direction == Direction.Forward ? 1f : -1f, 0, 1, true);
                State = State.Completed;
                
                yield break;
            }

            while (_timeSelector() < _endTime)
            {
                var timePassed = Direction == Direction.Forward ? _timeSelector() - _startTime : _endTime - _timeSelector();
                RewindTo(timePassed, 0, 1, true);
                yield return null;
            }

            RewindTo(Direction == Direction.Forward ? Duration : 0f, 0, 1, true);
            State = State.Completed;
        }

        public Playable Pause() => Pause(true);

        public Playable Pause(bool stopMoroutine)
        {
            if (!IsPlaying)
                throw new PlayControlException($"{Type} \"{Name}\": Can't be paused while not playing");

            // Unsubscribe moroutine reseted observer, because it not needed when paused.
            _playingMoroutine.Stopped -= MoroutineStopObserver;

            if (stopMoroutine)
            {
                try
                {
                    _playingMoroutine.Stop();
                }
                catch (PlayControlException ex)
                {
                    throw WrapMoroutineException(ex);
                }
            }

            State = State.Paused;

            return this;
        }

        public Playable Reset() => Reset(true);

        private Playable Reset(bool resetMoroutine)
        {
            if (IsReseted)
                throw new PlayControlException($"{Type} \"{Name}\": Already reseted");

            // Check playing state and remove moroutine reseted observer.
            // If Playable in pause state, then it means that observer already unsubscribed.
            // Otherwise we unsubscribe observer.
            if (IsPlaying || IsCompleted)
                _playingMoroutine.Stopped -= MoroutineStopObserver;

            if (resetMoroutine)
            {
                try
                {
                    _playingMoroutine.Reset();
                }
                catch (PlayControlException ex)
                {
                    throw WrapMoroutineException(ex);
                }
            }

            PlayedTime = Direction == Direction.Forward ? 0f : Duration;
            State = State.Reseted;

            return this;
        }
        #endregion

        #region Repeat
        protected abstract IRepeater<Playable> CreateRepeater();

        public IRepeater<Playable> GetRepeater() => CreateRepeater();

        public IRepeater<Playable> Repeat() => GetRepeater().Play();

        public IRepeater<Playable> RepeatForward() => GetRepeater().PlayForward();

        public IRepeater<Playable> RepeatBackward() => GetRepeater().PlayBackward();
        #endregion

        #region Awaiters
        public YieldAwaiter WaitForComplete() => _playingMoroutine.WaitForComplete();

        public YieldAwaiter WaitForPause() => _playingMoroutine.WaitForStop();

        public YieldAwaiter WaitForPlay() => _playingMoroutine.WaitForRun();
        #endregion
    }

    /// <summary>
    /// Represent interface to work with any <see cref="Playable{T}"/>.
    /// </summary>
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
        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <see cref="PhaseStarting"/> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The playable.</returns>
        public T OnPhaseStarting(Action callback);

        /// <summary>
        /// <inheritdoc cref="OnPhaseStarting(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPhaseStarting(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPhaseStarting(Action)"/></returns>
        public T OnPhaseStarting(Action<T, Direction> callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <see cref="PhaseStarted"/> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The playable.</returns>
        public T OnPhaseStarted(Action callback);

        /// <summary>
        /// <inheritdoc cref="OnPhaseStarted(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPhaseStarted(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPhaseStarted(Action)"/></returns>
        public T OnPhaseStarted(Action<T, Direction> callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <see cref="PhaseLoopStarting"/> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The playable.</returns>
        public T OnPhaseLoopStarting(Action callback);

        /// <summary>
        /// <inheritdoc cref="OnPhaseLoopStarting(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPhaseLoopStarting(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPhaseLoopStarting(Action)"/></returns>
        public T OnPhaseLoopStarting(Action<T, int, Direction> callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <see cref="PhaseLoopStarted"/> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The playable.</returns>
        public T OnPhaseLoopStarted(Action callback);

        /// <summary>
        /// <inheritdoc cref="OnPhaseLoopStarted(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPhaseLoopStarted(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPhaseLoopStarted(Action)"/></returns>
        public T OnPhaseLoopStarted(Action<T, int, Direction> callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <see cref="PhaseLoopUpdating"/> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The playable.</returns>
        public T OnPhaseLoopUpdating(Action callback);

        /// <summary>
        /// <inheritdoc cref="OnPhaseLoopUpdating(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPhaseLoopUpdating(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPhaseLoopUpdating(Action)"/></returns>
        public T OnPhaseLoopUpdating(Action<T, int, float, Direction> callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <see cref="PhaseLoopUpdated"/> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The playable.</returns>
        public T OnPhaseLoopUpdated(Action callback);

        /// <summary>
        /// <inheritdoc cref="OnPhaseLoopUpdated(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPhaseLoopUpdated(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPhaseLoopUpdated(Action)"/></returns>
        public T OnPhaseLoopUpdated(Action<T, int, float, Direction> callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <see cref="PhaseUpdating"/> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The playable.</returns>
        public T OnPhaseUpdating(Action callback);

        /// <summary>
        /// <inheritdoc cref="OnPhaseUpdating(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPhaseUpdating(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPhaseUpdating(Action)"/></returns>
        public T OnPhaseUpdating(Action<T, float, Direction> callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <see cref="PhaseUpdated"/> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The playable.</returns>
        public T OnPhaseUpdated(Action callback);

        /// <summary>
        /// <inheritdoc cref="OnPhaseUpdated(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPhaseUpdated(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPhaseUpdated(Action)"/></returns>
        public T OnPhaseUpdated(Action<T, float, Direction> callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <see cref="PhaseLoopCompleting"/> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The playable.</returns>
        public T OnPhaseLoopCompleting(Action callback);

        /// <summary>
        /// <inheritdoc cref="OnPhaseLoopCompleting(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPhaseLoopCompleting(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPhaseLoopCompleting(Action)"/></returns>
        public T OnPhaseLoopCompleting(Action<T, int, Direction> callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <see cref="PhaseLoopCompleted"/> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The playable.</returns>
        public T OnPhaseLoopCompleted(Action callback);

        /// <summary>
        /// <inheritdoc cref="OnPhaseLoopCompleted(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPhaseLoopCompleted(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPhaseLoopCompleted(Action)"/></returns>
        public T OnPhaseLoopCompleted(Action<T, int, Direction> callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <see cref="PhaseCompleting"/> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The playable.</returns>
        public T OnPhaseCompleting(Action callback);

        /// <summary>
        /// <inheritdoc cref="OnPhaseCompleting(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPhaseCompleting(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPhaseCompleting(Action)"/></returns>
        public T OnPhaseCompleting(Action<T, Direction> callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <see cref="PhaseCompleted"/> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The playable.</returns>
        public T OnPhaseCompleted(Action callback);

        /// <summary>
        /// <inheritdoc cref="OnPhaseCompleted(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPhaseCompleted(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPhaseCompleted(Action)"/></returns>
        public T OnPhaseCompleted(Action<T, Direction> callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <see cref="Reseted"/> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The playable.</returns>
        public T OnReseted(Action callback);

        /// <summary>
        /// <inheritdoc cref="OnReseted(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnReseted(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnReseted(Action)"/></returns>
        public T OnReseted(Action<T> callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <see cref="Playing"/> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The playable.</returns>
        public T OnPlaying(Action callback);

        /// <summary>
        /// <inheritdoc cref="OnPlaying(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPlaying(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPlaying(Action)"/></returns>
        public T OnPlaying(Action<T> callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <see cref="Paused"/> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The playable.</returns>
        public T OnPaused(Action callback);

        /// <summary>
        /// <inheritdoc cref="OnPaused(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPaused(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPaused(Action)"/></returns>
        public T OnPaused(Action<T> callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <see cref="Completed"/> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The playable.</returns>
        public T OnCompleted(Action callback);

        /// <summary>
        /// <inheritdoc cref="OnCompleted(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnCompleted(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnCompleted(Action)"/></returns>
        public T OnCompleted(Action<T> callback);
        #endregion

        /// <summary>
        /// <inheritdoc cref="IPlayable.SetEase(Ease)"/>
        /// </summary>
        /// <param name="ease"><inheritdoc cref="IPlayable.SetEase(Ease)"/></param>
        /// <returns><inheritdoc cref="IPlayable.SetEase(Ease)"/></returns>
        new T SetEase(Ease ease);

        /// <summary>
        /// <inheritdoc cref="IPlayable.SetEase(Ease)"/>
        /// </summary>
        /// <param name="loopsCount"><inheritdoc cref="IPlayable.SetLoopCount(int)(Ease)"/></param>
        /// <returns><inheritdoc cref="IPlayable.SetEase(Ease)"/></returns>
        new T SetLoopCount(int loopsCount);

        new T SetLoopType(LoopType loopType);

        /// <summary>
        /// <inheritdoc cref="IPlayable.SetDirection(Direction)"/>
        /// </summary>
        /// <param name="direction"><inheritdoc cref="IPlayable.SetDirection(Direction)"/></param>
        /// <returns><inheritdoc cref="IPlayable.SetDirection(Direction)"/></returns>
        new T SetDirection(Direction direction);

        #region Rewinds
        /// <summary>
        /// <inheritdoc cref="IPlayable.RewindToStart(bool)"/>
        /// </summary>
        /// <param name="emitEvents"><inheritdoc cref="IPlayable.RewindToStart(bool)"/></param>
        /// <returns><inheritdoc cref="IPlayable.RewindToStart(bool)"/></returns>
        new T RewindToStart(bool emitEvents = true);

        /// <summary>
        /// <inheritdoc cref="IPlayable.RewindToEnd(bool)"/>
        /// </summary>
        /// <param name="emitEvents"><inheritdoc cref="IPlayable.RewindToEnd(bool)"/></param>
        /// <returns><inheritdoc cref="IPlayable.RewindToEnd(bool)"/></returns>
        new T RewindToEnd(bool emitEvents = true);

        /// <summary>
        /// <inheritdoc cref="IPlayable.RewindTo(float, bool)"/>
        /// </summary>
        /// <param name="time"><inheritdoc cref="IPlayable.RewindTo(float, bool)"/></param>
        /// <param name="emitEvents"><inheritdoc cref="IPlayable.RewindTo(float, bool)"/></param>
        /// <returns><inheritdoc cref="IPlayable.RewindTo(float, bool)"/></returns>
        new T RewindTo(float time, bool emitEvents = true);
        #endregion

        #region Skips
        /// <summary>
        /// <inheritdoc cref="IPlayable.SkipToStart"/>
        /// </summary>
        /// <returns><inheritdoc cref="IPlayable.SkipToStart"/></returns>
        new T SkipToStart();

        /// <summary>
        /// <inheritdoc cref="IPlayable.SkipToEnd"/>
        /// </summary>
        /// <returns><inheritdoc cref="IPlayable.SkipToEnd"/></returns>
        new T SkipToEnd();

        /// <summary>
        /// <inheritdoc cref="IPlayable.SkipTo(float)"/>
        /// </summary>
        /// <param name="time"><inheritdoc cref="IPlayable.SkipTo(float)"/></param>
        /// <returns><inheritdoc cref="IPlayable.SkipTo(float)"/></returns>
        new T SkipTo(float time);
        #endregion

        #region Playing
        /// <summary>
        /// <inheritdoc cref="IPlayable.SetTimeType(TimeType)"/>   
        /// </summary>
        /// <param name="type"><inheritdoc cref="IPlayable.SetTimeType(TimeType)"/></param>
        /// <returns><inheritdoc cref="IPlayable.SetTimeType(TimeType)"/></returns>
        new T SetTimeType(TimeType type);

        /// <summary>
        /// <inheritdoc cref="IPlayable.PlayForward(bool)"/>
        /// </summary>
        /// <param name="resetIfCompleted"><inheritdoc cref="IPlayable.PlayForward(bool)"/></param>
        /// <returns><inheritdoc cref="IPlayable.PlayForward(bool)"/></returns>
        new T PlayForward(bool resetIfCompleted = true);

        /// <summary>
        /// <inheritdoc cref="IPlayable.PlayBackward(bool)"/>
        /// </summary>
        /// <param name="resetIfCompleted"><inheritdoc cref="IPlayable.PlayBackward(bool)"/></param>
        /// <returns><inheritdoc cref="IPlayable.PlayBackward(bool)"/></returns>
        new T PlayBackward(bool resetIfCompleted = true);

        /// <summary>
        /// <inheritdoc cref="IPlayable.Play(bool)"/>
        /// </summary>
        /// <param name="resetIfCompleted"><inheritdoc cref="IPlayable.Play(bool)"/></param>
        /// <returns><inheritdoc cref="IPlayable.Play(bool)"/></returns>
        new T Play(bool resetIfCompleted = true);

        /// <summary>
        /// <inheritdoc cref="IPlayable.Pause"/>
        /// </summary>
        /// <param name="resetIfCompleted"><inheritdoc cref="IPlayable.Pause"/></param>
        /// <returns><inheritdoc cref="IPlayable.Pause"/></returns>
        new T Pause();

        /// <summary>
        /// <inheritdoc cref="IPlayable.Reset"/>
        /// </summary>
        /// <param name="resetIfCompleted"><inheritdoc cref="IPlayable.Reset"/></param>
        /// <returns><inheritdoc cref="IPlayable.Reset"/></returns>
        new T Reset();
        #endregion

        #region Repeat
        /// <summary>
        /// <inheritdoc cref="IPlayable.GetRepeater"/>
        /// </summary>
        /// <returns><inheritdoc cref="IPlayable.GetRepeater"/></returns>
        new Playable.IRepeater<T> GetRepeater();

        /// <summary>
        /// <inheritdoc cref="IPlayable.Repeat"/>
        /// </summary>
        /// <returns><inheritdoc cref="IPlayable.Repeat"/></returns>
        new Playable.IRepeater<T> Repeat();

        /// <summary>
        /// <inheritdoc cref="IPlayable.RepeatForward"/>
        /// </summary>
        /// <returns><inheritdoc cref="IPlayable.RepeatForward"/></returns>
        new Playable.IRepeater<T> RepeatForward();

        /// <summary>
        /// <inheritdoc cref="IPlayable.RepeatBackward"/>
        /// </summary>
        /// <returns><inheritdoc cref="IPlayable.RepeatBackward"/></returns>
        new Playable.IRepeater<T> RepeatBackward();
        #endregion
    }

    /// <summary>
    /// Base class for <see cref="Tween{T, U}"/>, <see cref="Sequence"/>, <see cref="Callback"/> and <see cref="Interval"/> classes, or any other playable.
    /// </summary>
    /// <typeparam name="T"></typeparam>
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

        /// <summary>
        /// Create <see cref="Playable{T}"/> object.
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Playable(GameObject, string, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="Playable(GameObject, string, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Playable(GameObject, string, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Playable(GameObject, string, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Playable(GameObject, string, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Playable(GameObject, string, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Playable(GameObject, string, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        protected Playable(GameObject owner, string name, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : base(owner, name, loopDuration, ease, loopsCount, loopType, direction) { }

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
        public T OnPhaseStarting(Action callback) => OnPhaseStarting((p, d) => callback());

        public T OnPhaseStarting(Action<T, Direction> callback)
        {
            PhaseStarting += callback;
            return (T)(Playable)this;
        }

        public T OnPhaseStarted(Action callback) => OnPhaseStarted((p, d) => callback());

        public T OnPhaseStarted(Action<T, Direction> callback)
        {
            PhaseStarted += callback;
            return (T)(Playable)this;
        }

        public T OnPhaseLoopStarting(Action callback) => OnPhaseLoopStarting((p, l, d) => callback());

        public T OnPhaseLoopStarting(Action<T, int, Direction> callback)
        {
            PhaseLoopStarting += callback;
            return (T)(Playable)this;
        }

        public T OnPhaseLoopStarted(Action callback) => OnPhaseLoopStarted((p, l, d) => callback());

        public T OnPhaseLoopStarted(Action<T, int, Direction> callback)
        {
            PhaseLoopStarted += callback;
            return (T)(Playable)this;
        }

        public T OnPhaseLoopUpdating(Action callback) => OnPhaseLoopUpdating((p, l, lt, d) => callback());

        public T OnPhaseLoopUpdating(Action<T, int, float, Direction> callback)
        {
            PhaseLoopUpdating += callback;
            return (T)(Playable)this;
        }

        public T OnPhaseLoopUpdated(Action callback) => OnPhaseLoopUpdated((p, l, lt, d) => callback());

        public T OnPhaseLoopUpdated(Action<T, int, float, Direction> callback)
        {
            PhaseLoopUpdated += callback;
            return (T)(Playable)this;
        }

        public T OnPhaseUpdating(Action callback) => OnPhaseUpdating((p, t, d) => callback());

        public T OnPhaseUpdating(Action<T, float, Direction> callback)
        {
            PhaseUpdating += callback;
            return (T)(Playable)this;
        }

        public T OnPhaseUpdated(Action callback) => OnPhaseUpdated((p, t, d) => callback());

        public T OnPhaseUpdated(Action<T, float, Direction> callback)
        {
            PhaseUpdated += callback;
            return (T)(Playable)this;
        }

        public T OnPhaseLoopCompleting(Action callback) => OnPhaseLoopCompleting((p, l, d) => callback());

        public T OnPhaseLoopCompleting(Action<T, int, Direction> callback)
        {
            PhaseLoopCompleting += callback;
            return (T)(Playable)this;
        }

        public T OnPhaseLoopCompleted(Action callback) => OnPhaseLoopCompleted((p, l, d) => callback());

        public T OnPhaseLoopCompleted(Action<T, int, Direction> callback)
        {
            PhaseLoopCompleted += callback;
            return (T)(Playable)this;
        }

        public T OnPhaseCompleting(Action callback) => OnPhaseCompleting((p, d) => callback());

        public T OnPhaseCompleting(Action<T, Direction> callback)
        {
            PhaseCompleting += callback;
            return (T)(Playable)this;
        }

        public T OnPhaseCompleted(Action callback) => OnPhaseCompleted((p, d) => callback());

        public T OnPhaseCompleted(Action<T, Direction> callback)
        {
            PhaseCompleted += callback;
            return (T)(Playable)this;
        }

        public T OnReseted(Action callback) => OnReseted(p => callback());

        public T OnReseted(Action<T> callback)
        {
            Reseted += callback;
            return (T)(Playable)this;
        }

        public T OnPlaying(Action callback) => OnPlaying(p => callback());

        public T OnPlaying(Action<T> callback)
        {
            Playing += callback;
            return (T)(Playable)this;
        }

        public T OnPaused(Action callback) => OnPaused(p => callback());

        public T OnPaused(Action<T> callback)
        {
            Paused += callback;
            return (T)(Playable)this;
        }

        public T OnCompleted(Action callback) => OnCompleted(p => callback());

        public T OnCompleted(Action<T> callback)
        {
            Completed += callback;
            return (T)(Playable)this;
        }
        #endregion

        public new T SetEase(Ease ease) => (T)base.SetEase(ease);

        public new T SetLoopCount(int loopsCount) => (T)base.SetLoopCount(loopsCount);

        public new T SetLoopType(LoopType loopType) => (T)base.SetLoopType(loopType);

        public new T SetDirection(Direction direction) => (T)base.SetDirection(direction);

        protected override IRepeater<Playable> CreateRepeater() => new Repeater<T>((T)(Playable)this);

        #region Rewinds
        public new T RewindTo(float time, bool emitEvents = true) => RewindTo(time, 0, 1, emitEvents);

        internal new T RewindTo(float time, int parentContinueLoopIndex, int continueMaxLoopsCount, bool emitEvents) => (T)base.RewindTo(time, parentContinueLoopIndex, continueMaxLoopsCount, emitEvents);

        public new T RewindToStart(bool emitEvents = true) => RewindToStart(0, 1, emitEvents);

        internal new T RewindToStart(int parentContinueLoopIndex, int continueMaxLoopsCount, bool emitEvents) => (T)base.RewindToStart(parentContinueLoopIndex, continueMaxLoopsCount, emitEvents);

        public new T RewindToEnd(bool emitEvents = true) => RewindToEnd(0, 1, emitEvents);

        internal new T RewindToEnd(int parentContinueLoopIndex, int continueMaxLoopsCount, bool emitEvents) => (T)base.RewindToEnd(parentContinueLoopIndex, continueMaxLoopsCount, emitEvents);
        #endregion

        #region Skips
        public new T SkipTo(float time) => (T)base.SkipTo(time);

        public new T SkipToStart() => (T)base.SkipToStart();

        public new T SkipToEnd() => (T)base.SkipToEnd();
        #endregion

        #region Playing
        public new T SetTimeType(TimeType type) => (T)base.SetTimeType(type);

        public new T PlayForward(bool resetIfCompleted = true) => (T)base.PlayForward(resetIfCompleted);

        public new T PlayBackward(bool resetIfCompleted = true) => (T)base.PlayBackward(resetIfCompleted);

        public new T Play(bool resetIfCompleted = true) => (T)base.Play(resetIfCompleted);

        public new T Pause() => (T)base.Pause();

        public new T Reset() => (T)base.Reset();
        #endregion

        #region Repeat
        public new IRepeater<T> GetRepeater() => (IRepeater<T>)CreateRepeater();

        public new IRepeater<T> Repeat() => GetRepeater().PlayForward();

        public new IRepeater<T> RepeatForward() => GetRepeater().PlayForward();

        public new IRepeater<T> RepeatBackward() => GetRepeater().PlayBackward();
        #endregion
    }
}