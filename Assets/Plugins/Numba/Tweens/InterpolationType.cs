using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Extensions;

namespace Tweens
{
	public enum InterpolationType : byte
	{
		/// <summary>
		/// Use linear formula.
		/// </summary>
		Linear,

		/// <summary>
		/// Use spherical formula (useful for tweak directions).
		/// </summary>
		Spherical
	}
}