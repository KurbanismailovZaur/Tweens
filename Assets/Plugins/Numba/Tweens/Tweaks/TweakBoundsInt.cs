using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tweens.Tweaks
{
    public sealed class TweakBoundsInt : Tweak<BoundsInt>
    {
        protected override BoundsInt Interpolate(BoundsInt from, BoundsInt to, float interpolation) => Lerp.BoundsInt(from, to, interpolation);
    }
}