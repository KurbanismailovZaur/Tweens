using Moroutines.Exceptions;
using System;
using System.Collections;
using UnityEngine;

namespace Moroutines
{
    public sealed class Moroutine
    {
        #region Awaiter classes
        public abstract class MoroutineAwaiter : YieldAwaiter
        {
            protected Moroutine _moroutine;

            public MoroutineAwaiter(Moroutine coroutine) => _moroutine = coroutine;
        }

        public class CompleteAwaiter : MoroutineAwaiter
        {
            private IEnumerator _enumerator;

            public CompleteAwaiter(Moroutine moroutine) : base(moroutine) => _enumerator = moroutine._enumerator;

            public override bool KeepWaiting => _enumerator == _moroutine._enumerator && !_moroutine.IsCompleted;
        }

        public class StopAwaiter : MoroutineAwaiter
        {
            private Coroutine _coroutine;

            public StopAwaiter(Moroutine moroutine) : base(moroutine) => _coroutine = moroutine._coroutine;

            public override bool KeepWaiting => _coroutine == _moroutine._coroutine && _moroutine.IsRunning;
        }

        public class RunAwaiter : MoroutineAwaiter
        {
            private Coroutine _coroutine;

            public RunAwaiter(Moroutine moroutine) : base(moroutine) => _coroutine = moroutine._coroutine;

            public override bool KeepWaiting => _coroutine == _moroutine._coroutine && !_moroutine.IsRunning;
        }

        public class ResetAwaiter : MoroutineAwaiter
        {
            private IEnumerator _enumerator;

            public ResetAwaiter(Moroutine moroutine) : base(moroutine) => _enumerator = moroutine._enumerator;

            public override bool KeepWaiting => _enumerator == _moroutine._enumerator;
        }
        #endregion

        public enum State
        {
            Reseted,
            Running,
            Stopped,
            Completed
        }

        #region Owner and routines
        private GameObject _owner;

        public GameObject Owner => _owner;

        private IEnumerable _enumerable;

        private IEnumerator _enumerator;

        private Coroutine _coroutine;
        #endregion

        #region State
        private State _state;

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

        public bool IsReseted => CurrentState == State.Reseted;

        public bool IsRunning => CurrentState == State.Running;

        public bool IsStopped => CurrentState == State.Stopped;

        public bool IsCompleted => CurrentState == State.Completed;

        public object LastResult => _enumerator?.Current;

        private bool _locked;
        #endregion

        #region Events
        public event Action<Moroutine> Reseted;

        public event Action<Moroutine> Running;

        public event Action<Moroutine> Stopped;

        public event Action<Moroutine> Completed;
        #endregion

        private Moroutine(GameObject owner, IEnumerable enumerable)
        {
            _owner = owner != null ? owner : MoroutinesOwner.Instance.gameObject;
            _enumerable = enumerable ?? throw new ArgumentNullException(nameof(enumerable));
            _enumerator = _enumerable.GetEnumerator();

            if (!_owner.TryGetComponent(out DeactivationObserver observer))
                observer = _owner.gameObject.AddComponent<DeactivationObserver>();

            observer.Deactivated += DeactivationObserver_Deactivated;
        }

        #region Creation
        public static Moroutine Create(IEnumerator enumerator) => Create(new EnumerableEnumerator(enumerator));

        public static Moroutine Create(IEnumerable enumerable) => Create(null, enumerable);

        public static Moroutine Create(GameObject owner, IEnumerator enumerator) => Create(owner, new EnumerableEnumerator(enumerator));

        public static Moroutine Create(GameObject owner, IEnumerable enumerable) => new Moroutine(owner, enumerable);

        public static Moroutine Run(IEnumerator enumerator) => Run(new EnumerableEnumerator(enumerator));

        public static Moroutine Run(IEnumerable enumerable) => Run((GameObject)null, enumerable);

        public static Moroutine Run(GameObject owner, IEnumerator enumerator) => Run(owner, new EnumerableEnumerator(enumerator));

        public static Moroutine Run(GameObject owner, IEnumerable enumerable) => Create(owner, enumerable).Run();
        #endregion

        #region Control
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

        public Moroutine OnReseted(Action<Moroutine> action) => OnSubscribe(Reseted, action);

        public Moroutine OnRunning(Action<Moroutine> action) => OnSubscribe(Running, action);

        public Moroutine OnStopped(Action<Moroutine> action) => OnSubscribe(Stopped, action);

        public Moroutine OnCompleted(Action<Moroutine> action) => OnSubscribe(Completed, action);
        #endregion

        #region Yielders
        public YieldAwaiter WaitForComplete() => new CompleteAwaiter(this);

        public YieldAwaiter WaitForStop() => new StopAwaiter(this);

        public YieldAwaiter WaitForRun() => new RunAwaiter(this);

        public YieldAwaiter WaitForReset() => new ResetAwaiter(this);
        #endregion
    }
}