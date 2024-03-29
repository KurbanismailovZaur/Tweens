using Redcode.Extensions;
using Redcode.Tweens.Tweaks;
using UnityEngine;

namespace Redcode.Tweens
{
    public static class MaterialExtensions
    {
        #region DoColor
        #region DoColorOneAxis
        private static Tween<float, TweakFloat> DoColorOneAxis(Material material, int axis, float color, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
			return Tween.Float(material.color[axis], color, c => material.color = material.color.With(axis, c), duration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
		/// Tweens material's red channel.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="r">Target red channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<float, TweakFloat> DoColorR(this Material material, float r, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(material, 0, r, duration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
		/// Tweens material's green channel.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="g">Target green channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<float, TweakFloat> DoColorG(this Material material, float g, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(material, 1, g, duration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
		/// Tweens material's blue channel.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="b">Target blue channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<float, TweakFloat> DoColorB(this Material material, float b, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(material, 2, b, duration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
		/// Tweens material's alpha channel.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="a">Target alpha channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<float, TweakFloat> DoColorA(this Material material, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(material, 3, a, duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoColorTwoAxes
        private static Tween<Vector2, TweakVector2> DoColorTwoChannels(Material material, int channel1, int channel2, float value1, float value2, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
			return Tween.Vector2(material.color.Get(channel1, channel2), new Vector2(value1, value2), c => material.color = material.color.With(channel1, c.x, channel2, c.y), duration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
		/// Tweens material's red and green channel.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="r">Target red channel.</param>
		/// <param name="g">Target green channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Vector2, TweakVector2> DoColorRG(this Material material, float r, float g, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorTwoChannels(material, 0, 1, r, g, duration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
		/// Tweens material's red and blue channel.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="r">Target red channel.</param>
		/// <param name="b">Target blue channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Vector2, TweakVector2> DoColorRB(this Material material, float r, float b, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorTwoChannels(material, 0, 2, r, b, duration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
		/// Tweens material's red and alpha channel.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="r">Target red channel.</param>
		/// <param name="a">Target alpha channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Vector2, TweakVector2> DoColorRA(this Material material, float r, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorTwoChannels(material, 0, 3, r, a, duration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
		/// Tweens material's green and blue channel.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="g">Target green channel.</param>
		/// <param name="b">Target blue channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Vector2, TweakVector2> DoColorGB(this Material material, float g, float b, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorTwoChannels(material, 1, 2, g, b, duration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
		/// Tweens material's green and alpha channel.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="g">Target green channel.</param>
		/// <param name="a">Target alpha channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Vector2, TweakVector2> DoColorGA(this Material material, float g, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorTwoChannels(material, 1, 3, g, a, duration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
		/// Tweens material's blue and alpha channel.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="b">Target blue channel.</param>
		/// <param name="a">Target alpha channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Vector2, TweakVector2> DoColorBA(this Material material, float b, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorTwoChannels(material, 2, 3, b, a, duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoColorThreeAxes
        private static Tween<Vector3, TweakVector3> DoColorThreeChannels(Material material, int channel1, int channel2, int channel3, float value1, float value2, float value3, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Vector3(material.color.Get(channel1, channel2, channel3), new Vector3(value1, value2, value3), c => material.color = material.color.With(channel1, c.x, channel2, c.y, channel3, c.z), duration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
		/// Tweens material's red, green and blue channel.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="r">Target red channel.</param>
		/// <param name="g">Target green channel.</param>
		/// <param name="b">Target blue channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Vector3, TweakVector3> DoColorRGB(this Material material, float r, float g, float b, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorThreeChannels(material, 0, 1, 2, r, g, b, duration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
		/// Tweens material's red, green and alpha channel.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="r">Target red channel.</param>
		/// <param name="g">Target green channel.</param>
		/// <param name="a">Target alpha channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Vector3, TweakVector3> DoColorRGA(this Material material, float r, float g, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorThreeChannels(material, 0, 1, 3, r, g, a, duration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
		/// Tweens material's red, blue and alpha channel.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="r">Target red channel.</param>
		/// <param name="b">Target blue channel.</param>
		/// <param name="a">Target alpha channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Vector3, TweakVector3> DoColorRBA(this Material material, float r, float b, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorThreeChannels(material, 0, 2, 3, r, b, a, duration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
		/// Tweens material's green, blue and alpha channel.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="g">Target green channel.</param>
		/// <param name="b">Target blue channel.</param>
		/// <param name="a">Target alpha channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Vector3, TweakVector3> DoColorGBA(this Material material, float g, float b, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorThreeChannels(material, 1, 2, 3, g, b, a, duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoColor
        /// <summary>
		/// Tweens material's red, green, blue and alpha channel.
		/// </summary>
		/// <param name="material">Target material.</param>
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
        public static Tween<Color, TweakColor> DoColor(this Material material, float r, float g, float b, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColor(material, new Color(r, g, b, a), duration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
		/// Tweens material's color.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="color">Target color.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Color, TweakColor> DoColor(this Material material, Color color, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Color(material.color, color, c => material.color = c, duration, ease, loopsCount, loopType, direction);
        }
        #endregion
        #endregion

        #region DoMainTextureOffset
        /// <summary>
		/// Tweens material's main texture offset x.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="x">Target main texture offset x.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<float, TweakFloat> DoMainTextureOffsetX(this Material material, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(material.mainTextureOffset.x, x, ox => material.mainTextureOffset = material.mainTextureOffset.WithX(ox), duration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
		/// Tweens material's main texture offset y.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="y">Target main texture offset y.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<float, TweakFloat> DoMainTextureOffsetY(this Material material, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(material.mainTextureOffset.y, y, oy => material.mainTextureOffset = material.mainTextureOffset.WithY(oy), duration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
		/// Tweens material's main texture offset.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="x">Target main texture offset x.</param>
		/// <param name="y">Target main texture offset y.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Vector2, TweakVector2> DoMainTextureOffset(this Material material, float x, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoMainTextureOffset(material, new Vector2(x, y), duration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
		/// Tweens material's main texture offset.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="offset">Target main texture offset.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Vector2, TweakVector2> DoMainTextureOffset(this Material material, Vector2 offset, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Vector2(material.mainTextureOffset, offset, o => material.mainTextureOffset = o, duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoMainTextureScale
        /// <summary>
		/// Tweens material's main texture scale x.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="x">Target main texture scale x.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<float, TweakFloat> DoMainTextureScaleX(this Material material, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(material.mainTextureScale.x, x, ox => material.mainTextureScale = material.mainTextureScale.WithX(ox), duration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
		/// Tweens material's main texture scale y.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="y">Target main texture scale y.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<float, TweakFloat> DoMainTextureScaleY(this Material material, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(material.mainTextureScale.y, y, oy => material.mainTextureScale = material.mainTextureScale.WithY(oy), duration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
		/// Tweens material's main texture scale.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="x">Target main texture scale x.</param>
		/// <param name="y">Target main texture scale y.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Vector2, TweakVector2> DoMainTextureScale(this Material material, float x, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoMainTextureScale(material, new Vector2(x, y), duration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
		/// Tweens material's main texture scale.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="scale">Target main texture scale.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Vector2, TweakVector2> DoMainTextureScale(this Material material, Vector2 scale, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Vector2(material.mainTextureScale, scale, s => material.mainTextureScale = s, duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoColorProperty
        #region DoColorPropertyOneAxis
        private static Tween<float, TweakFloat> DoColorPropertyOneChannel(Material material, string property, int channel, float value, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(material.GetColor(property)[channel], value, c => material.SetColor(property, material.GetColor(property).With(channel, c)), duration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
		/// Tweens material's color property red channel.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="property">Target material's property.</param>
		/// <param name="r">Target red channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<float, TweakFloat> DoColorPropertyR(this Material material, string property, float r, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorPropertyOneChannel(material, property, 0, r, duration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
		/// Tweens material's color property green channel.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="property">Target material's property.</param>
		/// <param name="g">Target green channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<float, TweakFloat> DoColorPropertyG(this Material material, string property, float g, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorPropertyOneChannel(material, property, 1, g, duration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
		/// Tweens material's color property blue channel.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="property">Target material's property.</param>
		/// <param name="b">Target blue channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<float, TweakFloat> DoColorPropertyB(this Material material, string property, float b, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorPropertyOneChannel(material, property, 2, b, duration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
		/// Tweens material's color property alpha channel.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="property">Target material's property.</param>
		/// <param name="a">Target alpha channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<float, TweakFloat> DoColorPropertyA(this Material material, string property, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorPropertyOneChannel(material, property, 3, a, duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoColorPropertyTwoAxes
        private static Tween<Vector2, TweakVector2> DoColorPropertyTwoChannels(Material material, string property, int channel1, int channel2, float value1, float value2, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Vector2(material.GetColor(property).Get(channel1, channel2), new Vector2(value1, value2), c => material.SetColor(property, material.GetColor(property).With(channel1, c.x, channel2, c.y)), duration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
		/// Tweens material's color property red and green channel.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="property">Target material's property.</param>
		/// <param name="r">Target red channel.</param>
		/// <param name="g">Target green channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Vector2, TweakVector2> DoColorPropertyRG(this Material material, string property, float r, float g, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorPropertyTwoChannels(material, property, 0, 1, r, g, duration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
		/// Tweens material's color property red and blue channel.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="property">Target material's property.</param>
		/// <param name="r">Target red channel.</param>
		/// <param name="b">Target blue channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Vector2, TweakVector2> DoColorPropertyRB(this Material material, string property, float r, float b, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorPropertyTwoChannels(material, property, 0, 2, r, b, duration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
		/// Tweens material's color property red and alpha channel.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="property">Target material's property.</param>
		/// <param name="r">Target red channel.</param>
		/// <param name="a">Target alpha channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Vector2, TweakVector2> DoColorPropertyRA(this Material material, string property, float r, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorPropertyTwoChannels(material, property, 0, 3, r, a, duration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
		/// Tweens material's color property green and blue channel.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="property">Target material's property.</param>
		/// <param name="g">Target green channel.</param>
		/// <param name="b">Target blue channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Vector2, TweakVector2> DoColorPropertyGB(this Material material, string property, float g, float b, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorPropertyTwoChannels(material, property, 1, 2, g, b, duration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
		/// Tweens material's color property green and alpha channel.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="property">Target material's property.</param>
		/// <param name="g">Target green channel.</param>
		/// <param name="a">Target alpha channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Vector2, TweakVector2> DoColorPropertyGA(this Material material, string property, float g, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorPropertyTwoChannels(material, property, 1, 3, g, a, duration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
		/// Tweens material's color property blue and alpha channel.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="property">Target material's property.</param>
		/// <param name="b">Target blue channel.</param>
		/// <param name="a">Target alpha channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Vector2, TweakVector2> DoColorPropertyBA(this Material material, string property, float b, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorPropertyTwoChannels(material, property, 2, 3, b, a, duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoColorPropertyThreeAxes
        private static Tween<Vector3, TweakVector3> DoColorPropertyThreeChannels(Material material, string property, int channel1, int channel2, int channel3, float value1, float value2, float value3, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Vector3(material.GetColor(property).Get(channel1, channel2, channel3), new Vector3(value1, value2, value3), c => material.SetColor(property, material.GetColor(property).With(channel1, c.x, channel2, c.y, channel3, c.z)), duration, ease, loopsCount, loopType, direction);
        }

		/// <summary>
		/// Tweens material's color property red, green and blue channel.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="property">Target material's property.</param>
		/// <param name="r">Target red channel.</param>
		/// <param name="g">Target green channel.</param>
		/// <param name="b">Target blue channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Vector3, TweakVector3> DoColorPropertyRGB(this Material material, string property, float r, float g, float b, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorPropertyThreeChannels(material, property, 0, 1, 2, r, g, b, duration, ease, loopsCount, loopType, direction);
        }

		/// <summary>
		/// Tweens material's color property red, green and alpha channel.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="property">Target material's property.</param>
		/// <param name="r">Target red channel.</param>
		/// <param name="g">Target green channel.</param>
		/// <param name="a">Target alpha channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Vector3, TweakVector3> DoColorPropertyRGA(this Material material, string property, float r, float g, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorPropertyThreeChannels(material, property, 0, 1, 3, r, g, a, duration, ease, loopsCount, loopType, direction);
        }

		/// <summary>
		/// Tweens material's color property red, blue and alpha channel.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="property">Target material's property.</param>
		/// <param name="r">Target red channel.</param>
		/// <param name="b">Target blue channel.</param>
		/// <param name="a">Target alpha channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Vector3, TweakVector3> DoColorPropertyRBA(this Material material, string property, float r, float b, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorPropertyThreeChannels(material, property, 0, 2, 3, r, b, a, duration, ease, loopsCount, loopType, direction);
        }

		/// <summary>
		/// Tweens material's color property green, blue and alpha channel.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="property">Target material's property.</param>
		/// <param name="g">Target green channel.</param>
		/// <param name="b">Target blue channel.</param>
		/// <param name="a">Target alpha channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Vector3, TweakVector3> DoColorPropertyGBA(this Material material, string property, float g, float b, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorPropertyThreeChannels(material, property, 1, 2, 3, g, b, a, duration, ease, loopsCount, loopType, direction);
        }
		#endregion

		#region DoColorProperty
		/// <summary>
		/// Tweens material's color property.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="property">Target material's property.</param>
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
		public static Tween<Color, TweakColor> DoColorProperty(this Material material, string property, float r, float g, float b, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorProperty(material, property, new Color(r, g, b, a), duration, ease, loopsCount, loopType, direction);
        }

		/// <summary>
		/// Tweens material's color property.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="property">Target material's property.</param>
		/// <param name="color">Target color.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Color, TweakColor> DoColorProperty(this Material material, string property, Color color, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Color(material.GetColor(property), color, c => material.SetColor(property, c), duration, ease, loopsCount, loopType, direction);
        }
		#endregion
		#endregion

		/// <summary>
		/// Tweens material's float property.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="property">Target material's property.</param>
		/// <param name="value">Target value.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<float, TweakFloat> DoFloatProperty(this Material material, string property, float value, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(material.GetFloat(property), value, v => material.SetFloat(property, v), duration, ease, loopsCount, loopType, direction);
        }

		/// <summary>
		/// Tweens material's int property.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="property">Target material's property.</param>
		/// <param name="value">Target value.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<int, TweakInt> DoIntProperty(this Material material, string property, int value, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Int(material.GetInt(property), value, v => material.SetInt(property, v), duration, ease, loopsCount, loopType, direction);
        }

		#region DoMainTextureOffsetProperty
		/// <summary>
		/// Tweens material's main texture offset x value.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="property">Target material's property.</param>
		/// <param name="x">Target main texture offset x value.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<float, TweakFloat> DoMainTextureOffsetPropertyX(this Material material, string property, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(material.GetTextureOffset(property).x, x, ox => material.SetTextureOffset(property, material.GetTextureOffset(property).WithX(ox)), duration, ease, loopsCount, loopType, direction);
        }

		/// <summary>
		/// Tweens material's main texture offset y value.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="property">Target material's property.</param>
		/// <param name="y">Target main texture offset y value.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<float, TweakFloat> DoMainTextureOffsetPropertyY(this Material material, string property, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(material.GetTextureOffset(property).y, y, oy => material.SetTextureOffset(property, material.GetTextureOffset(property).WithY(oy)), duration, ease, loopsCount, loopType, direction);
        }

		/// <summary>
		/// Tweens material's main texture offset.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="property">Target material's property.</param>
		/// <param name="x">Target main texture offset x value.</param>
		/// <param name="y">Target main texture offset y value.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Vector2, TweakVector2> DoMainTextureOffsetProperty(this Material material, string property, float x, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoMainTextureOffsetProperty(material, property, new Vector2(x, y), duration, ease, loopsCount, loopType, direction);
        }

		/// <summary>
		/// Tweens material's main texture offset.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="property">Target material's property.</param>
		/// <param name="offset">Target offset.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Vector2, TweakVector2> DoMainTextureOffsetProperty(this Material material, string property, Vector2 offset, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Vector2(material.GetTextureOffset(property), offset, o => material.SetTextureOffset(property, o), duration, ease, loopsCount, loopType, direction);
        }
		#endregion

