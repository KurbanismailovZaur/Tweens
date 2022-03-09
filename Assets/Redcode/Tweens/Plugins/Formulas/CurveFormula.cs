using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tweens.Formulas
{
    /// <summary>
    /// Represent custom curve formula.
    /// <br/>Use <see cref="With(AnimationCurve)"/> method to set animation curve.
    /// </summary>
    public sealed class CurveFormula : FormulaBase
    {
        private AnimationCurve Curve { get; set; } = AnimationCurve.Linear(0f, 0f, 1f, 1f);

        public override float Remap(float value) => Curve.Evaluate(value);

        /// <summary>
        /// Sets animation curve.
        /// </summary>
        /// <param name="curve">Animation curve.</param>
        /// <returns>The formula.</returns>
        public CurveFormula With(AnimationCurve curve)
        {
            Curve = curve;
            return this;
        }
    }
}