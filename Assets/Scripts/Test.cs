using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Extensions;
using Coroutines;
using Coroutines.Extensions;
using Object = UnityEngine.Object;
using Coroutine = Coroutines.Coroutine;
using Tweens.Tweaks;

namespace Tweens
{
	public class Test : MonoBehaviour
	{
		[SerializeField]
		private Transform _target;

		[SerializeField]
		[Range(0f, 1f)]
		private float _interpolation;

		private FloatTweak _floatTweak = new FloatTweak();

		void Update()
		{
			_floatTweak.Apply(0f, 5f, _interpolation, x => _target.SetPositionX(x), Formula.BounceIn);
		}
	}
}