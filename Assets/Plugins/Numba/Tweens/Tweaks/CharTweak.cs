using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tweens.Tweaks
{
    public sealed class CharTweak : Tweak<char>
    {
        protected override char Interpolate(char from, char to, float interpolation) => Lerp.Char(from, to, interpolation);
    }
}