using UnityEngine;

namespace Redcode.Tweens.Eases
{
    public sealed class InOutBackFormula : Ease
    {
        public override float Remap(float value)
        {
            if (value < 0.5f)
            {
                var f = 2f * value;
                return 0.5f * (f * f * f - f * Mathf.Sin(f * Mathf.PI));
            }
            else
            {
                var f = (1f - (2f * value - 1f));
                return 0.5f * (1f - (f * f * f - f * Mathf.Sin(f * Mathf.PI))) + 0.5f;
            }
        }
    }
}