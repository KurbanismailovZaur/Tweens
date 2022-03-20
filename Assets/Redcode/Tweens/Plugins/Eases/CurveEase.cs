using UnityEngine;

namespace Redcode.Tweens.Eases
{
    /// <summary>
    /// Represent custom curve ease formula.
    /// <br/>Use <see cref="With(AnimationCurve)"/> method to set animation curve.
    /// </summary>
    public sealed class CurveEase : Ease
    {
        private new AnimationCurve Curve { get; set; } = AnimationCurve.Linear(0f, 0f, 1f, 1f);

        public override float Remap(float value) => Curve.Evaluate(value);

        /// <summary>
        /// Sets animation curve.
        /// </summary>
        /// <param name="curve">Animation curve.</param>
        /// <returns>The ease formula.</returns>
        public CurveEase With(AnimationCurve curve)
        {
            Curve = curve;
            return this;
        }
    }
}