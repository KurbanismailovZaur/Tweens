using UnityEngine;

namespace Redcode.Tweens.Tweaks
{
    public sealed class TweakRect : Tweak<Rect>
    {
        protected override Rect Interpolate(Rect from, Rect to, float interpolation) => Lerp.Rect(from, to, interpolation);
    }
}