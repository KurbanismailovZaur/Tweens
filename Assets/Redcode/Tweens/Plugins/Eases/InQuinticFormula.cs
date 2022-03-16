namespace Redcode.Tweens.Eases
{
    public sealed class InQuinticFormula : Ease
    {
        public override float Remap(float value) => value * value * value * value * value;
    }
}