namespace Redcode.Tweens.Eases
{
    public sealed class OutCubicFormula : Ease
    {
        public override float Remap(float value)
        {
            var f = value - 1f; 
            return f * f * f + 1f;
        }
    }
}