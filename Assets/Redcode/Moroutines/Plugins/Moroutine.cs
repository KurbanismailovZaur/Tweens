using Redcode.Moroutines.Exceptions;
using System;
using System.Collections;
using UnityEngine;

namespace Redcode.Moroutines
{
    /// <summary>
    /// Represents a more advanced coroutine. You can control execution, subscribe to events, <br/>
    /// get the last result, wait for a specific events, and more.
    /// </summary>
    public sealed class Moroutine
    {
        #region Awaiter classes
        /// <summary>
        /// Represents a base class for expectations.
        /// </summary>
        public abstract class MoroutineAwaiter : YieldAwaiter
        {
            protected Moroutine _moroutine;

            /// <summary>
            /// Create awaiter-object which can await some moroutine events.
            /// </summary>
            /// <param name="moroutine">Moroutine, whose event is to be expected.</param>
            public MoroutineAwaiter(Moroutine moroutine) => _moroutine = moroutine;
        }

        /// <summary>
        /// Represents a class capable of waiting for a moroutine completion event.
        /// </summary>
        public class CompleteAwaiter : MoroutineAwaiter
        {
            private IEnumerator _enumerator;

            /// <summary>
            /// Create awaiter-object which can await moroutine's complete event.
            /// </summary>
            /// <param name="moroutine"><inheritdoc cref="MoroutineAwaiter(Moroutine)"/></param>
            public CompleteAwaiter(Moroutine moroutine) : base(moroutine) => _enumerator = moroutine._enumerator;

            /// <summary>
            /// Should we continue to wait for the moroutine to be completed, or has it already been completed?
            /// </summary>
            public override bool KeepWaiting => _enumerator == _moroutine._enumerator && !_moroutine.IsCompleted;
        }

        /// <summary>
        /// Represents a class capable of waiting for a moroutine stop event.
        /// </summary>
        public class StopAwaiter : MoroutineAwaiter
        {
            private Coroutine _coroutine;

            /// <summary>
            /// Create awaiter-object which can await moroutine's stop event.
            /// </summary>
            /// <param name="moroutine"><inheritdoc cref="MoroutineAwaiter(Moroutine)"/></param>
            public StopAwaiter(Moroutine moroutine) : base(moroutine) => _coroutine = moroutine._coroutine;

            /// <summary>
            /// Should we continue to wait for the moroutine to be stopped, or has it already been stopped?
            /// </summary>
            public override bool KeepWaiting => _coroutine == _moroutine._coroutine && _moroutine.IsRunning;
        }

        /// <summary>
        /// Represents a class capable of waiting for a moroutine run event.
        /// </summary>
        public class RunAwaiter : MoroutineAwaiter
        {
            private Coroutine _coroutine;

            /// <summary>
            /// Create awaiter-object which can await moroutine's run event.
            /// </summary>
            /// <param name="moroutine"><inheritdoc cref="MoroutineAwaiter(Moroutine)"/></param>
            public RunAwaiter(Moroutine moroutine) : base(moroutine) => _coroutine = moroutine._coroutine;

            /// <summary>
            /// Should we continue to wait for the moroutine to be run, or has it already been runned?
            /// </summary>
            public override bool KeepWaiting => _coroutine == _moroutine._coroutine && !_moroutine.IsRunning;
        }

        /// <summary>
        /// Represents a class capable of waiting for a moroutine reset event.
        /// </summary>
        public class ResetAwaiter : MoroutineAwaiter
        {
            private IEnumerator _enumerator;

            /// <summary>
            /// Create awaiter-object which can await moroutine's reset event.
            /// </summary>
            /// <param name="moroutine"><inheritdoc cref="MoroutineAwaiter(Moroutine)"/></param>
            public ResetAwaiter(Moroutine moroutine) : base(moroutine) => _enumerator = moroutine._enumerator;

            /// <summary>
            /// Should we continue to wait for the moroutine to be reset, or has it already been reseted?
            /// </summary>
            public override bool KeepWaiting => _enumerator == _moroutine._enumerator;
        }
        #endregion

