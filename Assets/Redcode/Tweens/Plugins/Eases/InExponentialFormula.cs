using UnityEngine;

namespace Redcode.Tweens.Eases
{
    public sealed class InExponentialFormula : Ease
    {
        public override float Remap(float value) => (value == 0f) ? value : Mathf.Pow(2f, 10f * (value - 1f));
    }
}