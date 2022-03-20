namespace Redcode.Tweens.Eases
{
    public sealed class InBounceEase : Ease
    {
        public override float Remap(float value) => 1f - OutBounce.Remap(1f - value);
    }
}