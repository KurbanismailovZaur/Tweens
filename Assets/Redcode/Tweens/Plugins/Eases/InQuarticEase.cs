namespace Redcode.Tweens.Eases
{
    public sealed class InQuarticEase : Ease
    {
        public override float Remap(float value) => value * value * value * value;
    }
}