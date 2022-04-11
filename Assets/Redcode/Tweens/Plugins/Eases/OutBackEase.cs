using UnityEngine;

namespace Redcode.Tweens.Eases
{
    /// <summary>
    /// Represent back formula. <see href="https://easings.net/en#easeOutBack">See documentation here.</see>
    /// </summary>
    public sealed class OutBackEase : Ease
    {
        public override float Remap(float value)
        {
            if (value == 0f)
                return 0f;
                
            var f = (1f - value);
            return 1f - (f * f * f - f * Mathf.Sin(f * Mathf.PI));
        }
    }
}