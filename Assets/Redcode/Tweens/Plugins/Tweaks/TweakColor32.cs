using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tweens.Tweaks
{
    public sealed class TweakColor32 : Tweak<Color32>
    {
        protected override Color32 Interpolate(Color32 from, Color32 to, float interpolation) => Lerp.Color32(from, to, interpolation);
    }
}