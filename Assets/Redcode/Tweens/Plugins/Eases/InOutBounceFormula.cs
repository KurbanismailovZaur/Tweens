namespace Redcode.Tweens.Eases
{
    public sealed class InOutBounceFormula : Ease
    {
        public override float Remap(float value)
        {
            if (value < 0.5f)
                return 0.5f * InBounce.Remap(value * 2f);
            else
                return 0.5f * OutBounce.Remap(value * 2f - 1f) + 0.5f;
        }
    }
}