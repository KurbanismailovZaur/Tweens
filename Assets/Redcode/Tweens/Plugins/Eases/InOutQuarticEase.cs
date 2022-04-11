namespace Redcode.Tweens.Eases
{
    /// <summary>
    /// Represent quartic formula. <see href="https://easings.net/en#easeInOutQuart">See documentation here.</see>
    /// </summary>
    public sealed class InOutQuarticEase : Ease
    {
        public override float Remap(float value)
        {
            if (value < 0.5f) 
                return 8f * value * value * value * value;
            else
            {
                var f = (value - 1f);
                return -8f * f * f * f * f + 1f;
            }
        }
    }
}