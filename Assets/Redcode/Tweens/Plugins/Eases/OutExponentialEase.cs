using UnityEngine;

namespace Redcode.Tweens.Eases
{
    /// <summary>
    /// Represent exponential formula. <see href="https://easings.net/en#easeOutExpo">See documentation here.</see>
    /// </summary>
    public sealed class OutExponentialEase : Ease
    {
        public override float Remap(float value) => (value == 1f) ? value : 1f - Mathf.Pow(2f, -10f * value);
    }
}