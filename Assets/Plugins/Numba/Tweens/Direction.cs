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
	/// Represent direction in which <see cref="IPlayable"/> or <see cref="Playable.IRepeater{T}"/> will be playing.
	/// </summary>
	public enum Direction : byte
	{
		Forward,
		Backward
	}
}