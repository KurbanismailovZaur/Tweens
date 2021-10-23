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

        private FormulaBase InvertIfRequiredAndGetFormula(Direction direction) => direction == Direction.Forward ? Formula : Tweens.Formula.Invertion.WithFormula(Formula);

        protected override void RewindZeroHandler(int loop, float loopedNormalizedTime, Direction direction, int continueLoopIndex, int continueMaxLoopsCount)
        {
            if (LoopType == LoopType.Reset)
            {
                var (from, to) = (From(), To());

                if (direction == Direction.Forward)
                    (from, to) = (Tweak.Evaluate(from, to, continueLoopIndex), Tweak.Evaluate(from, to, continueLoopIndex + 1f));
                else
                    (from, to) = (Tweak.Evaluate(from, to, continueMaxLoopsCount), Tweak.Evaluate(from, to, continueMaxLoopsCount - 1f));

                Tweak.Apply(from, to, loopedNormalizedTime, Action, Formula);
            }
            else if (LoopType == LoopType.Continue)
            {
                var (from, to) = direction == Direction.Forward ? (From(), To()) : (Tweak.Evaluate(From(), To(), LoopsCount), Tweak.Evaluate(From(), To(), LoopsCount - 1));
                (from, to) = (Tweak.Evaluate(from, to, continueLoopIndex + loop), Tweak.Evaluate(from, to, continueLoopIndex + loop + 1f));

                Tweak.Apply(from, to, loopedNormalizedTime, Action, Formula);
            }
            else if (LoopType == LoopType.Mirror)
            {
                var (from, to) = (From(), To());
                (from, to) = (Tweak.Evaluate(from, to, continueLoopIndex), Tweak.Evaluate(from, to, continueLoopIndex + 1f));

                Tweak.Apply(From(), To(), 0f, Action, Formula);
            }
        }

        protected override void RewindHandler(int loop, float loopedTime, Direction direction, int continueLoopIndex, int continueMaxLoopsCount)
        {
            var loopedNormalizedTime = loopedTime / LoopDuration;

            if (LoopType == LoopType.Reset)
            {
                var (from, to) = (From(), To());

                if (direction == Direction.Forward)
                    (from, to) = (Tweak.Evaluate(from, to, continueLoopIndex), Tweak.Evaluate(from, to, continueLoopIndex + 1f));
                else
                    (from, to) = (Tweak.Evaluate(from, to, continueMaxLoopsCount - continueLoopIndex), Tweak.Evaluate(from, to, continueMaxLoopsCount - continueLoopIndex - 1f));

                Tweak.Apply(from, to, loopedNormalizedTime, Action, InvertIfRequiredAndGetFormula(direction));
            }
            else if (LoopType == LoopType.Continue)
            {
                var (from, to) = direction == Direction.Forward ? (From(), To()) : (Tweak.Evaluate(From(), To(), LoopsCount), Tweak.Evaluate(From(), To(), LoopsCount - 1));
                (from, to) = (Tweak.Evaluate(from, to, continueLoopIndex + loop), Tweak.Evaluate(from, to, continueLoopIndex + loop + 1f));

                Tweak.Apply(from, to, loopedNormalizedTime, Action, InvertIfRequiredAndGetFormula(direction));
            }
            else if (LoopType == LoopType.Mirror)
            {
                var loopedMirroredNormalizedTime = loopedNormalizedTime * 2f;

                if (loopedMirroredNormalizedTime > 1f)
                    loopedMirroredNormalizedTime = 2f - loopedMirroredNormalizedTime;

                var (from, to) = (From(), To());
                (from, to) = (Tweak.Evaluate(from, to, continueLoopIndex), Tweak.Evaluate(from, to, continueLoopIndex + 1f));

                Tweak.Apply(from, to, loopedMirroredNormalizedTime, Action, InvertIfRequiredAndGetFormula(direction));
            }
        }
    }
}