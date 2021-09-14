using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tweens.Tweaks
{
    public sealed class UShortTweak : Tweak<ushort>
    {
        protected override ushort Interpolate(ushort from, ushort to, float interpolation) => Lerp.UShort(from, to, interpolation);
    }
}