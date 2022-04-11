using UnityEngine;

namespace Redcode.Tweens.Eases
{
    /// <summary>
    /// Represent elastic formula. <see href="https://easings.net/en#easeOutElastic">See documentation here.</see>
    /// </summary>
    public sealed class OutElasticEase : Ease
    {
        public override float Remap(float value) => Mathf.Sin(-13f * (Mathf.PI / 2f) * (value + 1f)) * Mathf.Pow(2f, -10f * value) + 1f;
    }
}