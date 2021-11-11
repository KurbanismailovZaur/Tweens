using Extensions;
using Tweens.Formulas;
using Tweens.Tweaks;
using UnityEngine;

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