namespace Redcode.Tweens.Eases
{
    public sealed class InQuarticFormula : Ease
    {
        public override float Remap(float value) => value * value * value * value;
    }
}