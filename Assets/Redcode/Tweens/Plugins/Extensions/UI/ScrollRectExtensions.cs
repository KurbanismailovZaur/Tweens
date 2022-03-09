using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Redcode.Extensions;
using Tweens.Tweaks;
using Tweens.Formulas;
using UnityEngine.UI;

namespace Tweens
{
	public static class ScrollRectExtensions
	{
        #region DoHorizontalNormalizedPosition
        public static Tween<float, TweakFloat> DoHorizontalNormalizedPosition(this ScrollRect scrollRect, float normalizedPosition, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return DoHorizontalNormalizedPosition(scrollRect, scrollRect.gameObject, normalizedPosition, duration, formula, loopsCount, loopType, direction);
		}

		public static Tween<float, TweakFloat> DoHorizontalNormalizedPosition(this ScrollRect scrollRect, GameObject owner, float normalizedPosition, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(owner, owner.name, scrollRect.horizontalNormalizedPosition, normalizedPosition, np => scrollRect.horizontalNormalizedPosition = np, duration, formula, loopsCount, loopType, direction);
		}
		#endregion

		#region DoVerticalNormalizedPosition
		public static Tween<float, TweakFloat> DoVerticalNormalizedPosition(this ScrollRect scrollRect, float normalizedPosition, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return DoVerticalNormalizedPosition(scrollRect, scrollRect.gameObject, normalizedPosition, duration, formula, loopsCount, loopType, direction);
		}

		public static Tween<float, TweakFloat> DoVerticalNormalizedPosition(this ScrollRect scrollRect, GameObject owner, float normalizedPosition, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(owner, owner.name, scrollRect.verticalNormalizedPosition, normalizedPosition, np => scrollRect.verticalNormalizedPosition = np, duration, formula, loopsCount, loopType, direction);
		}
		#endregion
	}
}