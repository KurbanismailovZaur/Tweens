using UnityEngine;

namespace Redcode.Tweens.Tweaks
{
    /// <summary>
    /// Represent bounding spheres tweak.
    /// </summary>
    public sealed class TweakBoundingSphere : Tweak<BoundingSphere>
    {
        protected override BoundingSphere Interpolate(BoundingSphere from, BoundingSphere to, float interpolation) => Lerp.BoundingSphere(from, to, interpolation);
    }
}