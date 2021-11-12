using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tweens.Tweaks
{
    public sealed class TweakVector3 : TweakDirectional<Vector3>
    {
        protected override Vector3 Interpolate(Vector3 from, Vector3 to, float interpolation) => Lerp.Vector3(from, to, interpolation, InterpolationType);
    }
}