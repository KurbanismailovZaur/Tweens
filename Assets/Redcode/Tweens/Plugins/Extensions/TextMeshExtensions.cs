using Redcode.Tweens.Tweaks;
using UnityEngine;
using Redcode.Extensions;

namespace Redcode.Tweens
{
    public static class TextMeshExtensions
	{
        /// <summary>
		/// Tweens text's font size.
		/// </summary>
		/// <param name="text">Target sprite.</param>
		/// <param name="size">Target font size.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<float, TweakFloat> DoCharacterSize(this TextMesh text, float size, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(text.characterSize, size, s => text.characterSize = s, duration, ease, loopsCount, loopType, direction).SetOwner(text).SetName(text.name);
        }

        /// <summary>
		/// Tweens text's line spacing.
		/// </summary>
		/// <param name="text">Target sprite.</param>
		/// <param name="spacing">Target line spacing.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<float, TweakFloat> DoLineSpacing(this TextMesh text, float spacing, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(text.lineSpacing, spacing, ls => text.lineSpacing = ls, duration, ease, loopsCount, loopType, direction).SetOwner(text).SetName(text.name);
        }

        /// <summary>
		/// Tweens text's font size.
		/// </summary>
		/// <param name="text">Target sprite.</param>
		/// <param name="size">Target font size.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<int, TweakInt> DoFontSize(this TextMesh text, int size, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Int(text.fontSize, size, fs => text.fontSize = fs, duration, ease, loopsCount, loopType, direction).SetOwner(text).SetName(text.name);
        }

        #region DoColor
        #region DoColorOneAxis
        private static Tween<float, TweakFloat> DoColorOneAxis(TextMesh text, GameObject owner, int axis, float color, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(text.color[axis], color, c => text.color = text.color.With(axis, c), duration, ease, loopsCount, loopType, direction).SetOwner(owner).SetName(owner.name);
        }

        /// <summary>
		/// Tweens text's color red channel.
		/// </summary>
		/// <param name="text">Target sprite.</param>
		/// <param name="r">Target red channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<float, TweakFloat> DoColorR(this TextMesh text, float r, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(text, text.gameObject, 0, r, duration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
		/// Tweens text's color green channel.
		/// </summary>
		/// <param name="text">Target sprite.</param>
		/// <param name="g">Target green channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<float, TweakFloat> DoColorG(this TextMesh text, float g, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(text, text.gameObject, 1, g, duration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
		/// Tweens text's color blue channel.
		/// </summary>
		/// <param name="text">Target sprite.</param>
		/// <param name="b">Target blue channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<float, TweakFloat> DoColorB(this TextMesh text, float b, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(text, text.gameObject, 2, b, duration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
		/// Tweens text's color alpha channel.
		/// </summary>
		/// <param name="text">Target sprite.</param>
		/// <param name="a">Target alpha channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<float, TweakFloat> DoColorA(this TextMesh text, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(text, text.gameObject, 3, a, duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoColorTwoAxes
        private static Tween<Vector2, TweakVector2> DoColorTwoChannels(TextMesh text, GameObject owner, int channel1, int channel2, float value1, float value2, float duration, Ease ease, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            return Tween.Vector2(text.color.Get(channel1, channel2), new Vector2(value1, value2), c => text.color = text.color.With(channel1, c.x, channel2, c.y), duration, ease, loopsCount, loopType, direction).SetOwner(owner).SetName(owner.name);
        }

        /// <summary>
		/// Tweens text's color red and green channels.
		/// </summary>
		/// <param name="text">Target sprite.</param>
		/// <param name="r">Target red channel.</param>
		/// <param name="g">Target green channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Vector2, TweakVector2> DoColorRG(this TextMesh text, float r, float g, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoChannels(text, text.gameObject, 0, 1, r, g, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

		/// <summary>
		/// Tweens text's color red and blue channels.
		/// </summary>
		/// <param name="text">Target sprite.</param>
		/// <param name="r">Target red channel.</param>
		/// <param name="b">Target blue channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Vector2, TweakVector2> DoColorRB(this TextMesh text, float r, float b, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoChannels(text, text.gameObject, 0, 2, r, b, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

		/// <summary>
		/// Tweens text's color red and alpha channels.
		/// </summary>
		/// <param name="text">Target sprite.</param>
		/// <param name="r">Target red channel.</param>
		/// <param name="a">Target alpha channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Vector2, TweakVector2> DoColorRA(this TextMesh text, float r, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoChannels(text, text.gameObject, 0, 3, r, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

		/// <summary>
		/// Tweens text's color green and blue channels.
		/// </summary>
		/// <param name="text">Target sprite.</param>
		/// <param name="g">Target green channel.</param>
		/// <param name="b">Target blue channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Vector2, TweakVector2> DoColorGB(this TextMesh text, float g, float b, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoChannels(text, text.gameObject, 1, 2, g, b, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

		/// <summary>
		/// Tweens text's color green and alpha channels.
		/// </summary>
		/// <param name="text">Target sprite.</param>
		/// <param name="g">Target green channel.</param>
		/// <param name="a">Target alpha channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Vector2, TweakVector2> DoColorGA(this TextMesh text, float g, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoChannels(text, text.gameObject, 1, 3, g, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

		/// <summary>
		/// Tweens text's color blue and alpha channels.
		/// </summary>
		/// <param name="text">Target sprite.</param>
		/// <param name="b">Target blue channel.</param>
		/// <param name="a">Target alpha channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Vector2, TweakVector2> DoColorBA(this TextMesh text, float b, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoChannels(text, text.gameObject, 2, 3, b, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoColorThreeAxes
        private static Tween<Vector3, TweakVector3> DoColorThreeChannels(TextMesh text, GameObject owner, int channel1, int channel2, int channel3, float value1, float value2, float value3, float duration, Ease ease, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            return Tween.Vector3(text.color.Get(channel1, channel2, channel3), new Vector3(value1, value2, value2), c => text.color = text.color.With(channel1, c.x, channel2, c.y, channel3, c.z), duration, ease, loopsCount, loopType, direction).SetOwner(owner).SetName(owner.name);
        }

		/// <summary>
		/// Tweens text's color red, green and blue channels.
		/// </summary>
		/// <param name="text">Target sprite.</param>
		/// <param name="r">Target red channel.</param>
		/// <param name="g">Target green channel.</param>
		/// <param name="b">Target blue channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Vector3, TweakVector3> DoColorRGB(this TextMesh text, float r, float g, float b, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeChannels(text, text.gameObject, 0, 1, 2, r, g, b, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

		/// <summary>
		/// Tweens text's color red, green and alpha channels.
		/// </summary>
		/// <param name="text">Target sprite.</param>
		/// <param name="r">Target red channel.</param>
		/// <param name="g">Target green channel.</param>
		/// <param name="a">Target alpha channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Vector3, TweakVector3> DoColorRGA(this TextMesh text, float r, float g, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeChannels(text, text.gameObject, 0, 1, 3, r, g, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

		/// <summary>
		/// Tweens text's color red, blue and alpha channels.
		/// </summary>
		/// <param name="text">Target sprite.</param>
		/// <param name="r">Target red channel.</param>
		/// <param name="b">Target blue channel.</param>
		/// <param name="a">Target alpha channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Vector3, TweakVector3> DoColorRBA(this TextMesh text, float r, float b, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeChannels(text, text.gameObject, 0, 2, 3, r, b, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

		/// <summary>
		/// Tweens text's color green, blue and alpha channels.
		/// </summary>
		/// <param name="text">Target sprite.</param>
		/// <param name="g">Target green channel.</param>
		/// <param name="b">Target blue channel.</param>
		/// <param name="a">Target alpha channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Vector3, TweakVector3> DoColorGBA(this TextMesh text, float g, float b, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeChannels(text, text.gameObject, 1, 2, 3, g, b, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }
		#endregion

		/// <summary>
		/// Tweens text's color red, green, blue and alpha channels.
		/// </summary>
		/// <param name="text">Target sprite.</param>
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
		public static Tween<Color, TweakColor> DoColor(this TextMesh text, float r, float g, float b, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColor(text, new Color(r, g, b, a), duration, ease, loopsCount, loopType, direction);
        }

		/// <summary>
		/// Tweens text's color.
		/// </summary>
		/// <param name="text">Target sprite.</param>
		/// <param name="color">Target color.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Color, TweakColor> DoColor(this TextMesh text, Color color, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Color(text.color, color, c => text.color = color, duration, ease, loopsCount, loopType, direction).SetOwner(text).SetName(text.name);
        }
        #endregion
    }
}