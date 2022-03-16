using UnityEngine;

namespace Redcode.Tweens.Tweaks
{
    public sealed class TweakVector2Int : Tweak<Vector2Int>
    {
        protected override Vector2Int Interpolate(Vector2Int from, Vector2Int to, float interpolation) => Lerp.Vector2Int(from, to, interpolation);
    }
}