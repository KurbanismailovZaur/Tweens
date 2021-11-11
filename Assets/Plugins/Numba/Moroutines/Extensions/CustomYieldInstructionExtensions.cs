using UnityEngine;

namespace Moroutines.Extensions
{
    public static class CustomYieldInstructionExtensions
	{
		public static Moroutine AsMoroutine(this CustomYieldInstruction instruction) => Moroutine.Run(instruction);

		public static YieldInstruction AsYieldInstruction(this CustomYieldInstruction instruction)
		{
			return instruction.AsMoroutine().WaitForComplete();
		}
	}
}