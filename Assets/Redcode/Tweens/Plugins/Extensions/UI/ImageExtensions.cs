using Redcode.Tweens.Tweaks;
using UnityEngine;
using UnityEngine.UI;

namespace Redcode.Tweens
{
    public static class ImageExtensions
	{
		/// <summary>
		/// Tweens image's fill amount.
		/// </summary>
		/// <param name="image">Target image.</param>
		/// <param name="amount">Target fill amount.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<float, TweakFloat> DoFillAmount(this Image image, float amount, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(image.fillAmount, amount, a => image.fillAmount = a, duration, ease, loopsCount, loopType, direction).SetOwner(image).SetName(image.name); 	
		}
	}
}