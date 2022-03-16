namespace Redcode.Tweens.Tweaks
{
    public sealed class TweakDouble : Tweak<double>
    {
        protected override double Interpolate(double from, double to, float interpolation) => Lerp.Double(from, to, interpolation);
    }
}