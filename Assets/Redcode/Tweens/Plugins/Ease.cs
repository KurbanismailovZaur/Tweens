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
        public static CurveEase Curve => new();

        public static LinearEase Linear { get; private set; } = new();

        /// <summary>
        /// <see href="https://easings.net/en#easeInQuad">See documentation here.</see>
        /// </summary>
        public static InQuadraticEase InQuad { get; private set; } = new ();

        /// <summary>
        /// <see href="https://easings.net/en#easeOutQuad">See documentation here.</see>
        /// </summary>
        public static OutQuadraticEase OutQuad { get; private set; } = new ();

        /// <summary>
        /// <see href="https://easings.net/en#easeInOutQuad">See documentation here.</see>
        /// </summary>
        public static InOutQuadraticEase InOutQuad { get; private set; } = new ();

        /// <summary>
        /// <see href="https://easings.net/en#easeInCubic">See documentation here.</see>
        /// </summary>
        public static InCubicEase InCubic { get; private set; } = new ();

        /// <summary>
        /// <see href="https://easings.net/en#easeOutCubic">See documentation here.</see>
        /// </summary>
        public static OutCubicEase OutCubic { get; private set; } = new ();

        /// <summary>
        /// <see href="https://easings.net/en#easeInOutCubic">See documentation here.</see>
        /// </summary>
        public static InOutCubicEase InOutCubic { get; private set; } = new ();

        /// <summary>
        /// <see href="https://easings.net/en#easeInQuart">See documentation here.</see>
        /// </summary>
        public static InQuarticEase InQuart { get; private set; } = new ();

        /// <summary>
        /// <see href="https://easings.net/en#easeOutQuart">See documentation here.</see>
        /// </summary>
        public static OutQuarticEase OutQuart { get; private set; } = new ();

        /// <summary>
        /// <see href="https://easings.net/en#easeInOutQuart">See documentation here.</see>
        /// </summary>
        public static InOutQuarticEase InOutQuart { get; private set; } = new ();

        /// <summary>
        /// <see href="https://easings.net/en#easeInQuint">See documentation here.</see>
        /// </summary>
        public static InQuinticEase InQuint { get; private set; } = new ();

        /// <summary>
        /// <see href="https://easings.net/en#easeOutQuint">See documentation here.</see>
        /// </summary>
        public static OutQuinticEase OutQuint { get; private set; } = new ();

        /// <summary>
        /// <see href="https://easings.net/en#easeInOutQuint">See documentation here.</see>
        /// </summary>
        public static InOutQuinticEase InOutQuint { get; private set; } = new ();

        /// <summary>
        /// <see href="https://easings.net/en#easeInSine">See documentation here.</see>
        /// </summary>
        public static InSineEase InSine { get; private set; } = new ();

        /// <summary>
        /// <see href="https://easings.net/en#easeOutSine">See documentation here.</see>
        /// </summary>
        public static OutSineEase OutSine { get; private set; } = new ();

        /// <summary>
        /// <see href="https://easings.net/en#easeInOutSine">See documentation here.</see>
        /// </summary>
        public static InOutSineEase InOutSine { get; private set; } = new ();

        /// <summary>
        /// <see href="https://easings.net/en#easeInCirc">See documentation here.</see>
        /// </summary>
        public static InCircularEase InCirc { get; private set; } = new ();

        /// <summary>
        /// <see href="https://easings.net/en#easeOutCirc">See documentation here.</see>
        /// </summary>
        public static OutCircularEase OutCirc { get; private set; } = new ();

        /// <summary>
        /// <see href="https://easings.net/en#easeInOutCirc">See documentation here.</see>
        /// </summary>
        public static InOutCircularEase InOutCirc { get; private set; } = new ();

        /// <summary>
        /// <see href="https://easings.net/en#easeInExpo">See documentation here.</see>
        /// </summary>
        public static InExponentialEase InExpo { get; private set; } = new ();

        /// <summary>
        /// <see href="https://easings.net/en#easeOutExpo">See documentation here.</see>
        /// </summary>
        public static OutExponentialEase OutExpo { get; private set; } = new ();

        /// <summary>
        /// <see href="https://easings.net/en#easeInOutExpo">See documentation here.</see>
        /// </summary>
        public static InOutExponentialEase InOutExpo { get; private set; } = new ();

        /// <summary>
        /// <see href="https://easings.net/en#easeInElastic">See documentation here.</see>
        /// </summary>
        public static InElasticEase InElastic { get; private set; } = new ();

        /// <summary>
        /// <see href="https://easings.net/en#easeOutElastic">See documentation here.</see>
        /// </summary>
        public static OutElasticEase OutElastic { get; private set; } = new ();

        /// <summary>
        /// <see href="https://easings.net/en#easeInOutElastic">See documentation here.</see>
        /// </summary>
        public static InOutElasticEase InOutElastic { get; private set; } = new ();

        /// <summary>
        /// <see href="https://easings.net/en#easeInBack">See documentation here.</see>
        /// </summary>
        public static InBackEase InBack { get; private set; } = new ();

        /// <summary>
        /// <see href="https://easings.net/en#easeOutBack">See documentation here.</see>
        /// </summary>
        public static OutBackEase OutBack { get; private set; } = new ();

        /// <summary>
        /// <see href="https://easings.net/en#easeInOutBack">See documentation here.</see>
        /// </summary>
        public static InOutBackEase InOutBack { get; private set; } = new ();

        /// <summary>
        /// <see href="https://easings.net/en#easeInBounce">See documentation here.</see>
        /// </summary>
        public static InBounceEase InBounce { get; private set; } = new ();

        /// <summary>
        /// <see href="https://easings.net/en#easeOutBounce">See documentation here.</see>
        /// </summary>
        public static OutBounceEase OutBounce { get; private set; } = new ();

        /// <summary>
        /// <see href="https://easings.net/en#easeInOutBounce">See documentation here.</see>
        /// </summary>
        public static InOutBounceEase InOutBounce { get; private set; } = new ();
        #endregion
    }
}