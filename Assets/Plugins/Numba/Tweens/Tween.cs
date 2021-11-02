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

        protected override void RewindZeroHandler(int loop, float loopedNormalizedTime, Direction direction, bool emitEvents, int parentContinueLoopIndex, int continueMaxLoopsCount)
        {
            var (from, to) = (From(), To());

            (T, T) Evaluate(float fromInterlopation, float toInterpolation) => (Tweak.Evaluate(from, to, fromInterlopation), Tweak.Evaluate(from, to, toInterpolation));

            if (LoopType == LoopType.Reset)
            {
                if (direction == Direction.Forward)
                    (from, to) = Evaluate(parentContinueLoopIndex, parentContinueLoopIndex + 1f);
                else
                    (from, to) = Evaluate(continueMaxLoopsCount - parentContinueLoopIndex, continueMaxLoopsCount - parentContinueLoopIndex - 1f);

                Tweak.Apply(from, to, loopedNormalizedTime, Action, Formula);
            }
            else if (LoopType == LoopType.Continue)
            {
                if (direction == Direction.Forward)
                    (from, to) = Evaluate(parentContinueLoopIndex * LoopsCount + loop, parentContinueLoopIndex * LoopsCount + loop + 1f);
                else
                    (from, to) = Evaluate(continueMaxLoopsCount * LoopsCount - (parentContinueLoopIndex * LoopsCount) - loop, continueMaxLoopsCount * LoopsCount - (parentContinueLoopIndex * LoopsCount) - loop - 1f);

                Tweak.Apply(from, to, loopedNormalizedTime, Action, Formula);
            }
            else if (LoopType == LoopType.Mirror)
            {
                if (direction == Direction.Forward)
                    (from, to) = Evaluate(parentContinueLoopIndex, parentContinueLoopIndex + 1f);
                else
                    (from, to) = Evaluate(continueMaxLoopsCount - parentContinueLoopIndex - 1f, continueMaxLoopsCount - parentContinueLoopIndex);

                var loopedMirroredNormalizedTime = loopedNormalizedTime * 2f;

                if (loopedMirroredNormalizedTime > 1f)
                    loopedMirroredNormalizedTime = 2f - loopedMirroredNormalizedTime;

                Tweak.Apply(from, to, loopedMirroredNormalizedTime, Action, Formula);
            }
        }

        protected override void RewindHandler(int loop, float loopedTime, Direction direction, bool emitEvents, int parentContinueLoopIndex, int continueMaxLoopsCount)
        {
            var (from, to) = (From(), To());

            (T, T) Evaluate(float fromInterlopation, float toInterpolation) => (Tweak.Evaluate(from, to, fromInterlopation), Tweak.Evaluate(from, to, toInterpolation));

            var loopedNormalizedTime = loopedTime / LoopDuration;

            if (LoopType == LoopType.Reset)
            {
                if (direction == Direction.Forward)
                    (from, to) = Evaluate(parentContinueLoopIndex, parentContinueLoopIndex + 1f);
                else
                    (from, to) = Evaluate(continueMaxLoopsCount - parentContinueLoopIndex, continueMaxLoopsCount - parentContinueLoopIndex - 1f);

                Tweak.Apply(from, to, loopedNormalizedTime, Action, InvertIfRequiredAndGetFormula(direction));
            }
            else if (LoopType == LoopType.Continue)
            {
                if (direction == Direction.Forward)
                    (from, to) = Evaluate(parentContinueLoopIndex * LoopsCount + loop, parentContinueLoopIndex * LoopsCount + loop + 1f);
                else
                    (from, to) = Evaluate(continueMaxLoopsCount * LoopsCount - (parentContinueLoopIndex * LoopsCount) - loop, continueMaxLoopsCount * LoopsCount - (parentContinueLoopIndex * LoopsCount) - loop - 1f);

                Tweak.Apply(from, to, loopedNormalizedTime, Action, InvertIfRequiredAndGetFormula(direction));
            }
            else if (LoopType == LoopType.Mirror)
            {
                if (direction == Direction.Forward)
                    (from, to) = Evaluate(parentContinueLoopIndex, parentContinueLoopIndex + 1f);
                else
                    (from, to) = Evaluate(continueMaxLoopsCount - parentContinueLoopIndex - 1f, continueMaxLoopsCount - parentContinueLoopIndex);

                var loopedMirroredNormalizedTime = loopedNormalizedTime * 2f;

                if (loopedMirroredNormalizedTime > 1f)
                    loopedMirroredNormalizedTime = 2f - loopedMirroredNormalizedTime;

                Tweak.Apply(from, to, loopedMirroredNormalizedTime, Action, InvertIfRequiredAndGetFormula(direction));
            }
        }
    }
}