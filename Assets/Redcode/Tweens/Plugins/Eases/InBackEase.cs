using UnityEngine;

namespace Redcode.Tweens.Eases
{
    /// <summary>
    /// Represent back formula. <see href="https://easings.net/en#easeInBack">See documentation here.</see>
    /// </summary>
    public sealed class InBackEase : Ease
    {
        public override float Remap(float value) => value * value * value - value * Mathf.Sin(value * Mathf.PI);
    }
}