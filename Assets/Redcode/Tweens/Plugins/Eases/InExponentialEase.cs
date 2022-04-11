using UnityEngine;

namespace Redcode.Tweens.Eases
{
    /// <summary>
    /// Represent exponential formula. <see href="https://easings.net/en#easeInExpo">See documentation here.</see>
    /// </summary>
    public sealed class InExponentialEase : Ease
    {
        public override float Remap(float value) => (value == 0f) ? value : Mathf.Pow(2f, 10f * (value - 1f));
    }
}