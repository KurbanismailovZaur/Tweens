using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Extensions;
using Coroutines;
using Coroutines.Extensions;
using Object = UnityEngine.Object;
using Coroutine = Coroutines.Coroutine;
using Tweens.Tweaks;
using Tweens.Formulas;

namespace Tweens
{
	public static class TransformExtensions
	{
		public static Tween<float, TweakFloat> DoMoveX(this Transform transform, float x, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(transform.gameObject, transform.name, transform.position.x, x, transform.SetPositionX, duration, formula, loopsCount, loopType, direction);
		}
	}
}