using UnityEngine;

namespace Redcode.Tweens.Eases
{
    public sealed class InSineFormula : Ease
    {
        public override float Remap(float value) => Mathf.Sin((value - 1f) * (Mathf.PI / 2f)) + 1f;
    }
}