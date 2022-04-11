using UnityEngine;

namespace Redcode.Tweens.Tweaks
{
    /// <summary>
    /// Represent quaternions tweak. You can also set interpolation type.
    /// </summary>
    public sealed class TweakQuaternion : TweakDirectional<Quaternion>
    {
        public TweakQuaternion() => InterpolationType = InterpolationType.Spherical;

        protected override Quaternion Interpolate(Quaternion from, Quaternion to, float interpolation) => Lerp.Quaternion(from, to, interpolation, InterpolationType);
    }
}