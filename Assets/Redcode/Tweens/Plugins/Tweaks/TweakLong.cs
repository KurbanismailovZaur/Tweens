namespace Redcode.Tweens.Tweaks
{
    public sealed class TweakLong : Tweak<long>
    {
        protected override long Interpolate(long from, long to, float interpolation) => Lerp.Long(from, to, interpolation);
    }
}