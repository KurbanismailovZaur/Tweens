using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tweens.Tweaks
{
    public sealed class BoundsTweak : Tweak<Bounds>
    {
        protected override Bounds Interpolate(Bounds from, Bounds to, float interpolation) => Lerp.Bounds(from, to, interpolation);
    }
}