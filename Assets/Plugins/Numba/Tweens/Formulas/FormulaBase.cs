using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Extensions;
using Object = UnityEngine.Object;
using Coroutine = Coroutines.Coroutine;

namespace Tweens.Formulas
{
	/// <summary>
	/// Base class for all formulas
	/// </summary>
	[Serializable]
	public abstract class FormulaBase
	{
		/// <summary>
		/// Remap given value by formula.
		/// </summary>
		/// <param name="interpolation">Value to remap.</param>
		/// <returns>Remaped value.</returns>
		public abstract float Remap(float interpolation);
	}
}