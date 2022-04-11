namespace Redcode.Tweens.Eases
{
    /// <summary>
    /// Represent cubic formula. <see href="https://easings.net/en#easeInOutCubic">See documentation here.</see>
    /// </summary>
    public sealed class InOutCubicEase : Ease
    {
        public override float Remap(float value)
        {
            if (value < 0.5f) 
                return 4f * value * value * value;
            else
            {
                var f = ((2f * value) - 2f);
                return 0.5f * f * f * f + 1f;
            }
        }
    }
}