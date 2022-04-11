namespace Redcode.Tweens.Eases
{
    /// <summary>
    /// Represent bounce formula. <see href="https://easings.net/en#easeInBounce">See documentation here.</see>
    /// </summary>
    public sealed class InBounceEase : Ease
    {
        public override float Remap(float value) => 1f - OutBounce.Remap(1f - value);
    }
}