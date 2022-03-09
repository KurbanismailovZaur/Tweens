using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tweens.Tweaks
{
    public sealed class TweakDecimal : Tweak<Decimal>
    {
        protected override decimal Interpolate(decimal from, decimal to, float interpolation) => Lerp.Decimal(from, to, interpolation);
    }
}