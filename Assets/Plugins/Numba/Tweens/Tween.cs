using System;
using Tweens.Formulas;
using UnityEngine;

namespace Tweens
{
    public sealed class Tween<T, U> : Playable<Tween<T, U>> where T : struct where U : Tweak<T>, new()
    {
        public override Type Type => Type.Tween;

        public new float LoopDuration
        {
            get => base.LoopDuration;
            set => base.LoopDuration = value;
        }

        public U Tweak { get; set; }

        public Func<T> From { get; set; }

        public Func<T> To { get; set; }

        public Action<T> Action { private get; set; }

        #region Constructors
        public Tween(T from, T to, Action<T> action, float loopDuration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : this(new U(), from, to, action, loopDuration, formula, loopsCount, loopType, direction) { }

        public Tween(U tweak, T from, T to, Action<T> action, float loopDuration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : this((string)null, tweak, from, to, action, loopDuration, formula, loopsCount, loopType, direction) { }

        public Tween(string name, T from, T to, Action<T> action, float loopDuration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : this(name, new U(), from, to, action, loopDuration, formula, loopsCount, loopType, direction) { }

        public Tween(string name, U tweak, T from, T to, Action<T> action, float loopDuration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : this(null, name, tweak, from, to, action, loopDuration, formula, loopsCount, loopType, direction) { }

        public Tween(GameObject owner, T from, T to, Action<T> action, float loopDuration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : this(owner, new U(), from, to, action, loopDuration, formula, loopsCount, loopType, direction) { }

        public Tween(GameObject owner, U tweak, T from, T to, Action<T> action, float loopDuration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : this(owner, null, tweak, from, to, action, loopDuration, formula, loopsCount, loopType, direction) { }

        public Tween(GameObject owner, string name, T from, T to, Action<T> action, float loopDuration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : this(owner, name, new U(), from, to, action, loopDuration, formula, loopsCount, loopType, direction) { }

        public Tween(GameObject owner, string name, U tweak, T from, T to, Action<T> action, float loopDuration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : this(owner, name, tweak, () => from, () => to, action, loopDuration, formula, loopsCount, loopType, direction) { }

        public Tween(Func<T> from, Func<T> to, Action<T> action, float loopDuration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : this(new U(), from, to, action, loopDuration, formula, loopsCount, loopType, direction) { }

        public Tween(U tweak, Func<T> from, Func<T> to, Action<T> action, float loopDuration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : this((string)null, tweak, from, to, action, loopDuration, formula, loopsCount, loopType, direction) { }

        public Tween(string name, Func<T> from, Func<T> to, Action<T> action, float loopDuration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : this(name, new U(), from, to, action, loopDuration, formula, loopsCount, loopType, direction) { }

        public Tween(string name, U tweak, Func<T> from, Func<T> to, Action<T> action, float loopDuration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : this(null, name, tweak, from, to, action, loopDuration, formula, loopsCount, loopType, direction) { }

        public Tween(GameObject owner, Func<T> from, Func<T> to, Action<T> action, float loopDuration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : this(owner, new U(), from, to, action, loopDuration, formula, loopsCount, loopType, direction) { }

        public Tween(GameObject owner, U tweak, Func<T> from, Func<T> to, Action<T> action, float loopDuration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : this(owner, null, tweak, from, to, action, loopDuration, formula, loopsCount, loopType, direction) { }

        public Tween(GameObject owner, string name, Func<T> from, Func<T> to, Action<T> action, float loopDuration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : this(owner, name, new U(), from, to, action, loopDuration, formula, loopsCount, loopType, direction) { }

        public Tween(GameObject owner, string name, U tweak, Func<T> from, Func<T> to, Action<T> action, float loopDuration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : base(owner, name, loopDuration, formula, loopsCount, loopType, direction)
        {
            Tweak = tweak;
            From = from;
            To = to;
            Action = action;
        }
        #endregion

        protected override void RecalculateDuration()
        {
            base.RecalculateDuration();

            PlayedTime = Mathf.Clamp(PlayedTime, 0f, Duration);
            RecalculatePlayTimes();
        }

        private FormulaBase InvertIfRequiredAndGetFormula(Direction direction) => direction == Direction.Forward ? Formula : Tweens.Formula.Invertion.WithFormula(Formula);

        protected override void PerformCompletely(int loop, float loopedNormalizedTime, Direction direction)
        {
            if (LoopType == LoopType.Reset)
            {
                var (from, to) = direction == Direction.Forward ? (From(), To()) : (To(), From());
                Tweak.Apply(from, to, loopedNormalizedTime, Action, Formula);
            }
            else if (LoopType == LoopType.Continue)
            {
                var (from, to) = direction == Direction.Forward ? (From(), To()) : (Tweak.Evaluate(From(), To(), LoopsCount), Tweak.Evaluate(From(), To(), LoopsCount - 1));
                (from, to) = (Tweak.Evaluate(from, to, loop), Tweak.Evaluate(from, to, loop + 1f));

                Tweak.Apply(from, to, loopedNormalizedTime, Action, Formula);
            }
            else if (LoopType == LoopType.Mirror)
                Tweak.Apply(From(), To(), 0f, Action, Formula);
        }

        protected override void Perform(int loop, float loopedTime, Direction direction)
        {
            var loopedNormalizedTime = loopedTime / LoopDuration;

            if (LoopType == LoopType.Reset)
            {
                var (from, to) = direction == Direction.Forward ? (From(), To()) : (To(), From());
                Tweak.Apply(from, to, loopedNormalizedTime, Action, InvertIfRequiredAndGetFormula(direction));
            }
            else if (LoopType == LoopType.Continue)
            {
                var (from, to) = direction == Direction.Forward ? (From(), To()) : (Tweak.Evaluate(From(), To(), LoopsCount), Tweak.Evaluate(From(), To(), LoopsCount - 1));
                (from, to) = (Tweak.Evaluate(from, to, loop), Tweak.Evaluate(from, to, loop + 1f));

                Tweak.Apply(from, to, loopedNormalizedTime, Action, InvertIfRequiredAndGetFormula(direction));
            }
            else if (LoopType == LoopType.Mirror)
            {
                var loopedMirroredNormalizedTime = loopedNormalizedTime * 2f;

                if (loopedMirroredNormalizedTime > 1f)
                    loopedMirroredNormalizedTime = 2f - loopedMirroredNormalizedTime;

                Tweak.Apply(From(), To(), loopedMirroredNormalizedTime, Action, InvertIfRequiredAndGetFormula(direction));
            }
        }
    }
}