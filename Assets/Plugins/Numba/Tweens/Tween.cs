using System;
using Tweens.Formulas;
using UnityEngine;

namespace Tweens
{
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
        /// Delegate which return <c><b>from</b></c> value.
        /// </summary>
        public Func<T> From { get; set; }

        /// <summary>
        /// Delegate which return <c><b>to</b></c> value.
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
        /// <param name="to">Value to which tween starts animation.</param>
        /// <param name="action">Callback which receive animated value.</param>
        /// <param name="loopDuration">Loop duration of the tween.</param>
        /// <param name="formula">Formula which used when tween animate values.</param>
        /// <param name="loopsCount">Loops count of the tween.</param>
        /// <param name="loopType">Loop type which used between loops in the tween</param>
        /// <param name="direction">Direction in which the tween starts playing animation.</param>
        public Tween(T from, T to, Action<T> action, float loopDuration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : this(new U(), from, to, action, loopDuration, formula, loopsCount, loopType, direction) { }

        /// <summary>
        /// <inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="tweak">Tweak which used to interpolate values.</param>
        /// <param name="from"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="formula"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='formula']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        public Tween(U tweak, T from, T to, Action<T> action, float loopDuration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : this((string)null, tweak, from, to, action, loopDuration, formula, loopsCount, loopType, direction) { }

        /// <summary>
        /// <inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name">Name of the tween (usefull in sequences for finding elements and for debugging).</param>
        /// <param name="from"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="formula"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='formula']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        public Tween(string name, T from, T to, Action<T> action, float loopDuration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : this(name, new U(), from, to, action, loopDuration, formula, loopsCount, loopType, direction) { }

        /// <summary>
        /// <inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name"><inheritdoc cref="Tween{T, U}.Tween(string, T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="tweak"><inheritdoc cref="Tween{T, U}.Tween(U, T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='tweak']"/></param>
        /// <param name="from"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="formula"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='formula']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        public Tween(string name, U tweak, T from, T to, Action<T> action, float loopDuration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : this(null, name, tweak, from, to, action, loopDuration, formula, loopsCount, loopType, direction) { }

        /// <summary>
        /// <inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner">Game object to which this tween will be attached.</param>
        /// <param name="from"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="formula"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='formula']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        public Tween(GameObject owner, T from, T to, Action<T> action, float loopDuration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : this(owner, new U(), from, to, action, loopDuration, formula, loopsCount, loopType, direction) { }

        /// <summary>
        /// <inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Tween{T, U}.Tween(GameObject, T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="tweak"><inheritdoc cref="Tween{T, U}.Tween(U, T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='tweak']"/></param>
        /// <param name="from"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="formula"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='formula']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        public Tween(GameObject owner, U tweak, T from, T to, Action<T> action, float loopDuration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : this(owner, null, tweak, from, to, action, loopDuration, formula, loopsCount, loopType, direction) { }

        /// <summary>
        /// <inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Tween{T, U}.Tween(GameObject, T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="Tween{T, U}.Tween(string, U, T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="formula"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='formula']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        public Tween(GameObject owner, string name, T from, T to, Action<T> action, float loopDuration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : this(owner, name, new U(), from, to, action, loopDuration, formula, loopsCount, loopType, direction) { }

        /// <summary>
        /// <inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Tween{T, U}.Tween(GameObject, T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="Tween{T, U}.Tween(string, U, T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="tweak"><inheritdoc cref="Tween{T, U}.Tween(U, T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='tweak']"/></param>
        /// <param name="from"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="formula"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='formula']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        public Tween(GameObject owner, string name, U tweak, T from, T to, Action<T> action, float loopDuration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : this(owner, name, tweak, () => from, () => to, action, loopDuration, formula, loopsCount, loopType, direction) { }

        /// <summary>
        /// <inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="from">Callback which return value from which tween starts animation.</param>
        /// <param name="to">Callback which return value to which tween starts animation.</param>
        /// <param name="action"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="formula"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='formula']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        public Tween(Func<T> from, Func<T> to, Action<T> action, float loopDuration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : this(new U(), from, to, action, loopDuration, formula, loopsCount, loopType, direction) { }

        /// <summary>
        /// <inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="tweak"><inheritdoc cref="Tween{T, U}.Tween(U, T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='tweak']"/></param>
        /// <param name="from"><inheritdoc cref="Tween{T, U}.Tween(Func{T}, Func{T}, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Tween{T, U}.Tween(Func{T}, Func{T}, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="action"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="formula"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='formula']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        public Tween(U tweak, Func<T> from, Func<T> to, Action<T> action, float loopDuration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : this((string)null, tweak, from, to, action, loopDuration, formula, loopsCount, loopType, direction) { }

        /// <summary>
        /// <inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name"><inheritdoc cref="Tween{T, U}.Tween(string, T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Tween{T, U}.Tween(Func{T}, Func{T}, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Tween{T, U}.Tween(Func{T}, Func{T}, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="action"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="formula"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='formula']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        public Tween(string name, Func<T> from, Func<T> to, Action<T> action, float loopDuration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : this(name, new U(), from, to, action, loopDuration, formula, loopsCount, loopType, direction) { }

        /// <summary>
        /// <inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="name"><inheritdoc cref="Tween{T, U}.Tween(string, T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="tweak"><inheritdoc cref="Tween{T, U}.Tween(U, T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='tweak']"/></param>
        /// <param name="from"><inheritdoc cref="Tween{T, U}.Tween(Func{T}, Func{T}, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Tween{T, U}.Tween(Func{T}, Func{T}, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="action"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="formula"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='formula']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        public Tween(string name, U tweak, Func<T> from, Func<T> to, Action<T> action, float loopDuration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : this(null, name, tweak, from, to, action, loopDuration, formula, loopsCount, loopType, direction) { }

        /// <summary>
        /// <inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Tween{T, U}.Tween(GameObject, T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="from"><inheritdoc cref="Tween{T, U}.Tween(Func{T}, Func{T}, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Tween{T, U}.Tween(Func{T}, Func{T}, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="formula"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='formula']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        public Tween(GameObject owner, Func<T> from, Func<T> to, Action<T> action, float loopDuration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : this(owner, new U(), from, to, action, loopDuration, formula, loopsCount, loopType, direction) { }

        /// <summary>
        /// <inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Tween{T, U}.Tween(GameObject, T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="tweak"><inheritdoc cref="Tween{T, U}.Tween(U, T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='tweak']"/></param>
        /// <param name="from"><inheritdoc cref="Tween{T, U}.Tween(Func{T}, Func{T}, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Tween{T, U}.Tween(Func{T}, Func{T}, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="formula"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='formula']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        public Tween(GameObject owner, U tweak, Func<T> from, Func<T> to, Action<T> action, float loopDuration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : this(owner, null, tweak, from, to, action, loopDuration, formula, loopsCount, loopType, direction) { }

        /// <summary>
        /// <inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Tween{T, U}.Tween(GameObject, T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="Tween{T, U}.Tween(string, T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="from"><inheritdoc cref="Tween{T, U}.Tween(Func{T}, Func{T}, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Tween{T, U}.Tween(Func{T}, Func{T}, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="formula"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='formula']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        public Tween(GameObject owner, string name, Func<T> from, Func<T> to, Action<T> action, float loopDuration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : this(owner, name, new U(), from, to, action, loopDuration, formula, loopsCount, loopType, direction) { }

        /// <summary>
        /// <inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Tween{T, U}.Tween(GameObject, T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="Tween{T, U}.Tween(string, T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='name']"/></param>
        /// <param name="tweak"><inheritdoc cref="Tween{T, U}.Tween(U, T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='tweak']"/></param>
        /// <param name="from"><inheritdoc cref="Tween{T, U}.Tween(Func{T}, Func{T}, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Tween{T, U}.Tween(Func{T}, Func{T}, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='to']"/></param>
        /// <param name="action"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='action']"/></param>
        /// <param name="loopDuration"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='loopDuration']"/></param>
        /// <param name="formula"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='formula']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="direction"><inheritdoc cref="Tween{T, U}.Tween(T, T, Action{T}, float, FormulaBase, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        public Tween(GameObject owner, string name, U tweak, Func<T> from, Func<T> to, Action<T> action, float loopDuration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : base(owner, name, loopDuration, formula, loopsCount, loopType, direction)
        {
            Tweak = tweak;
            From = from;
            To = to;
            Action = action;
        }
        #endregion

        private FormulaBase InvertIfRequiredAndGetFormula(Direction direction) => direction == Direction.Forward ? Formula : Tweens.Formula.Invertion.WithFormula(Formula);

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

                Tweak.Apply(from, to, loopedNormalizedTime, Action, Formula);
            }
            else if (LoopType == LoopType.Continue)
            {
                if (direction == Direction.Forward)
                    (from, to) = Evaluate(parentContinueLoopIndex * LoopsCount + loop, parentContinueLoopIndex * LoopsCount + loop + 1f);
                else
                    (from, to) = Evaluate(continueMaxLoopsCount * LoopsCount - (parentContinueLoopIndex * LoopsCount) - loop, continueMaxLoopsCount * LoopsCount - (parentContinueLoopIndex * LoopsCount) - loop - 1f);

                Tweak.Apply(from, to, loopedNormalizedTime, Action, Formula);
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

                Tweak.Apply(from, to, loopedMirroredNormalizedTime, Action, Formula);
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

                Tweak.Apply(from, to, loopedNormalizedTime, Action, InvertIfRequiredAndGetFormula(direction));
            }
            else if (LoopType == LoopType.Continue)
            {
                if (direction == Direction.Forward)
                    (from, to) = Evaluate(parentContinueLoopIndex * LoopsCount + loop, parentContinueLoopIndex * LoopsCount + loop + 1f);
                else
                    (from, to) = Evaluate(continueMaxLoopsCount * LoopsCount - (parentContinueLoopIndex * LoopsCount) - loop, continueMaxLoopsCount * LoopsCount - (parentContinueLoopIndex * LoopsCount) - loop - 1f);

                Tweak.Apply(from, to, loopedNormalizedTime, Action, InvertIfRequiredAndGetFormula(direction));
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

                Tweak.Apply(from, to, loopedMirroredNormalizedTime, Action, InvertIfRequiredAndGetFormula(direction));
            }
        }
    }
}