namespace Redcode.Tweens.Eases
{
    /// <summary>
    /// Represent bounce formula. <see href="https://easings.net/en#easeInOutBounce">See documentation here.</see>
    /// </summary>
    public sealed class InOutBounceEase : Ease
    {
        public override float Remap(float value)
        {
            if (value < 0.5f)
                return 0.5f * InBounce.Remap(value * 2f);
            else
                return 0.5f * OutBounce.Remap(value * 2f - 1f) + 0.5f;
        }
    }
}