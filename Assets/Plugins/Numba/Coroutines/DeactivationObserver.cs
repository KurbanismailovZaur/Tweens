using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Coroutines
{
    internal sealed class DeactivationObserver : MonoBehaviour
    {
        internal event Action Deactivated;

        private void OnDisable() => Deactivated?.Invoke();
    }
}