using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tweens.Tweaks
{
    public sealed class ColorTweak : Tweak<Color>
    {
        protected override Color Interpolate(Color from, Color to, float interpolation) => Lerp.Color(from, to, interpolation);
    }
}