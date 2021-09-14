using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Text;

namespace Tweens.Formulas
{
    public sealed class QuinticInOutFormula : FormulaBase
    {
        public override float Remap(float value)
        {
            if (value < 0.5f)
                return 16f * value * value * value * value * value;
            else
            {
                var f = ((2f * value) - 2f);
                return 0.5f * f * f * f * f * f + 1f;
            }
        }
    }
}