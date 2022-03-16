using System;
using UnityEngine;

namespace Redcode.Tweens
{
    /// <summary>
    /// Auxiliary class for linear or spherical interpolation of many data types.
    /// </summary>
    public static class Lerp
    {
        public static byte Byte(byte from, byte to, float interpolation) => (byte)Mathf.LerpUnclamped(from, to, interpolation);

        public static sbyte SByte(sbyte from, sbyte to, float interpolation) => (sbyte)Mathf.LerpUnclamped(from, to, interpolation);

        public static short Short(short from, short to, float interpolation) => (short)Mathf.LerpUnclamped(from, to, interpolation);

        public static ushort UShort(ushort from, ushort to, float interpolation) => (ushort)Mathf.LerpUnclamped(from, to, interpolation);

        public static char Char(char from, char to, float interpolation) => (char)Mathf.LerpUnclamped(from, to, interpolation);

        public static int Int(int from, int to, float interpolation) => (int)Mathf.LerpUnclamped(from, to, interpolation);

        public static uint UInt(uint from, uint to, float interpolation) => (uint)Mathf.LerpUnclamped(from, to, interpolation);

        public static long Long(long from, long to, float interpolation) => (long)Mathf.LerpUnclamped(from, to, interpolation);

        public static ulong ULong(ulong from, ulong to, float interpolation) => (ulong)Mathf.LerpUnclamped(from, to, interpolation);

        public static float Float(float from, float to, float interpolation) => Mathf.LerpUnclamped(from, to, interpolation);

        public static double Double(double from, double to, float interpolation) => from + (to - from) * interpolation;

        public static decimal Decimal(decimal from, decimal to, float interpolation) => from + (to - from) * (decimal)interpolation;

        public static Vector2 Vector2(Vector2 from, Vector2 to, float interpolation) => UnityEngine.Vector2.LerpUnclamped(from, to, interpolation);

        public static Vector3 Vector3(Vector3 from, Vector3 to, float interpolation, InterpolationType interpolationType)
        {
            return interpolationType switch
            {
                InterpolationType.Linear => UnityEngine.Vector3.LerpUnclamped(from, to, interpolation),
                InterpolationType.Spherical => UnityEngine.Vector3.SlerpUnclamped(from, to, interpolation),
                _ => throw new ArgumentException("Intepolation type must be Linear ot Spherical", nameof(interpolationType))
            };
        }

        public static Vector4 Vector4(Vector4 from, Vector4 to, float interpolation) => UnityEngine.Vector4.LerpUnclamped(from, to, interpolation);

        public static Vector2Int Vector2Int(Vector2Int from, Vector2Int to, float interpolation) => new Vector2Int(Int(from.x, to.x, interpolation), Int(from.y, to.y, interpolation));

        public static Vector3Int Vector3Int(Vector3Int from, Vector3Int to, float interpolation) => new Vector3Int(Int(from.x, to.x, interpolation), Int(from.y, to.y, interpolation), Int(from.z, to.z, interpolation));

        public static Color32 Color32(Color32 from, Color32 to, float interpolation) => UnityEngine.Color32.LerpUnclamped(from, to, interpolation);

        public static Color Color(Color from, Color to, float interpolation) => UnityEngine.Color.LerpUnclamped(from, to, interpolation);

        public static Bounds Bounds(Bounds from, Bounds to, float interpolation) => new Bounds(UnityEngine.Vector3.LerpUnclamped(from.center, to.center, interpolation), UnityEngine.Vector3.LerpUnclamped(from.size, to.size, interpolation));

        public static BoundsInt BoundsInt(BoundsInt from, BoundsInt to, float interpolation) => new BoundsInt(Vector3Int(from.position, to.position, interpolation), Vector3Int(from.size, to.size, interpolation));

        public static BoundingSphere BoundingSphere(BoundingSphere from, BoundingSphere to, float interpolation) => new BoundingSphere(UnityEngine.Vector3.LerpUnclamped(from.position, to.position, interpolation), Float(from.radius, to.radius, interpolation));

        public static Matrix4x4 Matrix4x4(Matrix4x4 from, Matrix4x4 to, float interpolation)
        {
            var matrix = new Matrix4x4();
            matrix.SetRow(0, Vector4(from.GetRow(0), to.GetRow(0), interpolation));
            matrix.SetRow(1, Vector4(from.GetRow(1), to.GetRow(1), interpolation));
            matrix.SetRow(2, Vector4(from.GetRow(2), to.GetRow(2), interpolation));
            matrix.SetRow(3, Vector4(from.GetRow(3), to.GetRow(3), interpolation));

            return matrix;
        }

        public static Quaternion Quaternion(Quaternion from, Quaternion to, float interpolation, InterpolationType interpolationType)
        {
            return interpolationType switch
            {
                InterpolationType.Linear => UnityEngine.Quaternion.LerpUnclamped(from, to, interpolation),
                InterpolationType.Spherical => UnityEngine.Quaternion.SlerpUnclamped(from, to, interpolation),
                _ => throw new ArgumentException("Intepolation type must be Linear ot Spherical", nameof(interpolationType))
            };
        }

        public static Rect Rect(Rect from, Rect to, float interpolation) => new Rect(Vector2(from.position, to.position, interpolation), Vector2(from.size, to.size, interpolation));
    }
}