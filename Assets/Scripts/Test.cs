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

namespace Tweens
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

        [SerializeField]
        private Transform _target4;

        [SerializeField]
        private Transform _target5;

        [SerializeField]
        private Transform _target6;

        [SerializeField]
        private Transform _target7;

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
            
            var tween0 = new Tween<float, FloatTweak>("tween0", 0f, 1f, _target0.SetPositionX, 1f, Formula.Linear, 1, LoopType.Reset, Direction.Forward);
            var tween1 = new Tween<float, FloatTweak>("tween0", 0f, 1f, _target1.SetPositionX, 1f, Formula.Linear, 1, LoopType.Reset, Direction.Forward);
            var tween2 = new Tween<float, FloatTweak>("tween0", 0f, 1f, _target2.SetPositionX, 1f, Formula.Linear, 1, LoopType.Reset, Direction.Forward);
            var tween3 = new Tween<float, FloatTweak>("tween0", 0f, 1f, _target3.SetPositionX, 0f, Formula.Linear, 3, LoopType.Reset, Direction.Forward);
            var tween4 = new Tween<float, FloatTweak>("tween0", 0f, 1f, _target4.SetPositionX, 0f, Formula.Linear, 4, LoopType.Reset, Direction.Forward);
            var tween5 = new Tween<float, FloatTweak>("tween0", 0f, 1f, _target5.SetPositionX, 0.5f, Formula.Linear, 2, LoopType.Reset, Direction.Forward);
            var tween6 = new Tween<float, FloatTweak>("tween0", 0f, 1f, _target6.SetPositionX, 0f, Formula.Linear, 1, LoopType.Reset, Direction.Forward);
            var tween7 = new Tween<float, FloatTweak>("tween0", 0f, 1f, _target7.SetPositionX, 0f, Formula.Linear, 2, LoopType.Reset, Direction.Forward);

            SubscribeOnAllEvents(tween0);
            SubscribeOnAllEvents(tween1);
            SubscribeOnAllEvents(tween2);
            SubscribeOnAllEvents(tween3);
            SubscribeOnAllEvents(tween4);
            SubscribeOnAllEvents(tween5);
            SubscribeOnAllEvents(tween6);
            SubscribeOnAllEvents(tween7);

            var seq = new Sequence("seq", Formula.Linear, 1, LoopType.Reset, Direction.Forward, LoopResetBehaviour.Rewind);
            SubscribeOnAllEvents(seq);

            seq.Insert(0f, tween0);
            seq.Insert(0.5f, tween1);
            seq.Insert(1f, tween2);
            seq.Insert(1f, tween3);
            seq.Insert(4, 1f, tween4);
            seq.Insert(0.5f, tween5);
            seq.Insert(1f, tween6);
            seq.Insert(1f, tween7);

            yield return seq.Play().WaitForComplete();

            seq.PlayBackward();
        }
    }
}