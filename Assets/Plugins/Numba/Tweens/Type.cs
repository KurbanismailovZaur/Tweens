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
	/// Represent <c>Playable</c> type.
	/// </summary>
	public enum Type : byte
	{
		Tween,
		Sequence,
		Interval,
		Callback
	}
}