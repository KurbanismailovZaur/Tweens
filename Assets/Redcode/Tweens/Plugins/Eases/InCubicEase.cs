namespace Redcode.Tweens.Eases
{
    /// <summary>
    /// Represent cubic formula. <see href="https://easings.net/en#easeInCubic">See documentation here.</see>
    /// </summary>
    public sealed class InCubicEase : Ease
    {
        public override float Remap(float value) => value * value * value;
    }
}