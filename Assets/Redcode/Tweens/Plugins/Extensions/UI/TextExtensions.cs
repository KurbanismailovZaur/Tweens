using Redcode.Tweens.Tweaks;
using UnityEngine;
using UnityEngine.UI;

namespace Redcode.Tweens
{
    public static class TextExtensions
	{
		public static Tween<int, TweakInt> DoFontSize(this Text text, int size, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Int(text.fontSize, size, fs => text.fontSize = fs, duration, ease, loopsCount, loopType, direction).SetOwner(text).SetName(text.name);
		}

		public static Tween<float, TweakFloat> DoLineSpacing(this Text text, float spacing, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(text.lineSpacing, spacing, ls => text.lineSpacing = ls, duration, ease, loopsCount, loopType, direction).SetOwner(text).SetName(text.name);
		}
	}
}