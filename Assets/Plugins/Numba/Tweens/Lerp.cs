using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tweens
{
    /// <summary>
    /// Auxiliary class for linear interpolation of many data types.
    /// </summary>
    public static class Lerp
    {
        public static byte Byte(byte from, byte to, float interpolation) => (byte)(from + (to - from) * interpolation);

        public static sbyte SByte(sbyte from, sbyte to, float interpolation) => (sbyte)(from + (to - from) * interpolation);

        public static short Short(short from, short to, float interpolation) => (short)(from + (to - from) * interpolation);

        public static ushort UShort(ushort from, ushort to, float interpolation) => (ushort)(from + (to - from) * interpolation);

        public static char Char(char from, char to, float interpolation) => (char)(from + (to - from) * interpolation);

        public static int Int(int from, int to, float interpolation) => (int)(from + (to - from) * interpolation);

        public static uint UInt(uint from, uint to, float interpolation) => (uint)(from + (to - from) * interpolation);

        public static long Long(long from, long to, float interpolation) => (long)(from + (to - from) * interpolation);

        public static ulong ULong(ulong from, ulong to, float interpolation) => (ulong)(from + (to - from) * interpolation);

        public static float Float(float from, float to, float interpolation) => from + (to - from) * interpolation;

        public static double Double(double from, double to, float interpolation) => from + (to - from) * interpolation;

        public static decimal Decimal(decimal from, decimal to, float interpolation) => from + (to - from) * (decimal)interpolation;

        public static Vector2 Vector2(Vector2 from, Vector2 to, float interpolation) => new Vector2(Float(from.x, to.x, interpolation), Float(from.y, to.y, interpolation));

        public static Vector3 Vector3(Vector3 from, Vector3 to, float interpolation) => new Vector3(Float(from.x, to.x, interpolation), Float(from.y, to.y, interpolation), Float(from.z, to.z, interpolation));

        public static Vector4 Vector4(Vector4 from, Vector4 to, float interpolation) => new Vector4(Float(from.x, to.x, interpolation), Float(from.y, to.y, interpolation), Float(from.z, to.z, interpolation), Float(from.w, to.w, interpolation));

        public static Vector2Int Vector2Int(Vector2Int from, Vector2Int to, float interpolation) => new Vector2Int(Int(from.x, to.x, interpolation), Int(from.y, to.y, interpolation));

        public static Vector3Int Vector3Int(Vector3Int from, Vector3Int to, float interpolation) => new Vector3Int(Int(from.x, to.x, interpolation), Int(from.y, to.y, interpolation), Int(from.z, to.z, interpolation));

        public static Color32 Color32(Color32 from, Color32 to, float interpolation) => new Color32(Byte(from.r, to.r, interpolation), Byte(from.g, to.g, interpolation), Byte(from.b, to.b, interpolation), Byte(from.a, to.a, interpolation));

        public static Color Color(Color from, Color to, float interpolation) => new Color(Float(from.r, to.r, interpolation), Float(from.g, to.g, interpolation), Float(from.b, to.b, interpolation), Float(from.a, to.a, interpolation));

        public static Bounds Bounds(Bounds from, Bounds to, float interpolation) => new Bounds(Vector3(from.center, to.center, interpolation), Vector3(from.size, to.size, interpolation));

        public static BoundsInt BoundsInt(BoundsInt from, BoundsInt to, float interpolation) => new BoundsInt(Vector3Int(from.position, to.position, interpolation), Vector3Int(from.size, to.size, interpolation));

        public static BoundingSphere BoundingSphere(BoundingSphere from, BoundingSphere to, float interpolation) => new BoundingSphere(Vector3(from.position, to.position, interpolation), Float(from.radius, to.radius, interpolation));

        public static Matrix4x4 Matrix4x4(Matrix4x4 from, Matrix4x4 to, float interpolation)
        {
            var matrix = new Matrix4x4();
            matrix.SetRow(0, Vector4(from.GetRow(0), to.GetRow(0), interpolation));
            matrix.SetRow(1, Vector4(from.GetRow(1), to.GetRow(1), interpolation));
            matrix.SetRow(2, Vector4(from.GetRow(2), to.GetRow(2), interpolation));
            matrix.SetRow(3, Vector4(from.GetRow(3), to.GetRow(3), interpolation));

            return matrix;
        }

        public static Quaternion Quaternion(Quaternion from, Quaternion to, float interpolation) => UnityEngine.Quaternion.SlerpUnclamped(from, to, interpolation);

        public static Rect Rect(Rect from, Rect to, float interpolation) => new Rect(Vector2(from.position, to.position, interpolation), Vector2(from.size, to.size, interpolation));
    }
}