using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Text;

namespace Tweens.Formulas
{
    public sealed class InOutQuadraticFormula : FormulaBase
    {
        public override float Remap(float value) => (value < 0.5f ? 2f * value * value : (-2f * value * value + (4f * value) - 1f));
    }
}