namespace Redcode.Tweens.Eases
{
    /// <summary>
    /// Represent quartic formula. <see href="https://easings.net/en#easeOutQuart">See documentation here.</see>
    /// </summary>
    public sealed class OutQuarticEase : Ease
    {
        public override float Remap(float value)
        {
            var f = (value - 1f);
            return f * f * f * (1f - value) + 1f;
        }
    }
}