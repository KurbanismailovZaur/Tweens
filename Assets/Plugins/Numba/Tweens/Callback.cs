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
        public override Type Type => Type.Callback;

        private Action _callback;

        private bool _startPhaseFlag;

        public Callback(string name, Action callback) : base(null, name, 0f, Tweens.Formula.Linear, 1, LoopType.Reset, Direction.Forward)
        {
            _callback = callback ?? throw new ArgumentNullException(nameof(callback));
        }

        protected override void BeforeStarting(Direction direction, int loop, int parentContinueLoopIndex, int continueMaxLoopsCount) => _startPhaseFlag = true;

        protected override void RewindZeroHandler(int loop, float loopedNormalizedTime, Direction direction, bool emitEvents, int parentLoop, int continueMaxLoopsCount)
        {
            if (!_startPhaseFlag || !emitEvents)
                return;

            _callback();
            _startPhaseFlag = false;
        }
    }
}