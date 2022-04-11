using Redcode.Tweens.Tweaks;
using UnityEngine;
using UnityEngine.UI;

namespace Redcode.Tweens
{
    public static class SliderExtensions
	{
		public static Tween<float, TweakFloat> DoValue(this Slider slider, float value, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(slider.value, value, v => slider.value = v, duration, ease, loopsCount, loopType, direction).SetOwner(slider).SetName(slider.name);
		}
	}
}