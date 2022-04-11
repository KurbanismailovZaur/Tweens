using UnityEngine;

namespace Redcode.Tweens.Tweaks
{
    /// <summary>
    /// Represent vectors tweak.
    /// </summary>
    public sealed class TweakVector2 : Tweak<Vector2>
    {
        protected override Vector2 Interpolate(Vector2 from, Vector2 to, float interpolation) => Lerp.Vector2(from, to, interpolation);
    }
}