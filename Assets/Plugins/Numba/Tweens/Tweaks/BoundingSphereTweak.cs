using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tweens.Tweaks
{
    public sealed class BoundingSphereTweak : Tweak<BoundingSphere>
    {
        protected override BoundingSphere Interpolate(BoundingSphere from, BoundingSphere to, float interpolation) => Lerp.BoundingSphere(from, to, interpolation);
    }
}