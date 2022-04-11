namespace Redcode.Tweens.Tweaks
{
    /// <summary>
    /// Represent bytes tweak.
    /// </summary>
    public sealed class TweakByte : Tweak<byte>
    {
        protected override byte Interpolate(byte from, byte to, float interpolation) => Lerp.Byte(from, to, interpolation);
    }
}