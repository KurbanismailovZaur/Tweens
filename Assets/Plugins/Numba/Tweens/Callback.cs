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
    internal class Callback : Playable<Callback>
    {
        public Callback(GameObject owner) : base(owner, null, 0f, null, 1, LoopType.Reset, Direction.Forward) { }

        public override Type Type => Type.Callback;

        protected override void RewindZeroHandler(int loop, float loopedNormalizedTime, Direction direction, int parentLoop, int continueMaxLoopsCount, bool redirectBeforeStart) { }

        protected override void RewindHandler(int loop, float loopedTime, Direction direction, int parentLoop, int continueMaxLoopsCount, bool redirectBeforeStart) { }
    }
}