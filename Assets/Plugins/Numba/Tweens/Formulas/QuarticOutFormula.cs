using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Text;

namespace Tweens.Formulas
{
    public sealed class QuarticOutFormula : FormulaBase
    {
        public override float Remap(float value)
        {
            var f = (value - 1f);
            return f * f * f * (1f - value) + 1f;
        }
    }
}