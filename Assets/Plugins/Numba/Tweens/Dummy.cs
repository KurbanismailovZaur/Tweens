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

        protected override void RewindHandler(int loop, float loopedTime, Direction direction, bool emitEvents, int parentLoop, int continueMaxLoopsCount) { }

        protected override void RewindZeroHandler(int loop, float loopedNormalizedTime, Direction direction, bool emitEvents, int parentLoop, int continueMaxLoopsCount) { }
    }
}