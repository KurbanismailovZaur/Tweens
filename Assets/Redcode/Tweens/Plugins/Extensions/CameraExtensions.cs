using Redcode.Tweens.Tweaks;
using UnityEngine;
using Redcode.Extensions;

namespace Redcode.Tweens
{
    public static class CameraExtensions
    {
        /// <summary>
		/// Tweens camera's aspect.
		/// </summary>
		/// <param name="camera">Target camera.</param>
		/// <param name="aspect">Target aspect.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<float, TweakFloat> DoAspect(this Camera camera, float aspect, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(camera.aspect, aspect, a => camera.aspect = a, duration, ease, loopsCount, loopType, direction).SetOwner(camera).SetName(camera.name);
        }

        #region DoBackgroundColor
        #region DoBackgroundColorOneAxis
        private static Tween<float, TweakFloat> DoBackgroundColorOneAxis(Camera camera, GameObject owner, int axis, float color, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(camera.backgroundColor[axis], color, c => camera.backgroundColor = camera.backgroundColor.With(axis, c), duration, ease, loopsCount, loopType, direction).SetOwner(owner).SetName(owner.name);
        }

        /// <summary>
		/// Tweens camera's background red channel.
		/// </summary>
		/// <param name="camera">Target camera.</param>
		/// <param name="r">Target red channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<float, TweakFloat> DoBackgroundColorR(this Camera camera, float r, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorOneAxis(camera, camera.gameObject, 0, r, duration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
		/// Tweens camera's background green channel.
		/// </summary>
		/// <param name="camera">Target camera.</param>
		/// <param name="g">Target green channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<float, TweakFloat> DoBackgroundColorG(this Camera camera, float g, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorOneAxis(camera, camera.gameObject, 1, g, duration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
		/// Tweens camera's background blue channel.
		/// </summary>
		/// <param name="camera">Target camera.</param>
		/// <param name="b">Target blue channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<float, TweakFloat> DoBackgroundColorB(this Camera camera, float b, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorOneAxis(camera, camera.gameObject, 2, b, duration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
		/// Tweens camera's background alpha channel.
		/// </summary>
		/// <param name="camera">Target camera.</param>
		/// <param name="a">Target alpha channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<float, TweakFloat> DoBackgroundColorA(this Camera camera, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorOneAxis(camera, camera.gameObject, 3, a, duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoBackgroundColorTwoAxes
        private static Tween<Vector2, TweakVector2> DoBackgroundColorTwoChannels(Camera camera, GameObject owner, int channel1, int channel2, float value1, float value2, float duration, Ease ease, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            return Tween.Vector2(camera.backgroundColor.Get(channel1, channel2), new Vector2(value1, value2), c => camera.backgroundColor = camera.backgroundColor.With(channel1, c.x, channel2, c.y), duration, ease, loopsCount, loopType, direction).SetOwner(owner).SetName(owner.name);
        }

