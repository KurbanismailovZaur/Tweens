using UnityEngine;

namespace Redcode.Tweens.Eases
{
    /// <summary>
    /// Represent sine formula. <see href="https://easings.net/en#easeInOutSine">See documentation here.</see>
    /// </summary>
    public sealed class InOutSineEase : Ease
    {
        public override float Remap(float value) => 0.5f * (1f - Mathf.Cos(value * Mathf.PI));
    }
}