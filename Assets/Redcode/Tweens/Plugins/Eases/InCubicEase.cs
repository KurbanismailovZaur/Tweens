namespace Redcode.Tweens.Eases
{
    public sealed class InCubicEase : Ease
    {
        public override float Remap(float value) => value * value * value;
    }
}