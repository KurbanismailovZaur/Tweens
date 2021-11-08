using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Text;

namespace Tweens.Formulas
{
    public sealed class OutExponentialFormula : FormulaBase
    {
        public override float Remap(float value) => (value == 1f) ? value : 1f - Mathf.Pow(2f, -10f * value);
    }
}