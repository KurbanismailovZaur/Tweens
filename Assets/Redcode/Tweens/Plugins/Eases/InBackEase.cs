using UnityEngine;

namespace Redcode.Tweens.Eases
{
    public sealed class InBackEase : Ease
    {
        public override float Remap(float value) => value * value * value - value * Mathf.Sin(value * Mathf.PI);
    }
}