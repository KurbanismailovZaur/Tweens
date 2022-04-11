namespace Redcode.Tweens.Tweaks
{
    /// <summary>
    /// Represent longs tweak.
    /// </summary>
    public sealed class TweakLong : Tweak<long>
    {
        protected override long Interpolate(long from, long to, float interpolation) => Lerp.Long(from, to, interpolation);
    }
}