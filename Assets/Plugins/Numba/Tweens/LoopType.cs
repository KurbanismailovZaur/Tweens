using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Extensions;
using Object = UnityEngine.Object;
using Coroutine = Coroutines.Coroutine;

namespace Tweens
{
	/// <summary>
	/// Represents the behavior after <c>Playable</c> finishes playing one of its loops and moves on to the nextþ
	/// </summary>
	public enum LoopType : byte
	{
		/// <summary>
		/// Next loop starts from the same position as previous.
		/// </summary>
		Reset,

		/// <summary>
		/// Next loop starts from the end of previous loop.
		/// </summary>
		Continue,

		/// <summary>
		/// Next loop starts from the same position as previous, but every loop will moves forward and backward.
		/// </summary>
		Mirror
	}
}