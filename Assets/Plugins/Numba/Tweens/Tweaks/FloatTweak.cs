using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tweens.Tweaks
{
    public sealed class FloatTweak : Tweak<float>
    {
        protected override float Interpolate(float from, float to, float interpolation) => Lerp.Float(from, to, interpolation);
    }
}