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
        Owner Owner { get; }

        /// <summary>
        /// Type of the playable.
        /// </summary>
        Type Type { get; }

        /// <summary>
        /// Name of the playable (useful for debugging and in sequences).
        /// </summary>
        string Name { get; set; }

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
        /// Sets owner for the playable.
        /// </summary>
        /// <param name="component">Component whose game object used as owner.</param>
        /// <returns>The playable</returns>
        IPlayable SetOwner(Component component);

        /// <summary>
        /// Sets owner to the playable.
        /// </summary>
        /// <param name="gameObject">Owner for the playable.</param>
        /// <returns>The playable.</returns>
        IPlayable SetOwner(GameObject gameObject);

        /// <summary>
        /// Make playable unowned.
        /// </summary>
        /// <returns>The playable.</returns>
        IPlayable MakeUnowned();

        /// <summary>
        /// Sets name of the playable.
        /// </summary>
        /// <param name="name">Name to set.</param>
        /// <returns>The playable.</returns>
        IPlayable SetName(string name);

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
        IPlayable RewindToStart(bool emitEvents = true);

        /// <summary>
        /// Rewind to end time (Duration).
        /// </summary>
        /// <param name="emitEvents">Shoud events be emitted?</param>
        /// <returns>The playable.</returns>
        IPlayable RewindToEnd(bool emitEvents = true);

        /// <summary>
        /// Rewind to the <paramref name="time"/>.
        /// </summary>
        /// <param name="time">The time up to which you need to rewind.</param>
        /// <param name="emitEvents">Shoud events be emitted?</param>
        /// <returns>The playable.</returns>
        IPlayable RewindTo(float time, bool emitEvents = true);
        #endregion

        #region Skips
        /// <summary>
        /// Skip playing to start time (0). The method will ignore any events and callbacks.
        /// </summary>
        /// <returns>The playable.</returns>
        IPlayable SkipToStart();

        /// <summary>
        /// Skip playing to the end (Duration). The method will ignore any events and callbacks.
        /// <para/>Usefull when create playable and need to play in backward direction. Example:
        /// <code>
        /// playable.SkipToEnd().PlayBackward();
        /// </code>
        /// </summary>
        /// <returns>The playable.</returns>
        IPlayable SkipToEnd();

        /// <summary>
        /// Skip playing to <paramref name="time"/>. The method will ignore any events and callbacks.
        /// </summary>
        /// <param name="time">The time up to which you need to skip.</param>
        /// <returns>The playable.</returns>
        IPlayable SkipTo(float time);
        #endregion

        #region Playing
        /// <summary>
        /// Sets time type for playing methods. <br/>If you want to play the animation independently
        /// of the <see cref="Time.timeScale"/> multiplier, use <see cref="TimeType.Unscaled"/>.        
        /// </summary>
        /// <param name="type">The type of time used in the playback methods.</param>
        /// <returns>The playable.</returns>
        IPlayable SetTimeType(TimeType type);

        /// <summary>
        /// Starts playing in forward direction.
        /// </summary>
        /// <param name="resetIfCompleted">Should we reset playable if it in complete state?</param>
        /// <returns>The playable.</returns>
        IPlayable PlayForward(bool resetIfCompleted = true);

        /// <summary>
        /// Starts playing in backward direction.
        /// </summary>
        /// <param name="resetIfCompleted"><inheritdoc cref="IPlayable.PlayForward(bool)" path="/param[@name='resetIfCompleted']"/></param>
        /// <returns><inheritdoc cref="IPlayable.PlayForward(bool)"/></returns>
        IPlayable PlayBackward(bool resetIfCompleted = true);

        /// <summary>
        /// Starts playing in <see cref="Direction"/> direction.
        /// </summary>
        /// <param name="resetIfCompleted"><inheritdoc cref="IPlayable.PlayBackward(bool)" path="/param[@name='resetIfCompleted']"/></param>
        /// <returns><inheritdoc cref="IPlayable.PlayBackward(bool)"/></returns>
        IPlayable Play(bool resetIfCompleted = true);

        /// <summary>
        /// Pause the playable. Can be continued later with <see cref="Play(bool)"/> method.
        /// </summary>
        /// <returns>The playble.</returns>
        IPlayable Pause();

        /// <summary>
        /// Reset the playable if it in non reset state.
        /// </summary>
        /// <returns>The playable.</returns>
        IPlayable Reset();
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
        Playable.IRepeater<IPlayable> GetRepeater();

        /// <summary>
        /// Create repeater for the playable and starts repeating playable's playing in <see cref="Playable.IRepeater{T}.Direction"/> property.
        /// <br/>Example:
        /// <code>
        /// playable.Repeat();
        /// </code>
        /// </summary>
        /// <returns>Repeater.</returns>
        Playable.IRepeater<IPlayable> Repeat();

        /// <summary>
        /// Create repeater for the playable and starts repeating playable's playing in forward direction.
        /// <br/>Example:
        /// <code>
        /// playable.RepeatForward();
        /// </code>
        /// </summary>
        /// <returns>Repeater.</returns>
        Playable.IRepeater<IPlayable> RepeatForward();

        /// <summary>
        /// Create repeater for the playable and starts repeating playable's playing in backward direction.
        /// <br/>Example:
        /// <code>
        /// playable.RepeatBackward();
        /// </code>
        /// </summary>
        /// <returns>Repeater.</returns>
        Playable.IRepeater<IPlayable> RepeatBackward();
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
        public interface IRepeater<out T> where T : IPlayable
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
        public class Repeater<T> : IRepeater<T> where T : IPlayable
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
            public Repeater(T playable) : this(null, playable) { }

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

                if (Direction == Direction.Forward)
                    Target.PlayForward(true);
                else
                    Target.PlayBackward(true);

                return this;
            }

            private IEnumerable PlayRoutine()
            {
                while (true)
                {
                    yield return Target.WaitForComplete();

                    if (Direction == Direction.Forward)
                        Target.PlayForward(true);
                    else
                        Target.PlayBackward(true);
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
        public Owner Owner => _playingMoroutine.Owner;

        public abstract Type Type { get; }

        public string Name { get; set; }

        private float _loopDuration;

        public float LoopDuration
        {
            get => _loopDuration;
            protected set
            {
                if (value < 0f)
                    throw new ArgumentException($"{Type} \"{Name}\": Loop duration can't be less than 0 ({value} passed)");

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
        /// <param name="loopDuration">Loop duration of the playable.</param>
        /// <param name="ease">Easing formula which used when playable animate values.</param>
        /// <param name="loopsCount">Loops count of the playable.</param>
        /// <param name="loopType">Loop type which used between loops in the playable.</param>
        /// <param name="direction">Direction in which the playable starts playing animation.</param>
        protected Playable(float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            LoopDuration = loopDuration;
            Ease = ease ?? Ease.Linear;
            LoopsCount = loopsCount;
            LoopType = loopType;
            Direction = direction;

            _playingMoroutine = Moroutine.Create(PlayRoutine());
        }

        IPlayable IPlayable.SetOwner(Component component) => SetOwner(component);

        /// <summary>
        /// <inheritdoc cref="IPlayable.SetOwner(Component)"/>
        /// </summary>
        /// <param name="component"><inheritdoc cref="IPlayable.SetOwner(Component)" path="/param[@name='component']"/></param>
        /// <returns><inheritdoc cref="IPlayable.SetOwner(Component)"/></returns>
        public Playable SetOwner(Component component)
        {
            _playingMoroutine.SetOwner(component);
            return this;
        }

        IPlayable IPlayable.SetOwner(GameObject gameObject) => SetOwner(gameObject);

        /// <summary>
        /// <inheritdoc cref="IPlayable.SetOwner(GameObject)"/>
        /// </summary>
        /// <param name="gameObject"><inheritdoc cref="IPlayable.SetOwner(GameObject)" path="/param[@name='gameObject']"/></param>
        /// <returns><inheritdoc cref="IPlayable.SetOwner(GameObject)"/></returns>
        public Playable SetOwner(GameObject gameObject)
        {
            _playingMoroutine.SetOwner(gameObject);
            return this;
        }

        IPlayable IPlayable.MakeUnowned() => MakeUnowned();

        /// <summary>
        /// <inheritdoc cref="IPlayable.MakeUnowned()"/>
        /// </summary>
        /// <returns><inheritdoc cref="IPlayable.MakeUnowned()"/></returns>
        public Playable MakeUnowned()
        {
            _playingMoroutine.MakeUnowned();
            return this;
        }

        IPlayable IPlayable.SetName(string name) => SetName(name);

        /// <summary>
        /// <inheritdoc cref="IPlayable.SetName(string)"/>
        /// </summary>
        /// <param name="name"><inheritdoc cref="IPlayable.SetName(string)"/></param>
        /// <returns><inheritdoc cref="IPlayable.SetName(string)"/></returns>
        public Playable SetName(string name)
        {
            Name = name;
            return this;
        }

        IPlayable IPlayable.SetEase(Ease ease) => SetEase(ease);

        /// <summary>
        /// <inheritdoc cref="IPlayable.SetEase(Ease)"/>
        /// </summary>
        /// <param name="ease"><inheritdoc cref="IPlayable.SetEase(Ease)"/></param>
        /// <returns><inheritdoc cref="IPlayable.SetEase(Ease)"/></returns>
        public Playable SetEase(Ease ease)
        {
            _ease = ease;
            return this;
        }

        IPlayable IPlayable.SetLoopCount(int loopsCount) => SetLoopCount(loopsCount);

        /// <summary>
        /// <inheritdoc cref="IPlayable.SetLoopCount(int)"/>
        /// </summary>
        /// <param name="loopsCount"><inheritdoc cref="IPlayable.SetLoopCount(int)"/></param>
        /// <returns><inheritdoc cref="IPlayable.SetLoopCount(int)"/></returns>
        public Playable SetLoopCount(int loopsCount)
        {
            LoopsCount = loopsCount;
            return this;
        }

        IPlayable IPlayable.SetLoopType(LoopType loopType) => SetLoopType(loopType);

        /// <summary>
        /// <inheritdoc cref="IPlayable.SetLoopType(LoopType)"/>
        /// </summary>
        /// <param name="loopType"><inheritdoc cref="IPlayable.SetLoopType(LoopType)"/></param>
        /// <returns><inheritdoc cref="IPlayable.SetLoopType(LoopType)"/></returns>
        public Playable SetLoopType(LoopType loopType)
        {
            LoopType = loopType;
            return this;
        }

        IPlayable IPlayable.SetDirection(Direction direction) => SetDirection(direction);

        /// <summary>
        /// <inheritdoc cref="IPlayable.SetDirection(Direction)"/>
        /// </summary>
        /// <param name="direction"><inheritdoc cref="IPlayable.SetDirection(Direction)"/></param>
        /// <returns><inheritdoc cref="IPlayable.SetDirection(Direction)"/></returns>
        public Playable SetDirection(Direction direction)
        {
            Direction = direction;
            return this;
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
        IPlayable IPlayable.RewindToStart(bool emitEvents) => RewindToStart(emitEvents);

        /// <summary>
        /// <inheritdoc cref="IPlayable.RewindToStart(bool)"/>
        /// </summary>
        /// <param name="emitEvents"><inheritdoc cref="IPlayable.RewindToStart(bool)"/></param>
        /// <returns><inheritdoc cref="IPlayable.RewindToStart(bool)"/></returns>
        public Playable RewindToStart(bool emitEvents = true) => RewindToStart(0, 1, emitEvents);

        internal Playable RewindToStart(int parentContinueLoopIndex, int continueMaxLoopsCount, bool emitEvents) => Duration.Approximately(0f) ? RewindTo(-1f, parentContinueLoopIndex, continueMaxLoopsCount, emitEvents) : RewindTo(0f, parentContinueLoopIndex, continueMaxLoopsCount, emitEvents);

        IPlayable IPlayable.RewindToEnd(bool emitEvents) => RewindToEnd(emitEvents);

        /// <summary>
        /// <inheritdoc cref="IPlayable.RewindToEnd(bool)"/>
        /// </summary>
        /// <param name="emitEvents"><inheritdoc cref="IPlayable.RewindToEnd(bool)"/></param>
        /// <returns><inheritdoc cref="IPlayable.RewindToEnd(bool)"/></returns>
        public Playable RewindToEnd(bool emitEvents = true) => RewindToEnd(0, 1, emitEvents);

        internal Playable RewindToEnd(int parentContinueLoopIndex, int continueMaxLoopsCount, bool emitEvents) => Duration.Approximately(0f) ? RewindTo(1f, parentContinueLoopIndex, continueMaxLoopsCount, emitEvents) : RewindTo(Duration, parentContinueLoopIndex, continueMaxLoopsCount, emitEvents);

        IPlayable IPlayable.RewindTo(float time, bool emitEvents) => RewindTo(time, emitEvents);

        /// <summary>
        /// <inheritdoc cref="IPlayable.RewindTo(float, bool)"/>
        /// </summary>
        /// <param name="time"><inheritdoc cref="IPlayable.RewindTo(float, bool)" path="/param[@name='time']"/></param>
        /// <param name="emitEvents"><inheritdoc cref="IPlayable.RewindTo(float, bool)" path="/param[@name='emitEvents']"/></param>
        /// <returns><inheritdoc cref="IPlayable.RewindTo(float, bool)"/></returns>
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
        IPlayable IPlayable.SkipToStart() => SkipToStart();

        /// <summary>
        /// <inheritdoc cref="IPlayable.SkipToStart()"/>
        /// </summary>
        /// <returns><inheritdoc cref="IPlayable.SkipToStart()"/></returns>
        public Playable SkipToStart() => SkipTo(0f);

        IPlayable IPlayable.SkipToEnd() => SkipToEnd();

        /// <summary>
        /// <inheritdoc cref="IPlayable.SkipToEnd()"/>
        /// </summary>
        /// <returns><inheritdoc cref="IPlayable.SkipToEnd()"/></returns>
        public Playable SkipToEnd() => SkipTo(Duration);

        IPlayable IPlayable.SkipTo(float time) => SkipTo(time);

        /// <summary>
        /// <inheritdoc cref="IPlayable.SkipTo(float)"/>
        /// </summary>
        /// <param name="time"><inheritdoc cref="IPlayable.SkipTo(float)" path="/param[@name='time']"/></param>
        /// <returns><inheritdoc cref="IPlayable.SkipTo(float)"/></returns>
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
            return new PlayControlException($"{Type} \"{Name}\": {exception.Message}\n{exception.StackTrace}");
        }

        #region Playing
        IPlayable IPlayable.SetTimeType(TimeType type) => SetTimeType(type);

        /// <summary>
        /// <inheritdoc cref="IPlayable.SetTimeType(TimeType)"/>
        /// </summary>
        /// <param name="type"><inheritdoc cref="IPlayable.SetTimeType(TimeType)"/></param>
        /// <returns><inheritdoc cref="IPlayable.SetTimeType(TimeType)"/></returns>
        public Playable SetTimeType(TimeType type)
        {
            TimeType = type;
            return this;
        }

        IPlayable IPlayable.PlayForward(bool resetIfCompleted) => PlayForward(resetIfCompleted);

        /// <summary>
        /// <inheritdoc cref="IPlayable.PlayForward(bool)"/>
        /// </summary>
        /// <param name="resetIfCompleted"><inheritdoc cref="IPlayable.PlayForward(bool)" path="/param[@name='resetIfCompleted']"/></param>
        /// <returns><inheritdoc cref="IPlayable.PlayForward(bool)"/></returns>
        public Playable PlayForward(bool resetIfCompleted = true) => Play(resetIfCompleted, Direction.Forward);

        IPlayable IPlayable.PlayBackward(bool resetIfCompleted) => PlayBackward(resetIfCompleted);

        /// <summary>
        /// <inheritdoc cref="IPlayable.PlayBackward(bool)"/>
        /// </summary>
        /// <param name="resetIfCompleted"><inheritdoc cref="IPlayable.PlayBackward(bool)" path="/param[@name='resetIfCompleted']"/></param>
        /// <returns><inheritdoc cref="IPlayable.PlayBackward(bool)"/></returns>
        public Playable PlayBackward(bool resetIfCompleted = true) => Play(resetIfCompleted, Direction.Backward);

        IPlayable IPlayable.Play(bool resetIfCompleted) => Play(resetIfCompleted);

        /// <summary>
        /// <inheritdoc cref="IPlayable.Play(bool)"/>
        /// </summary>
        /// <param name="resetIfCompleted"><inheritdoc cref="IPlayable.PlayBackward(bool)" path="/param[@name='resetIfCompleted']"/></param>
        /// <returns><inheritdoc cref="IPlayable.Play(bool)"/></returns>
        public Playable Play(bool resetIfCompleted = true) => Play(resetIfCompleted, Direction);

        private Playable Play(bool resetIfCompleted, Direction direction)
        {
            if (IsPlaying && Direction == direction)
                return this;

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

        IPlayable IPlayable.Pause() => Pause();

        /// <summary>
        /// <inheritdoc cref="IPlayable.Pause()"/>
        /// </summary>
        /// <returns><inheritdoc cref="IPlayable.Pause()"/></returns>
        public Playable Pause() => Pause(true);

        private Playable Pause(bool stopMoroutine)
        {
            if (!IsPlaying)
                return this;

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

        IPlayable IPlayable.Reset() => Reset();

        /// <summary>
        /// <inheritdoc cref="IPlayable.Reset()"/>
        /// </summary>
        /// <returns><inheritdoc cref="IPlayable.Reset()"/></returns>
        public Playable Reset() => Reset(true);

        private Playable Reset(bool resetMoroutine)
        {
            if (IsReseted)
                return this;

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
        protected IRepeater<Playable> CreateRepeater() => new Repeater<Playable>(this);

        public IRepeater<IPlayable> GetRepeater() => CreateRepeater();

        public IRepeater<IPlayable> Repeat() => GetRepeater().Play();

        public IRepeater<IPlayable> RepeatForward() => GetRepeater().PlayForward();

        public IRepeater<IPlayable> RepeatBackward() => GetRepeater().PlayBackward();
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
    public interface IPlayable<out T> : IPlayable where T : IPlayable
    {
        #region Phase events
        /// <summary>
        /// Emits when playing position starts move from start position, but before moved.
        /// </summary>
        event Action<T, Direction> PhaseStarting;

        /// <summary>
        /// Emits when playing position moved from start position.
        /// </summary>
        event Action<T, Direction> PhaseStarted;

        /// <summary>
        /// Emits when playing position starts move from any looped start position, but before moved.
        /// </summary>
        event Action<T, int, Direction> PhaseLoopStarting;

        /// <summary>
        /// Emits when playing position moved from any looped start position.
        /// </summary>
        event Action<T, int, Direction> PhaseLoopStarted;

        /// <summary>
        /// Emits when playing position starts move to intermediate position, but before moved. Time parameter will be looped.
        /// </summary>
        event Action<T, int, float, Direction> PhaseLoopUpdating;

        /// <summary>
        /// Emits when playing position moved to intermediate position. Time parameter will be looped.
        /// </summary>
        event Action<T, int, float, Direction> PhaseLoopUpdated;

        /// <summary>
        /// Emits when playing position starts move to intermediate position, but before moved.
        /// </summary>
        event Action<T, float, Direction> PhaseUpdating;

        /// <summary>
        /// Emits when playing position moved to intermediate position.
        /// </summary>
        event Action<T, float, Direction> PhaseUpdated;

        /// <summary>
        /// Emits when playing position ends move on any looped end position, but before moved.
        /// </summary>
        event Action<T, int, Direction> PhaseLoopCompleting;

        /// <summary>
        /// Emits when playing position ends move on any looped end position.
        /// </summary>
        event Action<T, int, Direction> PhaseLoopCompleted;

        /// <summary>
        /// Emits when playing position ends move on end position, but before moved.
        /// </summary>
        event Action<T, Direction> PhaseCompleting;

        /// <summary>
        /// Emits when playing position ends move on end position.
        /// </summary>
        event Action<T, Direction> PhaseCompleted;
        #endregion

        #region Routine events
        /// <summary>
        /// Emits after reseting.
        /// </summary>
        event Action<T> Reseted;

        /// <summary>
        /// Emits after starts playing.
        /// </summary>
        event Action<T> Playing;

        /// <summary>
        /// Emits after paused.
        /// </summary>
        event Action<T> Paused;

        /// <summary>
        /// Emits after completed.
        /// </summary>
        event Action<T> Completed;
        #endregion

        #region Subscribes
        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <c>PhaseStarting</c> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The playable.</returns>
        IPlayable<T> OnPhaseStarting(Action callback);

        /// <summary>
        /// <inheritdoc cref="OnPhaseStarting(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPhaseStarting(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPhaseStarting(Action)"/></returns>
        IPlayable<T> OnPhaseStarting(Action<T, Direction> callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <c>PhaseStarted</c> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The playable.</returns>
        IPlayable<T> OnPhaseStarted(Action callback);

        /// <summary>
        /// <inheritdoc cref="OnPhaseStarted(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPhaseStarted(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPhaseStarted(Action)"/></returns>
        IPlayable<T> OnPhaseStarted(Action<T, Direction> callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <c>PhaseLoopStarting</c> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The playable.</returns>
        IPlayable<T> OnPhaseLoopStarting(Action callback);

        /// <summary>
        /// <inheritdoc cref="OnPhaseLoopStarting(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPhaseLoopStarting(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPhaseLoopStarting(Action)"/></returns>
        IPlayable<T> OnPhaseLoopStarting(Action<T, int, Direction> callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <c>PhaseLoopStarted</c> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The playable.</returns>
        IPlayable<T> OnPhaseLoopStarted(Action callback);

        /// <summary>
        /// <inheritdoc cref="OnPhaseLoopStarted(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPhaseLoopStarted(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPhaseLoopStarted(Action)"/></returns>
        IPlayable<T> OnPhaseLoopStarted(Action<T, int, Direction> callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <c>PhaseLoopUpdating</c> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The playable.</returns>
        IPlayable<T> OnPhaseLoopUpdating(Action callback);

        /// <summary>
        /// <inheritdoc cref="OnPhaseLoopUpdating(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPhaseLoopUpdating(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPhaseLoopUpdating(Action)"/></returns>
        IPlayable<T> OnPhaseLoopUpdating(Action<T, int, float, Direction> callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <c>PhaseLoopUpdated</c> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The playable.</returns>
        IPlayable<T> OnPhaseLoopUpdated(Action callback);

        /// <summary>
        /// <inheritdoc cref="OnPhaseLoopUpdated(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPhaseLoopUpdated(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPhaseLoopUpdated(Action)"/></returns>
        IPlayable<T> OnPhaseLoopUpdated(Action<T, int, float, Direction> callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <c>PhaseUpdating</c> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The playable.</returns>
        IPlayable<T> OnPhaseUpdating(Action callback);

        /// <summary>
        /// <inheritdoc cref="OnPhaseUpdating(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPhaseUpdating(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPhaseUpdating(Action)"/></returns>
        IPlayable<T> OnPhaseUpdating(Action<T, float, Direction> callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <c>PhaseUpdated</c> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The playable.</returns>
        IPlayable<T> OnPhaseUpdated(Action callback);

        /// <summary>
        /// <inheritdoc cref="OnPhaseUpdated(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPhaseUpdated(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPhaseUpdated(Action)"/></returns>
        IPlayable<T> OnPhaseUpdated(Action<T, float, Direction> callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <c>PhaseLoopCompleting</c> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The playable.</returns>
        IPlayable<T> OnPhaseLoopCompleting(Action callback);

        /// <summary>
        /// <inheritdoc cref="OnPhaseLoopCompleting(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPhaseLoopCompleting(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPhaseLoopCompleting(Action)"/></returns>
        IPlayable<T> OnPhaseLoopCompleting(Action<T, int, Direction> callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <c>PhaseLoopCompleted</c> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The playable.</returns>
        IPlayable<T> OnPhaseLoopCompleted(Action callback);

        /// <summary>
        /// <inheritdoc cref="OnPhaseLoopCompleted(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPhaseLoopCompleted(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPhaseLoopCompleted(Action)"/></returns>
        IPlayable<T> OnPhaseLoopCompleted(Action<T, int, Direction> callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <c>PhaseCompleting</c> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The playable.</returns>
        IPlayable<T> OnPhaseCompleting(Action callback);

        /// <summary>
        /// <inheritdoc cref="OnPhaseCompleting(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPhaseCompleting(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPhaseCompleting(Action)"/></returns>
        IPlayable<T> OnPhaseCompleting(Action<T, Direction> callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <c>PhaseCompleted</c> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The playable.</returns>
        IPlayable<T> OnPhaseCompleted(Action callback);

        /// <summary>
        /// <inheritdoc cref="OnPhaseCompleted(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPhaseCompleted(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPhaseCompleted(Action)"/></returns>
        IPlayable<T> OnPhaseCompleted(Action<T, Direction> callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <c>Reseted</c> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The playable.</returns>
        IPlayable<T> OnReseted(Action callback);

        /// <summary>
        /// <inheritdoc cref="OnReseted(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnReseted(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnReseted(Action)"/></returns>
        IPlayable<T> OnReseted(Action<T> callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <c>Playing</c> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The playable.</returns>
        IPlayable<T> OnPlaying(Action callback);

        /// <summary>
        /// <inheritdoc cref="OnPlaying(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPlaying(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPlaying(Action)"/></returns>
        IPlayable<T> OnPlaying(Action<T> callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <c>Paused</c> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The playable.</returns>
        IPlayable<T> OnPaused(Action callback);

        /// <summary>
        /// <inheritdoc cref="OnPaused(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPaused(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPaused(Action)"/></returns>
        IPlayable<T> OnPaused(Action<T> callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <c>Completed</c> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The playable.</returns>
        IPlayable<T> OnCompleted(Action callback);

        /// <summary>
        /// <inheritdoc cref="OnCompleted(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnCompleted(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnCompleted(Action)"/></returns>
        IPlayable<T> OnCompleted(Action<T> callback);
        #endregion

        /// <summary>
        /// <inheritdoc cref="IPlayable.SetOwner(Component)"/>
        /// </summary>
        /// <param name="component"><inheritdoc cref="IPlayable.SetOwner(Component)" path="/param[@name='component']"/></param>
        /// <returns><inheritdoc cref="IPlayable.SetOwner(Component)"/></returns>
        new IPlayable<T> SetOwner(Component component);

        /// <summary>
        /// <inheritdoc cref="IPlayable.SetOwner(GameObject)"/>
        /// </summary>
        /// <param name="gameObject"><inheritdoc cref="IPlayable.SetOwner(GameObject)" path="/param[@name='gameObject']"/></param>
        /// <returns><inheritdoc cref="IPlayable.SetOwner(GameObject)"/></returns>
        new IPlayable<T> SetOwner(GameObject gameObject);

        /// <summary>
        /// <inheritdoc cref="IPlayable.MakeUnowned()"/>
        /// </summary>
        /// <returns><inheritdoc cref="IPlayable.MakeUnowned()"/></returns>
        new IPlayable<T> MakeUnowned();

        /// <summary>
        /// <inheritdoc cref="IPlayable.SetName(string)"/>
        /// </summary>
        /// <param name="name"><inheritdoc cref="IPlayable.SetName(string)"/></param>
        /// <returns><inheritdoc cref="IPlayable.SetName(string)"/></returns>
        new IPlayable<T> SetName(string name);

        /// <summary>
        /// <inheritdoc cref="IPlayable.SetEase(Ease)"/>
        /// </summary>
        /// <param name="ease"><inheritdoc cref="IPlayable.SetEase(Ease)"/></param>
        /// <returns><inheritdoc cref="IPlayable.SetEase(Ease)"/></returns>
        new IPlayable<T> SetEase(Ease ease);

        /// <summary>
        /// <inheritdoc cref="IPlayable.SetEase(Ease)"/>
        /// </summary>
        /// <param name="loopsCount"><inheritdoc cref="IPlayable.SetLoopCount(int)"/></param>
        /// <returns><inheritdoc cref="IPlayable.SetEase(Ease)"/></returns>
        new IPlayable<T> SetLoopCount(int loopsCount);

        /// <summary>
        /// <inheritdoc cref="IPlayable.SetLoopType(LoopType)"/>
        /// </summary>
        /// <param name="loopType"><inheritdoc cref="IPlayable.SetLoopType(LoopType)"/></param>
        /// <returns><inheritdoc cref="IPlayable.SetLoopType(LoopType)"/></returns>
        new IPlayable<T> SetLoopType(LoopType loopType);

        /// <summary>
        /// <inheritdoc cref="IPlayable.SetDirection(Direction)"/>
        /// </summary>
        /// <param name="direction"><inheritdoc cref="IPlayable.SetDirection(Direction)"/></param>
        /// <returns><inheritdoc cref="IPlayable.SetDirection(Direction)"/></returns>
        new IPlayable<T> SetDirection(Direction direction);

        #region Rewinds
        /// <summary>
        /// <inheritdoc cref="IPlayable.RewindToStart(bool)"/>
        /// </summary>
        /// <param name="emitEvents"><inheritdoc cref="IPlayable.RewindToStart(bool)"/></param>
        /// <returns><inheritdoc cref="IPlayable.RewindToStart(bool)"/></returns>
        new IPlayable<T> RewindToStart(bool emitEvents = true);

        /// <summary>
        /// <inheritdoc cref="IPlayable.RewindToEnd(bool)"/>
        /// </summary>
        /// <param name="emitEvents"><inheritdoc cref="IPlayable.RewindToEnd(bool)"/></param>
        /// <returns><inheritdoc cref="IPlayable.RewindToEnd(bool)"/></returns>
        new IPlayable<T> RewindToEnd(bool emitEvents = true);

        /// <summary>
        /// <inheritdoc cref="IPlayable.RewindTo(float, bool)"/>
        /// </summary>
        /// <param name="time"><inheritdoc cref="IPlayable.RewindTo(float, bool)" path="/param[@name='time']"/></param>
        /// <param name="emitEvents"><inheritdoc cref="IPlayable.RewindTo(float, bool)" path="/param[@name='emitEvents']"/></param>
        /// <returns><inheritdoc cref="IPlayable.RewindTo(float, bool)"/></returns>
        new IPlayable<T> RewindTo(float time, bool emitEvents = true);
        #endregion

        #region Skips
        /// <summary>
        /// <inheritdoc cref="IPlayable.SkipToStart"/>
        /// </summary>
        /// <returns><inheritdoc cref="IPlayable.SkipToStart"/></returns>
        new IPlayable<T> SkipToStart();

        /// <summary>
        /// <inheritdoc cref="IPlayable.SkipToEnd"/>
        /// </summary>
        /// <returns><inheritdoc cref="IPlayable.SkipToEnd"/></returns>
        new IPlayable<T> SkipToEnd();

        /// <summary>
        /// <inheritdoc cref="IPlayable.SkipTo(float)"/>
        /// </summary>
        /// <param name="time"><inheritdoc cref="IPlayable.SkipTo(float)"/></param>
        /// <returns><inheritdoc cref="IPlayable.SkipTo(float)"/></returns>
        new IPlayable<T> SkipTo(float time);
        #endregion

        #region Playing
        /// <summary>
        /// <inheritdoc cref="IPlayable.SetTimeType(TimeType)"/>   
        /// </summary>
        /// <param name="type"><inheritdoc cref="IPlayable.SetTimeType(TimeType)"/></param>
        /// <returns><inheritdoc cref="IPlayable.SetTimeType(TimeType)"/></returns>
        new IPlayable<T> SetTimeType(TimeType type);

        /// <summary>
        /// <inheritdoc cref="IPlayable.PlayForward(bool)"/>
        /// </summary>
        /// <param name="resetIfCompleted"><inheritdoc cref="IPlayable.PlayForward(bool)"/></param>
        /// <returns><inheritdoc cref="IPlayable.PlayForward(bool)"/></returns>
        new IPlayable<T> PlayForward(bool resetIfCompleted = true);

        /// <summary>
        /// <inheritdoc cref="IPlayable.PlayBackward(bool)"/>
        /// </summary>
        /// <param name="resetIfCompleted"><inheritdoc cref="IPlayable.PlayBackward(bool)"/></param>
        /// <returns><inheritdoc cref="IPlayable.PlayBackward(bool)"/></returns>
        new IPlayable<T> PlayBackward(bool resetIfCompleted = true);

        /// <summary>
        /// <inheritdoc cref="IPlayable.Play(bool)"/>
        /// </summary>
        /// <param name="resetIfCompleted"><inheritdoc cref="IPlayable.Play(bool)"/></param>
        /// <returns><inheritdoc cref="IPlayable.Play(bool)"/></returns>
        new IPlayable<T> Play(bool resetIfCompleted = true);

        /// <summary>
        /// <inheritdoc cref="IPlayable.Pause"/>
        /// </summary>
        /// <param name="resetIfCompleted"><inheritdoc cref="IPlayable.Pause"/></param>
        /// <returns><inheritdoc cref="IPlayable.Pause"/></returns>
        new IPlayable<T> Pause();

        /// <summary>
        /// <inheritdoc cref="IPlayable.Reset"/>
        /// </summary>
        /// <param name="resetIfCompleted"><inheritdoc cref="IPlayable.Reset"/></param>
        /// <returns><inheritdoc cref="IPlayable.Reset"/></returns>
        new IPlayable<T> Reset();
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
    public abstract class Playable<T> : Playable, IPlayable<T> where T : IPlayable
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
        /// <param name="loopDuration"><inheritdoc cref="Playable(float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Playable(float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Playable(float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Playable(float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Playable(float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        protected Playable(float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : base(loopDuration, ease, loopsCount, loopType, direction) { }

        #region Phase calls
        protected override void CallPhaseStarting(Direction direction) => PhaseStarting?.Invoke((T)(IPlayable)this, direction);

        protected override void CallPhaseStarted(Direction direction) => PhaseStarted?.Invoke((T)(IPlayable)this, direction);

        protected override void CallPhaseLoopStarting(int loop, Direction direction) => PhaseLoopStarting?.Invoke((T)(IPlayable)this, loop, direction);

        protected override void CallPhaseLoopStarted(int loop, Direction direction) => PhaseLoopStarted?.Invoke((T)(IPlayable)this, loop, direction);

        protected override void CallPhaseLoopCompleting(int loop, Direction direction) => PhaseLoopCompleting?.Invoke((T)(IPlayable)this, loop, direction);

        protected override void CallPhaseLoopCompleted(int loop, Direction direction) => PhaseLoopCompleted?.Invoke((T)(IPlayable)this, loop, direction);

        protected override void CallPhaseUpdating(float time, Direction direction) => PhaseUpdating?.Invoke((T)(IPlayable)this, time, direction);

        protected override void CallPhaseUpdated(float time, Direction direction) => PhaseUpdated?.Invoke((T)(IPlayable)this, time, direction);

        protected override void CallPhaseLoopUpdating(int loop, float time, Direction direction) => PhaseLoopUpdating?.Invoke((T)(IPlayable)this, loop, time, direction);

        protected override void CallPhaseLoopUpdated(int loop, float time, Direction direction) => PhaseLoopUpdated?.Invoke((T)(IPlayable)this, loop, time, direction);

        protected override void CallPhaseCompleting(Direction direction) => PhaseCompleting?.Invoke((T)(IPlayable)this, direction);

        protected override void CallPhaseCompleted(Direction direction) => PhaseCompleted?.Invoke((T)(IPlayable)this, direction);
        #endregion

        #region Routine calls
        protected override void CallReseted() => Reseted?.Invoke((T)(IPlayable)this);

        protected override void CallPlaying() => Playing?.Invoke((T)(IPlayable)this);

        protected override void CallPaused() => Paused?.Invoke((T)(IPlayable)this);

        protected override void CallCompleted() => Completed?.Invoke((T)(IPlayable)this);
        #endregion

        #region Subscribes
        IPlayable<T> IPlayable<T>.OnPhaseStarting(Action callback) => OnPhaseStarting(callback);

        IPlayable<T> IPlayable<T>.OnPhaseStarting(Action<T, Direction> callback) => OnPhaseStarting(callback);

        /// <summary>
        /// <inheritdoc cref="IPlayable{T}.OnPhaseStarting(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="IPlayable{T}.OnPhaseStarting(Action)"/></param>
        /// <returns><inheritdoc cref="IPlayable{T}.OnPhaseStarting(Action)"/></returns>
        public Playable<T> OnPhaseStarting(Action callback) => OnPhaseStarting((p, d) => callback());

        /// <summary>
        /// <inheritdoc cref="IPlayable{T}.OnPhaseStarting(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="IPlayable{T}.OnPhaseStarting(Action)"/></param>
        /// <returns><inheritdoc cref="IPlayable{T}.OnPhaseStarting(Action)"/></returns>
        public Playable<T> OnPhaseStarting(Action<T, Direction> callback)
        {
            PhaseStarting += callback;
            return this;
        }

        IPlayable<T> IPlayable<T>.OnPhaseStarted(Action callback) => OnPhaseStarted(callback);

        IPlayable<T> IPlayable<T>.OnPhaseStarted(Action<T, Direction> callback) => OnPhaseStarted(callback);

        /// <summary>
        /// <inheritdoc cref="IPlayable{T}.OnPhaseStarted(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="IPlayable{T}.OnPhaseStarted(Action)"/></param>
        /// <returns><inheritdoc cref="IPlayable{T}.OnPhaseStarted(Action)"/></returns>
        public Playable<T> OnPhaseStarted(Action callback) => OnPhaseStarted((p, d) => callback());

        /// <summary>
        /// <inheritdoc cref="IPlayable{T}.OnPhaseStarted(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="IPlayable{T}.OnPhaseStarted(Action)"/></param>
        /// <returns><inheritdoc cref="IPlayable{T}.OnPhaseStarted(Action)"/></returns>
        public Playable<T> OnPhaseStarted(Action<T, Direction> callback)
        {
            PhaseStarted += callback;
            return this;
        }

        IPlayable<T> IPlayable<T>.OnPhaseLoopStarting(Action callback) => OnPhaseLoopStarting(callback);

        IPlayable<T> IPlayable<T>.OnPhaseLoopStarting(Action<T, int, Direction> callback) => OnPhaseLoopStarting(callback);

        /// <summary>
        /// <inheritdoc cref="IPlayable{T}.OnPhaseLoopStarting(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="IPlayable{T}.OnPhaseLoopStarting(Action)"/></param>
        /// <returns><inheritdoc cref="IPlayable{T}.OnPhaseLoopStarting(Action)"/></returns>
        public Playable<T> OnPhaseLoopStarting(Action callback) => OnPhaseLoopStarting((p, l, d) => callback());

        /// <summary>
        /// <inheritdoc cref="IPlayable{T}.OnPhaseLoopStarting(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="IPlayable{T}.OnPhaseLoopStarting(Action)"/></param>
        /// <returns><inheritdoc cref="IPlayable{T}.OnPhaseLoopStarting(Action)"/></returns>
        public Playable<T> OnPhaseLoopStarting(Action<T, int, Direction> callback)
        {
            PhaseLoopStarting += callback;
            return this;
        }

        IPlayable<T> IPlayable<T>.OnPhaseLoopStarted(Action callback) => OnPhaseLoopStarted(callback);

        IPlayable<T> IPlayable<T>.OnPhaseLoopStarted(Action<T, int, Direction> callback) => OnPhaseLoopStarted(callback);

        /// <summary>
        /// <inheritdoc cref="IPlayable{T}.OnPhaseLoopStarted(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="IPlayable{T}.OnPhaseLoopStarted(Action)"/></param>
        /// <returns><inheritdoc cref="IPlayable{T}.OnPhaseLoopStarted(Action)"/></returns>
        public Playable<T> OnPhaseLoopStarted(Action callback) => OnPhaseLoopStarted((p, l, d) => callback());

        /// <summary>
        /// <inheritdoc cref="IPlayable{T}.OnPhaseLoopStarted(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="IPlayable{T}.OnPhaseLoopStarted(Action)"/></param>
        /// <returns><inheritdoc cref="IPlayable{T}.OnPhaseLoopStarted(Action)"/></returns>
        public Playable<T> OnPhaseLoopStarted(Action<T, int, Direction> callback)
        {
            PhaseLoopStarted += callback;
            return this;
        }

        IPlayable<T> IPlayable<T>.OnPhaseLoopUpdating(Action callback) => OnPhaseLoopUpdating(callback);

        IPlayable<T> IPlayable<T>.OnPhaseLoopUpdating(Action<T, int, float, Direction> callback) => OnPhaseLoopUpdating(callback);

        /// <summary>
        /// <inheritdoc cref="IPlayable{T}.OnPhaseLoopUpdating(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="IPlayable{T}.OnPhaseLoopUpdating(Action)"/></param>
        /// <returns><inheritdoc cref="IPlayable{T}.OnPhaseLoopUpdating(Action)"/></returns>
        public Playable<T> OnPhaseLoopUpdating(Action callback) => OnPhaseLoopUpdating((p, l, lt, d) => callback());

        /// <summary>
        /// <inheritdoc cref="IPlayable{T}.OnPhaseLoopUpdating(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="IPlayable{T}.OnPhaseLoopUpdating(Action)"/></param>
        /// <returns><inheritdoc cref="IPlayable{T}.OnPhaseLoopUpdating(Action)"/></returns>
        public Playable<T> OnPhaseLoopUpdating(Action<T, int, float, Direction> callback)
        {
            PhaseLoopUpdating += callback;
            return this;
        }

        IPlayable<T> IPlayable<T>.OnPhaseLoopUpdated(Action callback) => OnPhaseLoopUpdated(callback);

        IPlayable<T> IPlayable<T>.OnPhaseLoopUpdated(Action<T, int, float, Direction> callback) => OnPhaseLoopUpdated(callback);

        /// <summary>
        /// <inheritdoc cref="IPlayable{T}.OnPhaseLoopUpdated(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="IPlayable{T}.OnPhaseLoopUpdated(Action)"/></param>
        /// <returns><inheritdoc cref="IPlayable{T}.OnPhaseLoopUpdated(Action)"/></returns>
        public Playable<T> OnPhaseLoopUpdated(Action callback) => OnPhaseLoopUpdated((p, l, lt, d) => callback());

        /// <summary>
        /// <inheritdoc cref="IPlayable{T}.OnPhaseLoopUpdated(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="IPlayable{T}.OnPhaseLoopUpdated(Action)"/></param>
        /// <returns><inheritdoc cref="IPlayable{T}.OnPhaseLoopUpdated(Action)"/></returns>
        public Playable<T> OnPhaseLoopUpdated(Action<T, int, float, Direction> callback)
        {
            PhaseLoopUpdated += callback;
            return this;
        }

        IPlayable<T> IPlayable<T>.OnPhaseUpdating(Action callback) => OnPhaseUpdating(callback);

        IPlayable<T> IPlayable<T>.OnPhaseUpdating(Action<T, float, Direction> callback) => OnPhaseUpdating(callback);

        /// <summary>
        /// <inheritdoc cref="IPlayable{T}.OnPhaseUpdating(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="IPlayable{T}.OnPhaseUpdating(Action)"/></param>
        /// <returns><inheritdoc cref="IPlayable{T}.OnPhaseUpdating(Action)"/></returns>
        public Playable<T> OnPhaseUpdating(Action callback) => OnPhaseUpdating((p, t, d) => callback());

        /// <summary>
        /// <inheritdoc cref="IPlayable{T}.OnPhaseUpdating(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="IPlayable{T}.OnPhaseUpdating(Action)"/></param>
        /// <returns><inheritdoc cref="IPlayable{T}.OnPhaseUpdating(Action)"/></returns>
        public Playable<T> OnPhaseUpdating(Action<T, float, Direction> callback)
        {
            PhaseUpdating += callback;
            return this;
        }

        IPlayable<T> IPlayable<T>.OnPhaseUpdated(Action callback) => OnPhaseUpdated(callback);

        IPlayable<T> IPlayable<T>.OnPhaseUpdated(Action<T, float, Direction> callback) => OnPhaseUpdated(callback);

        /// <summary>
        /// <inheritdoc cref="IPlayable{T}.OnPhaseUpdated(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="IPlayable{T}.OnPhaseUpdated(Action)"/></param>
        /// <returns><inheritdoc cref="IPlayable{T}.OnPhaseUpdated(Action)"/></returns>
        public Playable<T> OnPhaseUpdated(Action callback) => OnPhaseUpdated((p, t, d) => callback());

        /// <summary>
        /// <inheritdoc cref="IPlayable{T}.OnPhaseUpdated(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="IPlayable{T}.OnPhaseUpdated(Action)"/></param>
        /// <returns><inheritdoc cref="IPlayable{T}.OnPhaseUpdated(Action)"/></returns>
        public Playable<T> OnPhaseUpdated(Action<T, float, Direction> callback)
        {
            PhaseUpdated += callback;
            return this;
        }

        IPlayable<T> IPlayable<T>.OnPhaseLoopCompleting(Action callback) => OnPhaseLoopCompleting(callback);

        IPlayable<T> IPlayable<T>.OnPhaseLoopCompleting(Action<T, int, Direction> callback) => OnPhaseLoopCompleting(callback);

        /// <summary>
        /// <inheritdoc cref="IPlayable{T}.OnPhaseLoopCompleting(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="IPlayable{T}.OnPhaseLoopCompleting(Action)"/></param>
        /// <returns><inheritdoc cref="IPlayable{T}.OnPhaseLoopCompleting(Action)"/></returns>
        public Playable<T> OnPhaseLoopCompleting(Action callback) => OnPhaseLoopCompleting((p, l, d) => callback());

        /// <summary>
        /// <inheritdoc cref="IPlayable{T}.OnPhaseLoopCompleting(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="IPlayable{T}.OnPhaseLoopCompleting(Action)"/></param>
        /// <returns><inheritdoc cref="IPlayable{T}.OnPhaseLoopCompleting(Action)"/></returns>
        public Playable<T> OnPhaseLoopCompleting(Action<T, int, Direction> callback)
        {
            PhaseLoopCompleting += callback;
            return this;
        }

        IPlayable<T> IPlayable<T>.OnPhaseLoopCompleted(Action callback) => OnPhaseLoopCompleted(callback);

        IPlayable<T> IPlayable<T>.OnPhaseLoopCompleted(Action<T, int, Direction> callback) => OnPhaseLoopCompleted(callback);

        /// <summary>
        /// <inheritdoc cref="IPlayable{T}.OnPhaseLoopCompleted(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="IPlayable{T}.OnPhaseLoopCompleted(Action)"/></param>
        /// <returns><inheritdoc cref="IPlayable{T}.OnPhaseLoopCompleted(Action)"/></returns>
        public Playable<T> OnPhaseLoopCompleted(Action callback) => OnPhaseLoopCompleted((p, l, d) => callback());

        /// <summary>
        /// <inheritdoc cref="IPlayable{T}.OnPhaseLoopCompleted(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="IPlayable{T}.OnPhaseLoopCompleted(Action)"/></param>
        /// <returns><inheritdoc cref="IPlayable{T}.OnPhaseLoopCompleted(Action)"/></returns>
        public Playable<T> OnPhaseLoopCompleted(Action<T, int, Direction> callback)
        {
            PhaseLoopCompleted += callback;
            return this;
        }

        IPlayable<T> IPlayable<T>.OnPhaseCompleting(Action callback) => OnPhaseCompleting(callback);

        IPlayable<T> IPlayable<T>.OnPhaseCompleting(Action<T, Direction> callback) => OnPhaseCompleting(callback);

        /// <summary>
        /// <inheritdoc cref="IPlayable{T}.OnPhaseCompleting(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="IPlayable{T}.OnPhaseCompleting(Action)"/></param>
        /// <returns><inheritdoc cref="IPlayable{T}.OnPhaseCompleting(Action)"/></returns>
        public Playable<T> OnPhaseCompleting(Action callback) => OnPhaseCompleting((p, d) => callback());

        /// <summary>
        /// <inheritdoc cref="IPlayable{T}.OnPhaseCompleting(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="IPlayable{T}.OnPhaseCompleting(Action)"/></param>
        /// <returns><inheritdoc cref="IPlayable{T}.OnPhaseCompleting(Action)"/></returns>
        public Playable<T> OnPhaseCompleting(Action<T, Direction> callback)
        {
            PhaseCompleting += callback;
            return this;
        }

        IPlayable<T> IPlayable<T>.OnPhaseCompleted(Action callback) => OnPhaseCompleted(callback);

        IPlayable<T> IPlayable<T>.OnPhaseCompleted(Action<T, Direction> callback) => OnPhaseCompleted(callback);

        /// <summary>
        /// <inheritdoc cref="IPlayable{T}.OnPhaseCompleted(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="IPlayable{T}.OnPhaseCompleted(Action)"/></param>
        /// <returns><inheritdoc cref="IPlayable{T}.OnPhaseCompleted(Action)"/></returns>
        public Playable<T> OnPhaseCompleted(Action callback) => OnPhaseCompleted((p, d) => callback());

        /// <summary>
        /// <inheritdoc cref="IPlayable{T}.OnPhaseCompleted(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="IPlayable{T}.OnPhaseCompleted(Action)"/></param>
        /// <returns><inheritdoc cref="IPlayable{T}.OnPhaseCompleted(Action)"/></returns>
        public Playable<T> OnPhaseCompleted(Action<T, Direction> callback)
        {
            PhaseCompleted += callback;
            return this;
        }

        IPlayable<T> IPlayable<T>.OnReseted(Action callback) => OnReseted(callback);

        IPlayable<T> IPlayable<T>.OnReseted(Action<T> callback) => OnReseted(callback);

        /// <summary>
        /// <inheritdoc cref="IPlayable{T}.OnReseted(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="IPlayable{T}.OnReseted(Action)"/></param>
        /// <returns><inheritdoc cref="IPlayable{T}.OnReseted(Action)"/></returns>
        public Playable<T> OnReseted(Action callback) => OnReseted(p => callback());

        /// <summary>
        /// <inheritdoc cref="IPlayable{T}.OnReseted(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="IPlayable{T}.OnReseted(Action)"/></param>
        /// <returns><inheritdoc cref="IPlayable{T}.OnReseted(Action)"/></returns>
        public Playable<T> OnReseted(Action<T> callback)
        {
            Reseted += callback;
            return this;
        }

        IPlayable<T> IPlayable<T>.OnPlaying(Action callback) => OnPlaying(callback);

        IPlayable<T> IPlayable<T>.OnPlaying(Action<T> callback) => OnPlaying(callback);

        /// <summary>
        /// <inheritdoc cref="IPlayable{T}.OnPlaying(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="IPlayable{T}.OnPlaying(Action)"/></param>
        /// <returns><inheritdoc cref="IPlayable{T}.OnPlaying(Action)"/></returns>
        public Playable<T> OnPlaying(Action callback) => OnPlaying(p => callback());

        /// <summary>
        /// <inheritdoc cref="IPlayable{T}.OnPlaying(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="IPlayable{T}.OnPlaying(Action)"/></param>
        /// <returns><inheritdoc cref="IPlayable{T}.OnPlaying(Action)"/></returns>
        public Playable<T> OnPlaying(Action<T> callback)
        {
            Playing += callback;
            return this;
        }

        IPlayable<T> IPlayable<T>.OnPaused(Action callback) => OnPaused(callback);

        IPlayable<T> IPlayable<T>.OnPaused(Action<T> callback) => OnPaused(callback);

        /// <summary>
        /// <inheritdoc cref="IPlayable{T}.OnPaused(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="IPlayable{T}.OnPaused(Action)"/></param>
        /// <returns><inheritdoc cref="IPlayable{T}.OnPaused(Action)"/></returns>
        public Playable<T> OnPaused(Action callback) => OnPaused(p => callback());

        /// <summary>
        /// <inheritdoc cref="IPlayable{T}.OnPaused(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="IPlayable{T}.OnPaused(Action)"/></param>
        /// <returns><inheritdoc cref="IPlayable{T}.OnPaused(Action)"/></returns>
        public Playable<T> OnPaused(Action<T> callback)
        {
            Paused += callback;
            return this;
        }

        IPlayable<T> IPlayable<T>.OnCompleted(Action callback) => OnCompleted(callback);

        IPlayable<T> IPlayable<T>.OnCompleted(Action<T> callback) => OnCompleted(callback);

        /// <summary>
        /// <inheritdoc cref="IPlayable{T}.OnCompleted(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="IPlayable{T}.OnCompleted(Action)"/></param>
        /// <returns><inheritdoc cref="IPlayable{T}.OnCompleted(Action)"/></returns>
        public Playable<T> OnCompleted(Action callback) => OnCompleted(p => callback());

        /// <summary>
        /// <inheritdoc cref="IPlayable{T}.OnCompleted(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="IPlayable{T}.OnCompleted(Action)"/></param>
        /// <returns><inheritdoc cref="IPlayable{T}.OnCompleted(Action)"/></returns>
        public Playable<T> OnCompleted(Action<T> callback)
        {
            Completed += callback;
            return this;
        }
        #endregion

        IPlayable<T> IPlayable<T>.SetOwner(Component component) => SetOwner(component);

        /// <summary>
        /// <inheritdoc cref="IPlayable{T}.SetOwner(Component)"/>
        /// </summary>
        /// <param name="component"><inheritdoc cref="IPlayable{T}.SetOwner(Component)"/></param>
        /// <returns><inheritdoc cref="IPlayable{T}.SetOwner(Component)"/></returns>
        public new Playable<T> SetOwner(Component component) => (Playable<T>)base.SetOwner(component);

        IPlayable<T> IPlayable<T>.SetOwner(GameObject gameObject) => SetOwner(gameObject);

        /// <summary>
        /// <inheritdoc cref="IPlayable{T}.SetOwner(GameObject)"/>
        /// </summary>
        /// <param name="gameObject"><inheritdoc cref="IPlayable{T}.SetOwner(GameObject)"/></param>
        /// <returns><inheritdoc cref="IPlayable{T}.SetOwner(GameObject)"/></returns>
        public new Playable<T> SetOwner(GameObject gameObject) => (Playable<T>)base.SetOwner(gameObject);

        IPlayable<T> IPlayable<T>.MakeUnowned() => MakeUnowned();

        /// <summary>
        /// <inheritdoc cref="IPlayable{T}.MakeUnowned()"/>
        /// </summary>
        /// <param name="gameObject"><inheritdoc cref="IPlayable{T}.MakeUnowned()"/></param>
        /// <returns><inheritdoc cref="IPlayable{T}.MakeUnowned()"/></returns>
        public new Playable<T> MakeUnowned() => (Playable<T>)base.MakeUnowned();

        IPlayable<T> IPlayable<T>.SetName(string name) => SetName(name);

        /// <summary>
        /// <inheritdoc cref="IPlayable{T}.SetName(string)"/>
        /// </summary>
        /// <param name="name"><inheritdoc cref="IPlayable{T}.SetName(string)"/></param>
        /// <returns><inheritdoc cref="IPlayable{T}.SetName(string)"/></returns>
        public new Playable<T> SetName(string name) => (Playable<T>)base.SetName(name);

        IPlayable<T> IPlayable<T>.SetEase(Ease ease) => SetEase(ease);

        /// <summary>
        /// <inheritdoc cref="IPlayable{T}.SetEase(Ease)"/>
        /// </summary>
        /// <param name="ease"><inheritdoc cref="IPlayable{T}.SetEase(Ease)"/></param>
        /// <returns><inheritdoc cref="IPlayable{T}.SetEase(Ease)"/></returns>
        public new Playable<T> SetEase(Ease ease) => (Playable<T>)base.SetEase(ease);

        IPlayable<T> IPlayable<T>.SetLoopCount(int loopsCount) => SetLoopCount(loopsCount);

        /// <summary>
        /// <inheritdoc cref="IPlayable{T}.SetLoopCount(int)"/>
        /// </summary>
        /// <param name="loopsCount"><inheritdoc cref="IPlayable{T}.SetLoopCount(int)"/></param>
        /// <returns><inheritdoc cref="IPlayable{T}.SetLoopCount(int)"/></returns>
        public new Playable<T> SetLoopCount(int loopsCount) => (Playable<T>)base.SetLoopCount(loopsCount);

        IPlayable<T> IPlayable<T>.SetLoopType(LoopType loopType) => SetLoopType(loopType);

        /// <summary>
        /// <inheritdoc cref="IPlayable{T}.SetLoopType(LoopType)"/>
        /// </summary>
        /// <param name="loopType"><inheritdoc cref="IPlayable{T}.SetLoopType(LoopType)"/></param>
        /// <returns><inheritdoc cref="IPlayable{T}.SetLoopType(LoopType)"/></returns>
        public new Playable<T> SetLoopType(LoopType loopType) => (Playable<T>)base.SetLoopType(loopType);

        IPlayable<T> IPlayable<T>.SetDirection(Direction direction) => SetDirection(direction);

        /// <summary>
        /// <inheritdoc cref="IPlayable{T}.SetDirection(Direction)"/>
        /// </summary>
        /// <param name="direction"><inheritdoc cref="IPlayable{T}.SetDirection(Direction)"/></param>
        /// <returns><inheritdoc cref="IPlayable{T}.SetDirection(Direction)"/></returns>
        public new Playable<T> SetDirection(Direction direction) => (Playable<T>)base.SetDirection(direction);

        #region Rewinds
        IPlayable<T> IPlayable<T>.RewindTo(float time, bool emitEvents) => RewindTo(time, emitEvents);

        /// <summary>
        /// <inheritdoc cref="IPlayable{T}.RewindTo(float, bool)"/>
        /// </summary>
        /// <param name="time"><inheritdoc cref="IPlayable{T}.RewindTo(float, bool)" path="/param[@name='time']"/></param>
        /// <param name="emitEvents"><inheritdoc cref="IPlayable{T}.RewindTo(float, bool)" path="/param[@name='emitEvents']"/></param>
        /// <returns><inheritdoc cref="IPlayable{T}.RewindTo(float, bool)"/></returns>
        public new Playable<T> RewindTo(float time, bool emitEvents = true) => RewindTo(time, 0, 1, emitEvents);

        internal new Playable<T> RewindTo(float time, int parentContinueLoopIndex, int continueMaxLoopsCount, bool emitEvents) => (Playable<T>)base.RewindTo(time, parentContinueLoopIndex, continueMaxLoopsCount, emitEvents);

        IPlayable<T> IPlayable<T>.RewindToStart(bool emitEvents) => RewindToStart(emitEvents);

        /// <summary>
        /// <inheritdoc cref="IPlayable{T}.RewindToStart(bool)"/>
        /// </summary>
        /// <param name="emitEvents"><inheritdoc cref="IPlayable{T}.RewindToStart(bool)"/></param>
        /// <returns><inheritdoc cref="IPlayable{T}.RewindToStart(bool)"/></returns>
        public new Playable<T> RewindToStart(bool emitEvents = true) => RewindToStart(0, 1, emitEvents);

        internal new Playable<T> RewindToStart(int parentContinueLoopIndex, int continueMaxLoopsCount, bool emitEvents) => (Playable<T>)base.RewindToStart(parentContinueLoopIndex, continueMaxLoopsCount, emitEvents);

        IPlayable<T> IPlayable<T>.RewindToEnd(bool emitEvents) => RewindToEnd(emitEvents);

        /// <summary>
        /// <inheritdoc cref="IPlayable{T}.RewindToEnd(bool)"/>
        /// </summary>
        /// <param name="emitEvents"><inheritdoc cref="IPlayable{T}.RewindToEnd(bool)"/></param>
        /// <returns><inheritdoc cref="IPlayable{T}.RewindToEnd(bool)"/></returns>
        public new Playable<T> RewindToEnd(bool emitEvents = true) => RewindToEnd(0, 1, emitEvents);

        internal new Playable<T> RewindToEnd(int parentContinueLoopIndex, int continueMaxLoopsCount, bool emitEvents) => (Playable<T>)base.RewindToEnd(parentContinueLoopIndex, continueMaxLoopsCount, emitEvents);
        #endregion

        #region Skips
        IPlayable<T> IPlayable<T>.SkipTo(float time) => SkipTo(time);

        /// <summary>
        /// <inheritdoc cref="IPlayable{T}.SkipTo(float)"/>
        /// </summary>
        /// <param name="time"><inheritdoc cref="IPlayable{T}.SkipTo(float)"/></param>
        /// <returns><inheritdoc cref="IPlayable{T}.SkipTo(float)"/></returns>
        public new Playable<T> SkipTo(float time) => (Playable<T>)base.SkipTo(time);

        IPlayable<T> IPlayable<T>.SkipToStart() => SkipToStart();

        /// <summary>
        /// <inheritdoc cref="IPlayable{T}.SkipToStart()"/>
        /// </summary>
        /// <returns><inheritdoc cref="IPlayable{T}.SkipToStart()"/></returns>
        public new Playable<T> SkipToStart() => (Playable<T>)base.SkipToStart();

        IPlayable<T> IPlayable<T>.SkipToEnd() => SkipToEnd();

        /// <summary>
        /// <inheritdoc cref="IPlayable{T}.SkipToEnd()"/>
        /// </summary>
        /// <returns><inheritdoc cref="IPlayable{T}.SkipToEnd()"/></returns>
        public new Playable<T> SkipToEnd() => (Playable<T>)base.SkipToEnd();
        #endregion

        #region Playing
        IPlayable<T> IPlayable<T>.SetTimeType(TimeType type) => SetTimeType(type);

        /// <summary>
        /// <inheritdoc cref="IPlayable{T}.SetTimeType(TimeType)"/>
        /// </summary>
        /// <param name="type"><inheritdoc cref="IPlayable{T}.SetTimeType(TimeType)"/></param>
        /// <returns><inheritdoc cref="IPlayable{T}.SetTimeType(TimeType)"/></returns>
        public new Playable<T> SetTimeType(TimeType type) => (Playable<T>)base.SetTimeType(type);

        IPlayable<T> IPlayable<T>.PlayForward(bool resetIfCompleted) => PlayForward(resetIfCompleted);

        /// <summary>
        /// <inheritdoc cref="IPlayable{T}.PlayForward(bool)"/>
        /// </summary>
        /// <param name="resetIfCompleted"><inheritdoc cref="IPlayable{T}.PlayForward(bool)"/></param>
        /// <returns><inheritdoc cref="IPlayable{T}.PlayForward(bool)"/></returns>
        public new Playable<T> PlayForward(bool resetIfCompleted = true) => (Playable<T>)base.PlayForward(resetIfCompleted);

        IPlayable<T> IPlayable<T>.PlayBackward(bool resetIfCompleted) => PlayBackward(resetIfCompleted);

        /// <summary>
        /// <inheritdoc cref="IPlayable{T}.PlayBackward(bool)"/>
        /// </summary>
        /// <param name="resetIfCompleted"><inheritdoc cref="IPlayable{T}.PlayBackward(bool)"/></param>
        /// <returns><inheritdoc cref="IPlayable{T}.PlayBackward(bool)"/></returns>
        public new Playable<T> PlayBackward(bool resetIfCompleted = true) => (Playable<T>)base.PlayBackward(resetIfCompleted);

        IPlayable<T> IPlayable<T>.Play(bool resetIfCompleted) => Play(resetIfCompleted);

        /// <summary>
        /// <inheritdoc cref="IPlayable{T}.Play(bool)"/>
        /// </summary>
        /// <param name="resetIfCompleted"><inheritdoc cref="IPlayable{T}.Play(bool)"/></param>
        /// <returns><inheritdoc cref="IPlayable{T}.Play(bool)"/></returns>
        public new Playable<T> Play(bool resetIfCompleted = true) => (Playable<T>)base.Play(resetIfCompleted);

        IPlayable<T> IPlayable<T>.Pause() => Pause();

        /// <summary>
        /// <inheritdoc cref="IPlayable{T}.Pause()"/>
        /// </summary>
        /// <returns><inheritdoc cref="IPlayable{T}.Pause()"/></returns>
        public new Playable<T> Pause() => (Playable<T>)base.Pause();

        IPlayable<T> IPlayable<T>.Reset() => Reset();

        /// <summary>
        /// <inheritdoc cref="IPlayable{T}.Reset()"/>
        /// </summary>
        /// <returns><inheritdoc cref="IPlayable{T}.Reset()"/></returns>
        public new Playable<T> Reset() => (Playable<T>)base.Reset();
        #endregion

        #region Repeat
        protected new IRepeater<T> CreateRepeater() => new Repeater<T>((T)(IPlayable)this);

        public new IRepeater<T> GetRepeater() => CreateRepeater();

        public new IRepeater<T> Repeat() => GetRepeater().PlayForward();

        public new IRepeater<T> RepeatForward() => GetRepeater().PlayForward();

        public new IRepeater<T> RepeatBackward() => GetRepeater().PlayBackward();
        #endregion
    }
}