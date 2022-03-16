using Redcode.Tweens.Tweaks;
using UnityEngine;
using UnityEngine.UI;

namespace Redcode.Tweens
{
    public static class ImageExtensions
	{
        #region DoFillAmount
        public static Tween<float, TweakFloat> DoFillAmount(this Image image, float amount, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return DoFillAmount(image, image.gameObject, amount, duration, formula, loopsCount, loopType, direction);
		}

		public static Tween<float, TweakFloat> DoFillAmount(this Image image, GameObject owner, float amount, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(owner, owner.name, image.fillAmount, amount, a => image.fillAmount = a, duration, formula, loopsCount, loopType, direction);
		}
		#endregion
	}
}