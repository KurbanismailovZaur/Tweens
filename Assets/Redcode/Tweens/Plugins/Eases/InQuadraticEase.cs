namespace Redcode.Tweens.Eases
{
    public sealed class InQuadraticEase : Ease
    {
        public override float Remap(float value) => value * value;
    }
}