using System;

namespace Redcode.Tweens
{
    /// <summary>
    /// Base class for all tweaks, which used in <c>Tween</c> class.
    /// </summary>
    /// <typeparam name="T">Any struct type, which will be interpolated.</typeparam>
    public abstract class Tweak<T> where T : struct
    {
        /// <summary>
        /// Calculate interpolated value between <paramref name="from"/> and <paramref name="to"/>.
        /// </summary>
        /// <param name="from">Value from which we starts interpolating.</param>
        /// <param name="to">Value on which we complete interpolating.</param>
        /// <param name="interpolation">Interpolation value.</param>
        /// <param name="ease">Easing formula which will be used to remap interpolation value (<c>null</c> means linear ease formula).</param>
        /// <returns>Interpolated through <paramref name="ease"/> value.</returns>
        public T Evaluate(T from, T to, float interpolation, Ease ease = null) => Interpolate(from, to, ease?.Remap(interpolation) ?? interpolation);

        protected abstract T Interpolate(T from, T to, float interpolation);

        /// <summary>
        /// Apply interpolated value between <paramref name="from"/> and <paramref name="to"/>.
        /// </summary>
        /// <param name="from"><inheritdoc cref="Tweak{T}.Evaluate" path="/param[@name='from']"/></param>
        /// <param name="to"><inheritdoc cref="Tweak{T}.Evaluate" path="/param[@name='to']"/></param>
        /// <param name="interpolation"><inheritdoc cref="Tweak{T}.Evaluate" path="/param[@name='interpolation']"/></param>
        /// <param name="action">Callback which will be applied.</param>
        /// <param name="ease"><inheritdoc cref="Tweak{T}.Evaluate" path="/param[@name='formula']"/></param>
        public void Apply(T from, T to, float interpolation, Action<T> action, Ease ease = null) => action(Evaluate(from, to, interpolation, ease));
    }

    /// <summary>
    /// Gives control around what type of interpolation need to use when tweaks values.
    /// </summary>
    /// <typeparam name="T">Type which represent direction.</typeparam>
    public abstract class TweakDirectional<T> : Tweak<T> where T : struct
    {
        /// <summary>
        /// Interpolation type which will used when tweak values.
        /// </summary>
        public InterpolationType InterpolationType { get; set; }
    }
}