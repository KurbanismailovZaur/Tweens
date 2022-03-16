using UnityEngine;

namespace Redcode.Tweens.Eases
{
    public sealed class InOutExponentialFormula : Ease
    {
        public override float Remap(float value)
        {
            if (value == 0f || value == 1f) return value;

            return value < 0.5f ? 0.5f * Mathf.Pow(2f, (20f * value) - 10f) : -0.5f * Mathf.Pow(2f, (-20f * value) + 10f) + 1f;
        }
    }
}