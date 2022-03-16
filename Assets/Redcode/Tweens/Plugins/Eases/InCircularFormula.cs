using UnityEngine;

namespace Redcode.Tweens.Eases
{
    public sealed class InCircularFormula : Ease
    {
        public override float Remap(float value) => 1f - Mathf.Sqrt(1f - (value * value));
    }
}