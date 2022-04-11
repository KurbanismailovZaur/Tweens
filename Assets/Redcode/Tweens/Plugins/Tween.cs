using Redcode.Extensions;
using System;
using Redcode.Tweens.Tweaks;
using UnityEngine;

namespace Redcode.Tweens
{
    /// <summary>
    /// Helper class for creating tweens.
    /// </summary>
    public static class Tween
    {
        #region Static fields
        public static class AudioListener
        {
            public static Tween<float, TweakFloat> DoVolume(float volume, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
            {
                return Float(UnityEngine.AudioListener.volume, volume, v => UnityEngine.AudioListener.volume = v, duration, ease, loopsCount, loopType, direction);
            }
        }

        public static class Time
        {
            public static Tween<float, TweakFloat> DoTimeScale(float timeScale, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
            {
                return Float(UnityEngine.Time.timeScale, timeScale, ts => UnityEngine.Time.timeScale = ts, duration, ease, loopsCount, loopType, direction);
            }
        }

        public static class Physics
        {
            public static Tween<Vector3, TweakVector3> DoGravity(Vector3 gravity, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
            {
                return Vector3(UnityEngine.Physics.gravity, gravity, g => UnityEngine.Physics.gravity = g, duration, ease, loopsCount, loopType, direction);
            }

            public static Tween<Vector3, TweakVector3> DoClothGravity(Vector3 gravity, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
            {
                return Vector3(UnityEngine.Physics.clothGravity, gravity, g => UnityEngine.Physics.clothGravity = g, duration, ease, loopsCount, loopType, direction);
            }
        }

        public static class Physics2D
        {
            public static Tween<Vector2, TweakVector2> DoGravity(Vector2 gravity, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
            {
                return Vector2(UnityEngine.Physics2D.gravity, gravity, g => UnityEngine.Physics2D.gravity = g, duration, ease, loopsCount, loopType, direction);
            }
        }
        #endregion

        #region Types
        #region Byte
        /// <summary>
        /// Create byte tween.
        /// </summary>
        /// <param name="from">Value from which tween starts animation.</param>
        /// <param name="to">Value on which tween completes animation.</param>
        /// <param name="action">Callback which receive animated value.</param>
        /// <param name="loopDuration">Loop duration of the tween.</param>
        /// <param name="ease">Easing formula which used when tween animate values.</param>
        /// <param name="loopsCount">Loops count of the tween.</param>
        /// <param name="loopType">Loop type which used between loops in the tween</param>
        /// <param name="direction">Direction in which the tween starts playing animation.</param>
        /// <returns>Byte tween.</returns>
        public static Tween<byte, TweakByte> Byte(byte from, byte to, Action<byte> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Byte(() => from, () => to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="from">Callback which return value from which tween starts animation.</param>
        /// <param name="to">Callback which return value on which tween completes animation.</param>
        /// <param name="action"><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<byte, TweakByte> Byte(Func<byte> from, Func<byte> to, Action<byte> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return new Tween<byte, TweakByte>(new TweakByte(), from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region SByte
        /// <summary>
        /// Create sbyte tween.
        /// </summary>
        /// <param name="from">Value from which tween starts animation.</param>
        /// <param name="to">Value on which tween completes animation.</param>
        /// <param name="action">Callback which receive animated value.</param>
        /// <param name="loopDuration">Loop duration of the tween.</param>
        /// <param name="ease">Easing formula which used when tween animate values.</param>
        /// <param name="loopsCount">Loops count of the tween.</param>
        /// <param name="loopType">Loop type which used between loops in the tween</param>
        /// <param name="direction">Direction in which the tween starts playing animation.</param>
        /// <returns>SByte tween.</returns>
        public static Tween<sbyte, TweakSByte> SByte(sbyte from, sbyte to, Action<sbyte> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return SByte(() => from, () => to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="from"><inheritdoc cref="SByte(Func{sbyte}, Func{sbyte}, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="SByte(Func{sbyte}, Func{sbyte}, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<sbyte, TweakSByte> SByte(Func<sbyte> from, Func<sbyte> to, Action<sbyte> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return new Tween<sbyte, TweakSByte>(new TweakSByte(), from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region Short
        /// <summary>
        /// Create short tween.
        /// </summary>
        /// <param name="from">Value from which tween starts animation.</param>
        /// <param name="to">Value on which tween completes animation.</param>
        /// <param name="action">Callback which receive animated value.</param>
        /// <param name="loopDuration">Loop duration of the tween.</param>
        /// <param name="ease">Easing formula which used when tween animate values.</param>
        /// <param name="loopsCount">Loops count of the tween.</param>
        /// <param name="loopType">Loop type which used between loops in the tween</param>
        /// <param name="direction">Direction in which the tween starts playing animation.</param>
        /// <returns>Short tween.</returns>
        public static Tween<short, TweakShort> Short(short from, short to, Action<short> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Short(() => from, () => to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="from"><inheritdoc cref="Short(Func{short}, Func{short}, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Short(Func{short}, Func{short}, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<short, TweakShort> Short(Func<short> from, Func<short> to, Action<short> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return new Tween<short, TweakShort>(new TweakShort(), from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region UShort
        /// <summary>
        /// Create ushort tween.
        /// </summary>
        /// <param name="from">Value from which tween starts animation.</param>
        /// <param name="to">Value on which tween completes animation.</param>
        /// <param name="action">Callback which receive animated value.</param>
        /// <param name="loopDuration">Loop duration of the tween.</param>
        /// <param name="ease">Easing formula which used when tween animate values.</param>
        /// <param name="loopsCount">Loops count of the tween.</param>
        /// <param name="loopType">Loop type which used between loops in the tween</param>
        /// <param name="direction">Direction in which the tween starts playing animation.</param>
        /// <returns>UShort tween.</returns>
        public static Tween<ushort, TweakUShort> UShort(ushort from, ushort to, Action<ushort> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return UShort(() => from, () => to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="from"><inheritdoc cref="UShort(Func{ushort}, Func{ushort}, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="UShort(Func{ushort}, Func{ushort}, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<ushort, TweakUShort> UShort(Func<ushort> from, Func<ushort> to, Action<ushort> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return new Tween<ushort, TweakUShort>(new TweakUShort(), from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region Int
        /// <summary>
        /// Create int tween.
        /// </summary>
        /// <param name="from">Value from which tween starts animation.</param>
        /// <param name="to">Value on which tween completes animation.</param>
        /// <param name="action">Callback which receive animated value.</param>
        /// <param name="loopDuration">Loop duration of the tween.</param>
        /// <param name="ease">Easing formula which used when tween animate values.</param>
        /// <param name="loopsCount">Loops count of the tween.</param>
        /// <param name="loopType">Loop type which used between loops in the tween</param>
        /// <param name="direction">Direction in which the tween starts playing animation.</param>
        /// <returns>Int tween.</returns>
        public static Tween<int, TweakInt> Int(int from, int to, Action<int> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Int(() => from, () => to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="from"><inheritdoc cref="Int(Func{int}, Func{int}, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Int(Func{int}, Func{int}, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<int, TweakInt> Int(Func<int> from, Func<int> to, Action<int> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return new Tween<int, TweakInt>(new TweakInt(), from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region UInt
        /// <summary>
        /// Create uint tween.
        /// </summary>
        /// <param name="from">Value from which tween starts animation.</param>
        /// <param name="to">Value on which tween completes animation.</param>
        /// <param name="action">Callback which receive animated value.</param>
        /// <param name="loopDuration">Loop duration of the tween.</param>
        /// <param name="ease">Easing formula which used when tween animate values.</param>
        /// <param name="loopsCount">Loops count of the tween.</param>
        /// <param name="loopType">Loop type which used between loops in the tween</param>
        /// <param name="direction">Direction in which the tween starts playing animation.</param>
        /// <returns>UInt tween.</returns>
        public static Tween<uint, TweakUInt> UInt(uint from, uint to, Action<uint> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return UInt(() => from, () => to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="from"><inheritdoc cref="UInt(Func{uint}, Func{uint}, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="UInt(Func{uint}, Func{uint}, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<uint, TweakUInt> UInt(Func<uint> from, Func<uint> to, Action<uint> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return new Tween<uint, TweakUInt>(new TweakUInt(), from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region Long
        /// <summary>
        /// Create long tween.
        /// </summary>
        /// <param name="from">Value from which tween starts animation.</param>
        /// <param name="to">Value on which tween completes animation.</param>
        /// <param name="action">Callback which receive animated value.</param>
        /// <param name="loopDuration">Loop duration of the tween.</param>
        /// <param name="ease">Easing formula which used when tween animate values.</param>
        /// <param name="loopsCount">Loops count of the tween.</param>
        /// <param name="loopType">Loop type which used between loops in the tween</param>
        /// <param name="direction">Direction in which the tween starts playing animation.</param>
        /// <returns>Long tween.</returns>
        public static Tween<long, TweakLong> Long(long from, long to, Action<long> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Long(() => from, () => to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="from"><inheritdoc cref="Long(Func{long}, Func{long}, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Long(Func{long}, Func{long}, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<long, TweakLong> Long(Func<long> from, Func<long> to, Action<long> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return new Tween<long, TweakLong>(new TweakLong(), from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region ULong
        /// <summary>
        /// Create ulong tween.
        /// </summary>
        /// <param name="from">Value from which tween starts animation.</param>
        /// <param name="to">Value on which tween completes animation.</param>
        /// <param name="action">Callback which receive animated value.</param>
        /// <param name="loopDuration">Loop duration of the tween.</param>
        /// <param name="ease">Easing formula which used when tween animate values.</param>
        /// <param name="loopsCount">Loops count of the tween.</param>
        /// <param name="loopType">Loop type which used between loops in the tween</param>
        /// <param name="direction">Direction in which the tween starts playing animation.</param>
        /// <returns>ULong tween.</returns>
        public static Tween<ulong, TweakULong> ULong(ulong from, ulong to, Action<ulong> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return ULong(() => from, () => to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="from"><inheritdoc cref="ULong(Func{ulong}, Func{ulong}, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="ULong(Func{ulong}, Func{ulong}, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<ulong, TweakULong> ULong(Func<ulong> from, Func<ulong> to, Action<ulong> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return new Tween<ulong, TweakULong>(new TweakULong(), from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region Float
        /// <summary>
        /// Create float tween.
        /// </summary>
        /// <param name="from">Value from which tween starts animation.</param>
        /// <param name="to">Value on which tween completes animation.</param>
        /// <param name="action">Callback which receive animated value.</param>
        /// <param name="loopDuration">Loop duration of the tween.</param>
        /// <param name="ease">Easing formula which used when tween animate values.</param>
        /// <param name="loopsCount">Loops count of the tween.</param>
        /// <param name="loopType">Loop type which used between loops in the tween</param>
        /// <param name="direction">Direction in which the tween starts playing animation.</param>
        /// <returns>Float tween.</returns>
        public static Tween<float, TweakFloat> Float(float from, float to, Action<float> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Float(() => from, () => to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="from"><inheritdoc cref="Float(Func{float}, Func{float}, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Float(Func{float}, Func{float}, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<float, TweakFloat> Float(Func<float> from, Func<float> to, Action<float> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return new Tween<float, TweakFloat>(new TweakFloat(), from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region Double
        /// <summary>
        /// Create double tween.
        /// </summary>
        /// <param name="from">Value from which tween starts animation.</param>
        /// <param name="to">Value on which tween completes animation.</param>
        /// <param name="action">Callback which receive animated value.</param>
        /// <param name="loopDuration">Loop duration of the tween.</param>
        /// <param name="ease">Easing formula which used when tween animate values.</param>
        /// <param name="loopsCount">Loops count of the tween.</param>
        /// <param name="loopType">Loop type which used between loops in the tween</param>
        /// <param name="direction">Direction in which the tween starts playing animation.</param>
        /// <returns>Double tween.</returns>
        public static Tween<double, TweakDouble> Double(double from, double to, Action<double> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Double(() => from, () => to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="from"><inheritdoc cref="Double(Func{double}, Func{double}, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Double(Func{double}, Func{double}, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<double, TweakDouble> Double(Func<double> from, Func<double> to, Action<double> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return new Tween<double, TweakDouble>(new TweakDouble(), from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region Decimal
        /// <summary>
        /// Create decimal tween.
        /// </summary>
        /// <param name="from">Value from which tween starts animation.</param>
        /// <param name="to">Value on which tween completes animation.</param>
        /// <param name="action">Callback which receive animated value.</param>
        /// <param name="loopDuration">Loop duration of the tween.</param>
        /// <param name="ease">Easing formula which used when tween animate values.</param>
        /// <param name="loopsCount">Loops count of the tween.</param>
        /// <param name="loopType">Loop type which used between loops in the tween</param>
        /// <param name="direction">Direction in which the tween starts playing animation.</param>
        /// <returns>Decimal tween.</returns>
        public static Tween<decimal, TweakDecimal> Decimal(decimal from, decimal to, Action<decimal> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Decimal(() => from, () => to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="from"><inheritdoc cref="Decimal(Func{decimal}, Func{decimal}, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Decimal(Func{decimal}, Func{decimal}, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<decimal, TweakDecimal> Decimal(Func<decimal> from, Func<decimal> to, Action<decimal> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return new Tween<decimal, TweakDecimal>(new TweakDecimal(), from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region Char
        /// <summary>
        /// Create char tween.
        /// </summary>
        /// <param name="from">Value from which tween starts animation.</param>
        /// <param name="to">Value on which tween completes animation.</param>
        /// <param name="action">Callback which receive animated value.</param>
        /// <param name="loopDuration">Loop duration of the tween.</param>
        /// <param name="ease">Easing formula which used when tween animate values.</param>
        /// <param name="loopsCount">Loops count of the tween.</param>
        /// <param name="loopType">Loop type which used between loops in the tween</param>
        /// <param name="direction">Direction in which the tween starts playing animation.</param>
        /// <returns>Char tween.</returns>
        public static Tween<char, TweakChar> Char(char from, char to, Action<char> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Char(() => from, () => to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="from"><inheritdoc cref="Char(Func{char}, Func{char}, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Char(Func{char}, Func{char}, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<char, TweakChar> Char(Func<char> from, Func<char> to, Action<char> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return new Tween<char, TweakChar>(new TweakChar(), from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region Vector2
        /// <summary>
        /// Create Vector2 tween.
        /// </summary>
        /// <param name="from">Value from which tween starts animation.</param>
        /// <param name="to">Value on which tween completes animation.</param>
        /// <param name="action">Callback which receive animated value.</param>
        /// <param name="loopDuration">Loop duration of the tween.</param>
        /// <param name="ease">Easing formula which used when tween animate values.</param>
        /// <param name="loopsCount">Loops count of the tween.</param>
        /// <param name="loopType">Loop type which used between loops in the tween</param>
        /// <param name="direction">Direction in which the tween starts playing animation.</param>
        /// <returns>Vector2 tween.</returns>
        public static Tween<Vector2, TweakVector2> Vector2(Vector2 from, Vector2 to, Action<Vector2> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Vector2(() => from, () => to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="from"><inheritdoc cref="Vector2(Func{Vector2}, Func{Vector2}, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Vector2(Func{Vector2}, Func{Vector2}, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Vector2, TweakVector2> Vector2(Func<Vector2> from, Func<Vector2> to, Action<Vector2> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return new Tween<Vector2, TweakVector2>(new TweakVector2(), from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region Vector2Int
        /// <summary>
        /// Create Vector2Int tween.
        /// </summary>
        /// <param name="from">Value from which tween starts animation.</param>
        /// <param name="to">Value on which tween completes animation.</param>
        /// <param name="action">Callback which receive animated value.</param>
        /// <param name="loopDuration">Loop duration of the tween.</param>
        /// <param name="ease">Easing formula which used when tween animate values.</param>
        /// <param name="loopsCount">Loops count of the tween.</param>
        /// <param name="loopType">Loop type which used between loops in the tween</param>
        /// <param name="direction">Direction in which the tween starts playing animation.</param>
        /// <returns>Vector2Int tween.</returns>
        public static Tween<Vector2Int, TweakVector2Int> Vector2Int(Vector2Int from, Vector2Int to, Action<Vector2Int> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Vector2Int(() => from, () => to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="from"><inheritdoc cref="Vector2Int(Func{Vector2Int}, Func{Vector2Int}, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Vector2Int(Func{Vector2Int}, Func{Vector2Int}, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Vector2Int, TweakVector2Int> Vector2Int(Func<Vector2Int> from, Func<Vector2Int> to, Action<Vector2Int> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return new Tween<Vector2Int, TweakVector2Int>(new TweakVector2Int(), from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region Vector3
        /// <summary>
        /// Create Vector3 tween.
        /// </summary>
        /// <param name="from">Value from which tween starts animation.</param>
        /// <param name="to">Value on which tween completes animation.</param>
        /// <param name="action">Callback which receive animated value.</param>
        /// <param name="loopDuration">Loop duration of the tween.</param>
        /// <param name="ease">Easing formula which used when tween animate values.</param>
        /// <param name="loopsCount">Loops count of the tween.</param>
        /// <param name="loopType">Loop type which used between loops in the tween</param>
        /// <param name="direction">Direction in which the tween starts playing animation.</param>
        /// <returns>Vector3 tween.</returns>
        public static Tween<Vector3, TweakVector3> Vector3(Vector3 from, Vector3 to, Action<Vector3> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Vector3(() => from, () => to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="from"><inheritdoc cref="Vector3(Func{Vector3}, Func{Vector3}, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Vector3(Func{Vector3}, Func{Vector3}, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Vector3, TweakVector3> Vector3(Func<Vector3> from, Func<Vector3> to, Action<Vector3> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return new Tween<Vector3, TweakVector3>(new TweakVector3(), from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region Vector3Int
        /// <summary>
        /// Create Vector3Int tween.
        /// </summary>
        /// <param name="from">Value from which tween starts animation.</param>
        /// <param name="to">Value on which tween completes animation.</param>
        /// <param name="action">Callback which receive animated value.</param>
        /// <param name="loopDuration">Loop duration of the tween.</param>
        /// <param name="ease">Easing formula which used when tween animate values.</param>
        /// <param name="loopsCount">Loops count of the tween.</param>
        /// <param name="loopType">Loop type which used between loops in the tween</param>
        /// <param name="direction">Direction in which the tween starts playing animation.</param>
        /// <returns>Vector3Int tween.</returns>
        public static Tween<Vector3Int, TweakVector3Int> Vector3Int(Vector3Int from, Vector3Int to, Action<Vector3Int> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Vector3Int(() => from, () => to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="from"><inheritdoc cref="Vector3Int(Func{Vector3Int}, Func{Vector3Int}, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Vector3Int(Func{Vector3Int}, Func{Vector3Int}, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Vector3Int, TweakVector3Int> Vector3Int(Func<Vector3Int> from, Func<Vector3Int> to, Action<Vector3Int> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return new Tween<Vector3Int, TweakVector3Int>(new TweakVector3Int(), from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region Vector4
        /// <summary>
        /// Create Vector4 tween.
        /// </summary>
        /// <param name="from">Value from which tween starts animation.</param>
        /// <param name="to">Value on which tween completes animation.</param>
        /// <param name="action">Callback which receive animated value.</param>
        /// <param name="loopDuration">Loop duration of the tween.</param>
        /// <param name="ease">Easing formula which used when tween animate values.</param>
        /// <param name="loopsCount">Loops count of the tween.</param>
        /// <param name="loopType">Loop type which used between loops in the tween</param>
        /// <param name="direction">Direction in which the tween starts playing animation.</param>
        /// <returns>Vector4 tween.</returns>
        public static Tween<Vector4, TweakVector4> Vector4(Vector4 from, Vector4 to, Action<Vector4> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Vector4(() => from, () => to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="from"><inheritdoc cref="Vector4(Func{Vector4}, Func{Vector4}, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Vector4(Func{Vector4}, Func{Vector4}, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Vector4, TweakVector4> Vector4(Func<Vector4> from, Func<Vector4> to, Action<Vector4> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return new Tween<Vector4, TweakVector4>(new TweakVector4(), from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region Color
        /// <summary>
        /// Create Color tween.
        /// </summary>
        /// <param name="from">Value from which tween starts animation.</param>
        /// <param name="to">Value on which tween completes animation.</param>
        /// <param name="action">Callback which receive animated value.</param>
        /// <param name="loopDuration">Loop duration of the tween.</param>
        /// <param name="ease">Easing formula which used when tween animate values.</param>
        /// <param name="loopsCount">Loops count of the tween.</param>
        /// <param name="loopType">Loop type which used between loops in the tween</param>
        /// <param name="direction">Direction in which the tween starts playing animation.</param>
        /// <returns>Color tween.</returns>
        public static Tween<Color, TweakColor> Color(Color from, Color to, Action<Color> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Color(() => from, () => to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="from"><inheritdoc cref="Color(Func{Color}, Func{Color}, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Color(Func{Color}, Func{Color}, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Color, TweakColor> Color(Func<Color> from, Func<Color> to, Action<Color> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return new Tween<Color, TweakColor>(new TweakColor(), from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region Color32
        /// <summary>
        /// Create Color32 tween.
        /// </summary>
        /// <param name="from">Value from which tween starts animation.</param>
        /// <param name="to">Value on which tween completes animation.</param>
        /// <param name="action">Callback which receive animated value.</param>
        /// <param name="loopDuration">Loop duration of the tween.</param>
        /// <param name="ease">Easing formula which used when tween animate values.</param>
        /// <param name="loopsCount">Loops count of the tween.</param>
        /// <param name="loopType">Loop type which used between loops in the tween</param>
        /// <param name="direction">Direction in which the tween starts playing animation.</param>
        /// <returns>Color32 tween.</returns>
        public static Tween<Color32, TweakColor32> Color32(Color32 from, Color32 to, Action<Color32> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Color32(() => from, () => to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="from"><inheritdoc cref="Color32(Func{Color32}, Func{Color32}, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Color32(Func{Color32}, Func{Color32}, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Color32, TweakColor32> Color32(Func<Color32> from, Func<Color32> to, Action<Color32> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return new Tween<Color32, TweakColor32>(new TweakColor32(), from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region Matrix4x4
        /// <summary>
        /// Create Matrix4x4 tween.
        /// </summary>
        /// <param name="from">Value from which tween starts animation.</param>
        /// <param name="to">Value on which tween completes animation.</param>
        /// <param name="action">Callback which receive animated value.</param>
        /// <param name="loopDuration">Loop duration of the tween.</param>
        /// <param name="ease">Easing formula which used when tween animate values.</param>
        /// <param name="loopsCount">Loops count of the tween.</param>
        /// <param name="loopType">Loop type which used between loops in the tween</param>
        /// <param name="direction">Direction in which the tween starts playing animation.</param>
        /// <returns>Matrix4x4 tween.</returns>
        public static Tween<Matrix4x4, TweakMatrix4x4> Matrix4x4(Matrix4x4 from, Matrix4x4 to, Action<Matrix4x4> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Matrix4x4(() => from, () => to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="from"><inheritdoc cref="Matrix4x4(Func{Matrix4x4}, Func{Matrix4x4}, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Matrix4x4(Func{Matrix4x4}, Func{Matrix4x4}, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Matrix4x4, TweakMatrix4x4> Matrix4x4(Func<Matrix4x4> from, Func<Matrix4x4> to, Action<Matrix4x4> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return new Tween<Matrix4x4, TweakMatrix4x4>(new TweakMatrix4x4(), from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region Quaternion
        /// <summary>
        /// Create Quaternion tween.
        /// </summary>
        /// <param name="from">Value from which tween starts animation.</param>
        /// <param name="to">Value on which tween completes animation.</param>
        /// <param name="action">Callback which receive animated value.</param>
        /// <param name="loopDuration">Loop duration of the tween.</param>
        /// <param name="ease">Easing formula which used when tween animate values.</param>
        /// <param name="loopsCount">Loops count of the tween.</param>
        /// <param name="loopType">Loop type which used between loops in the tween</param>
        /// <param name="direction">Direction in which the tween starts playing animation.</param>
        /// <returns>Quaternion tween.</returns>
        public static Tween<Quaternion, TweakQuaternion> Quaternion(Quaternion from, Quaternion to, Action<Quaternion> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Quaternion(() => from, () => to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="from"><inheritdoc cref="Quaternion(Func{Quaternion}, Func{Quaternion}, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Quaternion(Func{Quaternion}, Func{Quaternion}, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Quaternion, TweakQuaternion> Quaternion(Func<Quaternion> from, Func<Quaternion> to, Action<Quaternion> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return new Tween<Quaternion, TweakQuaternion>(new TweakQuaternion(), from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region Rect
        /// <summary>
        /// Create Rect tween.
        /// </summary>
        /// <param name="from">Value from which tween starts animation.</param>
        /// <param name="to">Value on which tween completes animation.</param>
        /// <param name="action">Callback which receive animated value.</param>
        /// <param name="loopDuration">Loop duration of the tween.</param>
        /// <param name="ease">Easing formula which used when tween animate values.</param>
        /// <param name="loopsCount">Loops count of the tween.</param>
        /// <param name="loopType">Loop type which used between loops in the tween</param>
        /// <param name="direction">Direction in which the tween starts playing animation.</param>
        /// <returns>Rect tween.</returns>
        public static Tween<Rect, TweakRect> Rect(Rect from, Rect to, Action<Rect> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Rect(() => from, () => to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="from"><inheritdoc cref="Rect(Func{Rect}, Func{Rect}, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Rect(Func{Rect}, Func{Rect}, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Rect, TweakRect> Rect(Func<Rect> from, Func<Rect> to, Action<Rect> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return new Tween<Rect, TweakRect>(new TweakRect(), from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region Bounds
        /// <summary>
        /// Create Bounds tween.
        /// </summary>
        /// <param name="from">Value from which tween starts animation.</param>
        /// <param name="to">Value on which tween completes animation.</param>
        /// <param name="action">Callback which receive animated value.</param>
        /// <param name="loopDuration">Loop duration of the tween.</param>
        /// <param name="ease">Easing formula which used when tween animate values.</param>
        /// <param name="loopsCount">Loops count of the tween.</param>
        /// <param name="loopType">Loop type which used between loops in the tween</param>
        /// <param name="direction">Direction in which the tween starts playing animation.</param>
        /// <returns>Bounds tween.</returns>
        public static Tween<Bounds, TweakBounds> Bounds(Bounds from, Bounds to, Action<Bounds> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Bounds(() => from, () => to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="from"><inheritdoc cref="Bounds(Func{Bounds}, Func{Bounds}, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Bounds(Func{Bounds}, Func{Bounds}, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Bounds, TweakBounds> Bounds(Func<Bounds> from, Func<Bounds> to, Action<Bounds> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return new Tween<Bounds, TweakBounds>(new TweakBounds(), from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region BoundsInt
        /// <summary>
        /// Create BoundsInt tween.
        /// </summary>
        /// <param name="from">Value from which tween starts animation.</param>
        /// <param name="to">Value on which tween completes animation.</param>
        /// <param name="action">Callback which receive animated value.</param>
        /// <param name="loopDuration">Loop duration of the tween.</param>
        /// <param name="ease">Easing formula which used when tween animate values.</param>
        /// <param name="loopsCount">Loops count of the tween.</param>
        /// <param name="loopType">Loop type which used between loops in the tween</param>
        /// <param name="direction">Direction in which the tween starts playing animation.</param>
        /// <returns>BoundsInt tween.</returns>
        public static Tween<BoundsInt, TweakBoundsInt> BoundsInt(BoundsInt from, BoundsInt to, Action<BoundsInt> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return BoundsInt(() => from, () => to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="from"><inheritdoc cref="BoundsInt(Func{BoundsInt}, Func{BoundsInt}, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="BoundsInt(Func{BoundsInt}, Func{BoundsInt}, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<BoundsInt, TweakBoundsInt> BoundsInt(Func<BoundsInt> from, Func<BoundsInt> to, Action<BoundsInt> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return new Tween<BoundsInt, TweakBoundsInt>(new TweakBoundsInt(), from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region BoundingSphere
        /// <summary>
        /// Create BoundingSphere tween.
        /// </summary>
        /// <param name="from">Value from which tween starts animation.</param>
        /// <param name="to">Value on which tween completes animation.</param>
        /// <param name="action">Callback which receive animated value.</param>
        /// <param name="loopDuration">Loop duration of the tween.</param>
        /// <param name="ease">Easing formula which used when tween animate values.</param>
        /// <param name="loopsCount">Loops count of the tween.</param>
        /// <param name="loopType">Loop type which used between loops in the tween</param>
        /// <param name="direction">Direction in which the tween starts playing animation.</param>
        /// <returns>BoundingSphere tween.</returns>
        public static Tween<BoundingSphere, TweakBoundingSphere> BoundingSphere(BoundingSphere from, BoundingSphere to, Action<BoundingSphere> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return BoundingSphere(() => from, () => to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="from"><inheritdoc cref="BoundingSphere(Func{BoundingSphere}, Func{BoundingSphere}, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="BoundingSphere(Func{BoundingSphere}, Func{BoundingSphere}, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<BoundingSphere, TweakBoundingSphere> BoundingSphere(Func<BoundingSphere> from, Func<BoundingSphere> to, Action<BoundingSphere> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return new Tween<BoundingSphere, TweakBoundingSphere>(new TweakBoundingSphere(), from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }
        #endregion
        #endregion

        #region Shake
        public static Tween<float, TweakFloat> Shake(float from, int count, float strenght, float duration, Action<float> action, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            var startX = UnityEngine.Random.Range(0f, 100f);
            var y = UnityEngine.Random.Range(0f, 300f);

            duration = Mathf.Max(duration, 0f);

            count = Mathf.Max(count, 0);
            strenght = Mathf.Abs(strenght);

            var endX = startX + count;

            var tween = Float(startX, endX, x =>
            {
                if (count == 0)
                    return;

                var percent = (x - startX) / count;
                var smoother = 1f;

                if (percent.Approximately(leftSmoothness) || percent < leftSmoothness)
                    smoother = percent.Remap(0f, leftSmoothness, 0f, 1f);
                else if (percent.Approximately(1f - rightSmoothness) || percent > 1f - rightSmoothness)
                    smoother = percent.Remap(1f - rightSmoothness, 1f, 1f, 0f);

                action(from + Mathf.Clamp01(Mathf.PerlinNoise(x, y)).Remap(0f, 1f, -1f, 1f) * strenght * smoother);
            }, duration);

            return tween;
        }
        #endregion

        #region Punch
        public static Tween<float, TweakFloat> Punch(float from, int count, float strenght, float duration, Action<float> action, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            var totalCount = count * 2f;
            return Float(0f, totalCount, x =>
            {
                if (count == 0)
                    return;

                var multiplier = Mathf.Sin(x * 90f * Mathf.Deg2Rad);

                var percent = x / totalCount;
                var smoother = 1f;

                if (percent.Approximately(leftSmoothness) || percent < leftSmoothness)
                    smoother = percent.Remap(0f, leftSmoothness, 0f, 1f);
                else if (percent.Approximately(1f - rightSmoothness) || percent > 1f - rightSmoothness)
                    smoother = percent.Remap(1f - rightSmoothness, 1f, 1f, 0f);

                action(from + strenght * multiplier * smoother);
            }, duration);
        }

        public static Tween<float, TweakFloat> Punch(Quaternion from, int count, Quaternion to, float duration, Action<Quaternion> action, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            var totalCount = count * 2f;
            return Float(0f, totalCount, x =>
            {
                if (count == 0)
                    return;

                var multiplier = Mathf.Sin(x * 90f * Mathf.Deg2Rad);

                var percent = x / totalCount;
                var smoother = 1f;

                if (percent.Approximately(leftSmoothness) || percent < leftSmoothness)
                    smoother = percent.Remap(0f, leftSmoothness, 0f, 1f);
                else if (percent.Approximately(1f - rightSmoothness) || percent > 1f - rightSmoothness)
                    smoother = percent.Remap(1f - rightSmoothness, 1f, 1f, 0f);

                action(UnityEngine.Quaternion.SlerpUnclamped(from, to, multiplier * smoother));
            }, duration);
        }
        #endregion
    }

    /// <summary>
    /// Represent interface to work with tween object.
    /// </summary>
    public interface ITween : IPlayable
    {
        #region Subscribes
        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <c>PhaseStarting</c> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The tween.</returns>
        ITween OnPhaseStarting(Action callback);

        /// <summary>
        /// <inheritdoc cref="OnPhaseStarting(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPhaseStarting(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPhaseStarting(Action)"/></returns>
        ITween OnPhaseStarting(Action<ITween, Direction> callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <c>PhaseStarted</c> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The tween.</returns>
        ITween OnPhaseStarted(Action callback);

        /// <summary>
        /// <inheritdoc cref="OnPhaseStarted(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPhaseStarted(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPhaseStarted(Action)"/></returns>
        ITween OnPhaseStarted(Action<ITween, Direction> callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <c>PhaseLoopStarting</c> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The tween.</returns>
        ITween OnPhaseLoopStarting(Action callback);

        /// <summary>
        /// <inheritdoc cref="OnPhaseLoopStarting(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPhaseLoopStarting(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPhaseLoopStarting(Action)"/></returns>
        ITween OnPhaseLoopStarting(Action<ITween, int, Direction> callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <c>PhaseLoopStarted</c> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The tween.</returns>
        ITween OnPhaseLoopStarted(Action callback);

        /// <summary>
        /// <inheritdoc cref="OnPhaseLoopStarted(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPhaseLoopStarted(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPhaseLoopStarted(Action)"/></returns>
        ITween OnPhaseLoopStarted(Action<ITween, int, Direction> callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <c>PhaseLoopUpdating</c> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The tween.</returns>
        ITween OnPhaseLoopUpdating(Action callback);

        /// <summary>
        /// <inheritdoc cref="OnPhaseLoopUpdating(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPhaseLoopUpdating(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPhaseLoopUpdating(Action)"/></returns>
        ITween OnPhaseLoopUpdating(Action<ITween, int, float, Direction> callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <c>PhaseLoopUpdated</c> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The tween.</returns>
        ITween OnPhaseLoopUpdated(Action callback);

        /// <summary>
        /// <inheritdoc cref="OnPhaseLoopUpdated(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPhaseLoopUpdated(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPhaseLoopUpdated(Action)"/></returns>
        ITween OnPhaseLoopUpdated(Action<ITween, int, float, Direction> callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <c>PhaseUpdating</c> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The tween.</returns>
        ITween OnPhaseUpdating(Action callback);

        /// <summary>
        /// <inheritdoc cref="OnPhaseUpdating(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPhaseUpdating(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPhaseUpdating(Action)"/></returns>
        ITween OnPhaseUpdating(Action<ITween, float, Direction> callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <c>PhaseUpdated</c> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The tween.</returns>
        ITween OnPhaseUpdated(Action callback);

        /// <summary>
        /// <inheritdoc cref="OnPhaseUpdated(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPhaseUpdated(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPhaseUpdated(Action)"/></returns>
        ITween OnPhaseUpdated(Action<ITween, float, Direction> callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <c>PhaseLoopCompleting</c> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The tween.</returns>
        ITween OnPhaseLoopCompleting(Action callback);

        /// <summary>
        /// <inheritdoc cref="OnPhaseLoopCompleting(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPhaseLoopCompleting(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPhaseLoopCompleting(Action)"/></returns>
        ITween OnPhaseLoopCompleting(Action<ITween, int, Direction> callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <c>PhaseLoopCompleted</c> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The tween.</returns>
        ITween OnPhaseLoopCompleted(Action callback);

        /// <summary>
        /// <inheritdoc cref="OnPhaseLoopCompleted(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPhaseLoopCompleted(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPhaseLoopCompleted(Action)"/></returns>
        ITween OnPhaseLoopCompleted(Action<ITween, int, Direction> callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <c>PhaseCompleting</c> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The tween.</returns>
        ITween OnPhaseCompleting(Action callback);

        /// <summary>
        /// <inheritdoc cref="OnPhaseCompleting(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPhaseCompleting(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPhaseCompleting(Action)"/></returns>
        ITween OnPhaseCompleting(Action<ITween, Direction> callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <c>PhaseCompleted</c> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The tween.</returns>
        ITween OnPhaseCompleted(Action callback);

        /// <summary>
        /// <inheritdoc cref="OnPhaseCompleted(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPhaseCompleted(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPhaseCompleted(Action)"/></returns>
        ITween OnPhaseCompleted(Action<ITween, Direction> callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <c>Reseted</c> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The tween.</returns>
        ITween OnReseted(Action callback);

        /// <summary>
        /// <inheritdoc cref="OnReseted(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnReseted(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnReseted(Action)"/></returns>
        ITween OnReseted(Action<ITween> callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <c>Playing</c> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The tween.</returns>
        ITween OnPlaying(Action callback);

        /// <summary>
        /// <inheritdoc cref="OnPlaying(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPlaying(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPlaying(Action)"/></returns>
        ITween OnPlaying(Action<ITween> callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <c>Paused</c> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The tween.</returns>
        ITween OnPaused(Action callback);

        /// <summary>
        /// <inheritdoc cref="OnPaused(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPaused(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPaused(Action)"/></returns>
        ITween OnPaused(Action<ITween> callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <c>Completed</c> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The tween.</returns>
        ITween OnCompleted(Action callback);

        /// <summary>
        /// <inheritdoc cref="OnCompleted(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnCompleted(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnCompleted(Action)"/></returns>
        ITween OnCompleted(Action<ITween> callback);
        #endregion

        /// <summary>
        /// Sets owner for the tween.
        /// </summary>
        /// <param name="component">Component whose game object used as owner.</param>
        /// <returns>The tween.</returns>
        new ITween SetOwner(Component component);

        /// <summary>
        /// Sets owner to the tween.
        /// </summary>
        /// <param name="gameObject">Owner for the playable.</param>
        /// <returns>The tween.</returns>
        new ITween SetOwner(GameObject gameObject);

        /// <summary>
        /// Make tween unowned.
        /// </summary>
        /// <returns>The tween.</returns>
        new ITween MakeUnowned();

        /// <summary>
        /// Sets name of the tween.
        /// </summary>
        /// <param name="name">Name to set.</param>
        /// <returns>The tween.</returns>
        new ITween SetName(string name);

        /// <summary>
        /// <inheritdoc cref="IPlayable.SetEase(Ease)"/>
        /// </summary>
        /// <param name="ease"><inheritdoc cref="IPlayable.SetEase(Ease)"/></param>
        /// <returns>The tween.</returns>
        new ITween SetEase(Ease ease);

        /// <summary>
        /// <inheritdoc cref="IPlayable.SetLoopCount(int)"/>
        /// </summary>
        /// <param name="loopsCount"><inheritdoc cref="IPlayable.SetLoopCount(int)(Ease)"/></param>
        /// <returns>The tween.</returns>
        new ITween SetLoopCount(int loopsCount);

        /// <summary>
        /// <inheritdoc cref="IPlayable.SetLoopType(LoopType)"/>
        /// </summary>
        /// <param name="loopType"><inheritdoc cref="IPlayable.SetLoopType(LoopType)"/></param>
        /// <returns>The tween.</returns>
        new ITween SetLoopType(LoopType loopType);

        /// <summary>
        /// <inheritdoc cref="IPlayable.SetDirection(Direction)"/>
        /// </summary>
        /// <param name="direction"><inheritdoc cref="IPlayable.SetDirection(Direction)"/></param>
        /// <returns>The tween.</returns>
        new ITween SetDirection(Direction direction);

        /// <summary>
        /// <inheritdoc cref="IPlayable.RewindTo(float, bool)"/>
        /// </summary>
        /// <param name="time"><inheritdoc cref="IPlayable.RewindTo(float, bool)"/></param>
        /// <param name="emitEvents"><inheritdoc cref="IPlayable.RewindTo(float, bool)"/></param>
        /// <returns>The tween.</returns>
        new ITween RewindTo(float time, bool emitEvents);

        /// <summary>
        /// <inheritdoc cref="IPlayable.RewindToStart(bool)"/>
        /// </summary>
        /// <param name="emitEvents"><inheritdoc cref="IPlayable.RewindToStart(bool)"/></param>
        /// <returns>The tween.</returns>
        new ITween RewindToStart(bool emitEvents);

        /// <summary>
        /// <inheritdoc cref="IPlayable.RewindToEnd(bool)"/>
        /// </summary>
        /// <param name="emitEvents"><inheritdoc cref="IPlayable.RewindToEnd(bool)"/></param>
        /// <returns>The tween.</returns>
        new ITween RewindToEnd(bool emitEvents);

        /// <summary>
        /// <inheritdoc cref="IPlayable.SkipTo(float)"/>
        /// </summary>
        /// <param name="time"><inheritdoc cref="IPlayable.SkipTo(float)"/></param>
        /// <returns>The tween.</returns>
        new ITween SkipTo(float time);

        /// <summary>
        /// <inheritdoc cref="IPlayable.SkipToStart"/>
        /// </summary>
        /// <returns>The tween.</returns>
        new ITween SkipToStart();

        /// <summary>
        /// <inheritdoc cref="IPlayable.SkipToEnd"/>
        /// </summary>
        /// <returns>The tween.</returns>
        new ITween SkipToEnd();

        /// <summary>
        /// <inheritdoc cref="IPlayable.SetTimeType(TimeType)"/>   
        /// </summary>
        /// <param name="type"><inheritdoc cref="IPlayable.SetTimeType(TimeType)"/></param>
        /// <returns>The tween.</returns>
        new ITween SetTimeType(TimeType type);

        /// <summary>
        /// <inheritdoc cref="IPlayable.PlayForward(bool)"/>
        /// </summary>
        /// <param name="resetIfCompleted"><inheritdoc cref="IPlayable.PlayForward(bool)"/></param>
        /// <returns>The tween.</returns>
        new ITween PlayForward(bool resetIfCompleted);

        /// <summary>
        /// <inheritdoc cref="IPlayable.PlayBackward(bool)"/>
        /// </summary>
        /// <param name="resetIfCompleted"><inheritdoc cref="IPlayable.PlayBackward(bool)"/></param>
        /// <returns>The tween.</returns>
        new ITween PlayBackward(bool resetIfCompleted);

        /// <summary>
        /// <inheritdoc cref="IPlayable.Play(bool)"/>
        /// </summary>
        /// <param name="resetIfCompleted"><inheritdoc cref="IPlayable.Play(bool)"/></param>
        /// <returns>The tween.</returns>
        new ITween Play(bool resetIfCompleted);

        /// <summary>
        /// Pause the tween. Can be continued later with <see cref="Play(bool)"/> method.
        /// </summary>
        /// <param name="resetIfCompleted"><inheritdoc cref="IPlayable.Pause"/></param>
        /// <returns>The tween.</returns>
        new ITween Pause();

        /// <summary>
        /// Reset the tween if it in non reset state.
        /// </summary>
        /// <param name="resetIfCompleted"><inheritdoc cref="IPlayable.Reset"/></param>
        /// <returns>The tween.</returns>
        new ITween Reset();

        /// <summary>
        /// Create repeater for the tween. 
        /// <br/>Example:
        /// <code>
        /// tween.GetRepeater().Play();
        /// </code>
        /// </summary>
        /// <returns>Repeater.</returns>
        new Playable.IRepeater<ITween> GetRepeater();

        /// <summary>
        /// Create repeater for the tween and starts repeating playing in <see cref="Playable.IRepeater{T}.Direction"/> property.
        /// <br/>Example:
        /// <code>
        /// tween.Repeat();
        /// </code>
        /// </summary>
        /// <returns>Repeater.</returns>
        new Playable.IRepeater<ITween> Repeat();

        /// <summary>
        /// Create repeater for the tween and starts repeating playing in forward direction.
        /// <br/>Example:
        /// <code>
        /// tween.RepeatForward();
        /// </code>
        /// </summary>
        /// <returns>Repeater.</returns>
        new Playable.IRepeater<ITween> RepeatForward();

        /// <summary>
        /// Create repeater for the tween and starts repeating playing in backward direction.
        /// <br/>Example:
        /// <code>
        /// tween.RepeatBackward();
        /// </code>
        /// </summary>
        /// <returns>Repeater.</returns>
        new Playable.IRepeater<ITween> RepeatBackward();

        /// <summary>
        /// <inheritdoc cref="IPlayable.LoopDuration"/>
        /// </summary>
        new float LoopDuration { get; set; }

        /// <summary>
        /// <inheritdoc cref="Tween{T, U}.SetLoopDuration(float)"/>
        /// </summary>
        /// <param name="loopDuration"><inheritdoc cref="Tween{T, U}.SetLoopDuration(float)"/></param>
        /// <returns><inheritdoc cref="Tween{T, U}.SetLoopDuration(float)"/></returns>
        ITween SetLoopDuration(float loopDuration);

        /// <summary>
        /// <inheritdoc cref="Tween{T, U}.SetTweakInterpolationType(InterpolationType)"/>
        /// </summary>
        /// <param name="type"><inheritdoc cref="Tween{T, U}.SetTweakInterpolationType(InterpolationType)"/></param>
        /// <returns><inheritdoc cref="Tween{T, U}.SetTweakInterpolationType(InterpolationType)"/></returns>
        ITween SetTweakInterpolationType(InterpolationType type);
    }

    /// <summary>
    /// Represents a class which can animate values over time.
    /// </summary>
    /// <typeparam name="T">Source type of animated value. Must be a structure.</typeparam>
    /// <typeparam name="U">Tweak type which can interpolate source type. Must have default constructor.</typeparam>
    public sealed class Tween<T, U> : Playable<Tween<T, U>>, ITween where T : struct where U : Tweak<T>, new()
    {
        #region State
        public override Type Type => Type.Tween;

        public new float LoopDuration
        {
            get => base.LoopDuration;
            set => base.LoopDuration = value;
        }

        /// <summary>
        /// Tweak which used for interpolate source type values.
        /// </summary>
        public U Tweak { get; set; }

        /// <summary>
        /// Delegate which return <c><b>from</b></c> value. Tween starts from this value.
        /// </summary>
        public Func<T> From { get; set; }

        /// <summary>
        /// Delegate which return <c><b>to</b></c> value. Tween completes on this value.
        /// </summary>
        public Func<T> To { get; set; }

        /// <summary>
        /// Callback which applied when playing this tween.
        /// </summary>
        public Action<T> Action { private get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Create tween object.
        /// </summary>
        /// <param name="from">Value from which tween starts animation.</param>
        /// <param name="to">Value on which tween completes animation.</param>
        /// <param name="action">Callback which receive animated value.</param>
        /// <param name="loopDuration">Loop duration of the tween.</param>
        /// <param name="ease">Easing formula which used when tween animate values.</param>
        /// <param name="loopsCount">Loops count of the tween.</param>
        /// <param name="loopType">Loop type which used between loops in the tween.</param>
        /// <param name="direction">Direction in which the tween starts playing animation.</param>
        public Tween(T from, T to, Action<T> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : this(new U(), from, to, action, loopDuration, ease, loopsCount, loopType, direction) { }

        /// <summary>
        /// <inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="tweak">Tweak which used to interpolate values.</param>
        /// <param name="from"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        public Tween(U tweak, T from, T to, Action<T> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : this(tweak, () => from, () => to, action, loopDuration, ease, loopsCount, loopType, direction) { }

        /// <summary>
        /// <inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="from">Callback which return value from which tween starts animation.</param>
        /// <param name="to">Callback which return value on which tween completes animation.</param>
        /// <param name="action"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        public Tween(Func<T> from, Func<T> to, Action<T> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : this(new U(), from, to, action, loopDuration, ease, loopsCount, loopType, direction) { }

        /// <summary>
        /// <inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="tweak"><inheritdoc cref="Tween{T, U}.Tween(U, T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='tweak']"/></param>
        /// <param name="from"><inheritdoc cref="Tween{T, U}.Tween(Func{T}, Func{T}, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Tween{T, U}.Tween(Func{T}, Func{T}, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        public Tween(U tweak, Func<T> from, Func<T> to, Action<T> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : base(loopDuration, ease, loopsCount, loopType, direction)
        {
            Tweak = tweak;
            From = from;
            To = to;
            Action = action;
        }
        #endregion

        #region Set From and To
        /// <summary>
        /// Sets <see langword=""="From"/> value.
        /// </summary>
        /// <param name="from">Value to set.</param>
        /// <returns>The tween.</returns>
        public Tween<T, U> SetFrom(T from) => SetFrom(() => from);

        /// <summary>
        /// Sets <see langword="From"/> callback value.
        /// </summary>
        /// <param name="from">Callback value to set.</param>
        /// <returns>The tween.</returns>
        public Tween<T, U> SetFrom(Func<T> from)
        {
            From = from;
            return this;
        }

        /// <summary>
        /// Sets <see langword="To"/> value.
        /// </summary>
        /// <param name="to">Value to set.</param>
        /// <returns>The tween.</returns>
        public Tween<T, U> SetTo(T to) => SetTo(() => to);

        /// <summary>
        /// Sets <see langword="To"/> callback value.
        /// </summary>
        /// <param name="to">Callback value to set.</param>
        /// <returns>The tween.</returns>
        public Tween<T, U> SetTo(Func<T> to)
        {
            To = to;
            return this;
        }
        #endregion

        #region Overlaps
        #region Subscribes
        ITween ITween.OnPhaseStarting(Action callback) => OnPhaseStarting(callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <c>PhaseStarting</c> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The tween.</returns>
        public new Tween<T, U> OnPhaseStarting(Action callback) => OnPhaseStarting((p, d) => callback());

        ITween ITween.OnPhaseStarting(Action<ITween, Direction> callback) => OnPhaseStarting(callback);

        /// <summary>
        /// <inheritdoc cref="OnPhaseStarting(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPhaseStarting(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPhaseStarting(Action)"/></returns>
        public new Tween<T, U> OnPhaseStarting(Action<Tween<T, U>, Direction> callback) => (Tween<T, U>)base.OnPhaseStarting(callback);

        ITween ITween.OnPhaseStarted(Action callback) => OnPhaseStarted(callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <c>PhaseStarted</c> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The tween.</returns>
        public new Tween<T, U> OnPhaseStarted(Action callback) => OnPhaseStarted((p, d) => callback());

        ITween ITween.OnPhaseStarted(Action<ITween, Direction> callback) => OnPhaseStarted(callback);

        /// <summary>
        /// <inheritdoc cref="OnPhaseStarted(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPhaseStarted(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPhaseStarted(Action)"/></returns>
        public new Tween<T, U> OnPhaseStarted(Action<Tween<T, U>, Direction> callback) => (Tween<T, U>)base.OnPhaseStarted(callback);

        ITween ITween.OnPhaseLoopStarting(Action callback) => OnPhaseLoopStarting(callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <c>PhaseLoopStarting</c> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The tween.</returns>
        public new Tween<T, U> OnPhaseLoopStarting(Action callback) => OnPhaseLoopStarting((p, l, d) => callback());

        ITween ITween.OnPhaseLoopStarting(Action<ITween, int, Direction> callback) => OnPhaseLoopStarting(callback);

        /// <summary>
        /// <inheritdoc cref="OnPhaseLoopStarting(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPhaseLoopStarting(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPhaseLoopStarting(Action)"/></returns>
        public new Tween<T, U> OnPhaseLoopStarting(Action<Tween<T, U>, int, Direction> callback) => (Tween<T, U>)base.OnPhaseLoopStarting(callback);

        ITween ITween.OnPhaseLoopStarted(Action callback) => OnPhaseLoopStarted(callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <c>PhaseLoopStarted</c> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The tween.</returns>
        public new Tween<T, U> OnPhaseLoopStarted(Action callback) => OnPhaseLoopStarted((p, l, d) => callback());

        ITween ITween.OnPhaseLoopStarted(Action<ITween, int, Direction> callback) => OnPhaseLoopStarted(callback);

        /// <summary>
        /// <inheritdoc cref="OnPhaseLoopStarted(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPhaseLoopStarted(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPhaseLoopStarted(Action)"/></returns>
        public new Tween<T, U> OnPhaseLoopStarted(Action<Tween<T, U>, int, Direction> callback) => (Tween<T, U>)base.OnPhaseLoopStarted(callback);

        ITween ITween.OnPhaseLoopUpdating(Action callback) => OnPhaseLoopUpdating(callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <c>PhaseLoopUpdating</c> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The tween.</returns>
        public new Tween<T, U> OnPhaseLoopUpdating(Action callback) => OnPhaseLoopUpdating((p, l, lt, d) => callback());

        ITween ITween.OnPhaseLoopUpdating(Action<ITween, int, float, Direction> callback) => OnPhaseLoopUpdating(callback);

        /// <summary>
        /// <inheritdoc cref="OnPhaseLoopUpdating(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPhaseLoopUpdating(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPhaseLoopUpdating(Action)"/></returns>
        public new Tween<T, U> OnPhaseLoopUpdating(Action<Tween<T, U>, int, float, Direction> callback) => (Tween<T, U>)base.OnPhaseLoopUpdating(callback);

        ITween ITween.OnPhaseLoopUpdated(Action callback) => OnPhaseLoopUpdated(callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <c>PhaseLoopUpdated</c> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The tween.</returns>
        public new Tween<T, U> OnPhaseLoopUpdated(Action callback) => OnPhaseLoopUpdated((p, l, lt, d) => callback());

        ITween ITween.OnPhaseLoopUpdated(Action<ITween, int, float, Direction> callback) => OnPhaseLoopUpdated(callback);

        /// <summary>
        /// <inheritdoc cref="OnPhaseLoopUpdated(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPhaseLoopUpdated(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPhaseLoopUpdated(Action)"/></returns>
        public new Tween<T, U> OnPhaseLoopUpdated(Action<Tween<T, U>, int, float, Direction> callback) => (Tween<T, U>)base.OnPhaseLoopUpdated(callback);

        ITween ITween.OnPhaseUpdating(Action callback) => OnPhaseUpdating(callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <c>PhaseUpdating</c> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The tween.</returns>
        public new Tween<T, U> OnPhaseUpdating(Action callback) => OnPhaseUpdating((p, t, d) => callback());

        ITween ITween.OnPhaseUpdating(Action<ITween, float, Direction> callback) => OnPhaseUpdating(callback);

        /// <summary>
        /// <inheritdoc cref="OnPhaseUpdating(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPhaseUpdating(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPhaseUpdating(Action)"/></returns>
        public new Tween<T, U> OnPhaseUpdating(Action<Tween<T, U>, float, Direction> callback) => (Tween<T, U>)base.OnPhaseUpdating(callback);

        ITween ITween.OnPhaseUpdated(Action callback) => OnPhaseUpdated(callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <c>PhaseUpdated</c> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The tween.</returns>
        public new Tween<T, U> OnPhaseUpdated(Action callback) => OnPhaseUpdated((p, t, d) => callback());

        ITween ITween.OnPhaseUpdated(Action<ITween, float, Direction> callback) => OnPhaseUpdated(callback);

        /// <summary>
        /// <inheritdoc cref="OnPhaseUpdated(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPhaseUpdated(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPhaseUpdated(Action)"/></returns>
        public new Tween<T, U> OnPhaseUpdated(Action<Tween<T, U>, float, Direction> callback) => (Tween<T, U>)base.OnPhaseUpdated(callback);

        ITween ITween.OnPhaseLoopCompleting(Action callback) => OnPhaseLoopCompleting(callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <c>PhaseLoopCompleting</c> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The tween.</returns>
        public new Tween<T, U> OnPhaseLoopCompleting(Action callback) => OnPhaseLoopCompleting((p, l, d) => callback());

        ITween ITween.OnPhaseLoopCompleting(Action<ITween, int, Direction> callback) => OnPhaseLoopCompleting(callback);

        /// <summary>
        /// <inheritdoc cref="OnPhaseLoopCompleting(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPhaseLoopCompleting(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPhaseLoopCompleting(Action)"/></returns>
        public new Tween<T, U> OnPhaseLoopCompleting(Action<Tween<T, U>, int, Direction> callback) => (Tween<T, U>)base.OnPhaseLoopCompleting(callback);

        ITween ITween.OnPhaseLoopCompleted(Action callback) => OnPhaseLoopCompleted(callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <c>PhaseLoopCompleted</c> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The tween.</returns>
        public new Tween<T, U> OnPhaseLoopCompleted(Action callback) => OnPhaseLoopCompleted((p, l, d) => callback());

        ITween ITween.OnPhaseLoopCompleted(Action<ITween, int, Direction> callback) => OnPhaseLoopCompleted(callback);

        /// <summary>
        /// <inheritdoc cref="OnPhaseLoopCompleted(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPhaseLoopCompleted(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPhaseLoopCompleted(Action)"/></returns>
        public new Tween<T, U> OnPhaseLoopCompleted(Action<Tween<T, U>, int, Direction> callback) => (Tween<T, U>)base.OnPhaseLoopCompleted(callback);

        ITween ITween.OnPhaseCompleting(Action callback) => OnPhaseCompleting(callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <c>PhaseCompleting</c> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The tween.</returns>
        public new Tween<T, U> OnPhaseCompleting(Action callback) => OnPhaseCompleting((p, d) => callback());

        ITween ITween.OnPhaseCompleting(Action<ITween, Direction> callback) => OnPhaseCompleting(callback);

        /// <summary>
        /// <inheritdoc cref="OnPhaseCompleting(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPhaseCompleting(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPhaseCompleting(Action)"/></returns>
        public new Tween<T, U> OnPhaseCompleting(Action<Tween<T, U>, Direction> callback) => (Tween<T, U>)base.OnPhaseCompleting(callback);

        ITween ITween.OnPhaseCompleted(Action callback) => OnPhaseCompleted(callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <c>PhaseCompleted</c> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The tween.</returns>
        public new Tween<T, U> OnPhaseCompleted(Action callback) => OnPhaseCompleted((p, d) => callback());

        ITween ITween.OnPhaseCompleted(Action<ITween, Direction> callback) => OnPhaseCompleted(callback);

        /// <summary>
        /// <inheritdoc cref="OnPhaseCompleted(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPhaseCompleted(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPhaseCompleted(Action)"/></returns>
        public new Tween<T, U> OnPhaseCompleted(Action<Tween<T, U>, Direction> callback) => (Tween<T, U>)base.OnPhaseCompleted(callback);

        ITween ITween.OnReseted(Action callback) => OnReseted(callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <c>Reseted</c> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The tween.</returns>
        public new Tween<T, U> OnReseted(Action callback) => OnReseted(p => callback());

        ITween ITween.OnReseted(Action<ITween> callback) => OnReseted(callback);

        /// <summary>
        /// <inheritdoc cref="OnReseted(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnReseted(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnReseted(Action)"/></returns>
        public new Tween<T, U> OnReseted(Action<Tween<T, U>> callback) => (Tween<T, U>)base.OnReseted(callback);

        ITween ITween.OnPlaying(Action callback) => OnPlaying(callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <c>Playing</c> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The tween.</returns>
        public new Tween<T, U> OnPlaying(Action callback) => OnPlaying(p => callback());

        ITween ITween.OnPlaying(Action<ITween> callback) => OnPlaying(callback);

        /// <summary>
        /// <inheritdoc cref="OnPlaying(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPlaying(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPlaying(Action)"/></returns>
        public new Tween<T, U> OnPlaying(Action<Tween<T, U>> callback) => (Tween<T, U>)base.OnPlaying(callback);

        ITween ITween.OnPaused(Action callback) => OnPaused(callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <c>Paused</c> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The tween.</returns>
        public new Tween<T, U> OnPaused(Action callback) => OnPaused(p => callback());

        ITween ITween.OnPaused(Action<ITween> callback) => OnPaused(callback);

        /// <summary>
        /// <inheritdoc cref="OnPaused(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnPaused(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnPaused(Action)"/></returns>
        public new Tween<T, U> OnPaused(Action<Tween<T, U>> callback) => (Tween<T, U>)base.OnPaused(callback);

        ITween ITween.OnCompleted(Action callback) => OnCompleted(callback);

        /// <summary>
        /// Subscribe passed <paramref name="callback"/> to <c>Completed</c> event.
        /// </summary>
        /// <param name="callback">Callback to subscribe.</param>
        /// <returns>The tween.</returns>
        public new Tween<T, U> OnCompleted(Action callback) => OnCompleted(p => callback());

        ITween ITween.OnCompleted(Action<ITween> callback) => OnCompleted(callback);

        /// <summary>
        /// <inheritdoc cref="OnCompleted(Action)"/>
        /// </summary>
        /// <param name="callback"><inheritdoc cref="OnCompleted(Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="OnCompleted(Action)"/></returns>
        public new Tween<T, U> OnCompleted(Action<Tween<T, U>> callback) => (Tween<T, U>)base.OnCompleted(callback);
        #endregion

        #region Set methods
        ITween ITween.SetOwner(Component component) => SetOwner(component);

        /// <summary>
        /// <inheritdoc cref="ITween.SetOwner(Component)"/>
        /// </summary>
        /// <param name="component"><inheritdoc cref="ITween.SetOwner(Component)"/></param>
        /// <returns><inheritdoc cref="ITween.SetOwner(Component)"/></returns>
        public new Tween<T, U> SetOwner(Component component) => (Tween<T, U>)base.SetOwner(component);

        ITween ITween.SetOwner(GameObject gameObject) => SetOwner(gameObject);

        /// <summary>
        /// <inheritdoc cref="ITween.SetOwner(GameObject)"/>
        /// </summary>
        /// <param name="gameObject"><inheritdoc cref="ITween.SetOwner(GameObject)"/></param>
        /// <returns><inheritdoc cref="ITween.SetOwner(GameObject)"/></returns>
        public new Tween<T, U> SetOwner(GameObject gameObject) => (Tween<T, U>)base.SetOwner(gameObject);

        ITween ITween.MakeUnowned() => MakeUnowned();

        /// <summary>
        /// <inheritdoc cref="ITween.MakeUnowned()"/>
        /// </summary>
        /// <returns><inheritdoc cref="ITween.MakeUnowned()"/></returns>
        public new Tween<T, U> MakeUnowned() => (Tween<T, U>)base.MakeUnowned();

        ITween ITween.SetName(string name) => SetName(name);

        /// <summary>
        /// <inheritdoc cref="ITween.SetName(string)"/>
        /// </summary>
        /// <param name="name"><inheritdoc cref="ITween.SetName(string)"/></param>
        /// <returns><inheritdoc cref="ITween.SetName(string)"/></returns>
        public new Tween<T, U> SetName(string name) => (Tween<T, U>)base.SetName(name);

        ITween ITween.SetEase(Ease ease) => SetEase(ease);

        /// <summary>
        /// <inheritdoc cref="IPlayable.SetEase(Ease)"/>
        /// </summary>
        /// <param name="ease"><inheritdoc cref="IPlayable.SetEase(Ease)"/></param>
        /// <returns>The tween.</returns>
        public new Tween<T, U> SetEase(Ease ease) => (Tween<T, U>)base.SetEase(ease);

        ITween ITween.SetLoopCount(int loopsCount) => SetLoopCount(loopsCount);

        /// <summary>
        /// <inheritdoc cref="IPlayable.SetLoopCount(int)"/>
        /// </summary>
        /// <param name="loopsCount"><inheritdoc cref="IPlayable.SetLoopCount(int)(Ease)"/></param>
        /// <returns>The tween.</returns>
        public new Tween<T, U> SetLoopCount(int loopsCount) => (Tween<T, U>)base.SetLoopCount(loopsCount);

        ITween ITween.SetLoopDuration(float loopDuration) => SetLoopDuration(loopDuration);

        /// <summary>
        /// Sets loop duration of the tween.
        /// </summary>
        /// <param name="loopDuration">Loop duration.</param>
        /// <returns>The tween.</returns>
        public Tween<T, U> SetLoopDuration(float loopDuration)
        {
            LoopDuration = loopDuration;
            return this;
        }

        ITween ITween.SetLoopType(LoopType loopType) => SetLoopType(loopType);

        /// <summary>
        /// <inheritdoc cref="IPlayable.SetLoopType(LoopType)"/>
        /// </summary>
        /// <param name="loopType"><inheritdoc cref="IPlayable.SetLoopType(LoopType)"/></param>
        /// <returns>The tween.</returns>
        public new Tween<T, U> SetLoopType(LoopType loopType) => (Tween<T, U>)base.SetLoopType(loopType);

        ITween ITween.SetDirection(Direction direction) => SetDirection(direction);

        /// <summary>
        /// <inheritdoc cref="IPlayable.SetDirection(Direction)"/>
        /// </summary>
        /// <param name="direction"><inheritdoc cref="IPlayable.SetDirection(Direction)"/></param>
        /// <returns>The tween.</returns>
        public new Tween<T, U> SetDirection(Direction direction) => (Tween<T, U>)base.SetDirection(direction);

        #endregion

        #region Rewinds
        ITween ITween.RewindTo(float time, bool emitEvents) => RewindTo(time, emitEvents);

        /// <summary>
        /// <inheritdoc cref="IPlayable.RewindTo(float, bool)"/>
        /// </summary>
        /// <param name="time"><inheritdoc cref="IPlayable.RewindTo(float, bool)"/></param>
        /// <param name="emitEvents"><inheritdoc cref="IPlayable.RewindTo(float, bool)"/></param>
        /// <returns>The tween.</returns>
        public new Tween<T, U> RewindTo(float time, bool emitEvents = true) => RewindTo(time, 0, 1, emitEvents);

        internal new Tween<T, U> RewindTo(float time, int parentContinueLoopIndex, int continueMaxLoopsCount, bool emitEvents) => (Tween<T, U>)base.RewindTo(time, parentContinueLoopIndex, continueMaxLoopsCount, emitEvents);

        ITween ITween.RewindToStart(bool emitEvents) => RewindToStart(emitEvents);

        /// <summary>
        /// <inheritdoc cref="IPlayable.RewindToStart(bool)"/>
        /// </summary>
        /// <param name="emitEvents"><inheritdoc cref="IPlayable.RewindToStart(bool)"/></param>
        /// <returns>The tween.</returns>
        public new Tween<T, U> RewindToStart(bool emitEvents = true) => RewindToStart(0, 1, emitEvents);

        internal new Tween<T, U> RewindToStart(int parentContinueLoopIndex, int continueMaxLoopsCount, bool emitEvents) => (Tween<T, U>)base.RewindToStart(parentContinueLoopIndex, continueMaxLoopsCount, emitEvents);

        ITween ITween.RewindToEnd(bool emitEvents) => RewindToEnd(emitEvents);

        /// <summary>
        /// <inheritdoc cref="IPlayable.RewindToEnd(bool)"/>
        /// </summary>
        /// <param name="emitEvents"><inheritdoc cref="IPlayable.RewindToEnd(bool)"/></param>
        /// <returns>The tween.</returns>
        public new Tween<T, U> RewindToEnd(bool emitEvents = true) => RewindToEnd(0, 1, emitEvents);

        internal new Tween<T, U> RewindToEnd(int parentContinueLoopIndex, int continueMaxLoopsCount, bool emitEvents) => (Tween<T, U>)base.RewindToEnd(parentContinueLoopIndex, continueMaxLoopsCount, emitEvents);
        #endregion

        #region Skips
        ITween ITween.SkipTo(float time) => SkipTo(time);

        /// <summary>
        /// <inheritdoc cref="IPlayable.SkipTo(float)"/>
        /// </summary>
        /// <param name="time"><inheritdoc cref="IPlayable.SkipTo(float)"/></param>
        /// <returns>The tween.</returns>
        public new Tween<T, U> SkipTo(float time) => (Tween<T, U>)base.SkipTo(time);

        ITween ITween.SkipToStart() => SkipToStart();

        /// <summary>
        /// <inheritdoc cref="IPlayable.SkipToStart"/>
        /// </summary>
        /// <returns>The tween.</returns>
        public new Tween<T, U> SkipToStart() => (Tween<T, U>)base.SkipToStart();

        ITween ITween.SkipToEnd() => SkipToEnd();

        /// <summary>
        /// <inheritdoc cref="IPlayable.SkipToEnd"/>
        /// </summary>
        /// <returns>The tween.</returns>
        public new Tween<T, U> SkipToEnd() => (Tween<T, U>)base.SkipToEnd();
        #endregion

        #region Playing
        ITween ITween.SetTimeType(TimeType type) => SetTimeType(type);

        /// <summary>
        /// <inheritdoc cref="IPlayable.SetTimeType(TimeType)"/>   
        /// </summary>
        /// <param name="type"><inheritdoc cref="IPlayable.SetTimeType(TimeType)"/></param>
        /// <returns>The tween.</returns>
        public new Tween<T, U> SetTimeType(TimeType type) => (Tween<T, U>)base.SetTimeType(type);

        ITween ITween.PlayForward(bool resetIfCompleted) => PlayForward(resetIfCompleted);

        /// <summary>
        /// <inheritdoc cref="IPlayable.PlayForward(bool)"/>
        /// </summary>
        /// <param name="resetIfCompleted"><inheritdoc cref="IPlayable.PlayForward(bool)"/></param>
        /// <returns>The tween.</returns>
        public new Tween<T, U> PlayForward(bool resetIfCompleted = true) => (Tween<T, U>)base.PlayForward(resetIfCompleted);

        ITween ITween.PlayBackward(bool resetIfCompleted) => PlayBackward(resetIfCompleted);

        /// <summary>
        /// <inheritdoc cref="IPlayable.PlayBackward(bool)"/>
        /// </summary>
        /// <param name="resetIfCompleted"><inheritdoc cref="IPlayable.PlayBackward(bool)"/></param>
        /// <returns>The tween.</returns>
        public new Tween<T, U> PlayBackward(bool resetIfCompleted = true) => (Tween<T, U>)base.PlayBackward(resetIfCompleted);

        ITween ITween.Play(bool resetIfCompleted) => Play(resetIfCompleted);

        /// <summary>
        /// <inheritdoc cref="IPlayable.Play(bool)"/>
        /// </summary>
        /// <param name="resetIfCompleted"><inheritdoc cref="IPlayable.Play(bool)"/></param>
        /// <returns>The tween.</returns>
        public new Tween<T, U> Play(bool resetIfCompleted = true) => (Tween<T, U>)base.Play(resetIfCompleted);

        ITween ITween.Pause() => Pause();

        /// <summary>
        /// Pause the tween. Can be continued later with <see cref="Play(bool)"/> method.
        /// </summary>
        /// <param name="resetIfCompleted"><inheritdoc cref="IPlayable.Pause"/></param>
        /// <returns>The tween.</returns>
        public new Tween<T, U> Pause() => (Tween<T, U>)base.Pause();

        ITween ITween.Reset() => Reset();

        /// <summary>
        /// Reset the tween if it in non reset state.
        /// </summary>
        /// <param name="resetIfCompleted"><inheritdoc cref="IPlayable.Reset"/></param>
        /// <returns>The tween.</returns>
        public new Tween<T, U> Reset() => (Tween<T, U>)base.Reset();
        #endregion

        #region Repeater
        IRepeater<ITween> ITween.GetRepeater() => CreateRepeater();

        IRepeater<ITween> ITween.Repeat() => GetRepeater().Play();

        IRepeater<ITween> ITween.RepeatForward() => GetRepeater().PlayForward();

        IRepeater<ITween> ITween.RepeatBackward() => GetRepeater().PlayBackward();

        public new IRepeater<Tween<T, U>> RepeatBackward() => GetRepeater().PlayBackward();
        #endregion
        #endregion

        ITween ITween.SetTweakInterpolationType(InterpolationType type) => SetTweakInterpolationType(type);

        /// <summary>
        /// Set tweak interpolation type if tweak inherited by TweakDirectional<![CDATA[<]]>T<![CDATA[>]]>.
        /// </summary>
        /// <param name="type">Interpolation type to set.</param>
        /// <returns>The tween.</returns>
        public Tween<T, U> SetTweakInterpolationType(InterpolationType type)
        {
            if (Tweak is TweakDirectional<T> tweak)
                tweak.InterpolationType = type;

            return this;
        }

        private Ease InvertIfRequiredAndGetease(Direction direction) => direction == Direction.Forward ? Ease : Ease.Invertion.With(Ease);

        private void EvaluateFromTo(ref T from, ref T to, float fromInterlopation, float toInterpolation) => (from, to) = (Tweak.Evaluate(from, to, fromInterlopation), Tweak.Evaluate(from, to, toInterpolation));

        protected override void RewindZeroHandler(int loop, float loopedNormalizedTime, Direction direction, bool emitEvents, int parentContinueLoopIndex, int continueMaxLoopsCount)
        {
            var (from, to) = (From(), To());

            if (LoopType == LoopType.Reset)
            {
                if (direction == Direction.Forward)
                    EvaluateFromTo(ref from, ref to, parentContinueLoopIndex, parentContinueLoopIndex + 1f);
                else
                    EvaluateFromTo(ref from, ref to, continueMaxLoopsCount - parentContinueLoopIndex, continueMaxLoopsCount - parentContinueLoopIndex - 1f);

                Tweak.Apply(from, to, loopedNormalizedTime, Action, Ease);
            }
            else if (LoopType == LoopType.Continue)
            {
                if (direction == Direction.Forward)
                    EvaluateFromTo(ref from, ref to, parentContinueLoopIndex * LoopsCount + loop, parentContinueLoopIndex * LoopsCount + loop + 1f);
                else
                    EvaluateFromTo(ref from, ref to, continueMaxLoopsCount * LoopsCount - (parentContinueLoopIndex * LoopsCount) - loop, continueMaxLoopsCount * LoopsCount - (parentContinueLoopIndex * LoopsCount) - loop - 1f);

                Tweak.Apply(from, to, loopedNormalizedTime, Action, Ease);
            }
            else if (LoopType == LoopType.Mirror)
            {
                if (direction == Direction.Forward)
                    EvaluateFromTo(ref from, ref to, parentContinueLoopIndex, parentContinueLoopIndex + 1f);
                else
                    EvaluateFromTo(ref from, ref to, continueMaxLoopsCount - parentContinueLoopIndex - 1f, continueMaxLoopsCount - parentContinueLoopIndex);

                var loopedMirroredNormalizedTime = loopedNormalizedTime * 2f;

                if (loopedMirroredNormalizedTime > 1f)
                    loopedMirroredNormalizedTime = 2f - loopedMirroredNormalizedTime;

                Tweak.Apply(from, to, loopedMirroredNormalizedTime, Action, Ease);
            }
        }

        protected override void RewindHandler(int loop, float loopedTime, Direction direction, bool emitEvents, int parentContinueLoopIndex, int continueMaxLoopsCount)
        {
            var (from, to) = (From(), To());
            var loopedNormalizedTime = loopedTime / LoopDuration;

            if (LoopType == LoopType.Reset)
            {
                if (direction == Direction.Forward)
                    EvaluateFromTo(ref from, ref to, parentContinueLoopIndex, parentContinueLoopIndex + 1f);
                else
                    EvaluateFromTo(ref from, ref to, continueMaxLoopsCount - parentContinueLoopIndex, continueMaxLoopsCount - parentContinueLoopIndex - 1f);

                Tweak.Apply(from, to, loopedNormalizedTime, Action, InvertIfRequiredAndGetease(direction));
            }
            else if (LoopType == LoopType.Continue)
            {
                if (direction == Direction.Forward)
                    EvaluateFromTo(ref from, ref to, parentContinueLoopIndex * LoopsCount + loop, parentContinueLoopIndex * LoopsCount + loop + 1f);
                else
                    EvaluateFromTo(ref from, ref to, continueMaxLoopsCount * LoopsCount - (parentContinueLoopIndex * LoopsCount) - loop, continueMaxLoopsCount * LoopsCount - (parentContinueLoopIndex * LoopsCount) - loop - 1f);

                Tweak.Apply(from, to, loopedNormalizedTime, Action, InvertIfRequiredAndGetease(direction));
            }
            else if (LoopType == LoopType.Mirror)
            {
                if (direction == Direction.Forward)
                    EvaluateFromTo(ref from, ref to, parentContinueLoopIndex, parentContinueLoopIndex + 1f);
                else
                    EvaluateFromTo(ref from, ref to, continueMaxLoopsCount - parentContinueLoopIndex - 1f, continueMaxLoopsCount - parentContinueLoopIndex);

                var loopedMirroredNormalizedTime = loopedNormalizedTime * 2f;

                if (loopedMirroredNormalizedTime > 1f)
                    loopedMirroredNormalizedTime = 2f - loopedMirroredNormalizedTime;

                Tweak.Apply(from, to, loopedMirroredNormalizedTime, Action, Ease);
            }
        }

        /// <summary>
        /// Evaluate <c>Tweak</c> with tween <c>LoopsCount</c> and <c>LoopType</c> options. <br/>
        /// Zero duration tweens are always return end value.
        /// </summary>
        /// <param name="time">Time where to evaluate.</param>
        /// <returns>Evaluated value.</returns>
        public T Evaluate(float time)
        {
            if (LoopDuration.Approximately(0f))
                return EvaluateZero(LoopsCount - 1, 1f);
            else
            {
                var (loop, loopedTime) = LoopIndexTime(Mathf.Clamp(time, 0f, Duration));
                return Evaluate(loop, loopedTime);
            }
        }

        private T EvaluateZero(int loop, float loopedNormalizedTime)
        {
            var (from, to) = (From(), To());

            if (LoopType == LoopType.Reset)
                return Tweak.Evaluate(from, to, loopedNormalizedTime, Ease);
            else if (LoopType == LoopType.Continue)
            {
                EvaluateFromTo(ref from, ref to, loop, loop + 1f);
                return Tweak.Evaluate(from, to, loopedNormalizedTime, Ease);
            }
            else // LoopType.Mirror
            {
                var loopedMirroredNormalizedTime = loopedNormalizedTime * 2f;

                if (loopedMirroredNormalizedTime > 1f)
                    loopedMirroredNormalizedTime = 2f - loopedMirroredNormalizedTime;

                return Tweak.Evaluate(from, to, loopedMirroredNormalizedTime, Ease);
            }
        }

        private T Evaluate(int loop, float loopedTime)
        {
            var (from, to) = (From(), To());

            var loopedNormalizedTime = loopedTime / LoopDuration;

            if (LoopType == LoopType.Reset)
                return Tweak.Evaluate(from, to, loopedNormalizedTime, Ease);
            else if (LoopType == LoopType.Continue)
            {
                EvaluateFromTo(ref from, ref to, loop, loop + 1f);
                return Tweak.Evaluate(from, to, loopedNormalizedTime, Ease);
            }
            else // LoopType.Mirror
            {
                var loopedMirroredNormalizedTime = loopedNormalizedTime * 2f;

                if (loopedMirroredNormalizedTime > 1f)
                    loopedMirroredNormalizedTime = 2f - loopedMirroredNormalizedTime;

                return Tweak.Evaluate(from, to, loopedMirroredNormalizedTime, Ease);
            }
        }
    }
}