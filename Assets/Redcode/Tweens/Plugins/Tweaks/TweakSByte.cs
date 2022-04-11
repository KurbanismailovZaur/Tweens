namespace Redcode.Tweens.Tweaks
{
    /// <summary>
    /// Represent sbytes tweak.
    /// </summary>
    public sealed class TweakSByte : Tweak<sbyte>
    {
        protected override sbyte Interpolate(sbyte from, sbyte to, float interpolation) => Lerp.SByte(from, to, interpolation);
    }
}