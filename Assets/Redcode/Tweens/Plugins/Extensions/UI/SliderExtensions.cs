using Redcode.Tweens.Tweaks;
using UnityEngine;
using UnityEngine.UI;

namespace Redcode.Tweens
{
    public static class SliderExtensions
	{
		/// <summary>
		/// Tweens slider's value.
		/// </summary>
		/// <param name="slider">Target slider.</param>
		/// <param name="value">Target value.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<float, TweakFloat> DoValue(this Slider slider, float value, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(slider.value, value, v => slider.value = v, duration, ease, loopsCount, loopType, direction).SetOwner(slider).SetName(slider.name);
		}
	}
}