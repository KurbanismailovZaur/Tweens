using Redcode.Tweens.Tweaks;
using UnityEngine;

namespace Redcode.Tweens
{
    public static class CanvasGroupExtensions
	{
		#region DoAlpha
		public static Tween<float, TweakFloat> DoAlpha(this CanvasGroup group, float alpha, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return DoAlpha(group, group.gameObject, alpha, duration, formula, loopsCount, loopType, direction);
		}

		public static Tween<float, TweakFloat> DoAlpha(this CanvasGroup group, GameObject owner, float alpha, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(owner, owner.name, group.alpha, alpha, a => group.alpha = a, duration, formula, loopsCount, loopType, direction);
		}
		#endregion
	}
}