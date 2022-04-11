namespace Redcode.Tweens.Tweaks
{
    /// <summary>
    /// Represent ushorts tweak.
    /// </summary>
    public sealed class TweakUShort : Tweak<ushort>
    {
        protected override ushort Interpolate(ushort from, ushort to, float interpolation) => Lerp.UShort(from, to, interpolation);
    }
}