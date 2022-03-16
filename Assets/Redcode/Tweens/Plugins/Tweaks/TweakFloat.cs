namespace Redcode.Tweens.Tweaks
{
    public sealed class TweakFloat : Tweak<float>
    {
        protected override float Interpolate(float from, float to, float interpolation) => Lerp.Float(from, to, interpolation);
    }
}