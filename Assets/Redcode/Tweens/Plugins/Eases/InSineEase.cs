using UnityEngine;

namespace Redcode.Tweens.Eases
{
    /// <summary>
    /// Represent sine formula. <see href="https://easings.net/en#easeInSine">See documentation here.</see>
    /// </summary>
    public sealed class InSineEase : Ease
    {
        public override float Remap(float value) => Mathf.Sin((value - 1f) * (Mathf.PI / 2f)) + 1f;
    }
}