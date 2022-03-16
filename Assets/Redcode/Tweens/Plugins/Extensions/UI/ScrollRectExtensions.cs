using Redcode.Tweens.Tweaks;
using UnityEngine;
using UnityEngine.UI;

namespace Redcode.Tweens
{
    public static class ScrollRectExtensions
	{
        #region DoHorizontalNormalizedPosition
        public static Tween<float, TweakFloat> DoHorizontalNormalizedPosition(this ScrollRect scrollRect, float normalizedPosition, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return DoHorizontalNormalizedPosition(scrollRect, scrollRect.gameObject, normalizedPosition, duration, formula, loopsCount, loopType, direction);
		}

		public static Tween<float, TweakFloat> DoHorizontalNormalizedPosition(this ScrollRect scrollRect, GameObject owner, float normalizedPosition, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(owner, owner.name, scrollRect.horizontalNormalizedPosition, normalizedPosition, np => scrollRect.horizontalNormalizedPosition = np, duration, formula, loopsCount, loopType, direction);
		}
		#endregion

		#region DoVerticalNormalizedPosition
		public static Tween<float, TweakFloat> DoVerticalNormalizedPosition(this ScrollRect scrollRect, float normalizedPosition, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return DoVerticalNormalizedPosition(scrollRect, scrollRect.gameObject, normalizedPosition, duration, formula, loopsCount, loopType, direction);
		}

		public static Tween<float, TweakFloat> DoVerticalNormalizedPosition(this ScrollRect scrollRect, GameObject owner, float normalizedPosition, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(owner, owner.name, scrollRect.verticalNormalizedPosition, normalizedPosition, np => scrollRect.verticalNormalizedPosition = np, duration, formula, loopsCount, loopType, direction);
		}
		#endregion
	}
}