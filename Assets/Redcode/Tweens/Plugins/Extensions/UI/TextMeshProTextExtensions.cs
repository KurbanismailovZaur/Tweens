using Redcode.Tweens.Tweaks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Redcode.Tweens
{
    public static class TextMeshProTextExtensions
	{
		#region DoFontSize
		public static Tween<float, TweakFloat> DoFontSize(this TextMeshProUGUI text, int size, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return DoFontSize(text, text.gameObject, size, duration, formula, loopsCount, loopType, direction);
		}

		public static Tween<float, TweakFloat> DoFontSize(this TextMeshProUGUI text, GameObject owner, int size, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(owner, owner.name, text.fontSize, size, fs => text.fontSize = fs, duration, formula, loopsCount, loopType, direction);
		}
		#endregion

		#region Spacing
		#region DoCharacterSpacing
		public static Tween<float, TweakFloat> DoCharacterSpacing(this TextMeshProUGUI text, float spacing, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return DoCharacterSpacing(text, text.gameObject, spacing, duration, formula, loopsCount, loopType, direction);
		}

		public static Tween<float, TweakFloat> DoCharacterSpacing(this TextMeshProUGUI text, GameObject owner, float spacing, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(owner, owner.name, text.characterSpacing, spacing, cs => text.characterSpacing = cs, duration, formula, loopsCount, loopType, direction);
		}
		#endregion

		#region DoLineSpacing
		public static Tween<float, TweakFloat> DoLineSpacing(this TextMeshProUGUI text, float spacing, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return DoLineSpacing(text, text.gameObject, spacing, duration, formula, loopsCount, loopType, direction);
		}

		public static Tween<float, TweakFloat> DoLineSpacing(this TextMeshProUGUI text, GameObject owner, float spacing, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(owner, owner.name, text.lineSpacing, spacing, ls => text.lineSpacing = ls, duration, formula, loopsCount, loopType, direction);
		}
		#endregion

		#region DoWordSpacing
		public static Tween<float, TweakFloat> DoWordSpacing(this TextMeshProUGUI text, float spacing, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return DoWordSpacing(text, text.gameObject, spacing, duration, formula, loopsCount, loopType, direction);
		}

		public static Tween<float, TweakFloat> DoWordSpacing(this TextMeshProUGUI text, GameObject owner, float spacing, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(owner, owner.name, text.wordSpacing, spacing, ws => text.wordSpacing = ws, duration, formula, loopsCount, loopType, direction);
		}
		#endregion

		#region DoParagraphSpacing
		public static Tween<float, TweakFloat> DoParagraphSpacing(this TextMeshProUGUI text, float spacing, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return DoParagraphSpacing(text, text.gameObject, spacing, duration, formula, loopsCount, loopType, direction);
		}

		public static Tween<float, TweakFloat> DoParagraphSpacing(this TextMeshProUGUI text, GameObject owner, float spacing, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(owner, owner.name, text.paragraphSpacing, spacing, ps => text.paragraphSpacing = ps, duration, formula, loopsCount, loopType, direction);
		}
		#endregion
		#endregion

		#region DoMargin
		public static Tween<Vector4, TweakVector4> DoMargin(this TextMeshProUGUI text, Vector4 margin, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return DoMargin(text, text.gameObject, margin, duration, formula, loopsCount, loopType, direction);
		}

		public static Tween<Vector4, TweakVector4> DoMargin(this TextMeshProUGUI text, GameObject owner, Vector4 margin, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Vector4(owner, owner.name, text.margin, margin, m => text.margin = m, duration, formula, loopsCount, loopType, direction);
		}
		#endregion
	}
}