        /// <summary>
        /// Represents the state of moroutine.
        /// </summary>
        public enum State
        {
            /// <summary>
            /// Morutina is in the initial state.
            /// </summary>
            Reseted,

            /// <summary>
            /// Morutina is being executed right now.
            /// </summary>
            Running,

            /// <summary>
            /// Morutina is suspended.
            /// </summary>
            Stopped,

            /// <summary>
            /// The execution of the moroutine is completed.
            /// </summary>
            Completed
        }

        #region Owner and routines
        private GameObject _owner;

        /// <summary>
        /// The owner of this moroutine.
        /// </summary>
        public GameObject Owner => _owner;

        private IEnumerable _enumerable;

        private IEnumerator _enumerator;

        private Coroutine _coroutine;
        #endregion

        #region State
        private State _state;

        /// <summary>
        /// Current state of the  moroutine.
        /// </summary>
        public State CurrentState
        {
            get => _state;
            private set
            {
                _state = value;

                var stateEvent = _state switch
                {
                    State.Reseted => Reseted,
                    State.Running => Running,
                    State.Stopped => Stopped,
                    State.Completed => Completed,
                    _ => throw new PlayControlException("Wrong moroutine state.")
                };

                stateEvent?.Invoke(this);
            }
        }

        /// <summary>
        /// Is moroutine in reset state?
        /// </summary>
        public bool IsReseted => CurrentState == State.Reseted;

        /// <summary>
        /// Is moroutine being performed right now?
        /// </summary>
        public bool IsRunning => CurrentState == State.Running;

        /// <summary>
        /// Is moroutine in stopped state?
        /// </summary>
        public bool IsStopped => CurrentState == State.Stopped;

        /// <summary>
        /// Did moroutine complete the fulfillment?
        /// </summary>
        public bool IsCompleted => CurrentState == State.Completed;

        /// <summary>
        /// The last result of the moroutine (the last one that was returned via the yield return instruction inside moroutine). 
        /// </summary>
        public object LastResult => _enumerator?.Current;

        private bool _locked;
        #endregion

        #region Events
        /// <summary>
        /// The event that is redeemed when the moroutine resets to its initial state.
        /// </summary>
        public event Action<Moroutine> Reseted;

        /// <summary>
        /// The event that is redeemed when the moroutine starts performing.
        /// </summary>
        public event Action<Moroutine> Running;

        /// <summary>
        /// The event that is redeemed when the moroutine stops executing.
        /// </summary>
        public event Action<Moroutine> Stopped;

        /// <summary>
        /// The event that is redeemed when the moroutine complete executing.
        /// </summary>
        public event Action<Moroutine> Completed;
        #endregion

        private Moroutine(GameObject owner, IEnumerable enumerable)
        {
            _owner = owner != null ? owner : MoroutinesOwner.Instance.gameObject;
            _enumerable = enumerable ?? throw new ArgumentNullException(nameof(enumerable));
            _enumerator = _enumerable.GetEnumerator();

            if (!_owner.TryGetComponent(out DeactivationObserver observer))
            {
                observer = _owner.AddComponent<DeactivationObserver>();
                observer.hideFlags = HideFlags.HideInInspector;
            }

            observer.Deactivated += DeactivationObserver_Deactivated;
        }

        #region Creation
        /// <summary>
        /// Create moroutine.
        /// </summary>
        /// <param name="enumerator">Enumerator which will be perform by moroutine. <br/>
        /// The <see cref="Reset"/> method call will be ignored.</param>
        /// <returns>The moroutine.</returns>
        public static Moroutine Create(IEnumerator enumerator) => Create(new EnumerableEnumerator(enumerator));

        /// <summary>
        /// <inheritdoc cref="Create(IEnumerator)"/>
        /// </summary>
        /// <param name="enumerable">Enumerable which will be perform by moroutine. <br/>
        /// Calling the <see cref="Reset"/> method will reset the state of the moroutine.</param>
        /// <returns><inheritdoc cref="Create(IEnumerator)"/></returns>
        public static Moroutine Create(IEnumerable enumerable) => Create(null, enumerable);

