using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Text;

namespace Tweens.Formulas
{
    public sealed class SineInFormula : FormulaBase
    {
        public override float Remap(float value) => Mathf.Sin((value - 1f) * (Mathf.PI / 2f)) + 1f;
    }
}