        /// <summary>
		/// Tweens camera's background red and green channels.
		/// </summary>
		/// <param name="camera">Target camera.</param>
		/// <param name="r">Target red channel.</param>
		/// <param name="g">Target green channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Vector2, TweakVector2> DoBackgroundColorRG(this Camera camera, float r, float g, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorTwoChannels(camera, camera.gameObject, 0, 1, r, g, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        /// <summary>
		/// Tweens camera's background red and blue channels.
		/// </summary>
		/// <param name="camera">Target camera.</param>
		/// <param name="r">Target red channel.</param>
		/// <param name="b">Target blue channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Vector2, TweakVector2> DoBackgroundColorRB(this Camera camera, float r, float b, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorTwoChannels(camera, camera.gameObject, 0, 2, r, b, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        /// <summary>
		/// Tweens camera's background red and alpha channels.
		/// </summary>
		/// <param name="camera">Target camera.</param>
		/// <param name="r">Target red channel.</param>
		/// <param name="a">Target alpha channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Vector2, TweakVector2> DoBackgroundColorRA(this Camera camera, float r, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorTwoChannels(camera, camera.gameObject, 0, 3, r, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        /// <summary>
		/// Tweens camera's background green and blue channels.
		/// </summary>
		/// <param name="camera">Target camera.</param>
		/// <param name="g">Target green channel.</param>
		/// <param name="b">Target blue channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Vector2, TweakVector2> DoBackgroundColorGB(this Camera camera, float g, float b, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorTwoChannels(camera, camera.gameObject, 1, 2, g, b, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        /// <summary>
		/// Tweens camera's background green and alpha channels.
		/// </summary>
		/// <param name="camera">Target camera.</param>
		/// <param name="g">Target green channel.</param>
		/// <param name="a">Target alpha channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Vector2, TweakVector2> DoBackgroundColorGA(this Camera camera, float g, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorTwoChannels(camera, camera.gameObject, 1, 3, g, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        /// <summary>
		/// Tweens camera's background blue and alpha channels.
		/// </summary>
		/// <param name="camera">Target camera.</param>
		/// <param name="b">Target blue channel.</param>
		/// <param name="a">Target alpha channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Vector2, TweakVector2> DoBackgroundColorBA(this Camera camera, float b, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorTwoChannels(camera, camera.gameObject, 2, 3, b, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoBackgroundColorThreeAxes
        private static Tween<Vector3, TweakVector3> DoBackgroundColorThreeChannels(Camera camera, GameObject owner, int channel1, int channel2, int channel3, float value1, float value2, float value3, float duration, Ease ease, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            return Tween.Vector3(camera.backgroundColor.Get(channel1, channel2, channel3), new Vector3(value1, value2, value3), c => camera.backgroundColor = camera.backgroundColor.With(channel1, c.x, channel2, c.y, channel3, c.z), duration, ease, loopsCount, loopType, direction).SetOwner(owner).SetName(owner.name);
        }

        /// <summary>
		/// Tweens camera's background red, green and blue channels.
		/// </summary>
		/// <param name="camera">Target camera.</param>
		/// <param name="g">Target green channel.</param>
		/// <param name="b">Target blue channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Vector3, TweakVector3> DoBackgroundColorRGB(this Camera camera, float r, float g, float b, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorThreeChannels(camera, camera.gameObject, 0, 1, 2, r, g, b, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        /// <summary>
		/// Tweens camera's background red, green and alpha channels.
		/// </summary>
		/// <param name="camera">Target camera.</param>
		/// <param name="r">Target red channel.</param>
		/// <param name="g">Target green channel.</param>
		/// <param name="a">Target alpha channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Vector3, TweakVector3> DoBackgroundColorRGA(this Camera camera, float r, float g, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorThreeChannels(camera, camera.gameObject, 0, 1, 3, r, g, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        /// <summary>
		/// Tweens camera's background red, blue and alpha channels.
		/// </summary>
		/// <param name="camera">Target camera.</param>
		/// <param name="r">Target red channel.</param>
		/// <param name="b">Target blue channel.</param>
		/// <param name="a">Target alpha channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Vector3, TweakVector3> DoBackgroundColorRBA(this Camera camera, float r, float b, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorThreeChannels(camera, camera.gameObject, 0, 2, 3, r, b, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        /// <summary>
		/// Tweens camera's background red, blue and alpha channels.
		/// </summary>
		/// <param name="camera">Target camera.</param>
		/// <param name="g">Target green channel.</param>
		/// <param name="b">Target blue channel.</param>
		/// <param name="a">Target alpha channel.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Vector3, TweakVector3> DoBackgroundColorGBA(this Camera camera, float g, float b, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorThreeChannels(camera, camera.gameObject, 1, 2, 3, g, b, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        /// <summary>
		/// Tweens camera's background red, blue and alpha channels.
		/// </summary>
		/// <param name="camera">Target camera.</param>
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
        public static Tween<Color, TweakColor> DoBackgroundColor(this Camera camera, float r, float g, float b, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoBackgroundColor(camera, new Color(r, g, b, a), duration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
		/// Tweens camera's background color.
		/// </summary>
		/// <param name="camera">Target camera.</param>
		/// <param name="color">Target color.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Color, TweakColor> DoBackgroundColor(this Camera camera, Color color, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Color(camera.backgroundColor, color, c => camera.backgroundColor = color, duration, ease, loopsCount, loopType, direction).SetOwner(camera).SetName(camera.name);
        }
        #endregion

        /// <summary>
		/// Tweens camera's far clip plane.
		/// </summary>
		/// <param name="camera">Target camera.</param>
		/// <param name="distance">Target far clip plane.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<float, TweakFloat> DoFarClipPlane(this Camera camera, float distance, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(camera.farClipPlane, distance, d => camera.farClipPlane = d, duration, ease, loopsCount, loopType, direction).SetOwner(camera).SetName(camera.name);
        }

