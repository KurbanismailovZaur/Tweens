using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Extensions;

namespace Extensions
{
    public static class FloatExtensions
    {
        public static bool NearlyEquals(this float value, float other, float epsilon = 0.0000001f)
        {
            if (value == other) // Simple check, also handles infinities.
                return true;

            value = Mathf.Abs(value);
            other = Mathf.Abs(other);

            return Mathf.Abs(value - other) < epsilon;
        }
    }
}