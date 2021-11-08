using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tweens.Tweaks
{
    public sealed class TweakULong : Tweak<ulong>
    {
        protected override ulong Interpolate(ulong from, ulong to, float interpolation) => Lerp.ULong(from, to, interpolation);
    }
}