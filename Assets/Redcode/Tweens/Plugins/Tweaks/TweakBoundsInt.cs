using UnityEngine;

namespace Redcode.Tweens.Tweaks
{
    /// <summary>
    /// Represent bounds tweak.
    /// </summary>
    public sealed class TweakBoundsInt : Tweak<BoundsInt>
    {
        protected override BoundsInt Interpolate(BoundsInt from, BoundsInt to, float interpolation) => Lerp.BoundsInt(from, to, interpolation);
    }
}