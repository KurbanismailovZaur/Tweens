using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Text;

namespace Tweens.Formulas
{
    public sealed class BackInFormula : FormulaBase
    {
        public override float Remap(float value) => value * value * value - value * Mathf.Sin(value * Mathf.PI);
    }
}