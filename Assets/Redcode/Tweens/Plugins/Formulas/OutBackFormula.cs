using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Text;

namespace Tweens.Formulas
{
    public sealed class OutBackFormula : FormulaBase
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