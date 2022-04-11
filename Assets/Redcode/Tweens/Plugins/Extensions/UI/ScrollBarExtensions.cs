using Redcode.Tweens.Tweaks;
using UnityEngine;
using UnityEngine.UI;

namespace Redcode.Tweens
{
    public static class ScrollBarExtensions
	{
		/// <summary>
		/// Tweens scrollbar's value.
		/// </summary>
		/// <param name="scrollbar">Target scrollbar.</param>
		/// <param name="value">Target value.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<float, TweakFloat> DoValue(this Scrollbar scrollbar, float value, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(scrollbar.value, value, v => scrollbar.value = v, duration, ease, loopsCount, loopType, direction).SetOwner(scrollbar).SetName(scrollbar.name);
		}
	}
}