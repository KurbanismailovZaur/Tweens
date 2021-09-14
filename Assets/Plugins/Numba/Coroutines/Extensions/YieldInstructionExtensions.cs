using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Coroutines.Extensions
{
    public static class YieldInstructionExtensions
    {
        public static Coroutine AsCoroutine(this YieldInstruction instruction) => Coroutine.Run(Routines.Wait(instruction));

        public static CustomYieldInstruction AsCustomYieldInstruction(this YieldInstruction instruction)
        {
            var coroutine = instruction.AsCoroutine();
            return new WaitUntil(() => coroutine.IsCompleted);
        }
    }
}