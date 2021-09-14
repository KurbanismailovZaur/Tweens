using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;
using Coroutine = Coroutines.Coroutine;

namespace Coroutines.Exceptions
{
	public class PlayControlException : ApplicationException
	{
		public PlayControlException(string message) : base(message) { }
	}
}