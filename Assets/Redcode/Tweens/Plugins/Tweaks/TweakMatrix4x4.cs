using UnityEngine;

namespace Redcode.Tweens.Tweaks
{
    /// <summary>
    /// Represent matrixes tweak.
    /// </summary>
    public sealed class TweakMatrix4x4 : Tweak<Matrix4x4>
    {
        protected override Matrix4x4 Interpolate(Matrix4x4 from, Matrix4x4 to, float interpolation) => Lerp.Matrix4x4(from, to, interpolation);
    }
}