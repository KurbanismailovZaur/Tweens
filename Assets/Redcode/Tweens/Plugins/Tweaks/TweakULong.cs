namespace Redcode.Tweens.Tweaks
{
    /// <summary>
    /// Represent ulongs tweak.
    /// </summary>
    public sealed class TweakULong : Tweak<ulong>
    {
        protected override ulong Interpolate(ulong from, ulong to, float interpolation) => Lerp.ULong(from, to, interpolation);
    }
}