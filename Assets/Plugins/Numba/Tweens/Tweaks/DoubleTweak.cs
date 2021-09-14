using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tweens.Tweaks
{
    public sealed class DoubleTweak : Tweak<double>
    {
        protected override double Interpolate(double from, double to, float interpolation) => Lerp.Double(from, to, interpolation);
    }
}