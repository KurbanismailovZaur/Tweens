using Extensions;
using Tweens.Formulas;
using Tweens.Tweaks;
using UnityEngine;

namespace Tweens
{
    public static class TransformExtensions
    {
        #region DoPositionOneAxis
        private static Tween<float, TweakFloat> DoPositionOneAxis(this Transform transform, int axis, float position, float duration, FormulaBase formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(transform.gameObject, transform.name, transform.position[axis], position, p => transform.SetPosition(axis, p), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPositionX(this Transform transform, float x, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPositionOneAxis(transform, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPositionY(this Transform transform, float y, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPositionOneAxis(transform, 1, y, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPositionZ(this Transform transform, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPositionOneAxis(transform, 2, z, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoPositionTwoAxes
        private static Sequence DoPositionTwoAxes(this Transform transform, int axis1, int axis2, float position1, float position2, float duration, FormulaBase formula, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            var sequence = new Sequence(transform.gameObject, transform.name, formula, loopsCount, loopType, loopResetBehaviour, direction);

            sequence.Insert(0f, Tween.Float(transform.gameObject, transform.name, transform.position[axis1], position1, p => transform.SetPosition(axis1, p), duration));
            sequence.Insert(0f, Tween.Float(transform.gameObject, transform.name, transform.position[axis2], position2, p => transform.SetPosition(axis2, p), duration));

            return sequence;
        }

        public static Sequence DoPositionXY(this Transform transform, float x, float y, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoPositionTwoAxes(transform, 0, 1, x, y, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoPositionXZ(this Transform transform, float x, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoPositionTwoAxes(transform, 0, 2, x, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoPositionYZ(this Transform transform, float y, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoPositionTwoAxes(transform, 1, 2, y, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoPosition
        public static Tween<Vector3, TweakVector3> DoPosition(this Transform transform, float x, float y, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPosition(transform, new Vector3(x, y, z), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoPosition(this Transform transform, Vector3 position, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Vector3(transform.gameObject, transform.name, transform.position, position, p => transform.position = p, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoLocalPositionOneAxis
        private static Tween<float, TweakFloat> DoLocalPositionOneAxis(this Transform transform, int axis, float position, float duration, FormulaBase formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(transform.gameObject, transform.name, transform.localPosition[axis], position, p => transform.SetLocalPosition(axis, p), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLocalPositionX(this Transform transform, float x, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalPositionOneAxis(transform, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLocalPositionY(this Transform transform, float y, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalPositionOneAxis(transform, 1, y, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLocalPositionZ(this Transform transform, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalPositionOneAxis(transform, 2, z, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoLocalPositionTwoAxes
        private static Sequence DoLocalPositionTwoAxes(this Transform transform, int axis1, int axis2, float position1, float position2, float duration, FormulaBase formula, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            var sequence = new Sequence(transform.gameObject, transform.name, formula, loopsCount, loopType, loopResetBehaviour, direction);

            sequence.Insert(0f, Tween.Float(transform.gameObject, transform.name, transform.localPosition[axis1], position1, p => transform.SetLocalPosition(axis1, p), duration));
            sequence.Insert(0f, Tween.Float(transform.gameObject, transform.name, transform.localPosition[axis2], position2, p => transform.SetLocalPosition(axis2, p), duration));

            return sequence;
        }

        public static Sequence DoLocalPositionXY(this Transform transform, float x, float y, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalPositionTwoAxes(transform, 0, 1, x, y, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoLocalPositionXZ(this Transform transform, float x, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalPositionTwoAxes(transform, 0, 2, x, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoLocalPositionYZ(this Transform transform, float y, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalPositionTwoAxes(transform, 1, 2, y, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoLocalPosition
        public static Tween<Vector3, TweakVector3> DoLocalPosition(this Transform transform, float x, float y, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalPosition(transform, new Vector3(x, y, z), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoLocalPosition(this Transform transform, Vector3 position, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Vector3(transform.gameObject, transform.name, transform.localPosition, position, p => transform.localPosition = p, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoEulerAnglesOneAxis
        private static Tween<float, TweakFloat> DoEulerAnglesOneAxis(this Transform transform, int axis, float angle, float duration, FormulaBase formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(transform.gameObject, transform.name, transform.eulerAngles[axis], angle, a => transform.SetEulerAngle(axis, a), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoEulerAnglesX(this Transform transform, float x, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoEulerAnglesOneAxis(transform, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoEulerAnglesY(this Transform transform, float y, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoEulerAnglesOneAxis(transform, 1, y, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoEulerAnglesZ(this Transform transform, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoEulerAnglesOneAxis(transform, 2, z, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoEulerAnglesTwoAxes
        private static Sequence DoEulerAnglesTwoAxis(this Transform transform, int axis1, int axis2, float angle1, float angle2, float duration, FormulaBase formula, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            var sequence = new Sequence(transform.gameObject, transform.name, formula, loopsCount, loopType, loopResetBehaviour, direction);

            sequence.Insert(0f, Tween.Float(transform.gameObject, transform.name, transform.eulerAngles[axis1], angle1, a => transform.SetEulerAngle(axis1, a), duration));
            sequence.Insert(0f, Tween.Float(transform.gameObject, transform.name, transform.eulerAngles[axis2], angle2, a => transform.SetEulerAngle(axis2, a), duration));

            return sequence;
        }

        public static Sequence DoEulerAnglesXY(this Transform transform, float x, float y, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoEulerAnglesTwoAxis(transform, 0, 1, x, y, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoEulerAnglesXZ(this Transform transform, float x, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoEulerAnglesTwoAxis(transform, 0, 2, x, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoEulerAnglesYZ(this Transform transform, float y, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoEulerAnglesTwoAxis(transform, 1, 2, y, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoEulerAngles
        public static Tween<Vector3, TweakVector3> DoEulerAngles(this Transform transform, float x, float y, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoEulerAngles(transform, new Vector3(x, y, z), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoEulerAngles(this Transform transform, Vector3 angles, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Vector3(transform.gameObject, transform.name, transform.eulerAngles, angles, a => transform.eulerAngles = a, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoLocalEulerAnglesOneAxis
        private static Tween<float, TweakFloat> DoLocalEulerAnglesOneAxis(this Transform transform, int axis, float angle, float duration, FormulaBase formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(transform.gameObject, transform.name, transform.localEulerAngles[axis], angle, a => transform.SetLocalEulerAngle(axis, a), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLocalEulerAnglesX(this Transform transform, float x, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalEulerAnglesOneAxis(transform, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLocalEulerAnglesY(this Transform transform, float y, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalEulerAnglesOneAxis(transform, 1, y, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLocalEulerAnglesZ(this Transform transform, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalEulerAnglesOneAxis(transform, 2, z, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoLocalEulerAnglesTwoAxes
        private static Sequence DoLocalEulerAnglesTwoAxis(this Transform transform, int axis1, int axis2, float angle1, float angle2, float duration, FormulaBase formula, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            var sequence = new Sequence(transform.gameObject, transform.name, formula, loopsCount, loopType, loopResetBehaviour, direction);

            sequence.Insert(0f, Tween.Float(transform.gameObject, transform.name, transform.localEulerAngles[axis1], angle1, a => transform.SetLocalEulerAngle(axis1, a), duration));
            sequence.Insert(0f, Tween.Float(transform.gameObject, transform.name, transform.localEulerAngles[axis2], angle2, a => transform.SetLocalEulerAngle(axis2, a), duration));

            return sequence;
        }

        public static Sequence DoLocalEulerAnglesXY(this Transform transform, float x, float y, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalEulerAnglesTwoAxis(transform, 0, 1, x, y, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoLocalEulerAnglesXZ(this Transform transform, float x, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalEulerAnglesTwoAxis(transform, 0, 2, x, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoLocalEulerAnglesYZ(this Transform transform, float y, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalEulerAnglesTwoAxis(transform, 1, 2, y, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoLocalEulerAngles
        public static Tween<Vector3, TweakVector3> DoLocalEulerAngles(this Transform transform, float x, float y, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalEulerAngles(transform, new Vector3(x, y, z), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoLocalEulerAngles(this Transform transform, Vector3 angles, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Vector3(transform.gameObject, transform.name, transform.localEulerAngles, angles, a => transform.eulerAngles = a, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoRotation and DoLocalRotation
        public static Tween<Quaternion, TweakQuaternion> DoRotation(this Transform transform, Quaternion rotation, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Quaternion(transform.gameObject, transform.name, transform.rotation, rotation, r => transform.rotation = r, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Quaternion, TweakQuaternion> DoLocalRotation(this Transform transform, Quaternion rotation, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Quaternion(transform.gameObject, transform.name, transform.localRotation, rotation, r => transform.localRotation = r, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoLocalScaleOneAxis
        private static Tween<float, TweakFloat> DoLocalScaleOneAxis(this Transform transform, int axis, float scale, float duration, FormulaBase formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(transform.gameObject, transform.name, transform.localScale[axis], scale, s => transform.SetLocalScale(axis, s), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLocalScaleX(this Transform transform, float x, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalScaleOneAxis(transform, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLocalScaleY(this Transform transform, float y, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalScaleOneAxis(transform, 1, y, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLocalScaleZ(this Transform transform, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalScaleOneAxis(transform, 2, z, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoLocalPositionTwoAxes
        private static Sequence DoLocalScaleTwoAxes(this Transform transform, int axis1, int axis2, float scale1, float scale2, float duration, FormulaBase formula, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            var sequence = new Sequence(transform.gameObject, transform.name, formula, loopsCount, loopType, loopResetBehaviour, direction);

            sequence.Insert(0f, Tween.Float(transform.gameObject, transform.name, transform.localScale[axis1], scale1, s => transform.SetLocalScale(axis1, s), duration));
            sequence.Insert(0f, Tween.Float(transform.gameObject, transform.name, transform.localScale[axis2], scale2, s => transform.SetLocalScale(axis2, s), duration));

            return sequence;
        }

        public static Sequence DoLocalScaleXY(this Transform transform, float x, float y, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalScaleTwoAxes(transform, 0, 1, x, y, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoLocalScaleXZ(this Transform transform, float x, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalScaleTwoAxes(transform, 0, 2, x, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoLocalScaleYZ(this Transform transform, float y, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalScaleTwoAxes(transform, 1, 2, y, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoLocalPosition
        public static Tween<Vector3, TweakVector3> DoLocalScale(this Transform transform, float scale, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalScale(transform, new Vector3(scale, scale, scale), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoLocalScale(this Transform transform, float x, float y, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalScale(transform, new Vector3(x, y, z), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoLocalScale(this Transform transform, Vector3 scale, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Vector3(transform.gameObject, transform.name, transform.localScale, scale, s => transform.localScale = s, duration, formula, loopsCount, loopType, direction);
        }
        #endregion
    }
}