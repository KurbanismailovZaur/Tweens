using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace Redcode.Moroutines
{
    /// <summary>
    /// Moroutines owner. Automatically added to game objects that are owners.<br/>
    /// Partially controls the behavior of moroutines, such as stopping all associated moroutines if the game object is disabled.
    /// </summary>
    public sealed class Owner : MonoBehaviour
    {
        private List<Moroutine> _moroutines = new List<Moroutine>();

        /// <summary>
        /// All owned moroutines. Not contains destroyed moroutines.
        /// </summary>
        public ReadOnlyCollection<Moroutine> Moroutines => _moroutines.AsReadOnly();

        private void OnDisable()
        {
            foreach (var moroutine in _moroutines)
                moroutine.OnOwnerDeactivated();
        }

        internal void Add(Moroutine moroutine) => _moroutines.Add(moroutine);

        internal void Remove(Moroutine moroutine) => _moroutines.Remove(moroutine);

        internal void TryDestroy()
        {
            if (_moroutines.Count == 0)
                Destroy(this);
        }
    }
}