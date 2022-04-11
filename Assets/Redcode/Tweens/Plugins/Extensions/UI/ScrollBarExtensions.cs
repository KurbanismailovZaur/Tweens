using Redcode.Tweens.Tweaks;
using UnityEngine;
using UnityEngine.UI;

namespace Redcode.Tweens
{
    public static class ScrollBarExtensions
	{
		public static Tween<float, TweakFloat> DoValue(this Scrollbar scrollbar, float value, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(scrollbar.value, value, v => scrollbar.value = v, duration, ease, loopsCount, loopType, direction).SetOwner(scrollbar).SetName(scrollbar.name);
		}
	}
}