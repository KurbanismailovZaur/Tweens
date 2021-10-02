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
    internal class Dummy : Playable<Dummy>
    {
        public Dummy(GameObject owner, float duration) : base(owner, null, duration, null, 1, LoopType.Reset, Direction.Forward) { }

        public override Type Type => Type.Dummy;

        protected override void Perform(int loop, float loopedTime, Direction direction) { }

        protected override void PerformCompletely(int loop, float loopedNormalizedTime, Direction direction) { }
    }
}