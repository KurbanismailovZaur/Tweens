using Redcode.Tweens.Tweaks;
using UnityEngine;

namespace Redcode.Tweens
{
    public static class AudioListenerExtensions
	{
        public static Tween<float, TweakFloat> DoVolume(this AudioSource source, float volume, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(source.volume, volume, v => source.volume = v, duration, ease, loopsCount, loopType, direction).SetOwner(source).SetName(source.name);
		}

		public static Tween<float, TweakFloat> DoPitch(this AudioSource source, float pitch, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(source.pitch, pitch, p => source.pitch = p, duration, ease, loopsCount, loopType, direction).SetOwner(source).SetName(source.name);
		}

		public static Tween<float, TweakFloat> DoPanStereo(this AudioSource source, float pan, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(source.panStereo, pan, p => source.panStereo = p, duration, ease, loopsCount, loopType, direction).SetOwner(source).SetName(source.name);
		}

		public static Tween<float, TweakFloat> DoSpatialBlend(this AudioSource source, float blend, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(source.spatialBlend, blend, b => source.spatialBlend = b, duration, ease, loopsCount, loopType, direction).SetOwner(source).SetName(source.name);
		}
	}
}