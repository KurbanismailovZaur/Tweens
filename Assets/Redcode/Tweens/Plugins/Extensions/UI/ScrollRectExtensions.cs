using Redcode.Tweens.Tweaks;
using UnityEngine;
using UnityEngine.UI;

namespace Redcode.Tweens
{
    public static class ScrollRectExtensions
	{
		/// <summary>
		/// Tweens scrollRect's horizontal normalized position.
		/// </summary>
		/// <param name="scrollRect">Target scrollRect.</param>
		/// <param name="normalizedPosition">Target normalized horizontal position.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<float, TweakFloat> DoHorizontalNormalizedPosition(this ScrollRect scrollRect, float normalizedPosition, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(scrollRect.horizontalNormalizedPosition, normalizedPosition, np => scrollRect.horizontalNormalizedPosition = np, duration, ease, loopsCount, loopType, direction).SetOwner(scrollRect).SetName(scrollRect.name);
		}

		/// <summary>
		/// Tweens scrollRect's vertical normalized position.
		/// </summary>
		/// <param name="scrollRect">Target scrollRect.</param>
		/// <param name="normalizedPosition">Target normalized vertical position.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<float, TweakFloat> DoVerticalNormalizedPosition(this ScrollRect scrollRect, float normalizedPosition, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(scrollRect.verticalNormalizedPosition, normalizedPosition, np => scrollRect.verticalNormalizedPosition = np, duration, ease, loopsCount, loopType, direction).SetOwner(scrollRect).SetName(scrollRect.name);
		}
	}
}