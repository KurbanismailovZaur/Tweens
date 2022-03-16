using UnityEngine;

namespace Redcode.Tweens.Eases
{
    public sealed class OutExponentialFormula : Ease
    {
        public override float Remap(float value) => (value == 1f) ? value : 1f - Mathf.Pow(2f, -10f * value);
    }
}