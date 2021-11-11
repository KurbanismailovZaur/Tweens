using System;
using System.Collections;
using UnityEngine;

namespace Moroutines
{
    public static class Routines
    {
        public static IEnumerable Delay(float delay, Action action)
        {
            yield return new WaitForSeconds(delay);
            action();
        }

        public static IEnumerable Delay(float delay, IEnumerable enumerable)
        {
            yield return new WaitForSeconds(delay);

            var enumerator = enumerable.GetEnumerator();

            while (enumerator.MoveNext())
                yield return enumerator.Current;
        }

        public static IEnumerable Delay(float delay, IEnumerator enumerator) => Delay(delay, new EnumerableEnumerator(enumerator));

        public static IEnumerable Repeat(int count, IEnumerable enumerable)
        {
            while (Math.Max(-1, count--) != 0)
            {
                var enumerator = enumerable.GetEnumerator();

                while (enumerator.MoveNext())
                    yield return enumerator.Current;
            }
        }

        public static IEnumerable FrameDelay(int count, Action action)
        {
            while (count-- > 0)
                yield return null;

            action();
        }

        public static IEnumerable FrameDelay(int count, IEnumerable enumerable)
        {
            while (count-- > 0)
                yield return null;

            var enumerator = enumerable.GetEnumerator();

            while (enumerator.MoveNext())
                yield return enumerator.Current;
        }

        public static IEnumerable FrameDelay(int count, IEnumerator enumerator) => FrameDelay(count, new EnumerableEnumerator(enumerator));

        public static IEnumerable Wait(YieldInstruction instruction)
        {
            yield return instruction;
        }

        public static IEnumerable Wait(CustomYieldInstruction instruction)
        {
            yield return instruction;
        }
    }
}