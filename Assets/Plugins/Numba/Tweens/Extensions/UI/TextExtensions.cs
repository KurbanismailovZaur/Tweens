using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Extensions;
using Tweens.Tweaks;
using Tweens.Formulas;
using UnityEngine.UI;

namespace Tweens
{
	public static class TextExtensions
	{
		#region DoFontSize
		public static Tween<int, TweakInt> DoFontSize(this Text text, int size, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return DoFontSize(text, text.gameObject, size, duration, formula, loopsCount, loopType, direction);
		}

		public static Tween<int, TweakInt> DoFontSize(this Text text, GameObject owner, int size, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Int(owner, owner.name, text.fontSize, size, fs => text.fontSize = fs, duration, formula, loopsCount, loopType, direction);
		}
		#endregion

		#region DoLineSpacing
		public static Tween<float, TweakFloat> DoLineSpacing(this Text text, float spacing, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return DoLineSpacing(text, text.gameObject, spacing, duration, formula, loopsCount, loopType, direction);
		}

		public static Tween<float, TweakFloat> DoLineSpacing(this Text text, GameObject owner, float spacing, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(owner, owner.name, text.lineSpacing, spacing, ls => text.lineSpacing = ls, duration, formula, loopsCount, loopType, direction);
		}
		#endregion
	}
}