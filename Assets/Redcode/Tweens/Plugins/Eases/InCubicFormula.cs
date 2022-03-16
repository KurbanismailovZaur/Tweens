namespace Redcode.Tweens.Eases
{
    public sealed class InCubicFormula : Ease
    {
        public override float Remap(float value) => value * value * value;
    }
}