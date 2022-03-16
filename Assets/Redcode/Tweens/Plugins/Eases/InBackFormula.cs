using UnityEngine;

namespace Redcode.Tweens.Eases
{
    public sealed class InBackFormula : Ease
    {
        public override float Remap(float value) => value * value * value - value * Mathf.Sin(value * Mathf.PI);
    }
}