using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Redcode.Moroutines.Extensions
{
    public static class GameObjectExtensions
    {
        /// <summary>
        /// Gets all moroutines which associated with the game object.<br/>
        /// Destroyed moroutines are not taken into account.
        /// </summary>
        /// <param name="gameObject">The game object.</param>
        /// <returns>Associated moroutines.</returns>
        public static List<Moroutine> GetMoroutines(this GameObject gameObject) => GetMoroutines(gameObject, Moroutine.State.Reseted | Moroutine.State.Running | Moroutine.State.Stopped | Moroutine.State.Completed);

        /// <summary>
        /// Gets all moroutines by <paramref name="mask"/> which associated with the game object.<br/>
        /// Destroyed moroutines are not taken into account.
        /// </summary>
        /// <param name="gameObject">The game object.</param>
        /// <param name="mask">State mask.</param>
        /// <returns>Associated moroutines.</returns>
        public static List<Moroutine> GetMoroutines(this GameObject gameObject, Moroutine.State mask)
        {
            var owner = gameObject.GetComponent<Owner>();
            if (owner == null)
                return new List<Moroutine>();

            return new List<Moroutine>(owner.Moroutines.Where(m => (m.CurrentState & mask) != 0));
        }
    }
}