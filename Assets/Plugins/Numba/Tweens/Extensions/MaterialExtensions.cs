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
	public static class MaterialExtensions
	{
		public static Tween<float, TweakFloat> DoVolume(this AudioSource source, float volume, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(source.volume, volume, v => source.volume = v, duration, formula, loopsCount, loopType, direction);
		}

		public static Tween<float, TweakFloat> DoPitch(this AudioSource source, float pitch, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(source.pitch, pitch, p => source.pitch = p, duration, formula, loopsCount, loopType, direction);
		}

		public static Tween<float, TweakFloat> DoPanStereo(this AudioSource source, float pan, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(source.panStereo, pan, p => source.panStereo = p, duration, formula, loopsCount, loopType, direction);
		}

		public static Tween<float, TweakFloat> DoSpatialBlend(this AudioSource source, float blend, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(source.spatialBlend, blend, b => source.spatialBlend = b, duration, formula, loopsCount, loopType, direction);
		}
	}
}