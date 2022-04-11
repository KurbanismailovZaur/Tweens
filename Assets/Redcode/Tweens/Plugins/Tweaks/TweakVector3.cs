using UnityEngine;

namespace Redcode.Tweens.Tweaks
{
    /// <summary>
    /// Represent vectors tweak. You can also set interpolation type.
    /// </summary>
    public sealed class TweakVector3 : TweakDirectional<Vector3>
    {
        protected override Vector3 Interpolate(Vector3 from, Vector3 to, float interpolation) => Lerp.Vector3(from, to, interpolation, InterpolationType);
    }
}