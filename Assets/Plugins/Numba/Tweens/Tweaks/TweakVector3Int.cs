using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tweens.Tweaks
{
    public sealed class TweakVector3Int : Tweak<Vector3Int>
    {
        protected override Vector3Int Interpolate(Vector3Int from, Vector3Int to, float interpolation) => Lerp.Vector3Int(from, to, interpolation);
    }
}