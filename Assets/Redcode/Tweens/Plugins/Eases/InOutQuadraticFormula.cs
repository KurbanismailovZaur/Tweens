namespace Redcode.Tweens.Eases
{
    public sealed class InOutQuadraticFormula : Ease
    {
        public override float Remap(float value) => (value < 0.5f ? 2f * value * value : (-2f * value * value + (4f * value) - 1f));
    }
}