using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tweens.Tweaks
{
    public sealed class SByteTweak : Tweak<sbyte>
    {
        protected override sbyte Interpolate(sbyte from, sbyte to, float interpolation) => Lerp.SByte(from, to, interpolation);
    }
}