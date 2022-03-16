namespace Redcode.Tweens.Tweaks
{
    public sealed class TweakUShort : Tweak<ushort>
    {
        protected override ushort Interpolate(ushort from, ushort to, float interpolation) => Lerp.UShort(from, to, interpolation);
    }
}