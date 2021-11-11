using System;
using UnityEngine;

namespace Moroutines
{
    internal sealed class DeactivationObserver : MonoBehaviour
    {
        internal event Action Deactivated;

        private void OnDisable() => Deactivated?.Invoke();
    }
}