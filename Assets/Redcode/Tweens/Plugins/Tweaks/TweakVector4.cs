using UnityEngine;

namespace Redcode.Tweens.Tweaks
{
    public sealed class TweakVector4 : Tweak<Vector4>
    {
        protected override Vector4 Interpolate(Vector4 from, Vector4 to, float interpolation) => Lerp.Vector4(from, to, interpolation);
    }
}