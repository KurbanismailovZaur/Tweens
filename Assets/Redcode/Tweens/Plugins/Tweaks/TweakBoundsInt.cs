using UnityEngine;

namespace Redcode.Tweens.Tweaks
{
    public sealed class TweakBoundsInt : Tweak<BoundsInt>
    {
        protected override BoundsInt Interpolate(BoundsInt from, BoundsInt to, float interpolation) => Lerp.BoundsInt(from, to, interpolation);
    }
}