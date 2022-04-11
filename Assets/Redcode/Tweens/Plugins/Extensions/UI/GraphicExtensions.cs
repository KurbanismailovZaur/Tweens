using Redcode.Tweens.Tweaks;
using UnityEngine;
using UnityEngine.UI;
using Redcode.Extensions;

namespace Redcode.Tweens
{
    public static class GraphicExtensions
    {
        #region DoColor
        #region DoColorOneAxis
        private static Tween<float, TweakFloat> DoColorOneChannel(Graphic graphic, GameObject owner, int channel, float value, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(graphic.color[channel], value, c => graphic.color = graphic.color.With(channel, c), duration, ease, loopsCount, loopType, direction).SetOwner(owner).SetName(owner.name);
        }

        /// <summary>
		/// Tweens graphic's red channel value.
		/// </summary>
		/// <param name="graphic">Canvas group.</param>
		/// <param name="r">Target red channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<float, TweakFloat> DoColorR(this Graphic graphic, float r, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneChannel(graphic, graphic.gameObject, 0, r, duration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
		/// Tweens graphic's green channel value.
		/// </summary>
		/// <param name="graphic">Canvas group.</param>
		/// <param name="g">Target green channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<float, TweakFloat> DoColorG(this Graphic graphic, float g, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneChannel(graphic, graphic.gameObject, 1, g, duration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
		/// Tweens graphic's blue channel value.
		/// </summary>
		/// <param name="graphic">Canvas group.</param>
		/// <param name="b">Target blue channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<float, TweakFloat> DoColorB(this Graphic graphic, float b, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneChannel(graphic, graphic.gameObject, 2, b, duration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
		/// Tweens graphic's alpha channel value.
		/// </summary>
		/// <param name="graphic">Canvas group.</param>
		/// <param name="a">Target alpha channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<float, TweakFloat> DoColorA(this Graphic graphic, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneChannel(graphic, graphic.gameObject, 3, a, duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoColorTwoAxes
        private static Tween<Vector2, TweakVector2> DoColorTwoChannels(Graphic graphic, GameObject owner, int channel1, int channel2, float value1, float value2, float duration, Ease ease, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            return Tween.Vector2(graphic.color.Get(channel1, channel2), new Vector2(value1, value2), c => graphic.color = graphic.color.With(channel1, c.x, channel2, c.y), duration, ease, loopsCount, loopType, direction).SetOwner(owner).SetName(owner.name);
        }

        /// <summary>
		/// Tweens graphic's red and green channel value.
		/// </summary>
		/// <param name="graphic">Canvas group.</param>
		/// <param name="r">Target red channel.</param>
		/// <param name="g">Target green channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Vector2, TweakVector2> DoColorRG(this Graphic graphic, float r, float g, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoChannels(graphic, graphic.gameObject, 0, 1, r, g, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        /// <summary>
		/// Tweens graphic's red and blue channel value.
		/// </summary>
		/// <param name="graphic">Canvas group.</param>
		/// <param name="r">Target red channel.</param>
		/// <param name="b">Target blue channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Vector2, TweakVector2> DoColorRB(this Graphic graphic, float r, float b, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoChannels(graphic, graphic.gameObject, 0, 2, r, b, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        /// <summary>
		/// Tweens graphic's red and alpha channel value.
		/// </summary>
		/// <param name="graphic">Canvas group.</param>
		/// <param name="r">Target red channel.</param>
		/// <param name="a">Target alpha channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Vector2, TweakVector2> DoColorRA(this Graphic graphic, float r, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoChannels(graphic, graphic.gameObject, 0, 3, r, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        /// <summary>
		/// Tweens graphic's green and blue channel value.
		/// </summary>
		/// <param name="graphic">Canvas group.</param>
		/// <param name="g">Target green channel.</param>
		/// <param name="b">Target blue channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Vector2, TweakVector2> DoColorGB(this Graphic graphic, float g, float b, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoChannels(graphic, graphic.gameObject, 1, 2, g, b, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        /// <summary>
		/// Tweens graphic's green and alpha channel value.
		/// </summary>
		/// <param name="graphic">Canvas group.</param>
		/// <param name="g">Target green channel.</param>
		/// <param name="a">Target alpha channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Vector2, TweakVector2> DoColorGA(this Graphic graphic, float g, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoChannels(graphic, graphic.gameObject, 1, 3, g, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

