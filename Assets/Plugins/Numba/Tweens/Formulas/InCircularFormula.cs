using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Text;

namespace Tweens.Formulas
{
    public sealed class InCircularFormula : FormulaBase
    {
        public override float Remap(float value) => 1f - Mathf.Sqrt(1f - (value * value));
    }
}