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
            var tween1 = new Tween<float, FloatTweak>("tween1", 0f, 1f, _target1.SetPositionX, 1f, Formula.Linear, 1, LoopType.Reset, Direction.Forward);
            //var tween2 = new Tween<float, FloatTweak>("tween2", 0f, 1f, x => {}, 0f, Formula.Linear, 1, LoopType.Reset, Direction.Forward);
            //var tween3 = new Tween<float, FloatTweak>("tween3", 0f, 1f, x => {}, 3f, Formula.Linear, 1, LoopType.Reset, Direction.Forward);
            //var tween4 = new Tween<float, FloatTweak>("tween4", 0f, 1f, x => {}, 0f, Formula.Linear, 1, LoopType.Reset, Direction.Forward);
            //var tween5 = new Tween<float, FloatTweak>("tween5", 0f, 1f, x => {}, 0f, Formula.Linear, 1, LoopType.Reset, Direction.Forward);
            //var tween6 = new Tween<float, FloatTweak>("tween6", 0f, 1f, x => {}, 0f, Formula.Linear, 1, LoopType.Reset, Direction.Forward);
            //var tween7 = new Tween<float, FloatTweak>("tween7", 0f, 1f, x => {}, 0f, Formula.Linear, 1, LoopType.Reset, Direction.Forward);
            //var tween8 = new Tween<float, FloatTweak>("tween8", 0f, 1f, x => {}, 0f, Formula.Linear, 1, LoopType.Reset, Direction.Forward);

            var seq = new Sequence("seq", Formula.Linear, 2, LoopType.Reset, Direction.Forward, LoopResetBehaviour.Rewind);
            seq.Insert(0f, tween0);
            seq.Insert(1f, tween1);
            //seq.Insert(0.5f, tween2);
            //seq.Insert(3.5f, tween3);
            //seq.Insert(3.5f, tween4);
            //seq.Insert(5f, tween5);
            //seq.Insert(6.5f, tween6);
            //seq.Insert(7f, tween7);
            //seq.Insert(6.5f, tween8);

            seq.GenerateChronolines();
            seq.Play();
        }
    }
}