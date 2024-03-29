using System;

namespace Redcode.Tweens.Tweaks
{
    /// <summary>
    /// Represent decimals tweak.
    /// </summary>
    public sealed class TweakDecimal : Tweak<Decimal>
    {
        protected override decimal Interpolate(decimal from, decimal to, float interpolation) => Lerp.Decimal(from, to, interpolation);
    }
}