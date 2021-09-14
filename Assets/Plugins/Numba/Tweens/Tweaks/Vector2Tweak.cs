using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tweens.Tweaks
{
    public sealed class Vector2Tweak : Tweak<Vector2>
    {
        protected override Vector2 Interpolate(Vector2 from, Vector2 to, float interpolation) => Lerp.Vector2(from, to, interpolation);
    }
}