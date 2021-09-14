using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Text;

namespace Tweens.Formulas
{
    public sealed class BackInOutFormula : FormulaBase
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