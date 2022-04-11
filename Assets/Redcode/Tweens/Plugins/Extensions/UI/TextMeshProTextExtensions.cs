using Redcode.Tweens.Tweaks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Redcode.Tweens
{
    public static class TextMeshProTextExtensions
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
		public static Tween<float, TweakFloat> DoFontSize(this TextMeshProUGUI text, int size, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(text.fontSize, size, fs => text.fontSize = fs, duration, ease, loopsCount, loopType, direction).SetOwner(text).SetName(text.name);
		}

		#region Spacing
		/// <summary>
		/// Tweens text's character spacing.
		/// </summary>
		/// <param name="text">Target text.</param>
		/// <param name="spacing">Target character spacing.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<float, TweakFloat> DoCharacterSpacing(this TextMeshProUGUI text, float spacing, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(text.characterSpacing, spacing, cs => text.characterSpacing = cs, duration, ease, loopsCount, loopType, direction).SetOwner(text).SetName(text.name);
		}

		/// <summary>
		/// Tweens text's line spacing.
		/// </summary>
		/// <param name="text">Target text.</param>
		/// <param name="spacing">Target line spacing.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<float, TweakFloat> DoLineSpacing(this TextMeshProUGUI text, float spacing, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(text.lineSpacing, spacing, ls => text.lineSpacing = ls, duration, ease, loopsCount, loopType, direction).SetOwner(text).SetName(text.name);
		}

		/// <summary>
		/// Tweens text's word spacing.
		/// </summary>
		/// <param name="text">Target text.</param>
		/// <param name="spacing">Target word spacing.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<float, TweakFloat> DoWordSpacing(this TextMeshProUGUI text, float spacing, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(text.wordSpacing, spacing, ws => text.wordSpacing = ws, duration, ease, loopsCount, loopType, direction).SetOwner(text).SetName(text.name);
		}

		/// <summary>
		/// Tweens text's paragraph spacing.
		/// </summary>
		/// <param name="text">Target text.</param>
		/// <param name="spacing">Target paragraph spacing.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<float, TweakFloat> DoParagraphSpacing(this TextMeshProUGUI text, float spacing, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(text.paragraphSpacing, spacing, ps => text.paragraphSpacing = ps, duration, ease, loopsCount, loopType, direction).SetOwner(text).SetName(text.name);
		}
		#endregion

		/// <summary>
		/// Tweens text's character spacing.
		/// </summary>
		/// <param name="text">Target text.</param>
		/// <param name="margin">Target margin.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Vector4, TweakVector4> DoMargin(this TextMeshProUGUI text, Vector4 margin, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Vector4(text.margin, margin, m => text.margin = m, duration, ease, loopsCount, loopType, direction).SetOwner(text).SetName(text.name);
		}
	}
}