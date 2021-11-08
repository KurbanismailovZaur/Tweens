using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Extensions;
using Coroutines;
using Coroutines.Extensions;
using Object = UnityEngine.Object;
using Coroutine = Coroutines.Coroutine;

namespace Tweens
{
    /// <summary>
    /// Represents the empty interval that can be used in sequences.
    /// </summary>
    internal class Interval : Playable<Interval>
    {
        public override Type Type => Type.Interval;

        /// <summary>
        /// Create empty interval.
        /// </summary>
        /// <param name="name">Name of the interval.</param>
        /// <param name="duration">Duration of the interval.</param>
        public Interval(string name, float duration) : base(null, name, duration) { }
    }
}