using Redcode.Tweens.Tweaks;
using UnityEngine;
using UnityEngine.UI;

namespace Redcode.Tweens
{
    public static class TextExtensions
	{
		/// <summary>
		/// Tweens text's size.
		/// </summary>
		/// <param name="text">Target text.</param>
		/// <param name="size">Target size.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<int, TweakInt> DoFontSize(this Text text, int size, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Int(text.fontSize, size, fs => text.fontSize = fs, duration, ease, loopsCount, loopType, direction).SetOwner(text).SetName(text.name);
		}

		/// <summary>
		/// Tweens text's spacing.
		/// </summary>
		/// <param name="text">Target text.</param>
		/// <param name="spacing">Target spacing.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<float, TweakFloat> DoLineSpacing(this Text text, float spacing, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(text.lineSpacing, spacing, ls => text.lineSpacing = ls, duration, ease, loopsCount, loopType, direction).SetOwner(text).SetName(text.name);
		}
	}
}