namespace Redcode.Tweens.Eases
{
    public sealed class OutQuadraticEase : Ease
    {
        public override float Remap(float value) => -(value * (value - 2f));
    }
}