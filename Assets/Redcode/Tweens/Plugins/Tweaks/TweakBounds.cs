using UnityEngine;

namespace Redcode.Tweens.Tweaks
{
    public sealed class TweakBounds : Tweak<Bounds>
    {
        protected override Bounds Interpolate(Bounds from, Bounds to, float interpolation) => Lerp.Bounds(from, to, interpolation);
    }
}