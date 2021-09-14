using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tweens.Tweaks
{
    public sealed class Vector2IntTweak : Tweak<Vector2Int>
    {
        protected override Vector2Int Interpolate(Vector2Int from, Vector2Int to, float interpolation) => Lerp.Vector2Int(from, to, interpolation);
    }
}