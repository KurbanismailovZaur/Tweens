namespace Redcode.Tweens.Tweaks
{
    /// <summary>
    /// Represent doubles tweak.
    /// </summary>
    public sealed class TweakDouble : Tweak<double>
    {
        protected override double Interpolate(double from, double to, float interpolation) => Lerp.Double(from, to, interpolation);
    }
}