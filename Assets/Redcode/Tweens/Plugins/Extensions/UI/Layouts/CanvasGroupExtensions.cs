using Redcode.Tweens.Tweaks;
using UnityEngine;

namespace Redcode.Tweens
{
    public static class CanvasGroupExtensions
	{
		#region DoAlpha
		public static Tween<float, TweakFloat> DoAlpha(this CanvasGroup group, float alpha, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return DoAlpha(group, group.gameObject, alpha, duration, ease, loopsCount, loopType, direction);
		}

		public static Tween<float, TweakFloat> DoAlpha(this CanvasGroup group, GameObject owner, float alpha, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(owner, owner.name, group.alpha, alpha, a => group.alpha = a, duration, ease, loopsCount, loopType, direction);
		}
		#endregion
	}
}