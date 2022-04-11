namespace Redcode.Tweens.Eases
{
    /// <summary>
    /// Represent quartic formula. <see href="https://easings.net/en#easeInQuart">See documentation here.</see>
    /// </summary>
    public sealed class InQuarticEase : Ease
    {
        public override float Remap(float value) => value * value * value * value;
    }
}