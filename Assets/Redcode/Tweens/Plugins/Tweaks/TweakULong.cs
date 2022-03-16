namespace Redcode.Tweens.Tweaks
{
    public sealed class TweakULong : Tweak<ulong>
    {
        protected override ulong Interpolate(ulong from, ulong to, float interpolation) => Lerp.ULong(from, to, interpolation);
    }
}