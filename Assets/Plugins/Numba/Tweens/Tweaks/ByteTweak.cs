using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tweens.Tweaks
{
    public sealed class ByteTweak : Tweak<byte>
    {
        protected override byte Interpolate(byte from, byte to, float interpolation) => Lerp.Byte(from, to, interpolation);
    }
}