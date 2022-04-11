namespace Redcode.Tweens.Eases
{
    /// <summary>
    /// Linear easing.
    /// </summary>
    public sealed class LinearEase : Ease
    {
        public override float Remap(float value) => value;
    }
}