using System;
using UnityEngine;

namespace Redcode.Moroutines
{
    internal sealed class DeactivationObserver : MonoBehaviour
    {
        internal event Action Deactivated;

        private void OnDisable() => Deactivated?.Invoke();
    }
}