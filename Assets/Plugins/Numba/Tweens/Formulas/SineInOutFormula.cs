using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Text;

namespace Tweens.Formulas
{
    public sealed class SineInOutFormula : FormulaBase
    {
        public override float Remap(float value) => 0.5f * (1f - Mathf.Cos(value * Mathf.PI));
    }
}