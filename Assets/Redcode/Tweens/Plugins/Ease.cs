using System;
using Redcode.Tweens.Eases;

namespace Redcode.Tweens
{
    /// <summary>
    /// Base class for all ease types.
    /// Also contains all built-in formulas.
    /// <para>See all formulas behaviours here: <seealso href="https://easings.net/en#">Easing functions</seealso></para>
    /// </summary>
    [Serializable]
    public abstract class Ease
    {
        /// <summary>
        /// Remap given value by ease formula.
        /// </summary>
        /// <param name="interpolation">Value to remap.</param>
        /// <returns>Remaped value.</returns>
        public abstract float Remap(float interpolation);

        #region Built-in ease formulas
        /// <summary>
        /// Represent ease formula which can inverse other ease formula. Use <see cref="InversionEase.With(Ease)"/> method to set ease formula which need inverse.
        /// </summary>
        internal static InversionEase Invertion { get; private set; } = new InversionEase();

        /// <summary>
        /// Represent custom curve ease formula. Each call creates a new instance.
        /// <br/>Use <see cref="CurveEase.With(UnityEngine.AnimationCurve)"/> method to set animation curve.
        /// </summary>
        public static CurveEase Curve => new CurveEase();

        /// <summary>
        /// Linear easing.
        /// </summary>
        public static LinearEase Linear { get; private set; } = new LinearEase();

        /// <summary>
        /// <inheritdoc cref="InQuadraticEase"/>
        /// </summary>
        public static InQuadraticEase InQuad { get; private set; } = new InQuadraticEase();

        /// <summary>
        /// <inheritdoc cref="OutQuadraticEase"/>
        /// </summary>
        public static OutQuadraticEase OutQuad { get; private set; } = new OutQuadraticEase();

        /// <summary>
        /// <inheritdoc cref="InOutQuadraticEase"/>
        /// </summary>
        public static InOutQuadraticEase InOutQuad { get; private set; } = new InOutQuadraticEase();

        /// <summary>
        /// <inheritdoc cref="InCubicEase"/>
        /// </summary>
        public static InCubicEase InCubic { get; private set; } = new InCubicEase();

        /// <summary>
        /// <inheritdoc cref="OutCubicEase"/>
        /// </summary>
        public static OutCubicEase OutCubic { get; private set; } = new OutCubicEase();

        /// <summary>
        /// <inheritdoc cref="InOutCubicEase"/>
        /// </summary>
        public static InOutCubicEase InOutCubic { get; private set; } = new InOutCubicEase();

        /// <summary>
        /// <inheritdoc cref="InQuarticEase"/>
        /// </summary>
        public static InQuarticEase InQuart { get; private set; } = new InQuarticEase();

        /// <summary>
        /// <inheritdoc cref="OutQuarticEase"/>
        /// </summary>
        public static OutQuarticEase OutQuart { get; private set; } = new OutQuarticEase();

        /// <summary>
        /// <inheritdoc cref="InOutQuarticEase"/>
        /// </summary>
        public static InOutQuarticEase InOutQuart { get; private set; } = new InOutQuarticEase();

        /// <summary>
        /// <inheritdoc cref="InQuinticEase"/>
        /// </summary>
        public static InQuinticEase InQuint { get; private set; } = new InQuinticEase();

        /// <summary>
        /// <inheritdoc cref="OutQuinticEase"/>
        /// </summary>
        public static OutQuinticEase OutQuint { get; private set; } = new OutQuinticEase();

        /// <summary>
        /// <inheritdoc cref="InOutQuinticEase"/>
        /// </summary>
        public static InOutQuinticEase InOutQuint { get; private set; } = new InOutQuinticEase();

        /// <summary>
        /// <inheritdoc cref="InSineEase"/>
        /// </summary>
        public static InSineEase InSine { get; private set; } = new InSineEase();

        /// <summary>
        /// <inheritdoc cref="OutSineEase"/>
        /// </summary>
        public static OutSineEase OutSine { get; private set; } = new OutSineEase();

        /// <summary>
        /// <inheritdoc cref="InOutSineEase"/>
        /// </summary>
        public static InOutSineEase InOutSine { get; private set; } = new InOutSineEase();

        /// <summary>
        /// <inheritdoc cref="InCircularEase"/>
        /// </summary>
        public static InCircularEase InCirc { get; private set; } = new InCircularEase();

        /// <summary>
        /// <inheritdoc cref="OutCircularEase"/>
        /// </summary>
        public static OutCircularEase OutCirc { get; private set; } = new OutCircularEase();

        /// <summary>
        /// <inheritdoc cref="InOutCircularEase"/>
        /// </summary>
        public static InOutCircularEase InOutCirc { get; private set; } = new InOutCircularEase();

        /// <summary>
        /// <inheritdoc cref="InExponentialEase"/>
        /// </summary>
        public static InExponentialEase InExpo { get; private set; } = new InExponentialEase();

        /// <summary>
        /// <inheritdoc cref="OutExponentialEase"/>
        /// </summary>
        public static OutExponentialEase OutExpo { get; private set; } = new OutExponentialEase();

        /// <summary>
        /// <inheritdoc cref="InOutExponentialEase"/>
        /// </summary>
        public static InOutExponentialEase InOutExpo { get; private set; } = new InOutExponentialEase();

        /// <summary>
        /// <inheritdoc cref="InElasticEase"/>
        /// </summary>
        public static InElasticEase InElastic { get; private set; } = new InElasticEase();

        /// <summary>
        /// <inheritdoc cref="OutElasticEase"/>
        /// </summary>
        public static OutElasticEase OutElastic { get; private set; } = new OutElasticEase();

        /// <summary>
        /// <inheritdoc cref="InOutElasticEase"/>
        /// </summary>
        public static InOutElasticEase InOutElastic { get; private set; } = new InOutElasticEase();

        /// <summary>
        /// <inheritdoc cref="InBackEase"/>
        /// </summary>
        public static InBackEase InBack { get; private set; } = new InBackEase();

        /// <summary>
        /// <inheritdoc cref="OutBackEase"/>
        /// </summary>
        public static OutBackEase OutBack { get; private set; } = new OutBackEase();

        /// <summary>
        /// <inheritdoc cref="InOutBackEase"/>
        /// </summary>
        public static InOutBackEase InOutBack { get; private set; } = new InOutBackEase();

        /// <summary>
        /// <inheritdoc cref="InBounceEase"/>
        /// </summary>
        public static InBounceEase InBounce { get; private set; } = new InBounceEase();

        /// <summary>
        /// <inheritdoc cref="OutBounceEase"/>
        /// </summary>
        public static OutBounceEase OutBounce { get; private set; } = new OutBounceEase();

        /// <summary>
        /// <inheritdoc cref="InOutBounceEase"/>
        /// </summary>
        public static InOutBounceEase InOutBounce { get; private set; } = new InOutBounceEase();
        #endregion
    }
}