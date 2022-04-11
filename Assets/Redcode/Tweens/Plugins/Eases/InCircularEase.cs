using UnityEngine;

namespace Redcode.Tweens.Eases
{
    /// <summary>
    /// Represent circular formula. <see href="https://easings.net/en#easeInCirc">See documentation here.</see>
    /// </summary>
    public sealed class InCircularEase : Ease
    {
        public override float Remap(float value) => 1f - Mathf.Sqrt(1f - (value * value));
    }
}