        /// <summary>
        /// Create moroutine with owner.
        /// </summary>
        /// <param name="owner">The owner of the moroutine.</param>
        /// <param name="enumerator"><inheritdoc cref="Create(IEnumerator)"/></param>
        /// <returns><inheritdoc cref="Create(IEnumerator)"/></returns>
        public static Moroutine Create(GameObject owner, IEnumerator enumerator) => Create(owner, new EnumerableEnumerator(enumerator));

        /// <summary>
        /// Create moroutine with owner.
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Create(GameObject, IEnumerator)" path="/param[@name='owner']"/></param>
        /// <param name="enumerable"><inheritdoc cref="Create(IEnumerable)" path="/param[@name='enumerable']"/></param>
        /// <returns><inheritdoc cref="Create(IEnumerator)"/></returns>
        public static Moroutine Create(GameObject owner, IEnumerable enumerable) => new Moroutine(owner, enumerable);

        /// <summary>
        /// Create and run moroutine.
        /// </summary>
        /// <param name="enumerator"><inheritdoc cref="Create(IEnumerator)"/></param>
        /// <returns><inheritdoc cref="Create(IEnumerator)"/></returns>
        public static Moroutine Run(IEnumerator enumerator) => Run(new EnumerableEnumerator(enumerator));

        /// <summary>
        /// Create and run moroutine.
        /// </summary>
        /// <param name="enumerable"><inheritdoc cref="Create(IEnumerable)"/></param>
        /// <returns><inheritdoc cref="Create(IEnumerator)"/></returns>
        public static Moroutine Run(IEnumerable enumerable) => Run((GameObject)null, enumerable);

        /// <summary>
        /// Create and run moroutine.
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Create(GameObject, IEnumerator)" path="/param[@name='owner']"/></param>
        /// <param name="enumerator"><inheritdoc cref="Create(IEnumerator)"/></param>
        /// <returns><inheritdoc cref="Create(IEnumerator)"/></returns>
        public static Moroutine Run(GameObject owner, IEnumerator enumerator) => Run(owner, new EnumerableEnumerator(enumerator));

        /// <summary>
        /// Create and run moroutine.
        /// </summary>
        /// /// <param name="owner"><inheritdoc cref="Create(GameObject, IEnumerator)" path="/param[@name='owner']"/></param>
        /// <param name="enumerable"><inheritdoc cref="Create(IEnumerable)"/></param>
        /// <returns><inheritdoc cref="Create(IEnumerator)"/></returns>
        public static Moroutine Run(GameObject owner, IEnumerable enumerable) => Create(owner, enumerable).Run();
        #endregion

        #region Control
        /// <summary>
        /// Starts the moroutine for execution. If the moroutine has been stopped before, the method will continue.
        /// </summary>
        /// <param name="rerunIfCompleted">Is it necessary to automatically restart the moroutine if it has been completed?</param>
        /// <returns>The moroutine.</returns>
        /// <exception cref="PlayControlException"></exception>
        public Moroutine Run(bool rerunIfCompleted = true)
        {
            if (IsRunning)
                throw new PlayControlException("Moroutine already running.");

            if (IsCompleted)
            {
                if (!rerunIfCompleted)
                    throw new PlayControlException("Moroutine was completed. If you want to restart it, call \"Reset\" method before.");

                Reset();
            }

            if (_owner == null)
                throw new PlayControlException($"The moroutine's owner object was destroyed, but you try to run moroutine.");

            if (!_owner.gameObject.activeInHierarchy)
                throw new PlayControlException($"Moroutine couldn't be started because the game object '{_owner.name}' is deactivated.");

            CurrentState = State.Running;
            _coroutine = MoroutinesOwner.Instance.StartCoroutine(RunEnumerator());

            return this;
        }

        private IEnumerator RunEnumerator()
        {
            while (true)
            {
                _locked = true;
                var hasNext = _enumerator.MoveNext();
                _locked = false;

                if (!hasNext)
                    break;

                yield return _enumerator.Current;
            }

            CurrentState = State.Completed;
        }

