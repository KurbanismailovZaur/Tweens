namespace Redcode.Tweens.Eases
{
    public sealed class InQuadraticFormula : Ease
    {
        public override float Remap(float value) => value * value;
    }
}