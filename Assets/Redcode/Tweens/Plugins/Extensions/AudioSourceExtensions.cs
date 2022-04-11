using Redcode.Tweens.Tweaks;
using UnityEngine;

namespace Redcode.Tweens
{
    public static class AudioListenerExtensions
	{
		/// <summary>
		/// Tweens source's volume.
		/// </summary>
		/// <param name="source">Target source.</param>
		/// <param name="volume">Target volume.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<float, TweakFloat> DoVolume(this AudioSource source, float volume, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(source.volume, volume, v => source.volume = v, duration, ease, loopsCount, loopType, direction).SetOwner(source).SetName(source.name);
		}

		/// <summary>
		/// Tweens source's pitch.
		/// </summary>
		/// <param name="source">Target source.</param>
		/// <param name="pitch">Target pitch.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<float, TweakFloat> DoPitch(this AudioSource source, float pitch, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(source.pitch, pitch, p => source.pitch = p, duration, ease, loopsCount, loopType, direction).SetOwner(source).SetName(source.name);
		}

		/// <summary>
		/// Tweens source's pan.
		/// </summary>
		/// <param name="source">Target source.</param>
		/// <param name="pan">Target pan.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<float, TweakFloat> DoPanStereo(this AudioSource source, float pan, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(source.panStereo, pan, p => source.panStereo = p, duration, ease, loopsCount, loopType, direction).SetOwner(source).SetName(source.name);
		}

		/// <summary>
		/// Tweens source's blend.
		/// </summary>
		/// <param name="source">Target source.</param>
		/// <param name="blend">Target blend.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<float, TweakFloat> DoSpatialBlend(this AudioSource source, float blend, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(source.spatialBlend, blend, b => source.spatialBlend = b, duration, ease, loopsCount, loopType, direction).SetOwner(source).SetName(source.name);
		}
	}
}