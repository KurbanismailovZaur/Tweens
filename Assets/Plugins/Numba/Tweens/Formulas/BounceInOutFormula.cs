using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Text;

namespace Tweens.Formulas
{
    public sealed class BounceInOutFormula : FormulaBase
    {
        public override float Remap(float value)
        {
            if (value < 0.5f)
                return 0.5f * Formula.BounceIn.Remap(value * 2f);
            else
                return 0.5f * Formula.BounceOut.Remap(value * 2f - 1f) + 0.5f;
        }
    }
}