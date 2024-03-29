namespace Redcode.Tweens.Tweaks
{
    /// <summary>
    /// Represent floats tweak.
    /// </summary>
    public sealed class TweakFloat : Tweak<float>
    {
        protected override float Interpolate(float from, float to, float interpolation) => Lerp.Float(from, to, interpolation);
    }
}