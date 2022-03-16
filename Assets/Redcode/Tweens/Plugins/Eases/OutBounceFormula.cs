namespace Redcode.Tweens.Eases
{
    public sealed class OutBounceFormula : Ease
    {
        public override float Remap(float value)
        {
            if (value < 4f / 11f)
                return (121f * value * value) / 16f;
            else if (value < 8f / 11f)
                return (363f / 40f * value * value) - (99f / 10f * value) + 17f / 5f;
            else if (value < 9f / 10f)
                return (4356f / 361f * value * value) - (35442f / 1805f * value) + 16061f / 1805f;
            else
                return (54f / 5f * value * value) - (513f / 25f * value) + 268f / 25f;
        }
    }
}