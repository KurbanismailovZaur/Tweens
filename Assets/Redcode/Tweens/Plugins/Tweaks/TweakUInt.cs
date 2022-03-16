namespace Redcode.Tweens.Tweaks
{
    public sealed class TweakUInt : Tweak<uint>
    {
        protected override uint Interpolate(uint from, uint to, float interpolation) => Lerp.UInt(from, to, interpolation);
    }
}