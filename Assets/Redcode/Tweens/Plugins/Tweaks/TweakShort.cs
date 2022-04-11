namespace Redcode.Tweens.Tweaks
{
    /// <summary>
    /// Represent shorts tweak.
    /// </summary>
    public sealed class TweakShort : Tweak<short>
    {
        protected override short Interpolate(short from, short to, float interpolation) => Lerp.Short(from, to, interpolation);
    }
}