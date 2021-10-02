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
        public Tween(T from, T to, Action<T> action, float loopDuration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset) : this(new U(), from, to, action, loopDuration, formula, loopsCount, loopType) { }

        public Tween(U tweak, T from, T to, Action<T> action, float loopDuration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset) : this((string)null, tweak, from, to, action, loopDuration, formula, loopsCount, loopType) { }

        public Tween(string name, T from, T to, Action<T> action, float loopDuration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset) : this(name, new U(), from, to, action, loopDuration, formula, loopsCount, loopType) { }

        public Tween(string name, U tweak, T from, T to, Action<T> action, float loopDuration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset) : this(null, name, tweak, from, to, action, loopDuration, formula, loopsCount, loopType) { }

        public Tween(GameObject owner, T from, T to, Action<T> action, float loopDuration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset) : this(owner, new U(), from, to, action, loopDuration, formula, loopsCount, loopType) { }

        public Tween(GameObject owner, U tweak, T from, T to, Action<T> action, float loopDuration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset) : this(owner, null, tweak, from, to, action, loopDuration, formula, loopsCount, loopType) { }

        public Tween(GameObject owner, string name, T from, T to, Action<T> action, float loopDuration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset) : this(owner, name, new U(), from, to, action, loopDuration, formula, loopsCount, loopType) { }

        public Tween(GameObject owner, string name, U tweak, T from, T to, Action<T> action, float loopDuration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset) : this(owner, name, tweak, () => from, () => to, action, loopDuration, formula, loopsCount, loopType) { }

        public Tween(Func<T> from, Func<T> to, Action<T> action, float loopDuration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset) : this(new U(), from, to, action, loopDuration, formula, loopsCount, loopType) { }

        public Tween(U tweak, Func<T> from, Func<T> to, Action<T> action, float loopDuration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset) : this((string)null, tweak, from, to, action, loopDuration, formula, loopsCount, loopType) { }

        public Tween(string name, Func<T> from, Func<T> to, Action<T> action, float loopDuration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset) : this(name, new U(), from, to, action, loopDuration, formula, loopsCount, loopType) { }

        public Tween(string name, U tweak, Func<T> from, Func<T> to, Action<T> action, float loopDuration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset) : this(null, name, tweak, from, to, action, loopDuration, formula, loopsCount, loopType) { }

        public Tween(GameObject owner, Func<T> from, Func<T> to, Action<T> action, float loopDuration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset) : this(owner, new U(), from, to, action, loopDuration, formula, loopsCount, loopType) { }

        public Tween(GameObject owner, U tweak, Func<T> from, Func<T> to, Action<T> action, float loopDuration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset) : this(owner, null, tweak, from, to, action, loopDuration, formula, loopsCount, loopType) { }

        public Tween(GameObject owner, string name, Func<T> from, Func<T> to, Action<T> action, float loopDuration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset) : this(owner, name, new U(), from, to, action, loopDuration, formula, loopsCount, loopType) { }

        public Tween(GameObject owner, string name, U tweak, Func<T> from, Func<T> to, Action<T> action, float loopDuration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset) : base(owner, name, loopDuration, formula, loopsCount, loopType)
        {
            Tweak = tweak;
            From = from;
            To = to;
            Action = action;
        }
        #endregion

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