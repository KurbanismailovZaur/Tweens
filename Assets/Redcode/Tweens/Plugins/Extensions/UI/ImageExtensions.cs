using Redcode.Tweens.Tweaks;
using UnityEngine;
using UnityEngine.UI;

namespace Redcode.Tweens
{
    public static class ImageExtensions
	{
        public static Tween<float, TweakFloat> DoFillAmount(this Image image, float amount, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(image.fillAmount, amount, a => image.fillAmount = a, duration, ease, loopsCount, loopType, direction).SetOwner(image).SetName(image.name); 	
		}
	}
}