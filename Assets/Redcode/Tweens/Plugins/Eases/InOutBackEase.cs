using UnityEngine;

namespace Redcode.Tweens.Eases
{
    /// <summary>
    /// Represent back formula. <see href="https://easings.net/en#easeInOutBack">See documentation here.</see>
    /// </summary>
    public sealed class InOutBackEase : Ease
    {
        public override float Remap(float value)
        {
            if (value < 0.5f)
            {
                var f = 2f * value;
                return 0.5f * (f * f * f - f * Mathf.Sin(f * Mathf.PI));
            }
            else
            {
                var f = (1f - (2f * value - 1f));
                return 0.5f * (1f - (f * f * f - f * Mathf.Sin(f * Mathf.PI))) + 0.5f;
            }
        }
    }
}