namespace Redcode.Tweens.Eases
{
    /// <summary>
    /// Represent an inversion of the passed formula.
    /// </summary>
    public sealed class InversionEase : Ease
    {
        /// <summary>
        /// Ease formula which remaped values will be inverted.
        /// </summary>
        public Ease Ease { get; set; }

        /// <summary>
        /// Inverts the remaped value of the ease formula's result.
        /// </summary>
        /// <param name="interpolation">Value to remap.</param>
        /// <returns>Ease formula's inverted remaped value.</returns>
        public override float Remap(float interpolation) => 1f - Ease.Remap(1f - interpolation);

        /// <summary>
        /// Set ease formula.
        /// </summary>
        /// <param name="ease">Ease formula which remaped values will be inverted</param>
        /// <returns>Self.</returns>
        public InversionEase With(Ease ease)
        {
            Ease = ease;
            return this;
        }
    }
}