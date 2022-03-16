namespace Redcode.Tweens.Eases
{
    public sealed class InOutCubicFormula : Ease
    {
        public override float Remap(float value)
        {
            if (value < 0.5f) 
                return 4f * value * value * value;
            else
            {
                var f = ((2f * value) - 2f);
                return 0.5f * f * f * f + 1f;
            }
        }
    }
}