using Redcode.Tweens.Tweaks;
using UnityEngine;

namespace Redcode.Tweens
{
    public static class CameraExtensions
    {
        #region DoAspect
        public static Tween<float, TweakFloat> DoAspect(this Camera camera, float aspect, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAspect(camera, camera.gameObject, aspect, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoAspect(this Camera camera, GameObject owner, float aspect, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(owner, owner.name, camera.aspect, aspect, a => camera.aspect = a, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoBackgroundColor
        private static void SetBackgroundColor(this Camera camera, int axis, float color)
        {
            var backgroundColor = camera.backgroundColor;
            backgroundColor[axis] = color;
            camera.backgroundColor = backgroundColor;
        }

        #region DoBackgroundColorOneAxis
        private static Tween<float, TweakFloat> DoBackgroundColorOneAxis(Camera camera, GameObject owner, int axis, float color, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(owner, owner.name, camera.backgroundColor[axis], color, c => camera.SetBackgroundColor(axis, c), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoBackgroundColorR(this Camera camera, float r, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorOneAxis(camera, camera.gameObject, 0, r, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoBackgroundColorR(this Camera camera, GameObject owner, float r, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorOneAxis(camera, owner, 0, r, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoBackgroundColorG(this Camera camera, float g, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorOneAxis(camera, camera.gameObject, 1, g, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoBackgroundColorG(this Camera camera, GameObject owner, float g, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorOneAxis(camera, owner, 1, g, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoBackgroundColorB(this Camera camera, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorOneAxis(camera, camera.gameObject, 2, b, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoBackgroundColorB(this Camera camera, GameObject owner, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorOneAxis(camera, owner, 2, b, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoBackgroundColorA(this Camera camera, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorOneAxis(camera, camera.gameObject, 3, a, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoBackgroundColorA(this Camera camera, GameObject owner, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorOneAxis(camera, owner, 3, a, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoBackgroundColorTwoAxes
        private static Sequence DoBackgroundColorTwoAxes(Camera camera, GameObject owner, int axis1, int axis2, float color1, float color2, float duration, Ease formula, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            var sequence = new Sequence(owner, owner.name, formula, loopsCount, loopType, loopResetBehaviour, direction);

            sequence.Insert(0f, Tween.Float(owner, owner.name, camera.backgroundColor[axis1], color1, c => camera.SetBackgroundColor(axis1, c), duration, formula, loopsCount, loopType, direction));
            sequence.Insert(0f, Tween.Float(owner, owner.name, camera.backgroundColor[axis2], color2, c => camera.SetBackgroundColor(axis2, c), duration, formula, loopsCount, loopType, direction));

            return sequence;
        }

        public static Sequence DoBackgroundColorRG(this Camera camera, float r, float g, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorTwoAxes(camera, camera.gameObject, 0, 1, r, g, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoBackgroundColorRG(this Camera camera, GameObject owner, float r, float g, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorTwoAxes(camera, owner, 0, 1, r, g, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoBackgroundColorRB(this Camera camera, float r, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorTwoAxes(camera, camera.gameObject, 0, 2, r, b, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoBackgroundColorRB(this Camera camera, GameObject owner, float r, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorTwoAxes(camera, owner, 0, 2, r, b, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoBackgroundColorRA(this Camera camera, float r, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorTwoAxes(camera, camera.gameObject, 0, 3, r, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoBackgroundColorRA(this Camera camera, GameObject owner, float r, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorTwoAxes(camera, owner, 0, 3, r, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoBackgroundColorGB(this Camera camera, float g, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorTwoAxes(camera, camera.gameObject, 1, 2, g, b, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoBackgroundColorGB(this Camera camera, GameObject owner, float g, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorTwoAxes(camera, owner, 1, 2, g, b, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoBackgroundColorGA(this Camera camera, float g, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorTwoAxes(camera, camera.gameObject, 1, 3, g, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoBackgroundColorGA(this Camera camera, GameObject owner, float g, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorTwoAxes(camera, owner, 1, 3, g, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoBackgroundColorBA(this Camera camera, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorTwoAxes(camera, camera.gameObject, 2, 3, b, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoBackgroundColorBA(this Camera camera, GameObject owner, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorTwoAxes(camera, owner, 2, 3, b, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoBackgroundColorThreeAxes
        private static Sequence DoBackgroundColorThreeAxes(Camera camera, GameObject owner, int axis1, int axis2, int axis3, float color1, float color2, float color3, float duration, Ease formula, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            var sequence = new Sequence(owner, owner.name, formula, loopsCount, loopType, loopResetBehaviour, direction);

            sequence.Insert(0f, Tween.Float(owner, owner.name, camera.backgroundColor[axis1], color1, c => camera.SetBackgroundColor(axis1, c), duration, formula, loopsCount, loopType, direction));
            sequence.Insert(0f, Tween.Float(owner, owner.name, camera.backgroundColor[axis2], color2, c => camera.SetBackgroundColor(axis2, c), duration, formula, loopsCount, loopType, direction));
            sequence.Insert(0f, Tween.Float(owner, owner.name, camera.backgroundColor[axis3], color3, c => camera.SetBackgroundColor(axis3, c), duration, formula, loopsCount, loopType, direction));

            return sequence;
        }

        public static Sequence DoBackgroundColorRGB(this Camera camera, float r, float g, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorThreeAxes(camera, camera.gameObject, 0, 1, 2, r, g, b, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoBackgroundColorRGB(this Camera camera, GameObject owner, float r, float g, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorThreeAxes(camera, owner, 0, 1, 2, r, g, b, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoBackgroundColorRGA(this Camera camera, float r, float g, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorThreeAxes(camera, camera.gameObject, 0, 1, 3, r, g, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoBackgroundColorRGA(this Camera camera, GameObject owner, float r, float g, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorThreeAxes(camera, owner, 0, 1, 3, r, g, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoBackgroundColorRBA(this Camera camera, float r, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorThreeAxes(camera, camera.gameObject, 0, 2, 3, r, b, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoBackgroundColorRBA(this Camera camera, GameObject owner, float r, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorThreeAxes(camera, owner, 0, 2, 3, r, b, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoBackgroundColorGBA(this Camera camera, float g, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorThreeAxes(camera, camera.gameObject, 1, 2, 3, g, b, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoBackgroundColorGBA(this Camera camera, GameObject owner, float g, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorThreeAxes(camera, owner, 1, 2, 3, g, b, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        public static Tween<Color, TweakColor> DoBackgroundColor(this Camera camera, float r, float g, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoBackgroundColor(camera, camera.gameObject, new Color(r, g, b, a), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Color, TweakColor> DoBackgroundColor(this Camera camera, GameObject owner, float r, float g, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoBackgroundColor(camera, owner, new Color(r, g, b, a), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Color, TweakColor> DoBackgroundColor(this Camera camera, Color color, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoBackgroundColor(camera, camera.gameObject, color, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Color, TweakColor> DoBackgroundColor(this Camera camera, GameObject owner, Color color, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Color(owner, owner.name, camera.backgroundColor, color, c => camera.backgroundColor = color, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoFarClipPlane
        public static Tween<float, TweakFloat> DoFarClipPlane(this Camera camera, float distance, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoFarClipPlane(camera, camera.gameObject, distance, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoFarClipPlane(this Camera camera, GameObject owner, float distance, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(owner, owner.name, camera.farClipPlane, distance, d => camera.farClipPlane = d, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoNearClipPlane
        public static Tween<float, TweakFloat> DoNearClipPlane(this Camera camera, float distance, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoNearClipPlane(camera, camera.gameObject, distance, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoNearClipPlane(this Camera camera, GameObject owner, float distance, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(owner, owner.name, camera.nearClipPlane, distance, d => camera.nearClipPlane = d, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoFieldOfView
        public static Tween<float, TweakFloat> DoFieldOfView(this Camera camera, float fov, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoFieldOfView(camera, camera.gameObject, fov, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoFieldOfView(this Camera camera, GameObject owner, float fov, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(owner, owner.name, camera.fieldOfView, fov, f => camera.fieldOfView = f, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoFocalLength
        public static Tween<float, TweakFloat> DoFocalLength(this Camera camera, float focalLength, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoFocalLength(camera, camera.gameObject, focalLength, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoFocalLength(this Camera camera, GameObject owner, float focalLength, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(owner, owner.name, camera.focalLength, focalLength, fl => camera.focalLength = fl, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        private static void SetLensShift(this Camera camera, int axis, float shift)
        {
            var lensShift = camera.lensShift;
            lensShift[axis] = shift;
            camera.lensShift = lensShift;
        }

        private static Tween<float, TweakFloat> DoLensShiftOneAxis(Camera camera, GameObject owner, int axis, float shift, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(owner, owner.name, camera.lensShift[axis], shift, ls => camera.SetLensShift(axis, ls), duration, formula, loopsCount, loopType, direction);
        }

        #region DoLensShiftOneAxis
        public static Tween<float, TweakFloat> DoLensShiftX(this Camera camera, float x, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLensShiftOneAxis(camera, camera.gameObject, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLensShiftX(this Camera camera, GameObject owner, float x, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLensShiftOneAxis(camera, owner, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLensShiftY(this Camera camera, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLensShiftOneAxis(camera, camera.gameObject, 1, y, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLensShiftY(this Camera camera, GameObject owner, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLensShiftOneAxis(camera, owner, 1, y, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoLensShift
        public static Tween<Vector2, TweakVector2> DoLensShift(this Camera camera, float x, float y, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoLensShift(camera, camera.gameObject, new Vector2(x, y), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoLensShift(this Camera camera, GameObject owner, float x, float y, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoLensShift(camera, owner, new Vector2(x, y), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoLensShift(this Camera camera, Vector2 shift, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoLensShift(camera, camera.gameObject, shift, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoLensShift(this Camera camera, GameObject owner, Vector2 shift, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Vector2(owner, owner.name, camera.lensShift, shift, ls => camera.lensShift = ls, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoOrthographicSize
        public static Tween<float, TweakFloat> DoOrthographicSize(this Camera camera, float size, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoOrthographicSize(camera, camera.gameObject, size, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoOrthographicSize(this Camera camera, GameObject owner, float size, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(owner, owner.name, camera.orthographicSize, size, s => camera.orthographicSize = s, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoPixelRect
        public static Tween<Rect, TweakRect> DoPixelRect(this Camera camera, Rect rect, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPixelRect(camera, camera.gameObject, rect, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Rect, TweakRect> DoPixelRect(this Camera camera, GameObject owner, Rect rect, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Rect(owner, owner.name, camera.pixelRect, rect, r => camera.pixelRect = r, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoProjectionMatrix
        public static Tween<Matrix4x4, TweakMatrix4x4> DoProjectionMatrix(this Camera camera, Matrix4x4 matrix, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoProjectionMatrix(camera, camera.gameObject, matrix, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Matrix4x4, TweakMatrix4x4> DoProjectionMatrix(this Camera camera, GameObject owner, Matrix4x4 matrix, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Matrix4x4(owner, owner.name, camera.projectionMatrix, matrix, m => camera.projectionMatrix = m, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoRect
        public static Tween<Rect, TweakRect> DoRect(this Camera camera, Rect rect, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoRect(camera, camera.gameObject, rect, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Rect, TweakRect> DoRect(this Camera camera, GameObject owner, Rect rect, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Rect(owner, owner.name, camera.rect, rect, r => camera.rect = r, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        private static void SetSensorSize(this Camera camera, int axis, float size)
        {
            var sensorSize = camera.sensorSize;
            sensorSize[axis] = size;
            camera.sensorSize = sensorSize;
        }

        private static Tween<float, TweakFloat> DoSensorSizeOneAxis(this Camera camera, GameObject owner, int axis, float size, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(owner, owner.name, camera.sensorSize[axis], size, ss => camera.SetSensorSize(axis, ss), duration, formula, loopsCount, loopType, direction);
        }

        #region DoSensorSizeOneAxis
        public static Tween<float, TweakFloat> DoSensorSizeX(this Camera camera, float x, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoSensorSizeOneAxis(camera, camera.gameObject, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoSensorSizeX(this Camera camera, GameObject owner, float x, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoSensorSizeOneAxis(camera, owner, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoSensorSizeY(this Camera camera, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoSensorSizeOneAxis(camera, camera.gameObject, 1, y, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoSensorSizeY(this Camera camera, GameObject owner, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoSensorSizeOneAxis(camera, owner, 1, y, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoSensorSize
        public static Tween<Vector2, TweakVector2> DoSensorSize(this Camera camera, float x, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoSensorSize(camera, camera.gameObject, new Vector2(x, y), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoSensorSize(this Camera camera, GameObject owner, float x, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoSensorSize(camera, owner, new Vector2(x, y), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoSensorSize(this Camera camera, Vector2 size, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoSensorSize(camera, camera.gameObject, size, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoSensorSize(this Camera camera, GameObject owner, Vector2 size, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Vector2(owner, owner.name, camera.sensorSize, size, s => camera.sensorSize = s, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoStereoConvengence
        public static Tween<float, TweakFloat> DoStereoConvengence(this Camera camera, float convengence, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoStereoConvengence(camera, camera.gameObject, convengence, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoStereoConvengence(this Camera camera, GameObject owner, float convengence, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(owner, owner.name, camera.stereoConvergence, convengence, c => camera.stereoConvergence = c, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoStereoSeparation
        public static Tween<float, TweakFloat> DoStereoSeparation(this Camera camera, float separation, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoStereoSeparation(camera, camera.gameObject, separation, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoStereoSeparation(this Camera camera, GameObject owner, float separation, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(owner, owner.name, camera.stereoSeparation, separation, s => camera.stereoSeparation = s, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        private static void SetTransparencySortAxisOneAxis(this Camera camera, int axis, float value)
        {
            var transparencySortAxis = camera.transparencySortAxis;
            transparencySortAxis[axis] = value;
            camera.transparencySortAxis = transparencySortAxis;
        }

        #region DoTransparencySortAxisOneAxis
        private static Tween<float, TweakFloat> DoTransparencySortAxisOneAxis(Camera camera, GameObject owner, int axis, float value, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(owner, owner.name, camera.transparencySortAxis[axis], value, v => camera.SetTransparencySortAxisOneAxis(axis, v), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoTransparencySortAxisX(this Camera camera, float r, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoTransparencySortAxisOneAxis(camera, camera.gameObject, 0, r, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoTransparencySortAxisX(this Camera camera, GameObject owner, float r, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoTransparencySortAxisOneAxis(camera, owner, 0, r, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoTransparencySortAxisY(this Camera camera, float g, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoTransparencySortAxisOneAxis(camera, camera.gameObject, 1, g, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoTransparencySortAxisY(this Camera camera, GameObject owner, float g, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoTransparencySortAxisOneAxis(camera, owner, 1, g, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoTransparencySortAxisZ(this Camera camera, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoTransparencySortAxisOneAxis(camera, camera.gameObject, 2, b, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoTransparencySortAxisZ(this Camera camera, GameObject owner, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoTransparencySortAxisOneAxis(camera, owner, 2, b, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoTransparencySortAxisTwoAxes
        private static Sequence DoTransparencySortAxisTwoAxes(Camera camera, GameObject owner, int axis1, int axis2, float value1, float value2, float duration, Ease formula, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            var sequence = new Sequence(owner, owner.name, formula, loopsCount, loopType, loopResetBehaviour, direction);

            sequence.Insert(0f, Tween.Float(owner, owner.name, camera.transparencySortAxis[axis1], value1, c => camera.SetTransparencySortAxisOneAxis(axis1, c), duration, formula, loopsCount, loopType, direction));
            sequence.Insert(0f, Tween.Float(owner, owner.name, camera.transparencySortAxis[axis2], value2, c => camera.SetTransparencySortAxisOneAxis(axis2, c), duration, formula, loopsCount, loopType, direction));

            return sequence;
        }

        public static Sequence DoTransparencySortAxisXY(this Camera camera, float x, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoTransparencySortAxisTwoAxes(camera, camera.gameObject, 0, 1, x, y, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoTransparencySortAxisXY(this Camera camera, GameObject owner, float x, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoTransparencySortAxisTwoAxes(camera, owner, 0, 1, x, y, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoTransparencySortAxisXZ(this Camera camera, float x, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoTransparencySortAxisTwoAxes(camera, camera.gameObject, 0, 2, x, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoTransparencySortAxisXZ(this Camera camera, GameObject owner, float x, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoTransparencySortAxisTwoAxes(camera, owner, 0, 2, x, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoTransparencySortAxisYZ(this Camera camera, float y, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoTransparencySortAxisTwoAxes(camera, camera.gameObject, 1, 2, y, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoTransparencySortAxisYZ(this Camera camera, GameObject owner, float y, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoTransparencySortAxisTwoAxes(camera, owner, 1, 2, y, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        public static Tween<Vector3, TweakVector3> DoTransparencySortAxis(this Camera camera, float x, float y, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoTransparencySortAxis(camera, camera.gameObject, new Vector3(x, y, z), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoTransparencySortAxis(this Camera camera, GameObject owner, float x, float y, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoTransparencySortAxis(camera, owner, new Vector3(x, y, z), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoTransparencySortAxis(this Camera camera, Vector3 axis, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoTransparencySortAxis(camera, camera.gameObject, axis, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoTransparencySortAxis(this Camera camera, GameObject owner, Vector3 axis, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Vector3(owner, owner.name, camera.transparencySortAxis, axis, a => camera.transparencySortAxis = a, duration, formula, loopsCount, loopType, direction);
        }
    }
}