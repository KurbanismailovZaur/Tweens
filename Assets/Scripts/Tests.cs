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

namespace Tweens
{
	public class Tests : MonoBehaviour
	{
		[SerializeField]
		private Transform[] _targets;

        private IPlayable<Playable> SubscribeOnAllEvents(IPlayable<Playable> playable)
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

            return playable;
        }

        private void PrintWithLog(int index, float value)
        {
            _targets[index].SetPositionX(value);
            print($"<color=yellow>{value}</color>");
        }

        public void Tween0Rewind()
        {
            var tween = new Tween<float, FloatTweak>(0f, 1f, x => PrintWithLog(0, x), 0f);
            SubscribeOnAllEvents(tween);

            tween.RewindToEnd(0, 1);
        }

        public void Tween1Rewind()
        {
            var tween = new Tween<float, FloatTweak>(0f, 1f, x => PrintWithLog(0, x), 1f);
            SubscribeOnAllEvents(tween);

            tween.RewindToEnd(0, 1);
        }
    }
}