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
using Tweens.Tweaks;
using Tweens;

namespace Tweens.Scenes.Tests.Sequences.RewindToStartBackward4Elements
{
    public class Test : MonoBehaviour
    {
        [SerializeField]
        private Transform _target0;

        [SerializeField]
        private Transform _target1;

        [SerializeField]
        private Transform _target2;

        [SerializeField]
        private Transform _target3;

        private void SubscribeOnAllEvents(IPlayable<Playable> playable)
        {
            playable.OnPhaseStarting((p, dir) => print($"[{p.Name}] Phase starting in {dir} direction"));
            playable.OnPhaseStarted((p, dir) => print($"[{p.Name}] Phase started in {dir} direction"));
            playable.OnPhaseLoopStarting((p, li, dir) => print($"[{p.Name}] Phase loop {li} starting in {dir} direction"));
            playable.OnPhaseLoopStarted((p, li, dir) => print($"[{p.Name}] Phase loop {li} started in {dir} direction"));
            playable.OnPhaseUpdating((p, t, dir) => print($"[{p.Name}] Phase updating {t} time in {dir} direction"));
            playable.OnPhaseUpdated((p, t, dir) => print($"[{p.Name}] Phase updated {t} time in {dir} direction"));
            playable.OnPhaseLoopUpdating((p, li, lt, dir) => print($"[{p.Name}] Phase loop {li} updating {lt} time in {dir} direction"));
            playable.OnPhaseLoopUpdated((p, li, lt, dir) => print($"[{p.Name}] Phase loop {li} updated {lt} time in {dir} direction"));
            playable.OnPhaseLoopCompleting((p, li, dir) => print($"[{p.Name}] Phase loop {li} completing in {dir} direction"));
            playable.OnPhaseLoopCompleted((p, li, dir) => print($"[{p.Name}] Phase loop {li} completed in {dir} direction"));
            playable.OnPhaseCompleting((p, dir) => print($"[{p.Name}] Phase completing in {dir} direction"));
            playable.OnPhaseCompleted((p, dir) => print($"[{p.Name}] Phase completed in {dir} direction"));
        }

        IEnumerator Start()
        {
            yield return new WaitForSeconds(1f);

            var tween0 = new Tween<float, FloatTweak>("tween0", 0f, 1f, _target0.SetPositionX, 1f, Formula.Linear, 1, LoopType.Reset);
            SubscribeOnAllEvents(tween0);

            var tween1 = new Tween<float, FloatTweak>("tween1", 0f, 1f, _target1.SetPositionX, 0f, Formula.Linear, 1, LoopType.Reset);
            SubscribeOnAllEvents(tween1);

            var tween2 = new Tween<float, FloatTweak>("tween2", 0f, 1f, _target2.SetPositionX, 0f, Formula.Linear, 1, LoopType.Reset);
            SubscribeOnAllEvents(tween2);

            var tween3 = new Tween<float, FloatTweak>("tween3", 0f, 1f, _target3.SetPositionX, 0f, Formula.Linear, 1, LoopType.Reset);
            SubscribeOnAllEvents(tween3);

            var seq = new Sequence("seq", Formula.Linear, 1, LoopType.Reset, Direction.Backward, LoopResetBehaviour.Rewind);
            SubscribeOnAllEvents(seq);

            seq.Insert(0f, tween0);
            seq.Insert(0f, tween1);
            seq.Insert(0.5f, tween2);
            seq.Insert(1f, tween3);

            seq.SkipToEnd().RewindToStart(0);
        }
    }
}