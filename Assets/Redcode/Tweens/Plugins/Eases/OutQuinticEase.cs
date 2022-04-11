namespace Redcode.Tweens.Eases
{
    /// <summary>
    /// Represent quintic formula. <see href="https://easings.net/en#easeOutQuint">See documentation here.</see>
    /// </summary>
    public sealed class OutQuinticEase : Ease
    {
        public override float Remap(float value)
        {
            var f = (value - 1f);
            return f * f * f * f * f + 1f;
        }
    }
}