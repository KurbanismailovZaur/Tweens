namespace Redcode.Tweens.Tweaks
{
    /// <summary>
    /// Represent ints tweak.
    /// </summary>
    public sealed class TweakInt : Tweak<int>
    {
        protected override int Interpolate(int from, int to, float interpolation) => Lerp.Int(from, to, interpolation);
    }
}