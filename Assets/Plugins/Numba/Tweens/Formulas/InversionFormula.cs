using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Extensions;
using Object = UnityEngine.Object;
using Coroutine = Coroutines.Coroutine;

namespace Tweens.Formulas
{
    internal sealed class InversionFormula : FormulaBase
    {
        internal FormulaBase Formula { get; set; }

        public override float Remap(float interpolation) => 1f - Formula.Remap(1f - interpolation);

        public InversionFormula WithFormula(FormulaBase formula)
        {
            Formula = formula;
            return this;
        }
    }
}