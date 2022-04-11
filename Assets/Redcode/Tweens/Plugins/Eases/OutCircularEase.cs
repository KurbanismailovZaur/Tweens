using UnityEngine;

namespace Redcode.Tweens.Eases
{
    /// <summary>
    /// Represent sine formula. <see href="https://easings.net/en#easeOutCirc">See documentation here.</see>
    /// </summary>
    public sealed class OutCircularEase : Ease
    {
        public override float Remap(float value) => Mathf.Sqrt((2f - value) * value);
    }
}