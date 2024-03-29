using Redcode.Extensions;
using Redcode.Tweens.Tweaks;
using UnityEngine;

namespace Redcode.Tweens
{
    public class ALLTests : MonoBehaviour
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

        private void SetWithLog(int index, float value)
        {
            _targets[index].SetPositionX(value);
            print($"<color=yellow>Value: {value}</color>");
        }

        public void ResetAllTargets()
        {
            foreach (var target in _targets)
                target.SetPositionX(0f);
        }

        #region Tween
        #region Forward
        #region Reset
        public void Tween0ResetRewind()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 0f, null, 2);
            SubscribeOnAllEvents(tween);

            tween.RewindToEnd(true);
        }

        public void Tween0ResetPlay()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 0f, null, 2);
            SubscribeOnAllEvents(tween);

            tween.Play();
        }

        public void Tween1ResetRewind()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 1f, null, 2);
            SubscribeOnAllEvents(tween);

            tween.RewindToEnd(true);
        }

        public void Tween1ResetPlay()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 1f, Ease.InBounce, 2);
            SubscribeOnAllEvents(tween);

            tween.Play();
        }
        #endregion

        #region Continue
        public void Tween0ContinueRewind()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 0f, null, 2, LoopType.Continue);
            SubscribeOnAllEvents(tween);

            tween.RewindToEnd(true);
        }

        public void Tween0ContinuePlay()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 0f, null, 2, LoopType.Continue);
            SubscribeOnAllEvents(tween);

            tween.Play();
        }

        public void Tween1ContinueRewind()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 1f, null, 2, LoopType.Continue);
            SubscribeOnAllEvents(tween);

            tween.RewindToEnd(true);
        }

        public void Tween1ContinuePlay()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 1f, null, 2, LoopType.Continue);
            SubscribeOnAllEvents(tween);

            tween.Play();
        }
        #endregion

        #region Mirror
        public void Tween0MirrorRewind()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 0f, null, 2, LoopType.Mirror);
            SubscribeOnAllEvents(tween);

            tween.RewindToEnd(true);
        }

        public void Tween0MirrorPlay()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 0f, null, 2, LoopType.Mirror);
            SubscribeOnAllEvents(tween);

            tween.Play();
        }

        public void Tween1MirrorRewind()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 1f, null, 2, LoopType.Mirror);
            SubscribeOnAllEvents(tween);

            tween.RewindToEnd(true);
        }

        public void Tween1MirrorPlay()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 1f, Ease.InBounce, 2, LoopType.Mirror);
            SubscribeOnAllEvents(tween);

            tween.Play();
        }
        #endregion
        #endregion

        #region Backward
        #region Reset
        public void Tween0ResetRewindBackward()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 0f, null, 2, LoopType.Reset, Direction.Backward);
            SubscribeOnAllEvents(tween);

            tween.RewindToStart(true);
        }

        public void Tween0ResetPlayBackward()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 0f, null, 2, LoopType.Reset, Direction.Backward);
            SubscribeOnAllEvents(tween);

            tween.Play();
        }

        public void Tween1ResetRewindBackward()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 1f, null, 2, LoopType.Reset, Direction.Backward);
            SubscribeOnAllEvents(tween);

            tween.SkipToEnd().RewindToStart(true);
        }

        public void Tween1ResetPlayBackward()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 1f, Ease.InBounce, 2, LoopType.Reset, Direction.Backward);
            SubscribeOnAllEvents(tween);

            tween.SkipToEnd().Play();
        }
        #endregion

        #region Continue
        public void Tween0ContinueRewindBackward()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 0f, null, 2, LoopType.Continue, Direction.Backward);
            SubscribeOnAllEvents(tween);

            tween.RewindToStart(true);
        }

        public void Tween0ContinuePlayBackward()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 0f, null, 2, LoopType.Continue, Direction.Backward);
            SubscribeOnAllEvents(tween);

            tween.Play();
        }

        public void Tween1ContinueRewindBackward()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 1f, null, 2, LoopType.Continue, Direction.Backward);
            SubscribeOnAllEvents(tween);

            tween.SkipToEnd().RewindToStart(true);
        }

        public void Tween1ContinuePlayBackward()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 1f, null, 2, LoopType.Continue, Direction.Backward);
            SubscribeOnAllEvents(tween);

            tween.SkipToEnd().Play();
        }
        #endregion

        #region Mirror
        public void Tween0MirrorRewindBackward()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 0f, null, 2, LoopType.Mirror, Direction.Backward);
            SubscribeOnAllEvents(tween);

            tween.RewindToStart(true);
        }

        public void Tween0MirrorPlayBackward()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 0f, null, 2, LoopType.Mirror, Direction.Backward);
            SubscribeOnAllEvents(tween);

            tween.Play();
        }

        public void Tween1MirrorRewindBackward()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 1f, null, 2, LoopType.Mirror, Direction.Backward);
            SubscribeOnAllEvents(tween);

            tween.SkipToEnd().RewindToStart(true);
        }

        public void Tween1MirrorPlayBackward()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 1f, Ease.InBounce, 2, LoopType.Mirror, Direction.Backward);
            SubscribeOnAllEvents(tween);

            tween.SkipToEnd().Play();
        }
        #endregion
        #endregion
        #endregion

        #region Sequence > Empty
        #region Forward
        public void SequenceEmptyRewind()
        {
            var sequence = new Sequence();
            SubscribeOnAllEvents(sequence);

            sequence.RewindToEnd(true);
        }

        public void SequenceEmptyPlay()
        {
            var sequence = new Sequence();
            SubscribeOnAllEvents(sequence);

            sequence.Play();
        }
        #endregion

        #region Backward
        public void SequenceEmptyRewindBackward()
        {
            var sequence = new Sequence();
            SubscribeOnAllEvents(sequence);

            sequence.RewindToStart(true);
        }

        public void SequenceEmptyPlayBackward()
        {
            var sequence = new Sequence();
            SubscribeOnAllEvents(sequence);

            sequence.PlayBackward();
        }
        #endregion
        #endregion

        #region Sequence > Tween
        #region Forward
        #region Reset
        public void SequenceResetRewindTween0Reset()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 0f, null, 2).SetName("tween");

            var sequence = new Sequence("sequence", null, 2);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.RewindToEnd(true);
        }

        public void SequenceResetPlayTween0Reset()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 0f, null, 2).SetName("tween");

            var sequence = new Sequence("sequence", null, 2);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.Play();
        }

        public void SequenceResetRewindTween1Reset()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 1f, null, 2).SetName("tween");

            var sequence = new Sequence("sequence", null, 2);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.RewindToEnd(true);
        }

        public void SequenceResetPlayTween1Reset()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 1f, Ease.InBounce, 2).SetName("tween");

            var sequence = new Sequence("sequence", null, 2);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.Play();
        }

        public void SequenceResetRewindTween0Continue()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 0f, null, 2, LoopType.Continue).SetName("tween"); ;

            var sequence = new Sequence("sequence", null, 2);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.RewindToEnd(true);
        }

        public void SequenceResetPlayTween0Continue()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 0f, null, 2, LoopType.Continue);

            var sequence = new Sequence("sequence", null, 2);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.Play();
        }

        public void SequenceResetRewindTween1Continue()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 1f, null, 2, LoopType.Continue);

            var sequence = new Sequence("sequence", null, 2);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.RewindToEnd(true);
        }

        public void SequenceResetPlayTween1Continue()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 1f, null, 2, LoopType.Continue);

            var sequence = new Sequence("sequence", null, 2);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.Play();
        }

        public void SequenceResetRewindTween0Mirror()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 0f, null, 2, LoopType.Mirror);

            var sequence = new Sequence("sequence", null, 2);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.RewindToEnd(true);
        }

        public void SequenceResetPlayTween0Mirror()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 0f, null, 2, LoopType.Mirror);

            var sequence = new Sequence("sequence", null, 2);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.Play();
        }

        public void SequenceResetRewindTween1Mirror()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 1f, null, 2, LoopType.Mirror);

            var sequence = new Sequence("sequence", null, 2);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.RewindToEnd(true);
        }

        public void SequenceResetPlayTween1Mirror()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 1f, null, 2, LoopType.Mirror);

            var sequence = new Sequence("sequence", null, 2);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.Play();
        }
        #endregion

        #region Continue
        public void SequenceContinueRewindTween0Reset()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 0f, null, 2);

            var sequence = new Sequence("sequence", null, 2, LoopType.Continue);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.RewindToEnd(true);
        }

        public void SequenceContinuePlayTween0Reset()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 0f, null, 2);

            var sequence = new Sequence("sequence", null, 2, LoopType.Continue);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.Play();
        }

        public void SequenceContinueRewindTween1Reset()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 1f, null, 2);

            var sequence = new Sequence("sequence", null, 2, LoopType.Continue);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.RewindToEnd(true);
        }

        public void SequenceContinuePlayTween1Reset()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 1f, null, 2);

            var sequence = new Sequence("sequence", null, 2, LoopType.Continue);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.Play();
        }

        public void SequenceContinueRewindTween0Continue()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 0f, null, 2, LoopType.Continue);

            var sequence = new Sequence("sequence", null, 2, LoopType.Continue);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.RewindToEnd(true);
        }

        public void SequenceContinuePlayTween0Continue()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 0f, null, 2, LoopType.Continue);

            var sequence = new Sequence("sequence", null, 2, LoopType.Continue);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.Play();
        }

        public void SequenceContinueRewindTween1Continue()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 1f, null, 2, LoopType.Continue);

            var sequence = new Sequence("sequence", null, 2, LoopType.Continue);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.RewindToEnd(true);
        }

        public void SequenceContinuePlayTween1Continue()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 1f, null, 2, LoopType.Continue);

            var sequence = new Sequence("sequence", null, 2, LoopType.Continue);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.Play();
        }

        public void SequenceContinueRewindTween0Mirror()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 0f, null, 2, LoopType.Mirror);

            var sequence = new Sequence("sequence", null, 2, LoopType.Continue);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.RewindToEnd(true);
        }

        public void SequenceContinuePlayTween0Mirror()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 0f, null, 2, LoopType.Mirror);

            var sequence = new Sequence("sequence", null, 2, LoopType.Continue);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.Play();
        }

        public void SequenceContinueRewindTween1Mirror()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 1f, null, 2, LoopType.Mirror);

            var sequence = new Sequence("sequence", null, 2, LoopType.Continue);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.RewindToEnd(true);
        }

        public void SequenceContinuePlayTween1Mirror()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 1f, null, 2, LoopType.Mirror);

            var sequence = new Sequence("sequence", null, 2, LoopType.Continue);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.Play();
        }
        #endregion

        #region Mirror
        public void SequenceMirrorRewindTween0Reset()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 0f, null, 2);

            var sequence = new Sequence("sequence", null, 2, LoopType.Mirror);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.RewindToEnd(true);
        }

        public void SequenceMirrorPlayTween0Reset()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 0f, null, 2);

            var sequence = new Sequence("sequence", null, 2, LoopType.Mirror);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.Play();
        }

        public void SequenceMirrorRewindTween1Reset()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 1f, null, 2);

            var sequence = new Sequence("sequence", null, 2, LoopType.Mirror);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.RewindToEnd(true);
        }

        public void SequenceMirrorPlayTween1Reset()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 1f, Ease.InBounce, 2);

            var sequence = new Sequence("sequence", null, 2, LoopType.Mirror);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.Play();
        }

        public void SequenceMirrorRewindTween0Continue()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 0f, null, 2, LoopType.Continue);

            var sequence = new Sequence("sequence", null, 2, LoopType.Mirror);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.RewindToEnd(true);
        }

        public void SequenceMirrorPlayTween0Continue()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 0f, null, 2, LoopType.Continue);

            var sequence = new Sequence("sequence", null, 2, LoopType.Mirror);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.Play();
        }

        public void SequenceMirrorRewindTween1Continue()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 1f, null, 2, LoopType.Continue);

            var sequence = new Sequence("sequence", null, 2, LoopType.Mirror);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.RewindToEnd(true);
        }

        public void SequenceMirrorPlayTween1Continue()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 1f, Ease.InBounce, 2, LoopType.Continue);

            var sequence = new Sequence("sequence", null, 2, LoopType.Mirror);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.Play();
        }

        public void SequenceMirrorRewindTween0Mirror()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 0f, null, 2, LoopType.Mirror);

            var sequence = new Sequence("sequence", null, 2, LoopType.Mirror);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.RewindToEnd(true);
        }

        public void SequenceMirrorPlayTween0Mirror()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 0f, null, 2, LoopType.Mirror);

            var sequence = new Sequence("sequence", null, 2, LoopType.Mirror);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.Play();
        }

        public void SequenceMirrorRewindTween1Mirror()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 1f, null, 2, LoopType.Mirror);

            var sequence = new Sequence("sequence", null, 2, LoopType.Mirror);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.RewindToEnd(true);
        }

        public void SequenceMirrorPlayTween1Mirror()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 1f, Ease.InBounce, 2, LoopType.Mirror);

            var sequence = new Sequence("sequence", null, 2, LoopType.Mirror);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.Play();
        }
        #endregion
        #endregion

        #region Backward
        #region Reset
        public void SequenceResetRewindTween0ResetBackward()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 0f, null, 2);

            var sequence = new Sequence("sequence", null, 2);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.SkipToEnd().RewindToStart(true);
        }

        public void SequenceResetPlayTween0ResetBackward()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 0f, null, 2);

            var sequence = new Sequence("sequence", null, 2);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.SkipToEnd().PlayBackward();
        }

        public void SequenceResetRewindTween1ResetBackward()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 1f, null, 2);

            var sequence = new Sequence("sequence", null, 2);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.SkipToEnd().RewindToStart(true);
        }

        public void SequenceResetPlayTween1ResetBackward()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 1f, Ease.InBounce, 2);

            var sequence = new Sequence("sequence", null, 2);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.SkipToEnd().PlayBackward();
        }

        public void SequenceResetRewindTween0ContinueBackward()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 0f, null, 2, LoopType.Continue);

            var sequence = new Sequence("sequence", null, 2);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.SkipToEnd().RewindToStart(true);
        }

        public void SequenceResetPlayTween0ContinueBackward()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 0f, null, 2, LoopType.Continue);

            var sequence = new Sequence("sequence", null, 2);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.SkipToEnd().PlayBackward();
        }

        public void SequenceResetRewindTween1ContinueBackward()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 1f, null, 2, LoopType.Continue);

            var sequence = new Sequence("sequence", null, 2);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.SkipToEnd().RewindToStart(true);
        }

        public void SequenceResetPlayTween1ContinueBackward()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 1f, null, 2, LoopType.Continue);

            var sequence = new Sequence("sequence", null, 2);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.SkipToEnd().PlayBackward();
        }

        public void SequenceResetRewindTween0MirrorBackward()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 0f, null, 2, LoopType.Mirror);

            var sequence = new Sequence("sequence", null, 2);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.SkipToEnd().RewindToStart(true);
        }

        public void SequenceResetPlayTween0MirrorBackward()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 0f, null, 2, LoopType.Mirror);

            var sequence = new Sequence("sequence", null, 2);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.SkipToEnd().PlayBackward();
        }

        public void SequenceResetRewindTween1MirrorBackward()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 1f, null, 2, LoopType.Mirror);

            var sequence = new Sequence("sequence", null, 2);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.SkipToEnd().RewindToStart(true);
        }

        public void SequenceResetPlayTween1MirrorBackward()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 1f, null, 2, LoopType.Mirror);

            var sequence = new Sequence("sequence", null, 2);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.SkipToEnd().PlayBackward();
        }
        #endregion

        #region Continue
        public void SequenceContinueRewindTween0ResetBackward()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 0f, null, 2);

            var sequence = new Sequence("sequence", null, 2, LoopType.Continue);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.SkipToEnd().RewindToStart(true);
        }

        public void SequenceContinuePlayTween0ResetBackward()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 0f, null, 2);

            var sequence = new Sequence("sequence", null, 2, LoopType.Continue);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.SkipToEnd().PlayBackward();
        }

        public void SequenceContinueRewindTween1ResetBackward()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 1f, null, 2);

            var sequence = new Sequence("sequence", null, 2, LoopType.Continue);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.SkipToEnd().RewindToStart(true);
        }

        public void SequenceContinuePlayTween1ResetBackward()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 1f, null, 2);

            var sequence = new Sequence("sequence", null, 2, LoopType.Continue);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.SkipToEnd().PlayBackward();
        }

        public void SequenceContinueRewindTween0ContinueBackward()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 0f, null, 2, LoopType.Continue);

            var sequence = new Sequence("sequence", null, 2, LoopType.Continue);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.SkipToEnd().RewindToStart(true);
        }

        public void SequenceContinuePlayTween0ContinueBackward()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 0f, null, 2, LoopType.Continue);

            var sequence = new Sequence("sequence", null, 2, LoopType.Continue);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.SkipToEnd().PlayBackward();
        }

        public void SequenceContinueRewindTween1ContinueBackward()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 1f, null, 2, LoopType.Continue);

            var sequence = new Sequence("sequence", null, 2, LoopType.Continue);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.SkipToEnd().RewindToStart(true);
        }

        public void SequenceContinuePlayTween1ContinueBackward()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 1f, null, 2, LoopType.Continue);

            var sequence = new Sequence("sequence", null, 2, LoopType.Continue);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.SkipToEnd().PlayBackward();
        }

        public void SequenceContinueRewindTween0MirrorBackward()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 0f, null, 2, LoopType.Mirror);

            var sequence = new Sequence("sequence", null, 2, LoopType.Continue);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.SkipToEnd().RewindToStart(true);
        }

        public void SequenceContinuePlayTween0MirrorBackward()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 0f, null, 2, LoopType.Mirror);

            var sequence = new Sequence("sequence", null, 2, LoopType.Continue);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.SkipToEnd().PlayBackward();
        }

        public void SequenceContinueRewindTween1MirrorBackward()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 1f, null, 2, LoopType.Mirror);

            var sequence = new Sequence("sequence", null, 2, LoopType.Continue);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.SkipToEnd().RewindToStart(true);
        }

        public void SequenceContinuePlayTween1MirrorBackward()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 1f, null, 2, LoopType.Mirror);

            var sequence = new Sequence("sequence", null, 2, LoopType.Continue);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.SkipToEnd().PlayBackward();
        }
        #endregion

        #region Mirror
        public void SequenceMirrorRewindTween0ResetBackward()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 0f, null, 2);

            var sequence = new Sequence("sequence", null, 2, LoopType.Mirror);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.SkipToEnd().RewindToStart(true);
        }

        public void SequenceMirrorPlayTween0ResetBackward()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 0f, null, 2);

            var sequence = new Sequence("sequence", null, 2, LoopType.Mirror);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.SkipToEnd().PlayBackward();
        }

        public void SequenceMirrorRewindTween1ResetBackward()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 1f, null, 2);

            var sequence = new Sequence("sequence", null, 2, LoopType.Mirror);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.SkipToEnd().RewindToStart(true);
        }

        public void SequenceMirrorPlayTween1ResetBackward()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 1f, Ease.InBounce, 2);

            var sequence = new Sequence("sequence", null, 2, LoopType.Mirror);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.SkipToEnd().PlayBackward();
        }

        public void SequenceMirrorRewindTween0ContinueBackward()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 0f, null, 2, LoopType.Continue);

            var sequence = new Sequence("sequence", null, 2, LoopType.Mirror);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.SkipToEnd().RewindToStart(true);
        }

        public void SequenceMirrorPlayTween0ContinueBackward()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 0f, null, 2, LoopType.Continue);

            var sequence = new Sequence("sequence", null, 2, LoopType.Mirror);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.SkipToEnd().PlayBackward();
        }

        public void SequenceMirrorRewindTween1ContinueBackward()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 1f, null, 2, LoopType.Continue);

            var sequence = new Sequence("sequence", null, 2, LoopType.Mirror);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.SkipToEnd().RewindToStart(true);
        }

        public void SequenceMirrorPlayTween1ContinueBackward()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 1f, Ease.InBounce, 2, LoopType.Continue);

            var sequence = new Sequence("sequence", null, 2, LoopType.Mirror);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.SkipToEnd().PlayBackward();
        }

        public void SequenceMirrorRewindTween0MirrorBackward()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 0f, null, 2, LoopType.Mirror);

            var sequence = new Sequence("sequence", null, 2, LoopType.Mirror);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.SkipToEnd().RewindToStart(true);
        }

        public void SequenceMirrorPlayTween0MirrorBackward()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 0f, null, 2, LoopType.Mirror);

            var sequence = new Sequence("sequence", null, 2, LoopType.Mirror);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.SkipToEnd().PlayBackward();
        }

        public void SequenceMirrorRewindTween1MirrorBackward()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 1f, null, 2, LoopType.Mirror);

            var sequence = new Sequence("sequence", null, 2, LoopType.Mirror);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.SkipToEnd().RewindToStart(true);
        }

        public void SequenceMirrorPlayTween1MirrorBackward()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 1f, Ease.InBounce, 2, LoopType.Mirror);

            var sequence = new Sequence("sequence", null, 2, LoopType.Mirror);
            sequence.Append(tween);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(sequence);

            sequence.SkipToEnd().PlayBackward();
        }
        #endregion
        #endregion
        #endregion

        #region Sequence > Sequence > Tween
        public void SequenceResetRewindSequenceContinueTween0Mirror()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 0f, null, 2, LoopType.Mirror);

            var subsequence = new Sequence("sub-sequence", null, 2, LoopType.Continue);
            subsequence.Append(tween);

            var sequence = new Sequence("sequence", null, 2, LoopType.Reset);
            sequence.Append(subsequence);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(subsequence);
            SubscribeOnAllEvents(sequence);

            sequence.RewindToEnd(true);
        }

        public void SequenceResetPlaySequenceContinueTween0Mirror()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 0f, null, 2, LoopType.Mirror);

            var subsequence = new Sequence("sub-sequence", null, 2, LoopType.Continue);
            subsequence.Append(tween);

            var sequence = new Sequence("sequence", null, 2, LoopType.Reset);
            sequence.Append(subsequence);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(subsequence);
            SubscribeOnAllEvents(sequence);

            sequence.Play();
        }

        public void SequenceResetRewindSequenceContinueTween1Mirror()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 1f, null, 2, LoopType.Mirror);

            var subsequence = new Sequence("sub-sequence", null, 2, LoopType.Continue);
            subsequence.Append(tween);

            var sequence = new Sequence("sequence", null, 2, LoopType.Reset);
            sequence.Append(subsequence);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(subsequence);
            SubscribeOnAllEvents(sequence);

            sequence.RewindToEnd(true);
        }

        public void SequenceResetPlaySequenceContinueTween1Mirror()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 1f, null, 2, LoopType.Mirror);

            var subsequence = new Sequence("sub-sequence", null, 2, LoopType.Continue);
            subsequence.Append(tween);

            var sequence = new Sequence(gameObject, "sequence", null, 2, LoopType.Reset);
            sequence.Append(subsequence);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(subsequence);
            SubscribeOnAllEvents(sequence);

            sequence.Play();
        }

        public void SequenceContinueRewindSequenceMirrorTween0Reset()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 0f, null, 2, LoopType.Reset);

            var subsequence = new Sequence("sub-sequence", null, 2, LoopType.Mirror);
            subsequence.Append(tween);

            var sequence = new Sequence("sequence", null, 2, LoopType.Continue);
            sequence.Append(subsequence);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(subsequence);
            SubscribeOnAllEvents(sequence);

            sequence.RewindToEnd(true);
        }

        public void SequenceContinuePlaySequenceMirrorTween0Reset()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 0f, null, 2, LoopType.Reset);

            var subsequence = new Sequence("sub-sequence", null, 2, LoopType.Mirror);
            subsequence.Append(tween);

            var sequence = new Sequence("sequence", null, 2, LoopType.Continue);
            sequence.Append(subsequence);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(subsequence);
            SubscribeOnAllEvents(sequence);

            sequence.Play();
        }

        public void SequenceContinueRewindSequenceMirrorTween1Reset()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 1f, null, 2, LoopType.Reset);

            var subsequence = new Sequence("sub-sequence", null, 2, LoopType.Mirror);
            subsequence.Append(tween);

            var sequence = new Sequence("sequence", null, 2, LoopType.Continue);
            sequence.Append(subsequence);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(subsequence);
            SubscribeOnAllEvents(sequence);

            sequence.RewindToEnd(true);
        }

        public void SequenceContinuePlaySequenceMirrorTween1Reset()
        {
            var tween = new Tween<float, TweakFloat>(0f, 1f, x => SetWithLog(0, x), 1f, null, 1, LoopType.Reset);

            var subsequence = new Sequence("sub-sequence", null, 1, LoopType.Mirror);
            subsequence.Append(tween);

            var sequence = new Sequence("sequence", null, 2, LoopType.Continue);
            sequence.Append(subsequence);

            SubscribeOnAllEvents(tween);
            SubscribeOnAllEvents(subsequence);
            SubscribeOnAllEvents(sequence);

            sequence.Play();
        }
        #endregion
    }
}