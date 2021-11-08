using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tweens.Tweaks
{
    public sealed class TweakQuaternion : Tweak<Quaternion>
    {
        protected override Quaternion Interpolate(Quaternion from, Quaternion to, float interpolation) => Lerp.Quaternion(from, to, interpolation);
    }
}