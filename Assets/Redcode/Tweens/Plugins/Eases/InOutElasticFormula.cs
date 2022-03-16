using UnityEngine;

namespace Redcode.Tweens.Eases
{
    public sealed class InOutElasticFormula : Ease
    {
        public override float Remap(float value)
        {
            if (value < 0.5f)
                return 0.5f * Mathf.Sin(13f * (Mathf.PI / 2f) * (2f * value)) * Mathf.Pow(2f, 10f * ((2f * value) - 1f));
            else
                return 0.5f * (Mathf.Sin(-13f * (Mathf.PI / 2f) * ((2f * value - 1f) + 1f)) * Mathf.Pow(2f, -10f * (2f * value - 1f)) + 2f);
        }
    }
}