using UnityEngine;

namespace Redcode.Tweens.Eases
{
    public sealed class OutCircularFormula : Ease
    {
        public override float Remap(float value) => Mathf.Sqrt((2f - value) * value);
    }
}