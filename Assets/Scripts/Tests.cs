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
using UnityEditor;
using System.Reflection;


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

        public void ResetAllTargets()
        {
            foreach (var target in _targets)
                target.SetPositionX(0f);
        }

        #region Tween reset

        public void Tween0ResetRewind()
        {
            var tween = new Tween<float, FloatTweak>(0f, 1f, x => PrintWithLog(0, x), 0f, null, 2);
            SubscribeOnAllEvents(tween);

            tween.RewindToEnd(0, 1);
        }

        public void Tween0ResetPlay()
        {
            var tween = new Tween<float, FloatTweak>(0f, 1f, x => PrintWithLog(0, x), 0f, null, 2);
            SubscribeOnAllEvents(tween);

            tween.Play();
        }

        public void Tween1ResetRewind()
        {
            var tween = new Tween<float, FloatTweak>(0f, 1f, x => PrintWithLog(0, x), 1f, null, 2);
            SubscribeOnAllEvents(tween);

            tween.RewindToEnd(0, 1);
        }

        public void Tween1ResetPlay()
        {
            var tween = new Tween<float, FloatTweak>(0f, 1f, x => PrintWithLog(0, x), 1f, null, 2);
            SubscribeOnAllEvents(tween);

            tween.Play();
        }
        #endregion

        #region Tween continue
        public void Tween0ContinueRewind()
        {
            var tween = new Tween<float, FloatTweak>(0f, 1f, x => PrintWithLog(0, x), 0f, null, 2, LoopType.Continue);
            SubscribeOnAllEvents(tween);

            tween.RewindToEnd(0, 1);
        }

        public void Tween0ContinuePlay()
        {
            var tween = new Tween<float, FloatTweak>(0f, 1f, x => PrintWithLog(0, x), 0f, null, 2, LoopType.Continue);
            SubscribeOnAllEvents(tween);

            tween.Play();
        }

        public void Tween1ContinueRewind()
        {
            var tween = new Tween<float, FloatTweak>(0f, 1f, x => PrintWithLog(0, x), 1f, null, 2, LoopType.Continue);
            SubscribeOnAllEvents(tween);

            tween.RewindToEnd(0, 1);
        }

        public void Tween1ContinuePlay()
        {
            var tween = new Tween<float, FloatTweak>(0f, 1f, x => PrintWithLog(0, x), 1f, null, 2, LoopType.Continue);
            SubscribeOnAllEvents(tween);

            tween.Play();
        }
        #endregion

        #region Tween mirror
        public void Tween0MirrorRewind()
        {
            var tween = new Tween<float, FloatTweak>(0f, 1f, x => PrintWithLog(0, x), 0f, null, 2, LoopType.Mirror);
            SubscribeOnAllEvents(tween);

            tween.RewindToEnd(0, 1);
        }

        public void Tween0MirrorPlay()
        {
            var tween = new Tween<float, FloatTweak>(0f, 1f, x => PrintWithLog(0, x), 0f, null, 2, LoopType.Mirror);
            SubscribeOnAllEvents(tween);

            tween.Play();
        }

        public void Tween1MirrorRewind()
        {
            var tween = new Tween<float, FloatTweak>(0f, 1f, x => PrintWithLog(0, x), 1f, null, 2, LoopType.Mirror);
            SubscribeOnAllEvents(tween);

            tween.RewindToEnd(0, 1);
        }

        public void Tween1MirrorPlay()
        {
            var tween = new Tween<float, FloatTweak>(0f, 1f, x => PrintWithLog(0, x), 1f, null, 2, LoopType.Mirror);
            SubscribeOnAllEvents(tween);

            tween.Play();
        }
        #endregion
    }
}