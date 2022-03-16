namespace Redcode.Tweens.Tweaks
{
    public sealed class TweakSByte : Tweak<sbyte>
    {
        protected override sbyte Interpolate(sbyte from, sbyte to, float interpolation) => Lerp.SByte(from, to, interpolation);
    }
}