		#region DoMainTextureScaleProperty
		/// <summary>
		/// Tweens material's main texture scale x value.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="property">Target material's property.</param>
		/// <param name="x">Target scale x value.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<float, TweakFloat> DoMainTextureScalePropertyX(this Material material, string property, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(material.GetTextureScale(property).x, x, ox => material.SetTextureScale(property, material.GetTextureScale(property).WithX(ox)), duration, ease, loopsCount, loopType, direction);
        }

		/// <summary>
		/// Tweens material's main texture scale x value.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="property">Target material's property.</param>
		/// <param name="y">Target scale y value.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<float, TweakFloat> DoMainTextureScalePropertyY(this Material material, string property, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(material.GetTextureScale(property).y, y, oy => material.SetTextureScale(property, material.GetTextureScale(property).WithY(oy)), duration, ease, loopsCount, loopType, direction);
        }

		/// <summary>
		/// Tweens material's main texture scale.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="property">Target material's property.</param>
		/// <param name="x">Target scale x value.</param>
		/// <param name="y">Target scale y value.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Vector2, TweakVector2> DoMainTextureScaleProperty(this Material material, string property, float x, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoMainTextureScaleProperty(material, property, new Vector2(x, y), duration, ease, loopsCount, loopType, direction);
        }

		/// <summary>
		/// Tweens material's main texture scale.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="property">Target material's property.</param>
		/// <param name="scale">Target scale.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Vector2, TweakVector2> DoMainTextureScaleProperty(this Material material, string property, Vector2 scale, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Vector2(material.GetTextureScale(property), scale, o => material.SetTextureScale(property, o), duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoVectorProperty
        #region DoVectorPropertyOneAxis
        private static Tween<float, TweakFloat> DoVectorPropertyOneAxis(Material material, string property, int axis, float value, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(material.GetVector(property)[axis], value, v => material.SetVector(property, material.GetVector(property).With(axis, v)), duration, ease, loopsCount, loopType, direction);
        }

		/// <summary>
		/// Tweens material's vector x value.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="property">Target material's property.</param>
		/// <param name="x">Target x value.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<float, TweakFloat> DoVectorPropertyX(this Material material, string property, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyOneAxis(material, property, 0, x, duration, ease, loopsCount, loopType, direction);
        }

		/// <summary>
		/// Tweens material's vector y value.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="property">Target material's property.</param>
		/// <param name="y">Target y value.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<float, TweakFloat> DoVectorPropertyY(this Material material, string property, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyOneAxis(material, property, 1, y, duration, ease, loopsCount, loopType, direction);
        }

		/// <summary>
		/// Tweens material's vector z value.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="property">Target material's property.</param>
		/// <param name="z">Target z value.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<float, TweakFloat> DoVectorPropertyZ(this Material material, string property, float z, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyOneAxis(material, property, 2, z, duration, ease, loopsCount, loopType, direction);
        }

		/// <summary>
		/// Tweens material's vector w value.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="property">Target material's property.</param>
		/// <param name="w">Target w value.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<float, TweakFloat> DoVectorPropertyW(this Material material, string property, float w, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyOneAxis(material, property, 3, w, duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoVectorPropertyTwoAxes
        private static Tween<Vector2, TweakVector2> DoVectorPropertyTwoAxes(Material material, string property, int axis1, int axis2, float value1, float value2, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Vector2(material.GetVector(property).With(axis1, axis2), new Vector2(value1, value2), v => material.SetVector(property, material.GetVector(property).With(axis1, v.x, axis2, v.y)), duration, ease, loopsCount, loopType, direction);
        }

		/// <summary>
		/// Tweens material's vector x and y values.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="property">Target material's property.</param>
		/// <param name="x">Target x value.</param>
		/// <param name="y">Target y value.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Vector2, TweakVector2> DoVectorPropertyXY(this Material material, string property, float x, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyTwoAxes(material, property, 0, 1, x, y, duration, ease, loopsCount, loopType, direction);
        }

		/// <summary>
		/// Tweens material's vector x and z values.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="property">Target material's property.</param>
		/// <param name="x">Target x value.</param>
		/// <param name="z">Target z value.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Vector2, TweakVector2> DoVectorPropertyXZ(this Material material, string property, float x, float z, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyTwoAxes(material, property, 0, 2, x, z, duration, ease, loopsCount, loopType, direction);
        }

		/// <summary>
		/// Tweens material's vector x and w values.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="property">Target material's property.</param>
		/// <param name="x">Target x value.</param>
		/// <param name="w">Target w value.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Vector2, TweakVector2> DoVectorPropertyXW(this Material material, string property, float x, float w, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyTwoAxes(material, property, 0, 3, x, w, duration, ease, loopsCount, loopType, direction);
        }

		/// <summary>
		/// Tweens material's vector y and z values.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="property">Target material's property.</param>
		/// <param name="y">Target y value.</param>
		/// <param name="z">Target z value.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Vector2, TweakVector2> DoVectorPropertyYZ(this Material material, string property, float y, float z, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyTwoAxes(material, property, 1, 2, y, z, duration, ease, loopsCount, loopType, direction);
        }

		/// <summary>
		/// Tweens material's vector y and w values.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="property">Target material's property.</param>
		/// <param name="y">Target y value.</param>
		/// <param name="w">Target w value.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Vector2, TweakVector2> DoVectorPropertyYW(this Material material, string property, float y, float w, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyTwoAxes(material, property, 1, 3, y, w, duration, ease, loopsCount, loopType, direction);
        }

		/// <summary>
		/// Tweens material's vector z and w values.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="property">Target material's property.</param>
		/// <param name="z">Target z value.</param>
		/// <param name="w">Target w value.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Vector2, TweakVector2> DoVectorPropertyZW(this Material material, string property, float z, float w, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyTwoAxes(material, property, 2, 3, z, w, duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoVectorPropertyThreeAxes
        private static Tween<Vector3, TweakVector3> DoVectorPropertyThreeAxes(Material material, string property, int axis1, int axis2, int axis3, float value1, float value2, float value3, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Vector3(material.GetVector(property).Get(axis1, axis2, axis3), new Vector3(value1, value2, value3), v => material.SetVector(property, material.GetVector(property).With(axis1, v.x, axis2, v.y, axis3, v.z)), duration, ease, loopsCount, loopType, direction);
        }

		/// <summary>
		/// Tweens material's vector x, y and z values.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="property">Target material's property.</param>
		/// <param name="x">Target x value.</param>
		/// <param name="y">Target y value.</param>
		/// <param name="z">Target z value.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Vector3, TweakVector3> DoVectorPropertyXYZ(this Material material, string property, float x, float y, float z, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyThreeAxes(material, property, 0, 1, 2, x, y, z, duration, ease, loopsCount, loopType, direction);
        }

		/// <summary>
		/// Tweens material's vector x, y and w values.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="property">Target material's property.</param>
		/// <param name="x">Target x value.</param>
		/// <param name="y">Target y value.</param>
		/// <param name="w">Target w value.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Vector3, TweakVector3> DoVectorPropertyXYW(this Material material, string property, float x, float y, float w, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyThreeAxes(material, property, 0, 1, 3, x, y, w, duration, ease, loopsCount, loopType, direction);
        }

		/// <summary>
		/// Tweens material's vector x, z and w values.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="property">Target material's property.</param>
		/// <param name="x">Target x value.</param>
		/// <param name="z">Target z value.</param>
		/// <param name="w">Target w value.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Vector3, TweakVector3> DoVectorPropertyXZW(this Material material, string property, float x, float z, float w, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyThreeAxes(material, property, 0, 2, 3, x, z, w, duration, ease, loopsCount, loopType, direction);
        }

		/// <summary>
		/// Tweens material's vector y, z and w values.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="property">Target material's property.</param>
		/// <param name="y">Target y value.</param>
		/// <param name="z">Target z value.</param>
		/// <param name="w">Target w value.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Vector3, TweakVector3> DoVectorPropertyYZW(this Material material, string property, float y, float z, float w, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyThreeAxes(material, property, 1, 2, 3, y, z, w, duration, ease, loopsCount, loopType, direction);
        }
		#endregion

		#region DoVectorProperty
		/// <summary>
		/// Tweens material's vector.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="property">Target material's property.</param>
		/// <param name="x">Target x value.</param>
		/// <param name="y">Target y value.</param>
		/// <param name="z">Target z value.</param>
		/// <param name="w">Target w value.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Vector4, TweakVector4> DoVectorProperty(this Material material, string property, float x, float y, float z, float w, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoVectorProperty(material, property, new Vector4(x, y, z, w), duration, ease, loopsCount, loopType, direction);
        }

		/// <summary>
		/// Tweens material's vector.
		/// </summary>
		/// <param name="material">Target material.</param>
		/// <param name="property">Target material's property.</param>
		/// <param name="vector">Target vector.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Vector4, TweakVector4> DoVectorProperty(this Material material, string property, Vector4 vector, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Vector4(material.GetVector(property), vector, c => material.SetVector(property, c), duration, ease, loopsCount, loopType, direction);
        }
        #endregion
        #endregion
    }
}