        /// <summary>
		/// Tweens camera's near clip plane.
		/// </summary>
		/// <param name="camera">Target camera.</param>
		/// <param name="distance">Target near clip plane.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<float, TweakFloat> DoNearClipPlane(this Camera camera, float distance, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(camera.nearClipPlane, distance, d => camera.nearClipPlane = d, duration, ease, loopsCount, loopType, direction).SetOwner(camera).SetName(camera.name);
        }

        /// <summary>
		/// Tweens camera's field of view.
		/// </summary>
		/// <param name="camera">Target camera.</param>
		/// <param name="fov">Target field of view.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<float, TweakFloat> DoFieldOfView(this Camera camera, float fov, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(camera.fieldOfView, fov, f => camera.fieldOfView = f, duration, ease, loopsCount, loopType, direction).SetOwner(camera).SetName(camera.name);
        }

        /// <summary>
		/// Tweens camera's focal length.
		/// </summary>
		/// <param name="camera">Target camera.</param>
		/// <param name="focalLength">Target focal length.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<float, TweakFloat> DoFocalLength(this Camera camera, float focalLength, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(camera.focalLength, focalLength, fl => camera.focalLength = fl, duration, ease, loopsCount, loopType, direction).SetOwner(camera).SetName(camera.name);
        }

        private static Tween<float, TweakFloat> DoLensShiftOneAxis(Camera camera, GameObject owner, int axis, float shift, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(camera.lensShift[axis], shift, ls => camera.lensShift = camera.lensShift.With(axis, ls), duration, ease, loopsCount, loopType, direction).SetOwner(owner).SetName(owner.name);
        }

        #region DoLensShiftOneAxis
        /// <summary>
		/// Tweens camera's lens shift x value.
		/// </summary>
		/// <param name="camera">Target camera.</param>
		/// <param name="x">Target lens shift x value.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<float, TweakFloat> DoLensShiftX(this Camera camera, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLensShiftOneAxis(camera, camera.gameObject, 0, x, duration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
		/// Tweens camera's lens shift y value.
		/// </summary>
		/// <param name="camera">Target camera.</param>
		/// <param name="y">Target lens shift y value.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<float, TweakFloat> DoLensShiftY(this Camera camera, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLensShiftOneAxis(camera, camera.gameObject, 1, y, duration, ease, loopsCount, loopType, direction);
        }
		#endregion

		#region DoLensShift
		/// <summary>
		/// Tweens camera's lens shift x and y value.
		/// </summary>
		/// <param name="camera">Target camera.</param>
		/// <param name="x">Target lens shift x value.</param>
		/// <param name="y">Target lens shift y value.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Vector2, TweakVector2> DoLensShift(this Camera camera, float x, float y, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoLensShift(camera, new Vector2(x, y), duration, ease, loopsCount, loopType, direction);
        }

		/// <summary>
		/// Tweens camera's lens shift.
		/// </summary>
		/// <param name="camera">Target camera.</param>
		/// <param name="shift">Target lens shift.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Vector2, TweakVector2> DoLensShift(this Camera camera, Vector2 shift, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Vector2(camera.lensShift, shift, ls => camera.lensShift = ls, duration, ease, loopsCount, loopType, direction).SetOwner(camera).SetName(camera.name);
        }
		#endregion

		/// <summary>
		/// Tweens camera's orthographic size.
		/// </summary>
		/// <param name="camera">Target camera.</param>
		/// <param name="size">Target orthographic size.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<float, TweakFloat> DoOrthographicSize(this Camera camera, float size, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(camera.orthographicSize, size, s => camera.orthographicSize = s, duration, ease, loopsCount, loopType, direction).SetOwner(camera).SetName(camera.name);
        }

		/// <summary>
		/// Tweens camera's pixel rect.
		/// </summary>
		/// <param name="camera">Target camera.</param>
		/// <param name="rect">Target pixel rect.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Rect, TweakRect> DoPixelRect(this Camera camera, Rect rect, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Rect(camera.pixelRect, rect, r => camera.pixelRect = r, duration, ease, loopsCount, loopType, direction).SetOwner(camera).SetName(camera.name);
        }

		/// <summary>
		/// Tweens camera's projection matrix.
		/// </summary>
		/// <param name="camera">Target camera.</param>
		/// <param name="matrix">Target projection matrix.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Matrix4x4, TweakMatrix4x4> DoProjectionMatrix(this Camera camera, Matrix4x4 matrix, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Matrix4x4(camera.projectionMatrix, matrix, m => camera.projectionMatrix = m, duration, ease, loopsCount, loopType, direction).SetOwner(camera).SetName(camera.name);
        }

		/// <summary>
		/// Tweens camera's rect.
		/// </summary>
		/// <param name="camera">Target camera.</param>
		/// <param name="rect">Target rect.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Rect, TweakRect> DoRect(this Camera camera, Rect rect, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Rect(camera.rect, rect, r => camera.rect = r, duration, ease, loopsCount, loopType, direction).SetOwner(camera).SetName(camera.name);
        }

        private static Tween<float, TweakFloat> DoSensorSizeOneAxis(this Camera camera, GameObject owner, int axis, float size, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(camera.sensorSize[axis], size, ss => camera.sensorSize = camera.sensorSize.With(axis, ss), duration, ease, loopsCount, loopType, direction).SetOwner(owner).SetName(owner.name);
        }

		#region DoSensorSizeOneAxis
		/// <summary>
		/// Tweens camera's sensor size x value.
		/// </summary>
		/// <param name="camera">Target camera.</param>
		/// <param name="x">Target sensor size x value.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<float, TweakFloat> DoSensorSizeX(this Camera camera, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoSensorSizeOneAxis(camera, camera.gameObject, 0, x, duration, ease, loopsCount, loopType, direction);
        }

		/// <summary>
		/// Tweens camera's sensor size y value.
		/// </summary>
		/// <param name="camera">Target camera.</param>
		/// <param name="y">Target sensor size y value.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<float, TweakFloat> DoSensorSizeY(this Camera camera, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoSensorSizeOneAxis(camera, camera.gameObject, 1, y, duration, ease, loopsCount, loopType, direction);
        }
		#endregion

		#region DoSensorSize
		/// <summary>
		/// Tweens camera's sensor size.
		/// </summary>
		/// <param name="camera">Target camera.</param>
		/// <param name="x">Target sensor size x value.</param>
		/// <param name="y">Target sensor size y value.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Vector2, TweakVector2> DoSensorSize(this Camera camera, float x, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoSensorSize(camera, new Vector2(x, y), duration, ease, loopsCount, loopType, direction);
        }

		/// <summary>
		/// Tweens camera's sensor size.
		/// </summary>
		/// <param name="camera">Target camera.</param>
		/// <param name="size">Target sensor size.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Vector2, TweakVector2> DoSensorSize(this Camera camera, Vector2 size, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Vector2(camera.sensorSize, size, s => camera.sensorSize = s, duration, ease, loopsCount, loopType, direction).SetOwner(camera).SetName(camera.name);
        }
		#endregion

		/// <summary>
		/// Tweens camera's stereo convengence.
		/// </summary>
		/// <param name="camera">Target camera.</param>
		/// <param name="convengence">Target stereo convengence.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<float, TweakFloat> DoStereoConvengence(this Camera camera, float convengence, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(camera.stereoConvergence, convengence, c => camera.stereoConvergence = c, duration, ease, loopsCount, loopType, direction).SetOwner(camera).SetName(camera.name);
        }

		/// <summary>
		/// Tweens camera's stereo separation.
		/// </summary>
		/// <param name="camera">Target camera.</param>
		/// <param name="separation">Target stereo separation.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<float, TweakFloat> DoStereoSeparation(this Camera camera, float separation, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(camera.stereoSeparation, separation, s => camera.stereoSeparation = s, duration, ease, loopsCount, loopType, direction).SetOwner(camera).SetName(camera.name);
        }

        #region DoTransparencySortAxisOneAxis
        private static Tween<float, TweakFloat> DoTransparencySortAxisOneAxis(Camera camera, GameObject owner, int axis, float value, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(camera.transparencySortAxis[axis], value, v => camera.transparencySortAxis.With(axis, v), duration, ease, loopsCount, loopType, direction).SetOwner(owner).SetName(owner.name);
        }

		/// <summary>
		/// Tweens camera's transparency sort axis x value.
		/// </summary>
		/// <param name="camera">Target camera.</param>
		/// <param name="x">Target transparency sort axis x value.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<float, TweakFloat> DoTransparencySortAxisX(this Camera camera, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoTransparencySortAxisOneAxis(camera, camera.gameObject, 0, x, duration, ease, loopsCount, loopType, direction);
        }

		/// <summary>
		/// Tweens camera's transparency sort axis y value.
		/// </summary>
		/// <param name="camera">Target camera.</param>
		/// <param name="y">Target transparency sort axis y value.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<float, TweakFloat> DoTransparencySortAxisY(this Camera camera, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoTransparencySortAxisOneAxis(camera, camera.gameObject, 1, y, duration, ease, loopsCount, loopType, direction);
        }

		/// <summary>
		/// Tweens camera's transparency sort axis z value.
		/// </summary>
		/// <param name="camera">Target camera.</param>
		/// <param name="z">Target transparency sort axis z value.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<float, TweakFloat> DoTransparencySortAxisZ(this Camera camera, float z, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoTransparencySortAxisOneAxis(camera, camera.gameObject, 2, z, duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoTransparencySortAxisTwoAxes
        private static Tween<Vector2, TweakVector2> DoTransparencySortAxisTwoAxes(Camera camera, GameObject owner, int axis1, int axis2, float value1, float value2, float duration, Ease ease, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            return Tween.Vector2(camera.transparencySortAxis.Get(axis1, axis2), new Vector2(value1, value2), c => camera.transparencySortAxis = camera.transparencySortAxis.With(axis1, c.x, axis2, c.y), duration, ease, loopsCount, loopType, direction).SetOwner(owner).SetName(owner.name);
        }

		/// <summary>
		/// Tweens camera's transparency sort axis x and y values.
		/// </summary>
		/// <param name="camera">Target camera.</param>
		/// <param name="x">Target transparency sort axis x value.</param>
		/// <param name="y">Target transparency sort axis y value.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Vector2, TweakVector2> DoTransparencySortAxisXY(this Camera camera, float x, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoTransparencySortAxisTwoAxes(camera, camera.gameObject, 0, 1, x, y, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

		/// <summary>
		/// Tweens camera's transparency sort axis x and z values.
		/// </summary>
		/// <param name="camera">Target camera.</param>
		/// <param name="x">Target transparency sort axis x value.</param>
		/// <param name="z">Target transparency sort axis z value.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Vector2, TweakVector2> DoTransparencySortAxisXZ(this Camera camera, float x, float z, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoTransparencySortAxisTwoAxes(camera, camera.gameObject, 0, 2, x, z, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

		/// <summary>
		/// Tweens camera's transparency sort axis x and y values.
		/// </summary>
		/// <param name="camera">Target camera.</param>
		/// <param name="y">Target transparency sort axis y value.</param>
		/// <param name="z">Target transparency sort axis z value.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Vector2, TweakVector2> DoTransparencySortAxisYZ(this Camera camera, float y, float z, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoTransparencySortAxisTwoAxes(camera, camera.gameObject, 1, 2, y, z, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }
		#endregion

		/// <summary>
		/// Tweens camera's transparency sort axis.
		/// </summary>
		/// <param name="camera">Target camera.</param>
		/// <param name="x">Target transparency sort axis x value.</param>
		/// <param name="y">Target transparency sort axis y value.</param>
		/// <param name="z">Target transparency sort axis z value.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Vector3, TweakVector3> DoTransparencySortAxis(this Camera camera, float x, float y, float z, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoTransparencySortAxis(camera, new Vector3(x, y, z), duration, ease, loopsCount, loopType, direction);
        }

		/// <summary>
		/// Tweens camera's transparency sort axis.
		/// </summary>
		/// <param name="camera">Target camera.</param>
		/// <param name="axis">Target transparency sort axis.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
		public static Tween<Vector3, TweakVector3> DoTransparencySortAxis(this Camera camera, Vector3 axis, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Vector3(camera.transparencySortAxis, axis, a => camera.transparencySortAxis = a, duration, ease, loopsCount, loopType, direction).SetOwner(camera).SetName(camera.name);
        }
    }
}