        /// <summary>
        /// Stops the moroutine if it in playing state.
        /// </summary>
        /// <returns>The moroutine.</returns>
        /// <exception cref="PlayControlException"></exception>
        public Moroutine Stop()
        {
            if (_locked)
                throw new PlayControlException("Calling moroutine methods not allowed in moroutine enumerator.");

            if (!IsRunning)
                throw new PlayControlException("Moroutine not running and can not be stopped.");

            MoroutinesOwner.Instance.StopCoroutine(_coroutine);
            CurrentState = State.Stopped;

            return this;
        }

        /// <summary>
        /// Resets the moroutine to initial state.
        /// </summary>
        /// <returns>The moroutine</returns>
        /// <exception cref="PlayControlException"></exception>
        public Moroutine Reset()
        {
            if (_locked)
                throw new PlayControlException("Calling moroutine methods not allowed in moroutine enumerator.");

            if (IsReseted)
                throw new PlayControlException("Moroutine already reseted.");

            if (_coroutine != null)
                MoroutinesOwner.Instance.StopCoroutine(_coroutine);

            _enumerator = _enumerable.GetEnumerator();
            CurrentState = State.Reseted;

            return this;
        }
        #endregion

        private void DeactivationObserver_Deactivated()
        {
            #region Editor only
#if UNITY_EDITOR
            // Check if Coroutines object was removed previously
            if (MoroutinesOwner.Instance == null)
                return;
#endif
            #endregion

            if (!IsRunning)
                return;

            Stop();
        }

        #region Subscribing
        private Moroutine OnSubscribe(Action<Moroutine> @event, Action<Moroutine> action)
        {
            @event += action;
            return this;
        }

        /// <summary>
        /// Subscribe to reset event.
        /// </summary>
        /// <param name="action">Callback to invoke.</param>
        /// <returns>The moroutine.</returns>
        public Moroutine OnReseted(Action<Moroutine> action) => OnSubscribe(Reseted, action);

        /// <summary>
        /// Subscribe to run event.
        /// </summary>
        /// <param name="action"><inheritdoc cref="OnReseted(Action{Moroutine})"/></param>
        /// <returns>The moroutine.</returns>
        public Moroutine OnRunning(Action<Moroutine> action) => OnSubscribe(Running, action);

        /// <summary>
        /// Subscribe to stop event.
        /// </summary>
        /// <param name="action"><inheritdoc cref="OnReseted(Action{Moroutine})"/></param>
        /// <returns>The moroutine.</returns>
        public Moroutine OnStopped(Action<Moroutine> action) => OnSubscribe(Stopped, action);

        /// <summary>
        /// Subscribe to completed event.
        /// </summary>
        /// <param name="action"><inheritdoc cref="OnReseted(Action{Moroutine})"/></param>
        /// <returns>The moroutine.</returns>
        public Moroutine OnCompleted(Action<Moroutine> action) => OnSubscribe(Completed, action);
        #endregion

        #region Yielders
        /// <summary>
        /// Create an awaiter object, wich knows how to wait until the moroutine is complete.
        /// </summary>
        /// <returns>Awaiter object.</returns>
        public YieldAwaiter WaitForComplete() => new CompleteAwaiter(this);

        /// <summary>
        /// Create an awaiter object, wich knows how to wait until the moroutine is stopped.
        /// </summary>
        /// <returns><inheritdoc cref="WaitForComplete()"/></returns>
        public YieldAwaiter WaitForStop() => new StopAwaiter(this);

        /// <summary>
        /// Create an awaiter object, wich knows how to wait until the moroutine is running.
        /// </summary>
        /// <returns><inheritdoc cref="WaitForComplete()"/></returns>
        public YieldAwaiter WaitForRun() => new RunAwaiter(this);

        /// <summary>
        /// Create an awaiter object, wich knows how to wait until the moroutine is reseted.
        /// </summary>
        /// <returns><inheritdoc cref="WaitForComplete()"/></returns>
        public YieldAwaiter WaitForReset() => new ResetAwaiter(this);
        #endregion
    }
}