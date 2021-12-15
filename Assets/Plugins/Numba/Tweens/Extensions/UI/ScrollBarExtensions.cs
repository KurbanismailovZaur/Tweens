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
	public static class ScrollBarExtensions
	{
		#region DoValue
		public static Tween<float, TweakFloat> DoValue(this Scrollbar scrollbar, float value, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return DoValue(scrollbar, scrollbar.gameObject, value, duration, formula, loopsCount, loopType, direction);
		}

		public static Tween<float, TweakFloat> DoValue(this Scrollbar scrollbar, GameObject owner, float value, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(owner, owner.name, scrollbar.value, value, v => scrollbar.value = v, duration, formula, loopsCount, loopType, direction);
		}
		#endregion
	}
}