using UnityEngine;

namespace Redcode.Tweens.Tweaks
{
    /// <summary>
    /// Represent colors tweak.
    /// </summary>
    public sealed class TweakColor : Tweak<Color>
    {
        protected override Color Interpolate(Color from, Color to, float interpolation) => Lerp.Color(from, to, interpolation);
    }
}