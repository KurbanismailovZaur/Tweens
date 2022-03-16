namespace Redcode.Tweens.Eases
{
    public sealed class InOutQuinticFormula : Ease
    {
        public override float Remap(float value)
        {
            if (value < 0.5f)
                return 16f * value * value * value * value * value;
            else
            {
                var f = ((2f * value) - 2f);
                return 0.5f * f * f * f * f * f + 1f;
            }
        }
    }
}