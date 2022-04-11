namespace Redcode.Tweens.Eases
{
    public sealed class InOutQuinticEase : Ease
    {
        /// <summary>
        /// Represent quintic formula. <see href="https://easings.net/en#easeInOutQuint">See documentation here.</see>
        /// </summary>
        public override float Remap(float value)
        {
            if (value < 0.5f)
                return 16f * value * value * value * value * value;
            else
            {
                var f = ((2f * value) - 2f);
                return 0.5f * f * f * f * f * f + 1f;
            }
        }
    }
}