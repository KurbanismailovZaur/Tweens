using Redcode.Tweens.Tweaks;
using UnityEngine;

namespace Redcode.Tweens
{
    public static class CanvasGroupExtensions
	{
		/// <summary>
		/// Tweens canvas group's alpha value.
		/// </summary>
		/// <param name="group">Canvas group.</param>
		/// <param name="alpha">Target alpha.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<float, TweakFloat> DoAlpha(this CanvasGroup group, float alpha, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(group.alpha, alpha, a => group.alpha = a, duration, ease, loopsCount, loopType, direction);
		}
	}
}