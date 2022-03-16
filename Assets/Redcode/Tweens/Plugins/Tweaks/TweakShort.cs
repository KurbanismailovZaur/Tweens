namespace Redcode.Tweens.Tweaks
{
    public sealed class TweakShort : Tweak<short>
    {
        protected override short Interpolate(short from, short to, float interpolation) => Lerp.Short(from, to, interpolation);
    }
}