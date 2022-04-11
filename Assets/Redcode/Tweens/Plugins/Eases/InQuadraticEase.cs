namespace Redcode.Tweens.Eases
{
    /// <summary>
    /// Represent quadratic formula. <see href="https://easings.net/en#easeInQuad">See documentation here.</see>
    /// </summary>
    public sealed class InQuadraticEase : Ease
    {
        public override float Remap(float value) => value * value;
    }
}