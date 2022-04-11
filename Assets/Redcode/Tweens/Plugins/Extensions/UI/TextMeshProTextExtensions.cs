using Redcode.Tweens.Tweaks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Redcode.Tweens
{
    public static class TextMeshProTextExtensions
	{
		public static Tween<float, TweakFloat> DoFontSize(this TextMeshProUGUI text, int size, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(text.fontSize, size, fs => text.fontSize = fs, duration, ease, loopsCount, loopType, direction).SetOwner(text).SetName(text.name);
		}
		
		#region Spacing

		public static Tween<float, TweakFloat> DoCharacterSpacing(this TextMeshProUGUI text, float spacing, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(text.characterSpacing, spacing, cs => text.characterSpacing = cs, duration, ease, loopsCount, loopType, direction).SetOwner(text).SetName(text.name);
		}

		public static Tween<float, TweakFloat> DoLineSpacing(this TextMeshProUGUI text, float spacing, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(text.lineSpacing, spacing, ls => text.lineSpacing = ls, duration, ease, loopsCount, loopType, direction).SetOwner(text).SetName(text.name);
		}

		public static Tween<float, TweakFloat> DoWordSpacing(this TextMeshProUGUI text, float spacing, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(text.wordSpacing, spacing, ws => text.wordSpacing = ws, duration, ease, loopsCount, loopType, direction).SetOwner(text).SetName(text.name);
		}

		public static Tween<float, TweakFloat> DoParagraphSpacing(this TextMeshProUGUI text, float spacing, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(text.paragraphSpacing, spacing, ps => text.paragraphSpacing = ps, duration, ease, loopsCount, loopType, direction).SetOwner(text).SetName(text.name);
		}
		#endregion

		public static Tween<Vector4, TweakVector4> DoMargin(this TextMeshProUGUI text, Vector4 margin, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Vector4(text.margin, margin, m => text.margin = m, duration, ease, loopsCount, loopType, direction).SetOwner(text).SetName(text.name);
		}
	}
}