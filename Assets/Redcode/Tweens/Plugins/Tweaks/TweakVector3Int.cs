using UnityEngine;

namespace Redcode.Tweens.Tweaks
{
    /// <summary>
    /// Represent vectors tweak.
    /// </summary>
    public sealed class TweakVector3Int : Tweak<Vector3Int>
    {
        protected override Vector3Int Interpolate(Vector3Int from, Vector3Int to, float interpolation) => Lerp.Vector3Int(from, to, interpolation);
    }
}