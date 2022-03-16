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
            return Byte((string)null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name">Tween's name (useful for debugging and nesting in sequences).</param>
        /// <param name="from"><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<byte, TweakByte> Byte(string name, byte from, byte to, Action<byte> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Byte(null, name, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner">Game object to which this tween will be attached.</param>
        /// <param name="from"><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<byte, TweakByte> Byte(GameObject owner, byte from, byte to, Action<byte> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Byte(owner, null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Byte(GameObject, byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="Byte(string, byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<byte, TweakByte> Byte(GameObject owner, string name, byte from, byte to, Action<byte> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Byte(owner, name, () => from, () => to, action, loopDuration, ease, loopsCount, loopType, direction);
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
            return Byte((string)null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name"><inheritdoc cref="Byte(string, byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Byte(Func{byte}, Func{byte}, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Byte(Func{byte}, Func{byte}, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<byte, TweakByte> Byte(string name, Func<byte> from, Func<byte> to, Action<byte> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Byte(null, name, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Byte(GameObject, byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="from"><inheritdoc cref="Byte(Func{byte}, Func{byte}, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Byte(Func{byte}, Func{byte}, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<byte, TweakByte> Byte(GameObject owner, Func<byte> from, Func<byte> to, Action<byte> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Byte(owner, null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Byte(GameObject, byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="Byte(string, byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Byte(Func{byte}, Func{byte}, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Byte(Func{byte}, Func{byte}, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Byte(byte, byte, Action{byte}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<byte, TweakByte> Byte(GameObject owner, string name, Func<byte> from, Func<byte> to, Action<byte> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return new Tween<byte, TweakByte>(owner, name, new TweakByte(), from, to, action, loopDuration, ease, loopsCount, loopType, direction);
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
            return SByte((string)null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name">Tween's name (useful for debugging and nesting in sequences).</param>
        /// <param name="from"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<sbyte, TweakSByte> SByte(string name, sbyte from, sbyte to, Action<sbyte> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return SByte(null, name, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner">Game object to which this tween will be attached.</param>
        /// <param name="from"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<sbyte, TweakSByte> SByte(GameObject owner, sbyte from, sbyte to, Action<sbyte> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return SByte(owner, null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="SByte(GameObject, sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="SByte(string, sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<sbyte, TweakSByte> SByte(GameObject owner, string name, sbyte from, sbyte to, Action<sbyte> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return SByte(owner, name, () => from, () => to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="from">Callback which return value from which tween starts animation.</param>
        /// <param name="to">Callback which return value on which tween completes animation.</param>
        /// <param name="action"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<sbyte, TweakSByte> SByte(Func<sbyte> from, Func<sbyte> to, Action<sbyte> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return SByte((string)null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name"><inheritdoc cref="SByte(string, sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="SByte(Func{sbyte}, Func{sbyte}, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="SByte(Func{sbyte}, Func{sbyte}, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<sbyte, TweakSByte> SByte(string name, Func<sbyte> from, Func<sbyte> to, Action<sbyte> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return SByte(null, name, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="SByte(GameObject, sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="from"><inheritdoc cref="SByte(Func{sbyte}, Func{sbyte}, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="SByte(Func{sbyte}, Func{sbyte}, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<sbyte, TweakSByte> SByte(GameObject owner, Func<sbyte> from, Func<sbyte> to, Action<sbyte> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return SByte(owner, null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="SByte(GameObject, sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="SByte(string, sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="SByte(Func{sbyte}, Func{sbyte}, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="SByte(Func{sbyte}, Func{sbyte}, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="SByte(sbyte, sbyte, Action{sbyte}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<sbyte, TweakSByte> SByte(GameObject owner, string name, Func<sbyte> from, Func<sbyte> to, Action<sbyte> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return new Tween<sbyte, TweakSByte>(owner, name, new TweakSByte(), from, to, action, loopDuration, ease, loopsCount, loopType, direction);
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
            return Short((string)null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name">Tween's name (useful for debugging and nesting in sequences).</param>
        /// <param name="from"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<short, TweakShort> Short(string name, short from, short to, Action<short> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Short(null, name, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner">Game object to which this tween will be attached.</param>
        /// <param name="from"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<short, TweakShort> Short(GameObject owner, short from, short to, Action<short> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Short(owner, null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Short(GameObject, short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="Short(string, short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<short, TweakShort> Short(GameObject owner, string name, short from, short to, Action<short> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Short(owner, name, () => from, () => to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="from">Callback which return value from which tween starts animation.</param>
        /// <param name="to">Callback which return value on which tween completes animation.</param>
        /// <param name="action"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<short, TweakShort> Short(Func<short> from, Func<short> to, Action<short> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Short((string)null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name"><inheritdoc cref="Short(string, short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Short(Func{short}, Func{short}, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Short(Func{short}, Func{short}, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<short, TweakShort> Short(string name, Func<short> from, Func<short> to, Action<short> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Short(null, name, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Short(GameObject, short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="from"><inheritdoc cref="Short(Func{short}, Func{short}, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Short(Func{short}, Func{short}, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<short, TweakShort> Short(GameObject owner, Func<short> from, Func<short> to, Action<short> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Short(owner, null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Short(GameObject, short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="Short(string, short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Short(Func{short}, Func{short}, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Short(Func{short}, Func{short}, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Short(short, short, Action{short}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<short, TweakShort> Short(GameObject owner, string name, Func<short> from, Func<short> to, Action<short> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return new Tween<short, TweakShort>(owner, name, new TweakShort(), from, to, action, loopDuration, ease, loopsCount, loopType, direction);
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
            return UShort((string)null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name">Tween's name (useful for debugging and nesting in sequences).</param>
        /// <param name="from"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<ushort, TweakUShort> UShort(string name, ushort from, ushort to, Action<ushort> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return UShort(null, name, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner">Game object to which this tween will be attached.</param>
        /// <param name="from"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<ushort, TweakUShort> UShort(GameObject owner, ushort from, ushort to, Action<ushort> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return UShort(owner, null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="UShort(GameObject, ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="UShort(string, ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<ushort, TweakUShort> UShort(GameObject owner, string name, ushort from, ushort to, Action<ushort> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return UShort(owner, name, () => from, () => to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="from">Callback which return value from which tween starts animation.</param>
        /// <param name="to">Callback which return value on which tween completes animation.</param>
        /// <param name="action"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<ushort, TweakUShort> UShort(Func<ushort> from, Func<ushort> to, Action<ushort> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return UShort((string)null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name"><inheritdoc cref="UShort(string, ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="UShort(Func{ushort}, Func{ushort}, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="UShort(Func{ushort}, Func{ushort}, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<ushort, TweakUShort> UShort(string name, Func<ushort> from, Func<ushort> to, Action<ushort> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return UShort(null, name, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="UShort(GameObject, ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="from"><inheritdoc cref="UShort(Func{ushort}, Func{ushort}, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="UShort(Func{ushort}, Func{ushort}, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<ushort, TweakUShort> UShort(GameObject owner, Func<ushort> from, Func<ushort> to, Action<ushort> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return UShort(owner, null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="UShort(GameObject, ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="UShort(string, ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="UShort(Func{ushort}, Func{ushort}, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="UShort(Func{ushort}, Func{ushort}, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="UShort(ushort, ushort, Action{ushort}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<ushort, TweakUShort> UShort(GameObject owner, string name, Func<ushort> from, Func<ushort> to, Action<ushort> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return new Tween<ushort, TweakUShort>(owner, name, new TweakUShort(), from, to, action, loopDuration, ease, loopsCount, loopType, direction);
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
            return Int((string)null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name">Tween's name (useful for debugging and nesting in sequences).</param>
        /// <param name="from"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<int, TweakInt> Int(string name, int from, int to, Action<int> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Int(null, name, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner">Game object to which this tween will be attached.</param>
        /// <param name="from"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<int, TweakInt> Int(GameObject owner, int from, int to, Action<int> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Int(owner, null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Int(GameObject, int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="Int(string, int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<int, TweakInt> Int(GameObject owner, string name, int from, int to, Action<int> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Int(owner, name, () => from, () => to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="from">Callback which return value from which tween starts animation.</param>
        /// <param name="to">Callback which return value on which tween completes animation.</param>
        /// <param name="action"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<int, TweakInt> Int(Func<int> from, Func<int> to, Action<int> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Int((string)null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name"><inheritdoc cref="Int(string, int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Int(Func{int}, Func{int}, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Int(Func{int}, Func{int}, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<int, TweakInt> Int(string name, Func<int> from, Func<int> to, Action<int> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Int(null, name, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Int(GameObject, int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="from"><inheritdoc cref="Int(Func{int}, Func{int}, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Int(Func{int}, Func{int}, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<int, TweakInt> Int(GameObject owner, Func<int> from, Func<int> to, Action<int> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Int(owner, null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Int(GameObject, int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="Int(string, int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Int(Func{int}, Func{int}, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Int(Func{int}, Func{int}, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Int(int, int, Action{int}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<int, TweakInt> Int(GameObject owner, string name, Func<int> from, Func<int> to, Action<int> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return new Tween<int, TweakInt>(owner, name, new TweakInt(), from, to, action, loopDuration, ease, loopsCount, loopType, direction);
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
            return UInt((string)null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name">Tween's name (useful for debugging and nesting in sequences).</param>
        /// <param name="from"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<uint, TweakUInt> UInt(string name, uint from, uint to, Action<uint> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return UInt(null, name, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner">Game object to which this tween will be attached.</param>
        /// <param name="from"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<uint, TweakUInt> UInt(GameObject owner, uint from, uint to, Action<uint> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return UInt(owner, null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="UInt(GameObject, uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="UInt(string, uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<uint, TweakUInt> UInt(GameObject owner, string name, uint from, uint to, Action<uint> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return UInt(owner, name, () => from, () => to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="from">Callback which return value from which tween starts animation.</param>
        /// <param name="to">Callback which return value on which tween completes animation.</param>
        /// <param name="action"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<uint, TweakUInt> UInt(Func<uint> from, Func<uint> to, Action<uint> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return UInt((string)null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name"><inheritdoc cref="UInt(string, uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="UInt(Func{uint}, Func{uint}, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="UInt(Func{uint}, Func{uint}, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<uint, TweakUInt> UInt(string name, Func<uint> from, Func<uint> to, Action<uint> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return UInt(null, name, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="UInt(GameObject, uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="from"><inheritdoc cref="UInt(Func{uint}, Func{uint}, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="UInt(Func{uint}, Func{uint}, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<uint, TweakUInt> UInt(GameObject owner, Func<uint> from, Func<uint> to, Action<uint> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return UInt(owner, null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="UInt(GameObject, uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="UInt(string, uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="UInt(Func{uint}, Func{uint}, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="UInt(Func{uint}, Func{uint}, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="UInt(uint, uint, Action{uint}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<uint, TweakUInt> UInt(GameObject owner, string name, Func<uint> from, Func<uint> to, Action<uint> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return new Tween<uint, TweakUInt>(owner, name, new TweakUInt(), from, to, action, loopDuration, ease, loopsCount, loopType, direction);
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
            return Long((string)null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name">Tween's name (useful for debugging and nesting in sequences).</param>
        /// <param name="from"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<long, TweakLong> Long(string name, long from, long to, Action<long> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Long(null, name, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner">Game object to which this tween will be attached.</param>
        /// <param name="from"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<long, TweakLong> Long(GameObject owner, long from, long to, Action<long> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Long(owner, null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Long(GameObject, long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="Long(string, long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<long, TweakLong> Long(GameObject owner, string name, long from, long to, Action<long> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Long(owner, name, () => from, () => to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="from">Callback which return value from which tween starts animation.</param>
        /// <param name="to">Callback which return value on which tween completes animation.</param>
        /// <param name="action"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<long, TweakLong> Long(Func<long> from, Func<long> to, Action<long> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Long((string)null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name"><inheritdoc cref="Long(string, long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Long(Func{long}, Func{long}, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Long(Func{long}, Func{long}, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<long, TweakLong> Long(string name, Func<long> from, Func<long> to, Action<long> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Long(null, name, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Long(GameObject, long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="from"><inheritdoc cref="Long(Func{long}, Func{long}, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Long(Func{long}, Func{long}, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<long, TweakLong> Long(GameObject owner, Func<long> from, Func<long> to, Action<long> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Long(owner, null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Long(GameObject, long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="Long(string, long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Long(Func{long}, Func{long}, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Long(Func{long}, Func{long}, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Long(long, long, Action{long}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<long, TweakLong> Long(GameObject owner, string name, Func<long> from, Func<long> to, Action<long> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return new Tween<long, TweakLong>(owner, name, new TweakLong(), from, to, action, loopDuration, ease, loopsCount, loopType, direction);
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
            return ULong((string)null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name">Tween's name (useful for debugging and nesting in sequences).</param>
        /// <param name="from"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<ulong, TweakULong> ULong(string name, ulong from, ulong to, Action<ulong> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return ULong(null, name, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner">Game object to which this tween will be attached.</param>
        /// <param name="from"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<ulong, TweakULong> ULong(GameObject owner, ulong from, ulong to, Action<ulong> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return ULong(owner, null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="ULong(GameObject, ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="ULong(string, ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<ulong, TweakULong> ULong(GameObject owner, string name, ulong from, ulong to, Action<ulong> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return ULong(owner, name, () => from, () => to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="from">Callback which return value from which tween starts animation.</param>
        /// <param name="to">Callback which return value on which tween completes animation.</param>
        /// <param name="action"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<ulong, TweakULong> ULong(Func<ulong> from, Func<ulong> to, Action<ulong> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return ULong((string)null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name"><inheritdoc cref="ULong(string, ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="ULong(Func{ulong}, Func{ulong}, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="ULong(Func{ulong}, Func{ulong}, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<ulong, TweakULong> ULong(string name, Func<ulong> from, Func<ulong> to, Action<ulong> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return ULong(null, name, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="ULong(GameObject, ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="from"><inheritdoc cref="ULong(Func{ulong}, Func{ulong}, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="ULong(Func{ulong}, Func{ulong}, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<ulong, TweakULong> ULong(GameObject owner, Func<ulong> from, Func<ulong> to, Action<ulong> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return ULong(owner, null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="ULong(GameObject, ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="ULong(string, ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="ULong(Func{ulong}, Func{ulong}, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="ULong(Func{ulong}, Func{ulong}, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="ULong(ulong, ulong, Action{ulong}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<ulong, TweakULong> ULong(GameObject owner, string name, Func<ulong> from, Func<ulong> to, Action<ulong> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return new Tween<ulong, TweakULong>(owner, name, new TweakULong(), from, to, action, loopDuration, ease, loopsCount, loopType, direction);
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
            return Float((string)null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name">Tween's name (useful for debugging and nesting in sequences).</param>
        /// <param name="from"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<float, TweakFloat> Float(string name, float from, float to, Action<float> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Float(null, name, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner">Game object to which this tween will be attached.</param>
        /// <param name="from"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<float, TweakFloat> Float(GameObject owner, float from, float to, Action<float> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Float(owner, null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Float(GameObject, float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="Float(string, float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<float, TweakFloat> Float(GameObject owner, string name, float from, float to, Action<float> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Float(owner, name, () => from, () => to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="from">Callback which return value from which tween starts animation.</param>
        /// <param name="to">Callback which return value on which tween completes animation.</param>
        /// <param name="action"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<float, TweakFloat> Float(Func<float> from, Func<float> to, Action<float> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Float((string)null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name"><inheritdoc cref="Float(string, float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Float(Func{float}, Func{float}, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Float(Func{float}, Func{float}, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<float, TweakFloat> Float(string name, Func<float> from, Func<float> to, Action<float> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Float(null, name, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Float(GameObject, float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="from"><inheritdoc cref="Float(Func{float}, Func{float}, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Float(Func{float}, Func{float}, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<float, TweakFloat> Float(GameObject owner, Func<float> from, Func<float> to, Action<float> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Float(owner, null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Float(GameObject, float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="Float(string, float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Float(Func{float}, Func{float}, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Float(Func{float}, Func{float}, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Float(float, float, Action{float}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<float, TweakFloat> Float(GameObject owner, string name, Func<float> from, Func<float> to, Action<float> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return new Tween<float, TweakFloat>(owner, name, new TweakFloat(), from, to, action, loopDuration, ease, loopsCount, loopType, direction);
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
            return Double((string)null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name">Tween's name (useful for debugging and nesting in sequences).</param>
        /// <param name="from"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<double, TweakDouble> Double(string name, double from, double to, Action<double> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Double(null, name, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner">Game object to which this tween will be attached.</param>
        /// <param name="from"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<double, TweakDouble> Double(GameObject owner, double from, double to, Action<double> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Double(owner, null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Double(GameObject, double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="Double(string, double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<double, TweakDouble> Double(GameObject owner, string name, double from, double to, Action<double> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Double(owner, name, () => from, () => to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="from">Callback which return value from which tween starts animation.</param>
        /// <param name="to">Callback which return value on which tween completes animation.</param>
        /// <param name="action"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<double, TweakDouble> Double(Func<double> from, Func<double> to, Action<double> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Double((string)null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name"><inheritdoc cref="Double(string, double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Double(Func{double}, Func{double}, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Double(Func{double}, Func{double}, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<double, TweakDouble> Double(string name, Func<double> from, Func<double> to, Action<double> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Double(null, name, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Double(GameObject, double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="from"><inheritdoc cref="Double(Func{double}, Func{double}, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Double(Func{double}, Func{double}, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<double, TweakDouble> Double(GameObject owner, Func<double> from, Func<double> to, Action<double> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Double(owner, null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Double(GameObject, double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="Double(string, double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Double(Func{double}, Func{double}, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Double(Func{double}, Func{double}, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Double(double, double, Action{double}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<double, TweakDouble> Double(GameObject owner, string name, Func<double> from, Func<double> to, Action<double> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return new Tween<double, TweakDouble>(owner, name, new TweakDouble(), from, to, action, loopDuration, ease, loopsCount, loopType, direction);
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
            return Decimal((string)null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name">Tween's name (useful for debugging and nesting in sequences).</param>
        /// <param name="from"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<decimal, TweakDecimal> Decimal(string name, decimal from, decimal to, Action<decimal> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Decimal(null, name, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner">Game object to which this tween will be attached.</param>
        /// <param name="from"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<decimal, TweakDecimal> Decimal(GameObject owner, decimal from, decimal to, Action<decimal> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Decimal(owner, null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Decimal(GameObject, decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="Decimal(string, decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<decimal, TweakDecimal> Decimal(GameObject owner, string name, decimal from, decimal to, Action<decimal> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Decimal(owner, name, () => from, () => to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="from">Callback which return value from which tween starts animation.</param>
        /// <param name="to">Callback which return value on which tween completes animation.</param>
        /// <param name="action"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<decimal, TweakDecimal> Decimal(Func<decimal> from, Func<decimal> to, Action<decimal> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Decimal((string)null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name"><inheritdoc cref="Decimal(string, decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Decimal(Func{decimal}, Func{decimal}, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Decimal(Func{decimal}, Func{decimal}, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<decimal, TweakDecimal> Decimal(string name, Func<decimal> from, Func<decimal> to, Action<decimal> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Decimal(null, name, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Decimal(GameObject, decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="from"><inheritdoc cref="Decimal(Func{decimal}, Func{decimal}, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Decimal(Func{decimal}, Func{decimal}, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<decimal, TweakDecimal> Decimal(GameObject owner, Func<decimal> from, Func<decimal> to, Action<decimal> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Decimal(owner, null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Decimal(GameObject, decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="Decimal(string, decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Decimal(Func{decimal}, Func{decimal}, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Decimal(Func{decimal}, Func{decimal}, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Decimal(decimal, decimal, Action{decimal}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<decimal, TweakDecimal> Decimal(GameObject owner, string name, Func<decimal> from, Func<decimal> to, Action<decimal> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return new Tween<decimal, TweakDecimal>(owner, name, new TweakDecimal(), from, to, action, loopDuration, ease, loopsCount, loopType, direction);
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
            return Char((string)null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name">Tween's name (useful for debugging and nesting in sequences).</param>
        /// <param name="from"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<char, TweakChar> Char(string name, char from, char to, Action<char> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Char(null, name, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner">Game object to which this tween will be attached.</param>
        /// <param name="from"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<char, TweakChar> Char(GameObject owner, char from, char to, Action<char> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Char(owner, null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Char(GameObject, char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="Char(string, char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<char, TweakChar> Char(GameObject owner, string name, char from, char to, Action<char> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Char(owner, name, () => from, () => to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="from">Callback which return value from which tween starts animation.</param>
        /// <param name="to">Callback which return value on which tween completes animation.</param>
        /// <param name="action"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<char, TweakChar> Char(Func<char> from, Func<char> to, Action<char> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Char((string)null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name"><inheritdoc cref="Char(string, char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Char(Func{char}, Func{char}, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Char(Func{char}, Func{char}, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<char, TweakChar> Char(string name, Func<char> from, Func<char> to, Action<char> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Char(null, name, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Char(GameObject, char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="from"><inheritdoc cref="Char(Func{char}, Func{char}, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Char(Func{char}, Func{char}, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<char, TweakChar> Char(GameObject owner, Func<char> from, Func<char> to, Action<char> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Char(owner, null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Char(GameObject, char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="Char(string, char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Char(Func{char}, Func{char}, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Char(Func{char}, Func{char}, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Char(char, char, Action{char}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<char, TweakChar> Char(GameObject owner, string name, Func<char> from, Func<char> to, Action<char> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return new Tween<char, TweakChar>(owner, name, new TweakChar(), from, to, action, loopDuration, ease, loopsCount, loopType, direction);
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
            return Vector2((string)null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name">Tween's name (useful for debugging and nesting in sequences).</param>
        /// <param name="from"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Vector2, TweakVector2> Vector2(string name, Vector2 from, Vector2 to, Action<Vector2> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Vector2(null, name, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner">Game object to which this tween will be attached.</param>
        /// <param name="from"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Vector2, TweakVector2> Vector2(GameObject owner, Vector2 from, Vector2 to, Action<Vector2> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Vector2(owner, null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Vector2(GameObject, Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="Vector2(string, Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Vector2, TweakVector2> Vector2(GameObject owner, string name, Vector2 from, Vector2 to, Action<Vector2> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Vector2(owner, name, () => from, () => to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="from">Callback which return value from which tween starts animation.</param>
        /// <param name="to">Callback which return value on which tween completes animation.</param>
        /// <param name="action"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Vector2, TweakVector2> Vector2(Func<Vector2> from, Func<Vector2> to, Action<Vector2> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Vector2((string)null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name"><inheritdoc cref="Vector2(string, Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Vector2(Func{Vector2}, Func{Vector2}, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Vector2(Func{Vector2}, Func{Vector2}, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Vector2, TweakVector2> Vector2(string name, Func<Vector2> from, Func<Vector2> to, Action<Vector2> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Vector2(null, name, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Vector2(GameObject, Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="from"><inheritdoc cref="Vector2(Func{Vector2}, Func{Vector2}, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Vector2(Func{Vector2}, Func{Vector2}, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Vector2, TweakVector2> Vector2(GameObject owner, Func<Vector2> from, Func<Vector2> to, Action<Vector2> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Vector2(owner, null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Vector2(GameObject, Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="Vector2(string, Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Vector2(Func{Vector2}, Func{Vector2}, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Vector2(Func{Vector2}, Func{Vector2}, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Vector2(Vector2, Vector2, Action{Vector2}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Vector2, TweakVector2> Vector2(GameObject owner, string name, Func<Vector2> from, Func<Vector2> to, Action<Vector2> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return new Tween<Vector2, TweakVector2>(owner, name, new TweakVector2(), from, to, action, loopDuration, ease, loopsCount, loopType, direction);
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
            return Vector2Int((string)null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name">Tween's name (useful for debugging and nesting in sequences).</param>
        /// <param name="from"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Vector2Int, TweakVector2Int> Vector2Int(string name, Vector2Int from, Vector2Int to, Action<Vector2Int> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Vector2Int(null, name, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner">Game object to which this tween will be attached.</param>
        /// <param name="from"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Vector2Int, TweakVector2Int> Vector2Int(GameObject owner, Vector2Int from, Vector2Int to, Action<Vector2Int> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Vector2Int(owner, null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Vector2Int(GameObject, Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="Vector2Int(string, Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Vector2Int, TweakVector2Int> Vector2Int(GameObject owner, string name, Vector2Int from, Vector2Int to, Action<Vector2Int> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Vector2Int(owner, name, () => from, () => to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="from">Callback which return value from which tween starts animation.</param>
        /// <param name="to">Callback which return value on which tween completes animation.</param>
        /// <param name="action"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Vector2Int, TweakVector2Int> Vector2Int(Func<Vector2Int> from, Func<Vector2Int> to, Action<Vector2Int> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Vector2Int((string)null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name"><inheritdoc cref="Vector2Int(string, Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Vector2Int(Func{Vector2Int}, Func{Vector2Int}, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Vector2Int(Func{Vector2Int}, Func{Vector2Int}, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Vector2Int, TweakVector2Int> Vector2Int(string name, Func<Vector2Int> from, Func<Vector2Int> to, Action<Vector2Int> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Vector2Int(null, name, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Vector2Int(GameObject, Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="from"><inheritdoc cref="Vector2Int(Func{Vector2Int}, Func{Vector2Int}, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Vector2Int(Func{Vector2Int}, Func{Vector2Int}, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Vector2Int, TweakVector2Int> Vector2Int(GameObject owner, Func<Vector2Int> from, Func<Vector2Int> to, Action<Vector2Int> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Vector2Int(owner, null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Vector2Int(GameObject, Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="Vector2Int(string, Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Vector2Int(Func{Vector2Int}, Func{Vector2Int}, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Vector2Int(Func{Vector2Int}, Func{Vector2Int}, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Vector2Int(Vector2Int, Vector2Int, Action{Vector2Int}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Vector2Int, TweakVector2Int> Vector2Int(GameObject owner, string name, Func<Vector2Int> from, Func<Vector2Int> to, Action<Vector2Int> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return new Tween<Vector2Int, TweakVector2Int>(owner, name, new TweakVector2Int(), from, to, action, loopDuration, ease, loopsCount, loopType, direction);
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
            return Vector3((string)null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name">Tween's name (useful for debugging and nesting in sequences).</param>
        /// <param name="from"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Vector3, TweakVector3> Vector3(string name, Vector3 from, Vector3 to, Action<Vector3> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Vector3(null, name, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner">Game object to which this tween will be attached.</param>
        /// <param name="from"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Vector3, TweakVector3> Vector3(GameObject owner, Vector3 from, Vector3 to, Action<Vector3> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Vector3(owner, null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Vector3(GameObject, Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="Vector3(string, Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Vector3, TweakVector3> Vector3(GameObject owner, string name, Vector3 from, Vector3 to, Action<Vector3> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Vector3(owner, name, () => from, () => to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="from">Callback which return value from which tween starts animation.</param>
        /// <param name="to">Callback which return value on which tween completes animation.</param>
        /// <param name="action"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Vector3, TweakVector3> Vector3(Func<Vector3> from, Func<Vector3> to, Action<Vector3> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Vector3((string)null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name"><inheritdoc cref="Vector3(string, Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Vector3(Func{Vector3}, Func{Vector3}, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Vector3(Func{Vector3}, Func{Vector3}, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Vector3, TweakVector3> Vector3(string name, Func<Vector3> from, Func<Vector3> to, Action<Vector3> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Vector3(null, name, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Vector3(GameObject, Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="from"><inheritdoc cref="Vector3(Func{Vector3}, Func{Vector3}, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Vector3(Func{Vector3}, Func{Vector3}, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Vector3, TweakVector3> Vector3(GameObject owner, Func<Vector3> from, Func<Vector3> to, Action<Vector3> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Vector3(owner, null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Vector3(GameObject, Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="Vector3(string, Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Vector3(Func{Vector3}, Func{Vector3}, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Vector3(Func{Vector3}, Func{Vector3}, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Vector3(Vector3, Vector3, Action{Vector3}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Vector3, TweakVector3> Vector3(GameObject owner, string name, Func<Vector3> from, Func<Vector3> to, Action<Vector3> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return new Tween<Vector3, TweakVector3>(owner, name, new TweakVector3(), from, to, action, loopDuration, ease, loopsCount, loopType, direction);
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
            return Vector3Int((string)null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name">Tween's name (useful for debugging and nesting in sequences).</param>
        /// <param name="from"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Vector3Int, TweakVector3Int> Vector3Int(string name, Vector3Int from, Vector3Int to, Action<Vector3Int> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Vector3Int(null, name, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner">Game object to which this tween will be attached.</param>
        /// <param name="from"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Vector3Int, TweakVector3Int> Vector3Int(GameObject owner, Vector3Int from, Vector3Int to, Action<Vector3Int> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Vector3Int(owner, null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Vector3Int(GameObject, Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="Vector3Int(string, Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Vector3Int, TweakVector3Int> Vector3Int(GameObject owner, string name, Vector3Int from, Vector3Int to, Action<Vector3Int> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Vector3Int(owner, name, () => from, () => to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="from">Callback which return value from which tween starts animation.</param>
        /// <param name="to">Callback which return value on which tween completes animation.</param>
        /// <param name="action"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Vector3Int, TweakVector3Int> Vector3Int(Func<Vector3Int> from, Func<Vector3Int> to, Action<Vector3Int> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Vector3Int((string)null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name"><inheritdoc cref="Vector3Int(string, Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Vector3Int(Func{Vector3Int}, Func{Vector3Int}, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Vector3Int(Func{Vector3Int}, Func{Vector3Int}, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Vector3Int, TweakVector3Int> Vector3Int(string name, Func<Vector3Int> from, Func<Vector3Int> to, Action<Vector3Int> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Vector3Int(null, name, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Vector3Int(GameObject, Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="from"><inheritdoc cref="Vector3Int(Func{Vector3Int}, Func{Vector3Int}, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Vector3Int(Func{Vector3Int}, Func{Vector3Int}, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Vector3Int, TweakVector3Int> Vector3Int(GameObject owner, Func<Vector3Int> from, Func<Vector3Int> to, Action<Vector3Int> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Vector3Int(owner, null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Vector3Int(GameObject, Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="Vector3Int(string, Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Vector3Int(Func{Vector3Int}, Func{Vector3Int}, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Vector3Int(Func{Vector3Int}, Func{Vector3Int}, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Vector3Int(Vector3Int, Vector3Int, Action{Vector3Int}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Vector3Int, TweakVector3Int> Vector3Int(GameObject owner, string name, Func<Vector3Int> from, Func<Vector3Int> to, Action<Vector3Int> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return new Tween<Vector3Int, TweakVector3Int>(owner, name, new TweakVector3Int(), from, to, action, loopDuration, ease, loopsCount, loopType, direction);
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
            return Vector4((string)null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name">Tween's name (useful for debugging and nesting in sequences).</param>
        /// <param name="from"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Vector4, TweakVector4> Vector4(string name, Vector4 from, Vector4 to, Action<Vector4> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Vector4(null, name, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner">Game object to which this tween will be attached.</param>
        /// <param name="from"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Vector4, TweakVector4> Vector4(GameObject owner, Vector4 from, Vector4 to, Action<Vector4> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Vector4(owner, null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Vector4(GameObject, Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="Vector4(string, Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Vector4, TweakVector4> Vector4(GameObject owner, string name, Vector4 from, Vector4 to, Action<Vector4> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Vector4(owner, name, () => from, () => to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="from">Callback which return value from which tween starts animation.</param>
        /// <param name="to">Callback which return value on which tween completes animation.</param>
        /// <param name="action"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Vector4, TweakVector4> Vector4(Func<Vector4> from, Func<Vector4> to, Action<Vector4> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Vector4((string)null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name"><inheritdoc cref="Vector4(string, Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Vector4(Func{Vector4}, Func{Vector4}, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Vector4(Func{Vector4}, Func{Vector4}, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Vector4, TweakVector4> Vector4(string name, Func<Vector4> from, Func<Vector4> to, Action<Vector4> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Vector4(null, name, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Vector4(GameObject, Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="from"><inheritdoc cref="Vector4(Func{Vector4}, Func{Vector4}, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Vector4(Func{Vector4}, Func{Vector4}, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Vector4, TweakVector4> Vector4(GameObject owner, Func<Vector4> from, Func<Vector4> to, Action<Vector4> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Vector4(owner, null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Vector4(GameObject, Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="Vector4(string, Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Vector4(Func{Vector4}, Func{Vector4}, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Vector4(Func{Vector4}, Func{Vector4}, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Vector4(Vector4, Vector4, Action{Vector4}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Vector4, TweakVector4> Vector4(GameObject owner, string name, Func<Vector4> from, Func<Vector4> to, Action<Vector4> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return new Tween<Vector4, TweakVector4>(owner, name, new TweakVector4(), from, to, action, loopDuration, ease, loopsCount, loopType, direction);
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
            return Color((string)null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name">Tween's name (useful for debugging and nesting in sequences).</param>
        /// <param name="from"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Color, TweakColor> Color(string name, Color from, Color to, Action<Color> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Color(null, name, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner">Game object to which this tween will be attached.</param>
        /// <param name="from"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Color, TweakColor> Color(GameObject owner, Color from, Color to, Action<Color> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Color(owner, null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Color(GameObject, Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="Color(string, Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Color, TweakColor> Color(GameObject owner, string name, Color from, Color to, Action<Color> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Color(owner, name, () => from, () => to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="from">Callback which return value from which tween starts animation.</param>
        /// <param name="to">Callback which return value on which tween completes animation.</param>
        /// <param name="action"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Color, TweakColor> Color(Func<Color> from, Func<Color> to, Action<Color> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Color((string)null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name"><inheritdoc cref="Color(string, Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Color(Func{Color}, Func{Color}, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Color(Func{Color}, Func{Color}, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Color, TweakColor> Color(string name, Func<Color> from, Func<Color> to, Action<Color> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Color(null, name, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Color(GameObject, Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="from"><inheritdoc cref="Color(Func{Color}, Func{Color}, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Color(Func{Color}, Func{Color}, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Color, TweakColor> Color(GameObject owner, Func<Color> from, Func<Color> to, Action<Color> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Color(owner, null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Color(GameObject, Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="Color(string, Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Color(Func{Color}, Func{Color}, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Color(Func{Color}, Func{Color}, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Color(Color, Color, Action{Color}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Color, TweakColor> Color(GameObject owner, string name, Func<Color> from, Func<Color> to, Action<Color> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return new Tween<Color, TweakColor>(owner, name, new TweakColor(), from, to, action, loopDuration, ease, loopsCount, loopType, direction);
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
            return Color32((string)null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name">Tween's name (useful for debugging and nesting in sequences).</param>
        /// <param name="from"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Color32, TweakColor32> Color32(string name, Color32 from, Color32 to, Action<Color32> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Color32(null, name, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner">Game object to which this tween will be attached.</param>
        /// <param name="from"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Color32, TweakColor32> Color32(GameObject owner, Color32 from, Color32 to, Action<Color32> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Color32(owner, null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Color32(GameObject, Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="Color32(string, Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Color32, TweakColor32> Color32(GameObject owner, string name, Color32 from, Color32 to, Action<Color32> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Color32(owner, name, () => from, () => to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="from">Callback which return value from which tween starts animation.</param>
        /// <param name="to">Callback which return value on which tween completes animation.</param>
        /// <param name="action"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Color32, TweakColor32> Color32(Func<Color32> from, Func<Color32> to, Action<Color32> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Color32((string)null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name"><inheritdoc cref="Color32(string, Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Color32(Func{Color32}, Func{Color32}, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Color32(Func{Color32}, Func{Color32}, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Color32, TweakColor32> Color32(string name, Func<Color32> from, Func<Color32> to, Action<Color32> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Color32(null, name, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Color32(GameObject, Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="from"><inheritdoc cref="Color32(Func{Color32}, Func{Color32}, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Color32(Func{Color32}, Func{Color32}, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Color32, TweakColor32> Color32(GameObject owner, Func<Color32> from, Func<Color32> to, Action<Color32> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Color32(owner, null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Color32(GameObject, Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="Color32(string, Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Color32(Func{Color32}, Func{Color32}, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Color32(Func{Color32}, Func{Color32}, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Color32(Color32, Color32, Action{Color32}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Color32, TweakColor32> Color32(GameObject owner, string name, Func<Color32> from, Func<Color32> to, Action<Color32> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return new Tween<Color32, TweakColor32>(owner, name, new TweakColor32(), from, to, action, loopDuration, ease, loopsCount, loopType, direction);
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
            return Matrix4x4((string)null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name">Tween's name (useful for debugging and nesting in sequences).</param>
        /// <param name="from"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Matrix4x4, TweakMatrix4x4> Matrix4x4(string name, Matrix4x4 from, Matrix4x4 to, Action<Matrix4x4> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Matrix4x4(null, name, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner">Game object to which this tween will be attached.</param>
        /// <param name="from"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Matrix4x4, TweakMatrix4x4> Matrix4x4(GameObject owner, Matrix4x4 from, Matrix4x4 to, Action<Matrix4x4> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Matrix4x4(owner, null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Matrix4x4(GameObject, Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="Matrix4x4(string, Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Matrix4x4, TweakMatrix4x4> Matrix4x4(GameObject owner, string name, Matrix4x4 from, Matrix4x4 to, Action<Matrix4x4> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Matrix4x4(owner, name, () => from, () => to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="from">Callback which return value from which tween starts animation.</param>
        /// <param name="to">Callback which return value on which tween completes animation.</param>
        /// <param name="action"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Matrix4x4, TweakMatrix4x4> Matrix4x4(Func<Matrix4x4> from, Func<Matrix4x4> to, Action<Matrix4x4> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Matrix4x4((string)null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name"><inheritdoc cref="Matrix4x4(string, Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Matrix4x4(Func{Matrix4x4}, Func{Matrix4x4}, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Matrix4x4(Func{Matrix4x4}, Func{Matrix4x4}, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Matrix4x4, TweakMatrix4x4> Matrix4x4(string name, Func<Matrix4x4> from, Func<Matrix4x4> to, Action<Matrix4x4> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Matrix4x4(null, name, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Matrix4x4(GameObject, Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="from"><inheritdoc cref="Matrix4x4(Func{Matrix4x4}, Func{Matrix4x4}, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Matrix4x4(Func{Matrix4x4}, Func{Matrix4x4}, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Matrix4x4, TweakMatrix4x4> Matrix4x4(GameObject owner, Func<Matrix4x4> from, Func<Matrix4x4> to, Action<Matrix4x4> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Matrix4x4(owner, null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Matrix4x4(GameObject, Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="Matrix4x4(string, Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Matrix4x4(Func{Matrix4x4}, Func{Matrix4x4}, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Matrix4x4(Func{Matrix4x4}, Func{Matrix4x4}, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Matrix4x4(Matrix4x4, Matrix4x4, Action{Matrix4x4}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Matrix4x4, TweakMatrix4x4> Matrix4x4(GameObject owner, string name, Func<Matrix4x4> from, Func<Matrix4x4> to, Action<Matrix4x4> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return new Tween<Matrix4x4, TweakMatrix4x4>(owner, name, new TweakMatrix4x4(), from, to, action, loopDuration, ease, loopsCount, loopType, direction);
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
            return Quaternion((string)null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name">Tween's name (useful for debugging and nesting in sequences).</param>
        /// <param name="from"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Quaternion, TweakQuaternion> Quaternion(string name, Quaternion from, Quaternion to, Action<Quaternion> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Quaternion(null, name, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner">Game object to which this tween will be attached.</param>
        /// <param name="from"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Quaternion, TweakQuaternion> Quaternion(GameObject owner, Quaternion from, Quaternion to, Action<Quaternion> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Quaternion(owner, null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Quaternion(GameObject, Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="Quaternion(string, Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Quaternion, TweakQuaternion> Quaternion(GameObject owner, string name, Quaternion from, Quaternion to, Action<Quaternion> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Quaternion(owner, name, () => from, () => to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="from">Callback which return value from which tween starts animation.</param>
        /// <param name="to">Callback which return value on which tween completes animation.</param>
        /// <param name="action"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Quaternion, TweakQuaternion> Quaternion(Func<Quaternion> from, Func<Quaternion> to, Action<Quaternion> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Quaternion((string)null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name"><inheritdoc cref="Quaternion(string, Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Quaternion(Func{Quaternion}, Func{Quaternion}, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Quaternion(Func{Quaternion}, Func{Quaternion}, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Quaternion, TweakQuaternion> Quaternion(string name, Func<Quaternion> from, Func<Quaternion> to, Action<Quaternion> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Quaternion(null, name, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Quaternion(GameObject, Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="from"><inheritdoc cref="Quaternion(Func{Quaternion}, Func{Quaternion}, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Quaternion(Func{Quaternion}, Func{Quaternion}, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Quaternion, TweakQuaternion> Quaternion(GameObject owner, Func<Quaternion> from, Func<Quaternion> to, Action<Quaternion> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Quaternion(owner, null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Quaternion(GameObject, Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="Quaternion(string, Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Quaternion(Func{Quaternion}, Func{Quaternion}, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Quaternion(Func{Quaternion}, Func{Quaternion}, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Quaternion(Quaternion, Quaternion, Action{Quaternion}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Quaternion, TweakQuaternion> Quaternion(GameObject owner, string name, Func<Quaternion> from, Func<Quaternion> to, Action<Quaternion> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return new Tween<Quaternion, TweakQuaternion>(owner, name, new TweakQuaternion(), from, to, action, loopDuration, ease, loopsCount, loopType, direction);
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
            return Rect((string)null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name">Tween's name (useful for debugging and nesting in sequences).</param>
        /// <param name="from"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Rect, TweakRect> Rect(string name, Rect from, Rect to, Action<Rect> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Rect(null, name, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner">Game object to which this tween will be attached.</param>
        /// <param name="from"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Rect, TweakRect> Rect(GameObject owner, Rect from, Rect to, Action<Rect> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Rect(owner, null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Rect(GameObject, Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="Rect(string, Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Rect, TweakRect> Rect(GameObject owner, string name, Rect from, Rect to, Action<Rect> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Rect(owner, name, () => from, () => to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="from">Callback which return value from which tween starts animation.</param>
        /// <param name="to">Callback which return value on which tween completes animation.</param>
        /// <param name="action"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Rect, TweakRect> Rect(Func<Rect> from, Func<Rect> to, Action<Rect> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Rect((string)null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name"><inheritdoc cref="Rect(string, Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Rect(Func{Rect}, Func{Rect}, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Rect(Func{Rect}, Func{Rect}, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Rect, TweakRect> Rect(string name, Func<Rect> from, Func<Rect> to, Action<Rect> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Rect(null, name, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Rect(GameObject, Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="from"><inheritdoc cref="Rect(Func{Rect}, Func{Rect}, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Rect(Func{Rect}, Func{Rect}, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Rect, TweakRect> Rect(GameObject owner, Func<Rect> from, Func<Rect> to, Action<Rect> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Rect(owner, null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Rect(GameObject, Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="Rect(string, Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Rect(Func{Rect}, Func{Rect}, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Rect(Func{Rect}, Func{Rect}, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Rect(Rect, Rect, Action{Rect}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Rect, TweakRect> Rect(GameObject owner, string name, Func<Rect> from, Func<Rect> to, Action<Rect> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return new Tween<Rect, TweakRect>(owner, name, new TweakRect(), from, to, action, loopDuration, ease, loopsCount, loopType, direction);
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
            return Bounds((string)null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name">Tween's name (useful for debugging and nesting in sequences).</param>
        /// <param name="from"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Bounds, TweakBounds> Bounds(string name, Bounds from, Bounds to, Action<Bounds> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Bounds(null, name, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner">Game object to which this tween will be attached.</param>
        /// <param name="from"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Bounds, TweakBounds> Bounds(GameObject owner, Bounds from, Bounds to, Action<Bounds> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Bounds(owner, null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Bounds(GameObject, Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="Bounds(string, Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Bounds, TweakBounds> Bounds(GameObject owner, string name, Bounds from, Bounds to, Action<Bounds> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Bounds(owner, name, () => from, () => to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="from">Callback which return value from which tween starts animation.</param>
        /// <param name="to">Callback which return value on which tween completes animation.</param>
        /// <param name="action"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Bounds, TweakBounds> Bounds(Func<Bounds> from, Func<Bounds> to, Action<Bounds> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Bounds((string)null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name"><inheritdoc cref="Bounds(string, Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Bounds(Func{Bounds}, Func{Bounds}, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Bounds(Func{Bounds}, Func{Bounds}, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Bounds, TweakBounds> Bounds(string name, Func<Bounds> from, Func<Bounds> to, Action<Bounds> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Bounds(null, name, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Bounds(GameObject, Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="from"><inheritdoc cref="Bounds(Func{Bounds}, Func{Bounds}, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Bounds(Func{Bounds}, Func{Bounds}, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Bounds, TweakBounds> Bounds(GameObject owner, Func<Bounds> from, Func<Bounds> to, Action<Bounds> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Bounds(owner, null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Bounds(GameObject, Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="Bounds(string, Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Bounds(Func{Bounds}, Func{Bounds}, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Bounds(Func{Bounds}, Func{Bounds}, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="Bounds(Bounds, Bounds, Action{Bounds}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<Bounds, TweakBounds> Bounds(GameObject owner, string name, Func<Bounds> from, Func<Bounds> to, Action<Bounds> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return new Tween<Bounds, TweakBounds>(owner, name, new TweakBounds(), from, to, action, loopDuration, ease, loopsCount, loopType, direction);
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
            return BoundsInt((string)null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name">Tween's name (useful for debugging and nesting in sequences).</param>
        /// <param name="from"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<BoundsInt, TweakBoundsInt> BoundsInt(string name, BoundsInt from, BoundsInt to, Action<BoundsInt> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return BoundsInt(null, name, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner">Game object to which this tween will be attached.</param>
        /// <param name="from"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<BoundsInt, TweakBoundsInt> BoundsInt(GameObject owner, BoundsInt from, BoundsInt to, Action<BoundsInt> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return BoundsInt(owner, null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="BoundsInt(GameObject, BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="BoundsInt(string, BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<BoundsInt, TweakBoundsInt> BoundsInt(GameObject owner, string name, BoundsInt from, BoundsInt to, Action<BoundsInt> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return BoundsInt(owner, name, () => from, () => to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="from">Callback which return value from which tween starts animation.</param>
        /// <param name="to">Callback which return value on which tween completes animation.</param>
        /// <param name="action"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<BoundsInt, TweakBoundsInt> BoundsInt(Func<BoundsInt> from, Func<BoundsInt> to, Action<BoundsInt> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return BoundsInt((string)null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name"><inheritdoc cref="BoundsInt(string, BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="BoundsInt(Func{BoundsInt}, Func{BoundsInt}, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="BoundsInt(Func{BoundsInt}, Func{BoundsInt}, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<BoundsInt, TweakBoundsInt> BoundsInt(string name, Func<BoundsInt> from, Func<BoundsInt> to, Action<BoundsInt> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return BoundsInt(null, name, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="BoundsInt(GameObject, BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="from"><inheritdoc cref="BoundsInt(Func{BoundsInt}, Func{BoundsInt}, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="BoundsInt(Func{BoundsInt}, Func{BoundsInt}, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<BoundsInt, TweakBoundsInt> BoundsInt(GameObject owner, Func<BoundsInt> from, Func<BoundsInt> to, Action<BoundsInt> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return BoundsInt(owner, null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="BoundsInt(GameObject, BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="BoundsInt(string, BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="BoundsInt(Func{BoundsInt}, Func{BoundsInt}, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="BoundsInt(Func{BoundsInt}, Func{BoundsInt}, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="BoundsInt(BoundsInt, BoundsInt, Action{BoundsInt}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<BoundsInt, TweakBoundsInt> BoundsInt(GameObject owner, string name, Func<BoundsInt> from, Func<BoundsInt> to, Action<BoundsInt> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return new Tween<BoundsInt, TweakBoundsInt>(owner, name, new TweakBoundsInt(), from, to, action, loopDuration, ease, loopsCount, loopType, direction);
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
            return BoundingSphere((string)null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name">Tween's name (useful for debugging and nesting in sequences).</param>
        /// <param name="from"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<BoundingSphere, TweakBoundingSphere> BoundingSphere(string name, BoundingSphere from, BoundingSphere to, Action<BoundingSphere> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return BoundingSphere(null, name, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner">Game object to which this tween will be attached.</param>
        /// <param name="from"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<BoundingSphere, TweakBoundingSphere> BoundingSphere(GameObject owner, BoundingSphere from, BoundingSphere to, Action<BoundingSphere> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return BoundingSphere(owner, null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="BoundingSphere(GameObject, BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="BoundingSphere(string, BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<BoundingSphere, TweakBoundingSphere> BoundingSphere(GameObject owner, string name, BoundingSphere from, BoundingSphere to, Action<BoundingSphere> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return BoundingSphere(owner, name, () => from, () => to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="from">Callback which return value from which tween starts animation.</param>
        /// <param name="to">Callback which return value on which tween completes animation.</param>
        /// <param name="action"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<BoundingSphere, TweakBoundingSphere> BoundingSphere(Func<BoundingSphere> from, Func<BoundingSphere> to, Action<BoundingSphere> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return BoundingSphere((string)null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name"><inheritdoc cref="BoundingSphere(string, BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="BoundingSphere(Func{BoundingSphere}, Func{BoundingSphere}, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="BoundingSphere(Func{BoundingSphere}, Func{BoundingSphere}, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<BoundingSphere, TweakBoundingSphere> BoundingSphere(string name, Func<BoundingSphere> from, Func<BoundingSphere> to, Action<BoundingSphere> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return BoundingSphere(null, name, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="BoundingSphere(GameObject, BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="from"><inheritdoc cref="BoundingSphere(Func{BoundingSphere}, Func{BoundingSphere}, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="BoundingSphere(Func{BoundingSphere}, Func{BoundingSphere}, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<BoundingSphere, TweakBoundingSphere> BoundingSphere(GameObject owner, Func<BoundingSphere> from, Func<BoundingSphere> to, Action<BoundingSphere> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return BoundingSphere(owner, null, from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
        /// <inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="BoundingSphere(GameObject, BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="BoundingSphere(string, BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="BoundingSphere(Func{BoundingSphere}, Func{BoundingSphere}, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="BoundingSphere(Func{BoundingSphere}, Func{BoundingSphere}, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        /// <returns><inheritdoc cref="BoundingSphere(BoundingSphere, BoundingSphere, Action{BoundingSphere}, float, Ease, int, LoopType, Direction)"/></returns>
        public static Tween<BoundingSphere, TweakBoundingSphere> BoundingSphere(GameObject owner, string name, Func<BoundingSphere> from, Func<BoundingSphere> to, Action<BoundingSphere> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return new Tween<BoundingSphere, TweakBoundingSphere>(owner, name, new TweakBoundingSphere(), from, to, action, loopDuration, ease, loopsCount, loopType, direction);
        }
        #endregion
        #endregion

        #region Shake
        public static Tween<float, TweakFloat> Shake(float from, int count, float strenght, float duration, Action<float> action, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return Shake(null, null, from, count, strenght, duration, action, leftSmoothness, rightSmoothness);
        }

        public static Tween<float, TweakFloat> Shake(GameObject owner, string name, float from, int count, float strenght, float duration, Action<float> action, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            var startX = UnityEngine.Random.Range(0f, 100f);
            var y = UnityEngine.Random.Range(0f, 300f);

            duration = Mathf.Max(duration, 0f);

            count = Mathf.Max(count, 0);
            strenght = Mathf.Abs(strenght);

            var endX = startX + count;

            var tween = Float(owner, name, startX, endX, x =>
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
            return Punch(null, null, from, count, strenght, duration, action, leftSmoothness, rightSmoothness);
        }

        public static Tween<float, TweakFloat> Punch(GameObject owner, string name, float from, int count, float strenght, float duration, Action<float> action, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
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
            return Punch(null, null, from, count, to, duration, action, leftSmoothness, rightSmoothness);
        }

        public static Tween<float, TweakFloat> Punch(GameObject owner, string name, Quaternion from, int count, Quaternion to, float duration, Action<Quaternion> action, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
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
    /// Represents a class capable of animating values over time.
    /// </summary>
    /// <typeparam name="T">Source type of animated value. Must be a structure.</typeparam>
    /// <typeparam name="U">Tweak type which can interpolate source type. Must have default constructor.</typeparam>
    public sealed class Tween<T, U> : Playable<Tween<T, U>> where T : struct where U : Tweak<T>, new()
    {
        public override Type Type => Type.Tween;

        /// <summary>
        /// <inheritdoc cref="IPlayable.LoopDuration"/>
        /// </summary>
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
        public Tween(U tweak, T from, T to, Action<T> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : this((string)null, tweak, from, to, action, loopDuration, ease, loopsCount, loopType, direction) { }

        /// <summary>
        /// <inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name">Name of the tween (usefull in sequences for finding elements and for debugging).</param>
        /// <param name="from"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        public Tween(string name, T from, T to, Action<T> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : this(name, new U(), from, to, action, loopDuration, ease, loopsCount, loopType, direction) { }

        /// <summary>
        /// <inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name"><inheritdoc cref="Tween{T, U}.Tween(string, T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="tweak"><inheritdoc cref="Tween{T, U}.Tween(U, T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='tweak']"/></param>
        /// <param name="from"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        public Tween(string name, U tweak, T from, T to, Action<T> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : this(null, name, tweak, from, to, action, loopDuration, ease, loopsCount, loopType, direction) { }

        /// <summary>
        /// <inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner">Game object to which this tween will be attached.</param>
        /// <param name="from"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        public Tween(GameObject owner, T from, T to, Action<T> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : this(owner, new U(), from, to, action, loopDuration, ease, loopsCount, loopType, direction) { }

        /// <summary>
        /// <inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Tween{T, U}.Tween(GameObject, T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="tweak"><inheritdoc cref="Tween{T, U}.Tween(U, T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='tweak']"/></param>
        /// <param name="from"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        public Tween(GameObject owner, U tweak, T from, T to, Action<T> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : this(owner, null, tweak, from, to, action, loopDuration, ease, loopsCount, loopType, direction) { }

        /// <summary>
        /// <inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Tween{T, U}.Tween(GameObject, T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="Tween{T, U}.Tween(string, U, T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        public Tween(GameObject owner, string name, T from, T to, Action<T> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : this(owner, name, new U(), from, to, action, loopDuration, ease, loopsCount, loopType, direction) { }

        /// <summary>
        /// <inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Tween{T, U}.Tween(GameObject, T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="Tween{T, U}.Tween(string, U, T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="tweak"><inheritdoc cref="Tween{T, U}.Tween(U, T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='tweak']"/></param>
        /// <param name="from"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        public Tween(GameObject owner, string name, U tweak, T from, T to, Action<T> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : this(owner, name, tweak, () => from, () => to, action, loopDuration, ease, loopsCount, loopType, direction) { }

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
        public Tween(U tweak, Func<T> from, Func<T> to, Action<T> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : this((string)null, tweak, from, to, action, loopDuration, ease, loopsCount, loopType, direction) { }

        /// <summary>
        /// <inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name"><inheritdoc cref="Tween{T, U}.Tween(string, T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Tween{T, U}.Tween(Func{T}, Func{T}, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Tween{T, U}.Tween(Func{T}, Func{T}, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        public Tween(string name, Func<T> from, Func<T> to, Action<T> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : this(name, new U(), from, to, action, loopDuration, ease, loopsCount, loopType, direction) { }

        /// <summary>
        /// <inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name"><inheritdoc cref="Tween{T, U}.Tween(string, T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="tweak"><inheritdoc cref="Tween{T, U}.Tween(U, T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='tweak']"/></param>
        /// <param name="from"><inheritdoc cref="Tween{T, U}.Tween(Func{T}, Func{T}, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Tween{T, U}.Tween(Func{T}, Func{T}, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        public Tween(string name, U tweak, Func<T> from, Func<T> to, Action<T> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : this(null, name, tweak, from, to, action, loopDuration, ease, loopsCount, loopType, direction) { }

        /// <summary>
        /// <inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Tween{T, U}.Tween(GameObject, T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="from"><inheritdoc cref="Tween{T, U}.Tween(Func{T}, Func{T}, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Tween{T, U}.Tween(Func{T}, Func{T}, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        public Tween(GameObject owner, Func<T> from, Func<T> to, Action<T> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : this(owner, new U(), from, to, action, loopDuration, ease, loopsCount, loopType, direction) { }

        /// <summary>
        /// <inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Tween{T, U}.Tween(GameObject, T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="tweak"><inheritdoc cref="Tween{T, U}.Tween(U, T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='tweak']"/></param>
        /// <param name="from"><inheritdoc cref="Tween{T, U}.Tween(Func{T}, Func{T}, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Tween{T, U}.Tween(Func{T}, Func{T}, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        public Tween(GameObject owner, U tweak, Func<T> from, Func<T> to, Action<T> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : this(owner, null, tweak, from, to, action, loopDuration, ease, loopsCount, loopType, direction) { }

        /// <summary>
        /// <inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Tween{T, U}.Tween(GameObject, T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="Tween{T, U}.Tween(string, T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Tween{T, U}.Tween(Func{T}, Func{T}, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Tween{T, U}.Tween(Func{T}, Func{T}, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        public Tween(GameObject owner, string name, Func<T> from, Func<T> to, Action<T> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : this(owner, name, new U(), from, to, action, loopDuration, ease, loopsCount, loopType, direction) { }

        /// <summary>
        /// <inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Tween{T, U}.Tween(GameObject, T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="Tween{T, U}.Tween(string, T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="tweak"><inheritdoc cref="Tween{T, U}.Tween(U, T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='tweak']"/></param>
        /// <param name="from"><inheritdoc cref="Tween{T, U}.Tween(Func{T}, Func{T}, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Tween{T, U}.Tween(Func{T}, Func{T}, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="ease"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        public Tween(GameObject owner, string name, U tweak, Func<T> from, Func<T> to, Action<T> action, float loopDuration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : base(owner, name, loopDuration, ease, loopsCount, loopType, direction)
        {
            Tweak = tweak;
            From = from;
            To = to;
            Action = action;
        }
        #endregion

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

        protected override void RewindZeroHandler(int loop, float loopedNormalizedTime, Direction direction, bool emitEvents, int parentContinueLoopIndex, int continueMaxLoopsCount)
        {
            var (from, to) = (From(), To());

            (T, T) Evaluate(float fromInterlopation, float toInterpolation) => (Tweak.Evaluate(from, to, fromInterlopation), Tweak.Evaluate(from, to, toInterpolation));

            if (LoopType == LoopType.Reset)
            {
                if (direction == Direction.Forward)
                    (from, to) = Evaluate(parentContinueLoopIndex, parentContinueLoopIndex + 1f);
                else
                    (from, to) = Evaluate(continueMaxLoopsCount - parentContinueLoopIndex, continueMaxLoopsCount - parentContinueLoopIndex - 1f);

                Tweak.Apply(from, to, loopedNormalizedTime, Action, Ease);
            }
            else if (LoopType == LoopType.Continue)
            {
                if (direction == Direction.Forward)
                    (from, to) = Evaluate(parentContinueLoopIndex * LoopsCount + loop, parentContinueLoopIndex * LoopsCount + loop + 1f);
                else
                    (from, to) = Evaluate(continueMaxLoopsCount * LoopsCount - (parentContinueLoopIndex * LoopsCount) - loop, continueMaxLoopsCount * LoopsCount - (parentContinueLoopIndex * LoopsCount) - loop - 1f);

                Tweak.Apply(from, to, loopedNormalizedTime, Action, Ease);
            }
            else if (LoopType == LoopType.Mirror)
            {
                if (direction == Direction.Forward)
                    (from, to) = Evaluate(parentContinueLoopIndex, parentContinueLoopIndex + 1f);
                else
                    (from, to) = Evaluate(continueMaxLoopsCount - parentContinueLoopIndex - 1f, continueMaxLoopsCount - parentContinueLoopIndex);

                var loopedMirroredNormalizedTime = loopedNormalizedTime * 2f;

                if (loopedMirroredNormalizedTime > 1f)
                    loopedMirroredNormalizedTime = 2f - loopedMirroredNormalizedTime;

                Tweak.Apply(from, to, loopedMirroredNormalizedTime, Action, Ease);
            }
        }

        protected override void RewindHandler(int loop, float loopedTime, Direction direction, bool emitEvents, int parentContinueLoopIndex, int continueMaxLoopsCount)
        {
            var (from, to) = (From(), To());

            (T, T) Evaluate(float fromInterlopation, float toInterpolation) => (Tweak.Evaluate(from, to, fromInterlopation), Tweak.Evaluate(from, to, toInterpolation));

            var loopedNormalizedTime = loopedTime / LoopDuration;

            if (LoopType == LoopType.Reset)
            {
                if (direction == Direction.Forward)
                    (from, to) = Evaluate(parentContinueLoopIndex, parentContinueLoopIndex + 1f);
                else
                    (from, to) = Evaluate(continueMaxLoopsCount - parentContinueLoopIndex, continueMaxLoopsCount - parentContinueLoopIndex - 1f);

                Tweak.Apply(from, to, loopedNormalizedTime, Action, InvertIfRequiredAndGetease(direction));
            }
            else if (LoopType == LoopType.Continue)
            {
                if (direction == Direction.Forward)
                    (from, to) = Evaluate(parentContinueLoopIndex * LoopsCount + loop, parentContinueLoopIndex * LoopsCount + loop + 1f);
                else
                    (from, to) = Evaluate(continueMaxLoopsCount * LoopsCount - (parentContinueLoopIndex * LoopsCount) - loop, continueMaxLoopsCount * LoopsCount - (parentContinueLoopIndex * LoopsCount) - loop - 1f);

                Tweak.Apply(from, to, loopedNormalizedTime, Action, InvertIfRequiredAndGetease(direction));
            }
            else if (LoopType == LoopType.Mirror)
            {
                if (direction == Direction.Forward)
                    (from, to) = Evaluate(parentContinueLoopIndex, parentContinueLoopIndex + 1f);
                else
                    (from, to) = Evaluate(continueMaxLoopsCount - parentContinueLoopIndex - 1f, continueMaxLoopsCount - parentContinueLoopIndex);

                var loopedMirroredNormalizedTime = loopedNormalizedTime * 2f;

                if (loopedMirroredNormalizedTime > 1f)
                    loopedMirroredNormalizedTime = 2f - loopedMirroredNormalizedTime;

                Tweak.Apply(from, to, loopedMirroredNormalizedTime, Action, Ease);
            }
        }
    }
}