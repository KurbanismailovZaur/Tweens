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
	public static class ImageExtensions
	{
        #region DoFillAmount
        public static Tween<float, TweakFloat> DoFillAmount(this Image image, float amount, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return DoFillAmount(image, image.gameObject, amount, duration, formula, loopsCount, loopType, direction);
		}

		public static Tween<float, TweakFloat> DoFillAmount(this Image image, GameObject owner, float amount, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(owner, owner.name, image.fillAmount, amount, a => image.fillAmount = a, duration, formula, loopsCount, loopType, direction);
		}
		#endregion
	}
}