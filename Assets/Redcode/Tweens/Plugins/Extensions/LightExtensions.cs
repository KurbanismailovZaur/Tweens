using Redcode.Tweens.Tweaks;
using UnityEngine;
using Redcode.Extensions;

namespace Redcode.Tweens
{
    public static class LightExtensions
    {
        #region DoColorOneAxis
        private static Tween<float, TweakFloat> DoColorOneAxis(Light light, GameObject owner, int axis, float color, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(light.color[axis], color, c => light.color = light.color.With(axis, c), duration, ease, loopsCount, loopType, direction).SetOwner(owner).SetName(owner.name);
        }

        /// <summary>
		/// Tweens light's red channel.
		/// </summary>
		/// <param name="light">Target light.</param>
		/// <param name="r">Target red channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<float, TweakFloat> DoColorR(this Light light, float r, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(light, light.gameObject, 0, r, duration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
		/// Tweens light's green channel.
		/// </summary>
		/// <param name="light">Target light.</param>
		/// <param name="g">Target green channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<float, TweakFloat> DoColorG(this Light light, float g, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(light, light.gameObject, 1, g, duration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
		/// Tweens light's blue channel.
		/// </summary>
		/// <param name="light">Target light.</param>
		/// <param name="b">Target blue channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<float, TweakFloat> DoColorB(this Light light, float b, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(light, light.gameObject, 2, b, duration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
		/// Tweens light's alpha channel.
		/// </summary>
		/// <param name="light">Target light.</param>
		/// <param name="a">Target alpha channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<float, TweakFloat> DoColorA(this Light light, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(light, light.gameObject, 3, a, duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoColorTwoAxes
        private static Tween<Vector2, TweakVector2> DoColorTwoChannels(Light light, GameObject owner, int channel1, int channel2, float value1, float value2, float duration, Ease ease, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            return Tween.Vector2(light.color.Get(channel1, channel2), new Vector2(value1, value2), c => light.color = light.color.With(channel1, c.x, channel2, c.y), duration, ease, loopsCount, loopType, direction).SetOwner(owner).SetName(owner.name);
        }

        /// <summary>
		/// Tweens light's red and green channel.
		/// </summary>
		/// <param name="light">Target light.</param>
		/// <param name="r">Target red channel.</param>
		/// <param name="g">Target green channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Vector2, TweakVector2> DoColorRG(this Light light, float r, float g, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoChannels(light, light.gameObject, 0, 1, r, g, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        /// <summary>
		/// Tweens light's red and blue channel.
		/// </summary>
		/// <param name="light">Target light.</param>
		/// <param name="r">Target red channel.</param>
		/// <param name="b">Target blue channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Vector2, TweakVector2> DoColorRB(this Light light, float r, float b, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoChannels(light, light.gameObject, 0, 2, r, b, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        /// <summary>
		/// Tweens light's red and alpha channel.
		/// </summary>
		/// <param name="light">Target light.</param>
		/// <param name="r">Target red channel.</param>
		/// <param name="a">Target alpha channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Vector2, TweakVector2> DoColorRA(this Light light, float r, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoChannels(light, light.gameObject, 0, 3, r, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        /// <summary>
		/// Tweens light's green and blue channel.
		/// </summary>
		/// <param name="light">Target light.</param>
		/// <param name="g">Target green channel.</param>
		/// <param name="b">Target blue channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Vector2, TweakVector2> DoColorGB(this Light light, float g, float b, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoChannels(light, light.gameObject, 1, 2, g, b, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        /// <summary>
		/// Tweens light's green and alpha channel.
		/// </summary>
		/// <param name="light">Target light.</param>
		/// <param name="g">Target green channel.</param>
		/// <param name="a">Target alpha channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Vector2, TweakVector2> DoColorGA(this Light light, float g, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoChannels(light, light.gameObject, 1, 3, g, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        /// <summary>
		/// Tweens light's blue and alpha channel.
		/// </summary>
		/// <param name="light">Target light.</param>
		/// <param name="b">Target blue channel.</param>
		/// <param name="a">Target alpha channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Vector2, TweakVector2> DoColorBA(this Light light, float b, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoChannels(light, light.gameObject, 2, 3, b, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoColorThreeAxes
        private static Tween<Vector3, TweakVector3> DoColorThreeChannels(Light light, GameObject owner, int channel1, int channel2, int channel3, float value1, float value2, float value3, float duration, Ease ease, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            return Tween.Vector3(light.color.Get(channel1, channel2, channel3), new Vector3(value1, value2, value3), c => light.color = light.color.With(channel1, c.x, channel2, c.y, channel3, c.y), duration, ease, loopsCount, loopType, direction).SetOwner(owner).SetName(owner.name);
        }

