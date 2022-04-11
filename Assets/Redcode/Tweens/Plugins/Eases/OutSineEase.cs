using UnityEngine;

namespace Redcode.Tweens.Eases
{
    /// <summary>
    /// Represent sine formula. <see href="https://easings.net/en#easeOutSine">See documentation here.</see>
    /// </summary>
    public sealed class OutSineEase : Ease
    {
        public override float Remap(float value) => Mathf.Sin(value * (Mathf.PI / 2f));
    }
}