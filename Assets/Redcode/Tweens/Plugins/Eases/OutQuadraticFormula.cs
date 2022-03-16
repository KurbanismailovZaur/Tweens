namespace Redcode.Tweens.Eases
{
    public sealed class OutQuadraticFormula : Ease
    {
        public override float Remap(float value) => -(value * (value - 2f));
    }
}