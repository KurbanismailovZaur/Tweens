using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Text;

namespace Tweens.Formulas
{
    public sealed class InOutCircularFormula : FormulaBase
    {
        public override float Remap(float value)
        {
            if (value < 0.5f)
                return 0.5f * (1f - Mathf.Sqrt(1f - 4f * (value * value)));
            else
                return 0.5f * (Mathf.Sqrt(-((2f * value) - 3f) * ((2f * value) - 1f)) + 1f);
        }
    }
}