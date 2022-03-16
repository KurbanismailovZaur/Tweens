namespace Redcode.Tweens.Tweaks
{
    public sealed class TweakInt : Tweak<int>
    {
        protected override int Interpolate(int from, int to, float interpolation) => Lerp.Int(from, to, interpolation);
    }
}