using UnityEngine;

namespace Redcode.Tweens.Eases
{
    /// <summary>
    /// Represent exponential formula. <see href="https://easings.net/en#easeInOutExpo">See documentation here.</see>
    /// </summary>
    public sealed class InOutExponentialEase : Ease
    {
        public override float Remap(float value)
        {
            if (value == 0f || value == 1f) return value;

            return value < 0.5f ? 0.5f * Mathf.Pow(2f, (20f * value) - 10f) : -0.5f * Mathf.Pow(2f, (-20f * value) + 10f) + 1f;
        }
    }
}