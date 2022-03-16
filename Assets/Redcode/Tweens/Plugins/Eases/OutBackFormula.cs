using UnityEngine;

namespace Redcode.Tweens.Eases
{
    public sealed class OutBackFormula : Ease
    {
        public override float Remap(float value)
        {
            if (value == 0f)
                return 0f;
                
            var f = (1f - value);
            return 1f - (f * f * f - f * Mathf.Sin(f * Mathf.PI));
        }
    }
}