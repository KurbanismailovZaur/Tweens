using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Text;

namespace Tweens.Formulas
{
    public sealed class ElasticOutFormula : FormulaBase
    {
        public override float Remap(float value) => Mathf.Sin(-13f * (Mathf.PI / 2f) * (value + 1f)) * Mathf.Pow(2f, -10f * value) + 1f;
    }
}