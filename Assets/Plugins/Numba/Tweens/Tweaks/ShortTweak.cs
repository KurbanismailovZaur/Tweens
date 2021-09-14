using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tweens.Tweaks
{
    public sealed class ShortTweak : Tweak<short>
    {
        protected override short Interpolate(short from, short to, float interpolation) => Lerp.Short(from, to, interpolation);
    }
}