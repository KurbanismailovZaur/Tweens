namespace Tweens.Formulas
{
    /// <summary>
    /// Represent an inversion of the passed formula.
    /// </summary>
    internal sealed class InversionFormula : FormulaBase
    {
        /// <summary>
        /// Formula which remaped values will be inverted.
        /// </summary>
        internal FormulaBase Formula { get; set; }

        /// <summary>
        /// Inverts the remaped value of the formula's result.
        /// </summary>
        /// <param name="interpolation">Value to remap.</param>
        /// <returns>Formula's inverted remaped value.</returns>
        public override float Remap(float interpolation) => 1f - Formula.Remap(1f - interpolation);

        /// <summary>
        /// Set formula.
        /// </summary>
        /// <param name="formula">Formula which remaped values will be inverted</param>
        /// <returns>Self.</returns>
        public InversionFormula WithFormula(FormulaBase formula)
        {
            Formula = formula;
            return this;
        }
    }
}