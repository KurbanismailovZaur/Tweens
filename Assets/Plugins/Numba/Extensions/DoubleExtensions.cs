using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Extensions;

namespace Extensions
{
	public static class DoubleExtensions
    {
        public static bool NearlyEquals(this double value, double other, double epsilon = 0.0000001f)
        {
            if (value == other) // Simple check, also handles infinities.
                return true;

            value = Math.Abs(value);
            other = Math.Abs(other);

            return Math.Abs(value - other) < epsilon;
        }
    }
}