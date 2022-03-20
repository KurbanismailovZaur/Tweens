using UnityEngine;

namespace Redcode.Tweens.Eases
{
    public sealed class InOutSineEase : Ease
    {
        public override float Remap(float value) => 0.5f * (1f - Mathf.Cos(value * Mathf.PI));
    }
}