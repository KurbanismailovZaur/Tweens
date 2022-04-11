namespace Redcode.Tweens.Tweaks
{
    /// <summary>
    /// Represent chars tweak.
    /// </summary>
    public sealed class TweakChar : Tweak<char>
    {
        protected override char Interpolate(char from, char to, float interpolation) => Lerp.Char(from, to, interpolation);
    }
}