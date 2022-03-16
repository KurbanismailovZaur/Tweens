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
		/// Remap given value by formula.
		/// </summary>
		/// <param name="interpolation">Value to remap.</param>
		/// <returns>Remaped value.</returns>
		public abstract float Remap(float interpolation);

        #region Built-in ease formulas
        /// <summary>
        /// Represent formula which can inverse other formula. Use <see cref="InversionFormula.With(Ease)"/> method to set formula which need inverse.
        /// </summary>
        internal static InversionFormula Invertion { get; private set; } = new InversionFormula();

        /// <summary>
        /// Represent custom curve formula. Each call creates a new instance.
        /// <br/>Use <see cref="CurveFormula.With(UnityEngine.AnimationCurve)"/> method to set animation curve.
        /// </summary>
        public static CurveFormula Curve => new CurveFormula();

        public static LinearFormula Linear { get; private set; } = new LinearFormula();

        /// <summary>
        /// <see href="https://easings.net/en#easeInQuad">See documentation here.</see>
        /// </summary>
        public static InQuadraticFormula InQuad { get; private set; } = new InQuadraticFormula();

        /// <summary>
        /// <see href="https://easings.net/en#easeOutQuad">See documentation here.</see>
        /// </summary>
        public static OutQuadraticFormula OutQuad { get; private set; } = new OutQuadraticFormula();

        /// <summary>
        /// <see href="https://easings.net/en#easeInOutQuad">See documentation here.</see>
        /// </summary>
        public static InOutQuadraticFormula InOutQuad { get; private set; } = new InOutQuadraticFormula();

        /// <summary>
        /// <see href="https://easings.net/en#easeInCubic">See documentation here.</see>
        /// </summary>
        public static InCubicFormula InCubic { get; private set; } = new InCubicFormula();

        /// <summary>
        /// <see href="https://easings.net/en#easeOutCubic">See documentation here.</see>
        /// </summary>
        public static OutCubicFormula OutCubic { get; private set; } = new OutCubicFormula();

        /// <summary>
        /// <see href="https://easings.net/en#easeInOutCubic">See documentation here.</see>
        /// </summary>
        public static InOutCubicFormula InOutCubic { get; private set; } = new InOutCubicFormula();

        /// <summary>
        /// <see href="https://easings.net/en#easeInQuart">See documentation here.</see>
        /// </summary>
        public static InQuarticFormula InQuart { get; private set; } = new InQuarticFormula();

        /// <summary>
        /// <see href="https://easings.net/en#easeOutQuart">See documentation here.</see>
        /// </summary>
        public static OutQuarticFormula OutQuart { get; private set; } = new OutQuarticFormula();

        /// <summary>
        /// <see href="https://easings.net/en#easeInOutQuart">See documentation here.</see>
        /// </summary>
        public static InOutQuarticFormula InOutQuart { get; private set; } = new InOutQuarticFormula();

        /// <summary>
        /// <see href="https://easings.net/en#easeInQuint">See documentation here.</see>
        /// </summary>
        public static InQuinticFormula InQuint { get; private set; } = new InQuinticFormula();

        /// <summary>
        /// <see href="https://easings.net/en#easeOutQuint">See documentation here.</see>
        /// </summary>
        public static OutQuinticFormula OutQuint { get; private set; } = new OutQuinticFormula();

        /// <summary>
        /// <see href="https://easings.net/en#easeInOutQuint">See documentation here.</see>
        /// </summary>
        public static InOutQuinticFormula InOutQuint { get; private set; } = new InOutQuinticFormula();

        /// <summary>
        /// <see href="https://easings.net/en#easeInSine">See documentation here.</see>
        /// </summary>
        public static InSineFormula InSine { get; private set; } = new InSineFormula();

        /// <summary>
        /// <see href="https://easings.net/en#easeOutSine">See documentation here.</see>
        /// </summary>
        public static OutSineFormula OutSine { get; private set; } = new OutSineFormula();

        /// <summary>
        /// <see href="https://easings.net/en#easeInOutSine">See documentation here.</see>
        /// </summary>
        public static InOutSineFormula InOutSine { get; private set; } = new InOutSineFormula();

        /// <summary>
        /// <see href="https://easings.net/en#easeInCirc">See documentation here.</see>
        /// </summary>
        public static InCircularFormula InCirc { get; private set; } = new InCircularFormula();

        /// <summary>
        /// <see href="https://easings.net/en#easeOutCirc">See documentation here.</see>
        /// </summary>
        public static OutCircularFormula OutCirc { get; private set; } = new OutCircularFormula();

        /// <summary>
        /// <see href="https://easings.net/en#easeInOutCirc">See documentation here.</see>
        /// </summary>
        public static InOutCircularFormula InOutCirc { get; private set; } = new InOutCircularFormula();

        /// <summary>
        /// <see href="https://easings.net/en#easeInExpo">See documentation here.</see>
        /// </summary>
        public static InExponentialFormula InExpo { get; private set; } = new InExponentialFormula();

        /// <summary>
        /// <see href="https://easings.net/en#easeOutExpo">See documentation here.</see>
        /// </summary>
        public static OutExponentialFormula OutExpo { get; private set; } = new OutExponentialFormula();

        /// <summary>
        /// <see href="https://easings.net/en#easeInOutExpo">See documentation here.</see>
        /// </summary>
        public static InOutExponentialFormula InOutExpo { get; private set; } = new InOutExponentialFormula();

        /// <summary>
        /// <see href="https://easings.net/en#easeInElastic">See documentation here.</see>
        /// </summary>
        public static InElasticFormula InElastic { get; private set; } = new InElasticFormula();

        /// <summary>
        /// <see href="https://easings.net/en#easeOutElastic">See documentation here.</see>
        /// </summary>
        public static OutElasticFormula OutElastic { get; private set; } = new OutElasticFormula();

        /// <summary>
        /// <see href="https://easings.net/en#easeInOutElastic">See documentation here.</see>
        /// </summary>
        public static InOutElasticFormula InOutElastic { get; private set; } = new InOutElasticFormula();

        /// <summary>
        /// <see href="https://easings.net/en#easeInBack">See documentation here.</see>
        /// </summary>
        public static InBackFormula InBack { get; private set; } = new InBackFormula();

        /// <summary>
        /// <see href="https://easings.net/en#easeOutBack">See documentation here.</see>
        /// </summary>
        public static OutBackFormula OutBack { get; private set; } = new OutBackFormula();

        /// <summary>
        /// <see href="https://easings.net/en#easeInOutBack">See documentation here.</see>
        /// </summary>
        public static InOutBackFormula InOutBack { get; private set; } = new InOutBackFormula();

        /// <summary>
        /// <see href="https://easings.net/en#easeInBounce">See documentation here.</see>
        /// </summary>
        public static InBounceFormula InBounce { get; private set; } = new InBounceFormula();

        /// <summary>
        /// <see href="https://easings.net/en#easeOutBounce">See documentation here.</see>
        /// </summary>
        public static OutBounceFormula OutBounce { get; private set; } = new OutBounceFormula();

        /// <summary>
        /// <see href="https://easings.net/en#easeInOutBounce">See documentation here.</see>
        /// </summary>
        public static InOutBounceFormula InOutBounce { get; private set; } = new InOutBounceFormula();
        #endregion
    }
}