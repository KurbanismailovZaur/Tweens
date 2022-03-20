namespace Redcode.Tweens.Eases
{
    public sealed class OutQuinticEase : Ease
    {
        public override float Remap(float value)
        {
            var f = (value - 1f);
            return f * f * f * f * f + 1f;
        }
    }
}