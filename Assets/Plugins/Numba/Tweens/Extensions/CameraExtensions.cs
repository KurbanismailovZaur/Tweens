using Extensions;
using Tweens.Formulas;
using Tweens.Tweaks;
using UnityEngine;

namespace Tweens
{
    public static class CameraExtensions
    {
        public static Tween<float, TweakFloat> DoAspect(this Camera camera, float aspect, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(camera.gameObject, camera.name, camera.aspect, aspect, a => camera.aspect = a, duration, formula, loopsCount, loopType, direction);
        }

        private static void SetBackgroundColor(this Camera camera, int axis, float color)
        {
            var backgroundColor = camera.backgroundColor;
            backgroundColor[axis] = color;
            camera.backgroundColor = backgroundColor;
        }

        #region DoBackgroundColorOneAxis
        private static Tween<float, TweakFloat> DoBackgroundColorOneAxis(Camera camera, int axis, float color, float duration, FormulaBase formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(camera.gameObject, camera.name, camera.backgroundColor[axis], color, c => camera.SetBackgroundColor(axis, c), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoBackgroundColorR(this Camera camera, float r, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorOneAxis(camera, 0, r, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoBackgroundColorG(this Camera camera, float g, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorOneAxis(camera, 1, g, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoBackgroundColorB(this Camera camera, float b, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorOneAxis(camera, 2, b, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoBackgroundColorA(this Camera camera, float a, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorOneAxis(camera, 3, a, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoBackgroundColorTwoAxes
        private static Sequence DoBackgroundColorTwoAxes(Camera camera, int axis1, int axis2, float color1, float color2, float duration, FormulaBase formula, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            var sequence = new Sequence(camera.gameObject, camera.name, formula, loopsCount, loopType, loopResetBehaviour, direction);

            sequence.Insert(0f, Tween.Float(camera.gameObject, camera.name, camera.backgroundColor[axis1], color1, c => camera.SetBackgroundColor(axis1, c), duration, formula, loopsCount, loopType, direction));
            sequence.Insert(0f, Tween.Float(camera.gameObject, camera.name, camera.backgroundColor[axis2], color2, c => camera.SetBackgroundColor(axis2, c), duration, formula, loopsCount, loopType, direction));

            return sequence;
        }

        public static Sequence DoBackgroundColorRG(this Camera camera, float r, float g, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorTwoAxes(camera, 0, 1, r, g, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoBackgroundColorRB(this Camera camera, float r, float b, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorTwoAxes(camera, 0, 2, r, b, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoBackgroundColorRA(this Camera camera, float r, float a, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorTwoAxes(camera, 0, 3, r, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoBackgroundColorGB(this Camera camera, float g, float b, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorTwoAxes(camera, 1, 2, g, b, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoBackgroundColorGA(this Camera camera, float g, float a, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorTwoAxes(camera, 1, 3, g, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoBackgroundColorBA(this Camera camera, float b, float a, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorTwoAxes(camera, 2, 3, b, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoBackgroundColorThreeAxes
        private static Sequence DoBackgroundColorThreeAxes(Camera camera, int axis1, int axis2, int axis3, float color1, float color2, float color3, float duration, FormulaBase formula, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            var sequence = new Sequence(camera.gameObject, camera.name, formula, loopsCount, loopType, loopResetBehaviour, direction);

            sequence.Insert(0f, Tween.Float(camera.gameObject, camera.name, camera.backgroundColor[axis1], color1, c => camera.SetBackgroundColor(axis1, c), duration, formula, loopsCount, loopType, direction));
            sequence.Insert(0f, Tween.Float(camera.gameObject, camera.name, camera.backgroundColor[axis2], color2, c => camera.SetBackgroundColor(axis2, c), duration, formula, loopsCount, loopType, direction));
            sequence.Insert(0f, Tween.Float(camera.gameObject, camera.name, camera.backgroundColor[axis3], color3, c => camera.SetBackgroundColor(axis3, c), duration, formula, loopsCount, loopType, direction));

            return sequence;
        }

        public static Sequence DoBackgroundColorRGB(this Camera camera, float r, float g, float b, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorThreeAxes(camera, 0, 1, 2, r, g, b, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoBackgroundColorRGA(this Camera camera, float r, float g, float a, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorThreeAxes(camera, 0, 1, 3, r, g, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoBackgroundColorRBA(this Camera camera, float r, float b, float a, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorThreeAxes(camera, 0, 2, 3, r, b, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoBackgroundColorGBA(this Camera camera, float g, float b, float a, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoBackgroundColorThreeAxes(camera, 1, 2, 3, g, b, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoBackgroundColor
        public static Tween<Color, TweakColor> DoBackgroundColor(this Camera camera, float r, float g, float b, float a, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoBackgroundColor(camera, new Color(r, g, b, a), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Color, TweakColor> DoBackgroundColor(this Camera camera, Color color, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Color(camera.gameObject, camera.name, camera.backgroundColor, color, c => camera.backgroundColor = color, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        public static Tween<float, TweakFloat> DoFarClipPlane(this Camera camera, float distance, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(camera.gameObject, camera.name, camera.farClipPlane, distance, d => camera.farClipPlane = d, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoNearClipPlane(this Camera camera, float distance, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(camera.gameObject, camera.name, camera.nearClipPlane, distance, d => camera.nearClipPlane = d, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoFieldOfView(this Camera camera, float fov, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(camera.gameObject, camera.name, camera.fieldOfView, fov, f => camera.fieldOfView = f, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoFocalLength(this Camera camera, float focalLength, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(camera.gameObject, camera.name, camera.focalLength, focalLength, fl => camera.focalLength = fl, duration, formula, loopsCount, loopType, direction);
        }

        private static void SetLensShift(this Camera camera, int axis, float shift)
        {
            var lensShift = camera.lensShift;
            lensShift[axis] = shift;
            camera.lensShift = lensShift;
        }

        private static Tween<float, TweakFloat> DoLensShiftOneAxis(Camera camera, int axis, float shift, float duration, FormulaBase formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(camera.gameObject, camera.name, camera.lensShift[axis], shift, ls => camera.SetLensShift(axis, ls), duration, formula, loopsCount, loopType, direction);
        }

        #region DoLensShiftOneAxis
        public static Tween<float, TweakFloat> DoLensShiftX(this Camera camera, float x, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLensShiftOneAxis(camera, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLensShiftY(this Camera camera, float y, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLensShiftOneAxis(camera, 1, y, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoLensShift
        private static Tween<Vector2, TweakVector2> DoLensShift(this Camera camera, float x, float y, float duration, FormulaBase formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoLensShift(camera, new Vector2(x, y), duration, formula, loopsCount, loopType, direction);
        }

        private static Tween<Vector2, TweakVector2> DoLensShift(this Camera camera, Vector2 shift, float duration, FormulaBase formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Vector2(camera.gameObject, camera.name, camera.lensShift, shift, ls => camera.lensShift = ls, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        public static Tween<float, TweakFloat> DoOrthographicSize(this Camera camera, float size, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(camera.gameObject, camera.name, camera.orthographicSize, size, s => camera.orthographicSize = s, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Rect, TweakRect> DoPixelRect(this Camera camera, Rect rect, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Rect(camera.gameObject, camera.name, camera.pixelRect, rect, r => camera.pixelRect = r, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Matrix4x4, TweakMatrix4x4> DoProjectionMatrix(this Camera camera, Matrix4x4 matrix, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Matrix4x4(camera.gameObject, camera.name, camera.projectionMatrix, matrix, m => camera.projectionMatrix = m, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Rect, TweakRect> DoRect(this Camera camera, Rect rect, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Rect(camera.gameObject, camera.name, camera.rect, rect, r => camera.rect = r, duration, formula, loopsCount, loopType, direction);
        }

        private static void SetSensorSize(this Camera camera, int axis, float size)
        {
            var sensorSize = camera.sensorSize;
            sensorSize[axis] = size;
            camera.sensorSize = sensorSize;
        }

        private static Tween<float, TweakFloat> DoSensorSizeOneAxis(this Camera camera, int axis, float size, float duration, FormulaBase formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(camera.gameObject, camera.name, camera.sensorSize[axis], size, ss => camera.SetSensorSize(axis, ss), duration, formula, loopsCount, loopType, direction);
        }

        #region DoSensorSizeOneAxis
        public static Tween<float, TweakFloat> DoSensorSizeX(this Camera camera, float x, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoSensorSizeOneAxis(camera, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoSensorSizeY(this Camera camera, float y, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoSensorSizeOneAxis(camera, 1, y, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoSensorSize
        public static Tween<Vector2, TweakVector2> DoSensorSize(this Camera camera, float x, float y, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoSensorSize(camera, new Vector2(x, y), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoSensorSize(this Camera camera, Vector2 size, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Vector2(camera.gameObject, camera.name, camera.sensorSize, size, s => camera.sensorSize = s, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        public static Tween<float, TweakFloat> DoStereoConvengence(this Camera camera, float convengence, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(camera.gameObject, camera.name, camera.stereoConvergence, convengence, c => camera.stereoConvergence = c, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoStereoSeparation(this Camera camera, float separation, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(camera.gameObject, camera.name, camera.stereoSeparation, separation, s => camera.stereoSeparation = s, duration, formula, loopsCount, loopType, direction);
        }

        private static void SetTransparencySortAxisOneAxis(this Camera camera, int axis, float value)
        {
            var transparencySortAxis = camera.transparencySortAxis;
            transparencySortAxis[axis] = value;
            camera.transparencySortAxis = transparencySortAxis;
        }

        #region DoTransparencySortAxisOneAxis
        private static Tween<float, TweakFloat> DoTransparencySortAxisOneAxis(Camera camera, int axis, float value, float duration, FormulaBase formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(camera.gameObject, camera.name, camera.transparencySortAxis[axis], value, v => camera.SetTransparencySortAxisOneAxis(axis, v), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoTransparencySortAxisX(this Camera camera, float r, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoTransparencySortAxisOneAxis(camera, 0, r, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoTransparencySortAxisY(this Camera camera, float g, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoTransparencySortAxisOneAxis(camera, 1, g, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoTransparencySortAxisZ(this Camera camera, float b, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoTransparencySortAxisOneAxis(camera, 2, b, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoTransparencySortAxisTwoAxes
        private static Sequence DoTransparencySortAxisTwoAxes(Camera camera, int axis1, int axis2, float value1, float value2, float duration, FormulaBase formula, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            var sequence = new Sequence(camera.gameObject, camera.name, formula, loopsCount, loopType, loopResetBehaviour, direction);

            sequence.Insert(0f, Tween.Float(camera.gameObject, camera.name, camera.transparencySortAxis[axis1], value1, c => camera.SetTransparencySortAxisOneAxis(axis1, c), duration, formula, loopsCount, loopType, direction));
            sequence.Insert(0f, Tween.Float(camera.gameObject, camera.name, camera.transparencySortAxis[axis2], value2, c => camera.SetTransparencySortAxisOneAxis(axis2, c), duration, formula, loopsCount, loopType, direction));

            return sequence;
        }

        public static Sequence DoTransparencySortAxisXY(this Camera camera, float x, float y, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoTransparencySortAxisTwoAxes(camera, 0, 1, x, y, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoTransparencySortAxisXZ(this Camera camera, float x, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoTransparencySortAxisTwoAxes(camera, 0, 2, x, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoTransparencySortAxisYZ(this Camera camera, float y, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoTransparencySortAxisTwoAxes(camera, 1, 2, y, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        public static Tween<Vector3, TweakVector3> DoTransparencySortAxis(this Camera camera, float x, float y, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoTransparencySortAxis(camera, new Vector3(x, y, z), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoTransparencySortAxis(this Camera camera, Vector3 axis, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Vector3(camera.gameObject, camera.name, camera.transparencySortAxis, axis, a => camera.transparencySortAxis = a, duration, formula, loopsCount, loopType, direction);
        }
    }
}