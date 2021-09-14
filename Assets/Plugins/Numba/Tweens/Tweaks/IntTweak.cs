using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tweens.Tweaks
{
    public sealed class IntTweak : Tweak<int>
    {
        protected override int Interpolate(int from, int to, float interpolation) => Lerp.Int(from, to, interpolation);
    }
}