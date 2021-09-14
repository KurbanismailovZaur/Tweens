using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tweens.Tweaks
{
    public sealed class Vector4Tweak : Tweak<Vector4>
    {
        protected override Vector4 Interpolate(Vector4 from, Vector4 to, float interpolation) => Lerp.Vector4(from, to, interpolation);
    }
}