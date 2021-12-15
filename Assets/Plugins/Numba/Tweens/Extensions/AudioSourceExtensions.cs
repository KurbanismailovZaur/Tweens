using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Extensions;
using Tweens.Tweaks;
using Tweens.Formulas;

namespace Tweens
{
	public static class AudioListenerExtensions
	{
        #region DoVolume
        public static Tween<float, TweakFloat> DoVolume(this AudioSource source, float volume, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return DoVolume(source, source.gameObject, volume, duration, formula, loopsCount, loopType, direction);
		}

		public static Tween<float, TweakFloat> DoVolume(this AudioSource source, GameObject owner, float volume, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(owner, owner.name, source.volume, volume, v => source.volume = v, duration, formula, loopsCount, loopType, direction);
		}
		#endregion

		#region DoPitch
		public static Tween<float, TweakFloat> DoPitch(this AudioSource source, float pitch, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return DoPitch(source, source.gameObject, pitch, duration, formula, loopsCount, loopType, direction);
		}

		public static Tween<float, TweakFloat> DoPitch(this AudioSource source, GameObject owner, float pitch, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(owner, owner.name, source.pitch, pitch, p => source.pitch = p, duration, formula, loopsCount, loopType, direction);
		}
		#endregion

		#region DoPanStereo
		public static Tween<float, TweakFloat> DoPanStereo(this AudioSource source, float pan, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return DoPanStereo(source, source.gameObject, pan, duration, formula, loopsCount, loopType, direction);
		}

		public static Tween<float, TweakFloat> DoPanStereo(this AudioSource source, GameObject owner, float pan, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(owner, owner.name, source.panStereo, pan, p => source.panStereo = p, duration, formula, loopsCount, loopType, direction);
		}
		#endregion

		#region DoSpatialBlend
		public static Tween<float, TweakFloat> DoSpatialBlend(this AudioSource source, float blend, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return DoSpatialBlend(source, source.gameObject, blend, duration, formula, loopsCount, loopType, direction);
		}

		public static Tween<float, TweakFloat> DoSpatialBlend(this AudioSource source, GameObject owner, float blend, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(owner, owner.name, source.spatialBlend, blend, b => source.spatialBlend = b, duration, formula, loopsCount, loopType, direction);
		}
		#endregion
	}
}