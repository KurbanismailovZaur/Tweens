namespace Redcode.Tweens.Eases
{
    public sealed class InOutQuarticFormula : Ease
    {
        public override float Remap(float value)
        {
            if (value < 0.5f) 
                return 8f * value * value * value * value;
            else
            {
                var f = (value - 1f);
                return -8f * f * f * f * f + 1f;
            }
        }
    }
}