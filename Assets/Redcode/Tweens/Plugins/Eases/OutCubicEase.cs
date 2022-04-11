namespace Redcode.Tweens.Eases
{
    /// <summary>
    /// Represent cubic formula. <see href="https://easings.net/en#easeOutCubic">See documentation here.</see>
    /// </summary>
    public sealed class OutCubicEase : Ease
    {
        public override float Remap(float value)
        {
            var f = value - 1f; 
            return f * f * f + 1f;
        }
    }
}