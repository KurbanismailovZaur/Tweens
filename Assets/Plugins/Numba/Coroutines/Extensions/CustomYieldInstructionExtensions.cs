using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Coroutines.Extensions
{
	public static class CustomYieldInstructionExtensions
	{
		public static Coroutine AsCoroutine(this CustomYieldInstruction instruction) => Coroutine.Run(instruction);

		public static YieldInstruction AsYieldInstruction(this CustomYieldInstruction instruction)
		{
			return instruction.AsCoroutine().WaitForComplete();
		}
	}
}