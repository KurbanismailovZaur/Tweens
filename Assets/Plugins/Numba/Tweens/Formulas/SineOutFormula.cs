using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Text;

namespace Tweens.Formulas
{
    public sealed class SineOutFormula : FormulaBase
    {
        public override float Remap(float value) => Mathf.Sin(value * (Mathf.PI / 2f));
    }
}