using UnityEngine;

namespace Redcode.Tweens.Eases
{
    public sealed class InElasticFormula : Ease
    {
        public override float Remap(float value) => Mathf.Sin(13f * (Mathf.PI / 2f) * value) * Mathf.Pow(2f, 10f * (value - 1f));
    }
}