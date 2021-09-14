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
	[Serializable]
	public abstract class FormulaBase
	{
		public abstract float Remap(float interpolation);
	}
}