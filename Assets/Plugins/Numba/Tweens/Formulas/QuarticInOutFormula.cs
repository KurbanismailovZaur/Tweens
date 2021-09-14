using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Text;

namespace Tweens.Formulas
{
    public sealed class QuarticInOutFormula : FormulaBase
    {
        public override float Remap(float value)
        {
            if (value < 0.5f) 
                return 8f * value * value * value * value;
            else
            {
                var f = (value - 1f);
                return -8f * f * f * f * f + 1f;
            }
        }
    }
}