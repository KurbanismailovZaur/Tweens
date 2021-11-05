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
    internal class Interval : Playable<Interval>
    {
        public override Type Type => Type.Interval;

        public Interval(string name, float duration) : base(null, name, duration) { }
    }
}