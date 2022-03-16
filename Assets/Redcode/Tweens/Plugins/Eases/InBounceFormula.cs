namespace Redcode.Tweens.Eases
{
    public sealed class InBounceFormula : Ease
    {
        public override float Remap(float value) => 1f - OutBounce.Remap(1f - value);
    }
}