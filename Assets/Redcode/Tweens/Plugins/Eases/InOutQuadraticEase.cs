namespace Redcode.Tweens.Eases
{
    /// <summary>
    /// Represent quadratic formula. <see href="https://easings.net/en#easeInOutQuad">See documentation here.</see>
    /// </summary>
    public sealed class InOutQuadraticEase : Ease
    {
        public override float Remap(float value) => (value < 0.5f ? 2f * value * value : (-2f * value * value + (4f * value) - 1f));
    }
}