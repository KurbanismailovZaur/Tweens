namespace Redcode.Tweens.Eases
{
    /// <summary>
    /// Represent quadratic formula. <see href="https://easings.net/en#easeOutQuad">See documentation here.</see>
    /// </summary>
    public sealed class OutQuadraticEase : Ease
    {
        public override float Remap(float value) => -(value * (value - 2f));
    }
}