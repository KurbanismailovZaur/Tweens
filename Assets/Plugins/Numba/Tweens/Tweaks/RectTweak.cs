using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tweens.Tweaks
{
    public sealed class RectTweak : Tweak<Rect>
    {
        protected override Rect Interpolate(Rect from, Rect to, float interpolation) => Lerp.Rect(from, to, interpolation);
    }
}