using Redcode.Tweens.Tweaks;
using UnityEngine;
using UnityEngine.UI;

namespace Redcode.Tweens
{
    public static class SliderExtensions
	{
		#region DoValue
		public static Tween<float, TweakFloat> DoValue(this Slider slider, float value, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return DoValue(slider, slider.gameObject, value, duration, formula, loopsCount, loopType, direction);
		}

		public static Tween<float, TweakFloat> DoValue(this Slider slider, GameObject owner, float value, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(owner, owner.name, slider.value, value, v => slider.value = v, duration, formula, loopsCount, loopType, direction);
		}
		#endregion
	}
}