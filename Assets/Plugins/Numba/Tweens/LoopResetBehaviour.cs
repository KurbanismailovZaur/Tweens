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

namespace Tweens
{
	/// <summary>
	/// Represent behaviour which applied to sequences before every loop start event.
	/// </summary>
	public enum LoopResetBehaviour : byte
	{
		/// <summary>
		/// Before every loop start event sequence will rewind all its elements to start state without emitting they events.
		/// </summary>
		Rewind,

		/// <summary>
		/// Before every loop start event sequence will skip all its elements to start state.
		/// </summary>
		Skip
	}
}