		/// <summary>
		/// Tweens graphic's blue and alpha channel value.
		/// </summary>
		/// <param name="graphic">Canvas group.</param>
		/// <param name="b">Target blue channel.</param>
		/// <param name="a">Target alpha channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Vector2, TweakVector2> DoColorBA(this Graphic graphic, float b, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoChannels(graphic, graphic.gameObject, 2, 3, b, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoColorThreeAxes
        private static Tween<Vector3, TweakVector3> DoColorThreeChannels(Graphic graphic, GameObject owner, int channel1, int channel2, int channel3, float value1, float value2, float value3, float duration, Ease ease, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            return Tween.Vector3(graphic.color.Get(channel1, channel2, channel3), new Vector3(value1, value2, value3), c => graphic.color = graphic.color.With(channel1, c.x, channel2, c.y, channel3, c.z), duration, ease, loopsCount, loopType, direction).SetOwner(owner).SetName(owner.name);
        }

		/// <summary>
		/// Tweens graphic's red, green and blue channel value.
		/// </summary>
		/// <param name="graphic">Canvas group.</param>
		/// <param name="r">Target red channel.</param>
		/// <param name="g">Target green channel.</param>
		/// <param name="b">Target blue channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Vector3, TweakVector3> DoColorRGB(this Graphic graphic, float r, float g, float b, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeChannels(graphic, graphic.gameObject, 0, 1, 2, r, g, b, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

		/// <summary>
		/// Tweens graphic's red, green and alpha channel value.
		/// </summary>
		/// <param name="graphic">Canvas group.</param>
		/// <param name="r">Target red channel.</param>
		/// <param name="g">Target green channel.</param>
		/// <param name="a">Target alpha channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Vector3, TweakVector3> DoColorRGA(this Graphic graphic, float r, float g, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeChannels(graphic, graphic.gameObject, 0, 1, 3, r, g, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

		/// <summary>
		/// Tweens graphic's red, blue and alpha channel value.
		/// </summary>
		/// <param name="graphic">Canvas group.</param>
		/// <param name="r">Target red channel.</param>
		/// <param name="b">Target blue channel.</param>
		/// <param name="a">Target alpha channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Vector3, TweakVector3> DoColorRBA(this Graphic graphic, float r, float b, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeChannels(graphic, graphic.gameObject, 0, 2, 3, r, b, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

		/// <summary>
		/// Tweens graphic's green, blue and alpha channel value.
		/// </summary>
		/// <param name="graphic">Canvas group.</param>
		/// <param name="g">Target green channel.</param>
		/// <param name="b">Target blue channel.</param>
		/// <param name="a">Target alpha channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Vector3, TweakVector3> DoColorGBA(this Graphic graphic, float g, float b, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeChannels(graphic, graphic.gameObject, 1, 2, 3, g, b, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }
		#endregion

		/// <summary>
		/// Tweens graphic's red, green, blue and alpha channel value.
		/// </summary>
		/// <param name="graphic">Canvas group.</param>
		/// <param name="r">Target red channel.</param>
		/// <param name="g">Target green channel.</param>
		/// <param name="b">Target blue channel.</param>
		/// <param name="a">Target alpha channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Color, TweakColor> DoColor(this Graphic graphic, float r, float g, float b, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColor(graphic, new Color(r, g, b, a), duration, ease, loopsCount, loopType, direction);
        }

		/// <summary>
		/// Tweens graphic's color.
		/// </summary>
		/// <param name="graphic">Canvas group.</param>
		/// <param name="color">Target color.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Color, TweakColor> DoColor(this Graphic graphic, Color color, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Color(graphic.color, color, c => graphic.color = color, duration, ease, loopsCount, loopType, direction).SetOwner(graphic).SetName(graphic.name);
        }
        #endregion
    }
}