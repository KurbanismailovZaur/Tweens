using System.Collections;
using UnityEngine;

namespace Coroutines
{
    public abstract class YieldAwaiter : YieldInstruction, IEnumerator
    {
        object IEnumerator.Current => null;

        bool IEnumerator.MoveNext() => KeepWaiting;

        void IEnumerator.Reset() { }

        public abstract bool KeepWaiting { get; }
    }
}