        /// <summary>
		/// Tweens light's red, green and blue channel.
		/// </summary>
		/// <param name="light">Target light.</param>
		/// <param name="r">Target red channel.</param>
		/// <param name="g">Target green channel.</param>
		/// <param name="b">Target blue channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Vector3, TweakVector3> DoColorRGB(this Light light, float r, float g, float b, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeChannels(light, light.gameObject, 0, 1, 2, r, g, b, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

		/// <summary>
		/// Tweens light's red, green and alpha channel.
		/// </summary>
		/// <param name="light">Target light.</param>
		/// <param name="r">Target red channel.</param>
		/// <param name="g">Target green channel.</param>
		/// <param name="a">Target alpha channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Vector3, TweakVector3> DoColorRGA(this Light light, float r, float g, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeChannels(light, light.gameObject, 0, 1, 3, r, g, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

		/// <summary>
		/// Tweens light's red, blue and alphachannel.
		/// </summary>
		/// <param name="light">Target light.</param>
		/// <param name="r">Target red channel.</param>
		/// <param name="b">Target blue channel.</param>
		/// <param name="a">Target alpha channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Vector3, TweakVector3> DoColorRBA(this Light light, float r, float b, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeChannels(light, light.gameObject, 0, 2, 3, r, b, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

		/// <summary>
		/// Tweens light's green, blue and blue channel.
		/// </summary>
		/// <param name="light">Target light.</param>
		/// <param name="g">Target green channel.</param>
		/// <param name="b">Target blue channel.</param>
		/// <param name="a">Target alpha channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Vector3, TweakVector3> DoColorGBA(this Light light, float g, float b, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeChannels(light, light.gameObject, 1, 2, 3, g, b, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }
		#endregion

		#region DoColor
		/// <summary>
		/// Tweens light's color.
		/// </summary>
		/// <param name="light">Target light.</param>
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
		public static Tween<Color, TweakColor> DoColor(this Light light, float r, float g, float b, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColor(light, new Color(r, g, b, a), duration, ease, loopsCount, loopType, direction);
        }

		/// <summary>
		/// Tweens light's color.
		/// </summary>
		/// <param name="light">Target light.</param>
		/// <param name="color">Target color.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Color, TweakColor> DoColor(this Light light, Color color, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Color(light.color, color, c => light.color = color, duration, ease, loopsCount, loopType, direction).SetOwner(light).SetName(light.name);
        }
		#endregion

		/// <summary>
		/// Tweens light's color temperature.
		/// </summary>
		/// <param name="light">Target light.</param>
		/// <param name="temperature">Target color temperature.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<float, TweakFloat> DoColorTemperature(this Light light, float temperature, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(light.colorTemperature, temperature, t => light.colorTemperature = t, duration, ease, loopsCount, loopType, direction).SetOwner(light).SetName(light.name);
        }

		/// <summary>
		/// Tweens light's inner spot angle.
		/// </summary>
		/// <param name="light">Target light.</param>
		/// <param name="angle">Target inner spot angle.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<float, TweakFloat> DoInnerSpotAngle(this Light light, float angle, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(light.innerSpotAngle, angle, a => light.innerSpotAngle = a, duration, ease, loopsCount, loopType, direction).SetOwner(light).SetName(light.name);
        }

		/// <summary>
		/// Tweens light's spot angle.
		/// </summary>
		/// <param name="light">Target light.</param>
		/// <param name="angle">Target spot angle.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<float, TweakFloat> DoSpotAngle(this Light light, float angle, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(light.spotAngle, angle, a => light.spotAngle = a, duration, ease, loopsCount, loopType, direction).SetOwner(light).SetName(light.name);
        }

		/// <summary>
		/// Tweens light's intensity.
		/// </summary>
		/// <param name="light">Target light.</param>
		/// <param name="intensity">Target intensity.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<float, TweakFloat> DoIntensity(this Light light, float intensity, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(light.intensity, intensity, i => light.intensity = i, duration, ease, loopsCount, loopType, direction).SetOwner(light).SetName(light.name);
        }

		/// <summary>
		/// Tweens light's range.
		/// </summary>
		/// <param name="light">Target light.</param>
		/// <param name="range">Target range.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<float, TweakFloat> DoRange(this Light light, float range, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(light.range, range, r => light.range = r, duration, ease, loopsCount, loopType, direction).SetOwner(light).SetName(light.name);
        }
    }
}