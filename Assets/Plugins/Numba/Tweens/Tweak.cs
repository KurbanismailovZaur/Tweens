using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Extensions;
using Object = UnityEngine.Object;
using Coroutine = Coroutines.Coroutine;
using Tweens.Formulas;

namespace Tweens
{
    public abstract class Tweak<T> where T : struct
    {
        public T Evaluate(T from, T to, float interpolation, FormulaBase formula = null) => Interpolate(from, to, formula?.Remap(interpolation) ?? interpolation);

        protected abstract T Interpolate(T from, T to, float interpolation);

        public void Apply(T from, T to, float interpolation, Action<T> action, FormulaBase formula = null) => action(Evaluate(from, to, interpolation, formula));
    }
}