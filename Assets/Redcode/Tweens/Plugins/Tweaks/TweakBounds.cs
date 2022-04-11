using UnityEngine;

namespace Redcode.Tweens.Tweaks
{
    /// <summary>
    /// Represent bounds tweak.
    /// </summary>
    public sealed class TweakBounds : Tweak<Bounds>
    {
        protected override Bounds Interpolate(Bounds from, Bounds to, float interpolation) => Lerp.Bounds(from, to, interpolation);
    }
}