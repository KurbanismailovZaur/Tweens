using Redcode.Tweens.Tweaks;
using UnityEngine;
using UnityEngine.UI;

namespace Redcode.Tweens
{
    public static class ScrollRectExtensions
	{
		public static Tween<float, TweakFloat> DoHorizontalNormalizedPosition(this ScrollRect scrollRect, float normalizedPosition, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(scrollRect.horizontalNormalizedPosition, normalizedPosition, np => scrollRect.horizontalNormalizedPosition = np, duration, ease, loopsCount, loopType, direction).SetOwner(scrollRect).SetName(scrollRect.name);
		}
		
		public static Tween<float, TweakFloat> DoVerticalNormalizedPosition(this ScrollRect scrollRect, float normalizedPosition, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(scrollRect.verticalNormalizedPosition, normalizedPosition, np => scrollRect.verticalNormalizedPosition = np, duration, ease, loopsCount, loopType, direction).SetOwner(scrollRect).SetName(scrollRect.name);
		}
	}
}