namespace Redcode.Tweens.Eases
{
    public sealed class InQuinticEase : Ease
    {
        public override float Remap(float value) => value * value * value * value * value;
    }
}