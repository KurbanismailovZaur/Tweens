namespace Redcode.Tweens.Eases
{
    /// <summary>
    /// Represent quintic formula. <see href="https://easings.net/en#easeInQuint">See documentation here.</see>
    /// </summary>
    public sealed class InQuinticEase : Ease
    {
        public override float Remap(float value) => value * value * value * value * value;
    }
}