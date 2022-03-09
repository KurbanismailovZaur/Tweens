using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tweens.Tweaks
{
    public sealed class TweakLong : Tweak<long>
    {
        protected override long Interpolate(long from, long to, float interpolation) => Lerp.Long(from, to, interpolation);
    }
}