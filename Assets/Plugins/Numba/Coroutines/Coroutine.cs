using Coroutines.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using NativeCoroutine = UnityEngine.Coroutine;

namespace Coroutines
{
    public sealed class Coroutine
    {
        #region Awaiter classes
        public abstract class CoroutineAwaiter : YieldAwaiter
        {
            protected Coroutine _coroutine;

            public CoroutineAwaiter(Coroutine coroutine) => _coroutine = coroutine;
        }

        public class CompleteAwaiter : CoroutineAwaiter
        {
            private IEnumerator _enumerator;

            public CompleteAwaiter(Coroutine coroutine) : base(coroutine) => _enumerator = coroutine._enumerator;

            public override bool KeepWaiting => _enumerator == _coroutine._enumerator && !_coroutine.IsCompleted;
        }

        public class StopAwaiter : CoroutineAwaiter
        {
            private NativeCoroutine _nativeCoroutine;

            public StopAwaiter(Coroutine coroutine) : base(coroutine) => _nativeCoroutine = coroutine._nativeCoroutine;

            public override bool KeepWaiting => _nativeCoroutine == _coroutine._nativeCoroutine && _coroutine.IsRunning;
        }

        public class RunAwaiter : CoroutineAwaiter
        {
            private NativeCoroutine _nativeCoroutine;

            public RunAwaiter(Coroutine coroutine) : base(coroutine) => _nativeCoroutine = coroutine._nativeCoroutine;

            public override bool KeepWaiting => _nativeCoroutine == _coroutine._nativeCoroutine && !_coroutine.IsRunning;
        }

        public class ResetAwaiter : CoroutineAwaiter
        {
            private IEnumerator _enumerator;

            public ResetAwaiter(Coroutine coroutine) : base(coroutine) => _enumerator = coroutine._enumerator;

            public override bool KeepWaiting => _enumerator == _coroutine._enumerator;
        }
        #endregion

        public enum State
        {
            Reseted,
            Running,
            Stoped,
            Completed
        }

        #region Owner and routines
        private GameObject _owner;

        public GameObject Owner => _owner;

        private IEnumerable _enumerable;

        private IEnumerator _enumerator;

        private NativeCoroutine _nativeCoroutine;
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
                    State.Stoped => Stoped,
                    State.Completed => Completed,
                    _ => throw new PlayControlException("Wrong coroutine state.")
                };

                stateEvent?.Invoke(this);
            }
        }

        public bool IsReseted => CurrentState == State.Reseted;

        public bool IsRunning => CurrentState == State.Running;

        public bool IsStoped => CurrentState == State.Stoped;

        public bool IsCompleted => CurrentState == State.Completed;

        private bool _locked;
        #endregion

        #region Events
        public event Action<Coroutine> Reseted;

        public event Action<Coroutine> Running;

        public event Action<Coroutine> Stoped;

        public event Action<Coroutine> Completed;
        #endregion

        private Coroutine(GameObject owner, IEnumerable enumerable)
        {
            _owner = owner != null ? owner : CoroutinesOwner.Instance.gameObject;
            _enumerable = enumerable ?? throw new ArgumentNullException(nameof(enumerable));
            _enumerator = _enumerable.GetEnumerator();

            if (!_owner.TryGetComponent(out DeactivationObserver observer))
                observer = _owner.gameObject.AddComponent<DeactivationObserver>();

            observer.Deactivated += DeactivationObserver_Deactivated;
        }

        #region Creation
        public static Coroutine Create(IEnumerator enumerator) => Create(new EnumerableEnumerator(enumerator));

        public static Coroutine Create(IEnumerable enumerable) => Create((GameObject)null, enumerable);

        public static Coroutine Create(GameObject owner, IEnumerator enumerator) => Create(owner, new EnumerableEnumerator(enumerator));

        public static Coroutine Create(GameObject owner, IEnumerable enumerable) => new Coroutine(owner, enumerable);

        public static Coroutine Run(IEnumerator enumerator) => Run(new EnumerableEnumerator(enumerator));

        public static Coroutine Run(IEnumerable enumerable) => Run((GameObject)null, enumerable);

        public static Coroutine Run(GameObject owner, IEnumerator enumerator) => Run(owner, new EnumerableEnumerator(enumerator));

        public static Coroutine Run(GameObject owner, IEnumerable enumerable) => Create(owner, enumerable).Run();
        #endregion

        #region Control
        public Coroutine Run(bool rerunIfCompleted = true)
        {
            if (IsRunning)
                throw new PlayControlException("Coroutine already running.");

            if (IsCompleted)
            {
                if (!rerunIfCompleted)
                    throw new PlayControlException("Coroutine was completed. If you want to restart it, call \"Reset\" method before.");

                Reset();
            }

            if (_owner == null)
                throw new PlayControlException($"The coroutine's owner object was destroyed, but you try to run coroutine.");

            if (!_owner.gameObject.activeInHierarchy)
                throw new PlayControlException($"Coroutine couldn't be started because the the game object '{_owner.name}' is deactivated.");

            CurrentState = State.Running;
            _nativeCoroutine = CoroutinesOwner.Instance.StartCoroutine(RunEnumerator());

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

        public Coroutine Stop()
        {
            if (_locked)
                throw new PlayControlException("Calling coroutine methods not allowed in coroutine enumerator.");

            if (!IsRunning)
                throw new PlayControlException("Coroutine not running and can not be stoped.");

            CoroutinesOwner.Instance.StopCoroutine(_nativeCoroutine);
            CurrentState = State.Stoped;

            return this;
        }

        public Coroutine Reset()
        {
            if (_locked)
                throw new PlayControlException("Calling coroutine methods not allowed in coroutine enumerator.");

            if (IsReseted)
                throw new PlayControlException("Coroutine already reseted.");

            if (_nativeCoroutine != null)
                CoroutinesOwner.Instance.StopCoroutine(_nativeCoroutine);

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
            if (CoroutinesOwner.Instance == null)
                return;
#endif
            #endregion

            if (IsReseted)
                return;

            Reset();
        }

        #region Subscribing
        private Coroutine OnSubscribe(Action<Coroutine> @event, Action<Coroutine> action)
        {
            @event += action;
            return this;
        }

        public Coroutine OnReseted(Action<Coroutine> action) => OnSubscribe(Reseted, action);

        public Coroutine OnRunning(Action<Coroutine> action) => OnSubscribe(Running, action);

        public Coroutine OnStoped(Action<Coroutine> action) => OnSubscribe(Stoped, action);

        public Coroutine OnCompleted(Action<Coroutine> action) => OnSubscribe(Completed, action);
        #endregion

        #region Yielders
        public YieldAwaiter WaitForComplete() => new CompleteAwaiter(this);

        public YieldAwaiter WaitForStop() => new StopAwaiter(this);

        public YieldAwaiter WaitForRun() => new RunAwaiter(this);

        public YieldAwaiter WaitForReset() => new ResetAwaiter(this);
        #endregion
    }
}