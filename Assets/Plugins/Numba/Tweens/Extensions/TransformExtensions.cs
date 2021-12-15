using Extensions;
using Tweens.Formulas;
using Tweens.Tweaks;
using UnityEngine;

namespace Tweens
{
    public static class TransformExtensions
    {
        private static void SetPosition(this Transform transform, int axis, float position)
        {
            var pos = transform.position;
            pos[axis] = position;
            transform.position = pos;
        }

        #region DoPositionOneAxis
        private static Tween<float, TweakFloat> DoPositionOneAxis(GameObject owner, Transform transform, int axis, float position, float duration, FormulaBase formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(owner, owner.name, transform.position[axis], position, p => transform.SetPosition(axis, p), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPositionX(this Transform transform, float x, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPositionOneAxis(transform.gameObject, transform, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPositionX(this Transform transform, GameObject owner, float x, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPositionOneAxis(owner, transform, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPositionY(this Transform transform, float y, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPositionOneAxis(transform.gameObject, transform, 1, y, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPositionY(this Transform transform, GameObject owner, float y, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPositionOneAxis(owner, transform, 1, y, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPositionZ(this Transform transform, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPositionOneAxis(transform.gameObject, transform, 2, z, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPositionZ(this Transform transform, GameObject owner, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPositionOneAxis(owner, transform, 2, z, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoPositionTwoAxes
        private static Sequence DoPositionTwoAxes(GameObject owner, Transform transform, int axis1, int axis2, float position1, float position2, float duration, FormulaBase formula, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            var sequence = new Sequence(owner, owner.name, formula, loopsCount, loopType, loopResetBehaviour, direction);

            sequence.Insert(0f, Tween.Float(owner, owner.name, transform.position[axis1], position1, p => transform.SetPosition(axis1, p), duration));
            sequence.Insert(0f, Tween.Float(owner, owner.name, transform.position[axis2], position2, p => transform.SetPosition(axis2, p), duration));

            return sequence;
        }

        public static Sequence DoPositionXY(this Transform transform, float x, float y, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoPositionTwoAxes(transform.gameObject, transform, 0, 1, x, y, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoPositionXY(this Transform transform, GameObject owner, float x, float y, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoPositionTwoAxes(owner, transform, 0, 1, x, y, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoPositionXZ(this Transform transform, float x, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoPositionTwoAxes(transform.gameObject, transform, 0, 2, x, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoPositionXZ(this Transform transform, GameObject owner, float x, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoPositionTwoAxes(owner, transform, 0, 2, x, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoPositionYZ(this Transform transform, float y, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoPositionTwoAxes(transform.gameObject, transform, 1, 2, y, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoPositionYZ(this Transform transform, GameObject owner, float y, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoPositionTwoAxes(owner, transform, 1, 2, y, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoPosition
        public static Tween<Vector3, TweakVector3> DoPosition(this Transform transform, float x, float y, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPosition(transform, transform.gameObject, new Vector3(x, y, z), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoPosition(this Transform transform, GameObject owner, float x, float y, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPosition(transform, owner, new Vector3(x, y, z), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoPosition(this Transform transform, Vector3 position, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPosition(transform, transform.gameObject, position, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoPosition(this Transform transform, GameObject owner, Vector3 position, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Vector3(owner, owner.name, transform.position, position, p => transform.position = p, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        private static void SetLocalPosition(this Transform transform, int axis, float position)
        {
            var pos = transform.localPosition;
            pos[axis] = position;
            transform.localPosition = pos;
        }

        #region DoLocalPositionOneAxis
        private static Tween<float, TweakFloat> DoLocalPositionOneAxis(Transform transform, GameObject owner, int axis, float position, float duration, FormulaBase formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(owner, owner.name, transform.localPosition[axis], position, p => transform.SetLocalPosition(axis, p), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLocalPositionX(this Transform transform, float x, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalPositionOneAxis(transform, transform.gameObject, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLocalPositionX(this Transform transform, GameObject owner, float x, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalPositionOneAxis(transform, owner, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLocalPositionY(this Transform transform, float y, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalPositionOneAxis(transform, transform.gameObject, 1, y, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLocalPositionY(this Transform transform, GameObject owner, float y, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalPositionOneAxis(transform, owner, 1, y, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLocalPositionZ(this Transform transform, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalPositionOneAxis(transform, transform.gameObject, 2, z, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLocalPositionZ(this Transform transform, GameObject owner, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalPositionOneAxis(transform, owner, 2, z, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoLocalPositionTwoAxes
        private static Sequence DoLocalPositionTwoAxes(Transform transform, GameObject owner, int axis1, int axis2, float position1, float position2, float duration, FormulaBase formula, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            var sequence = new Sequence(owner, owner.name, formula, loopsCount, loopType, loopResetBehaviour, direction);

            sequence.Insert(0f, Tween.Float(owner, owner.name, transform.localPosition[axis1], position1, p => transform.SetLocalPosition(axis1, p), duration));
            sequence.Insert(0f, Tween.Float(owner, owner.name, transform.localPosition[axis2], position2, p => transform.SetLocalPosition(axis2, p), duration));

            return sequence;
        }

        public static Sequence DoLocalPositionXY(this Transform transform, float x, float y, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalPositionTwoAxes(transform, transform.gameObject, 0, 1, x, y, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoLocalPositionXY(this Transform transform, GameObject owner, float x, float y, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalPositionTwoAxes(transform, owner, 0, 1, x, y, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoLocalPositionXZ(this Transform transform, float x, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalPositionTwoAxes(transform, transform.gameObject, 0, 2, x, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoLocalPositionXZ(this Transform transform, GameObject owner, float x, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalPositionTwoAxes(transform, owner, 0, 2, x, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoLocalPositionYZ(this Transform transform, float y, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalPositionTwoAxes(transform, transform.gameObject, 1, 2, y, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoLocalPositionYZ(this Transform transform, GameObject owner, float y, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalPositionTwoAxes(transform, owner, 1, 2, y, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoLocalPosition
        public static Tween<Vector3, TweakVector3> DoLocalPosition(this Transform transform, float x, float y, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalPosition(transform, transform.gameObject, new Vector3(x, y, z), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoLocalPosition(this Transform transform, GameObject owner, float x, float y, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalPosition(transform, owner, new Vector3(x, y, z), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoLocalPosition(this Transform transform, Vector3 position, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalPosition(transform, transform.gameObject, position, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoLocalPosition(this Transform transform, GameObject owner, Vector3 position, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Vector3(owner, owner.name, transform.localPosition, position, p => transform.localPosition = p, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        private static void SetEulerAngle(this Transform transform, int axis, float angle)
        {
            var angles = transform.eulerAngles;
            angles[axis] = angle;
            transform.eulerAngles = angles;
        }

        #region DoEulerAnglesOneAxis
        private static Tween<float, TweakFloat> DoEulerAnglesOneAxis(Transform transform, GameObject owner, int axis, float angle, float duration, FormulaBase formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(owner, owner.name, transform.eulerAngles[axis], angle, a => transform.SetEulerAngle(axis, a), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoEulerAnglesX(this Transform transform, float x, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoEulerAnglesOneAxis(transform, transform.gameObject, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoEulerAnglesX(this Transform transform, GameObject owner, float x, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoEulerAnglesOneAxis(transform, owner, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoEulerAnglesY(this Transform transform, float y, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoEulerAnglesOneAxis(transform, transform.gameObject, 1, y, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoEulerAnglesY(this Transform transform, GameObject owner, float y, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoEulerAnglesOneAxis(transform, owner, 1, y, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoEulerAnglesZ(this Transform transform, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoEulerAnglesOneAxis(transform, transform.gameObject, 2, z, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoEulerAnglesZ(this Transform transform, GameObject owner, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoEulerAnglesOneAxis(transform, owner, 2, z, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoEulerAnglesTwoAxes
        private static Sequence DoEulerAnglesTwoAxis(Transform transform, GameObject owner, int axis1, int axis2, float angle1, float angle2, float duration, FormulaBase formula, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            var sequence = new Sequence(owner, owner.name, formula, loopsCount, loopType, loopResetBehaviour, direction);

            sequence.Insert(0f, Tween.Float(owner, owner.name, transform.eulerAngles[axis1], angle1, a => transform.SetEulerAngle(axis1, a), duration));
            sequence.Insert(0f, Tween.Float(owner, owner.name, transform.eulerAngles[axis2], angle2, a => transform.SetEulerAngle(axis2, a), duration));

            return sequence;
        }

        public static Sequence DoEulerAnglesXY(this Transform transform, float x, float y, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoEulerAnglesTwoAxis(transform, transform.gameObject, 0, 1, x, y, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoEulerAnglesXY(this Transform transform, GameObject owner, float x, float y, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoEulerAnglesTwoAxis(transform, owner, 0, 1, x, y, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoEulerAnglesXZ(this Transform transform, float x, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoEulerAnglesTwoAxis(transform, transform.gameObject, 0, 2, x, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoEulerAnglesXZ(this Transform transform, GameObject owner, float x, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoEulerAnglesTwoAxis(transform, owner, 0, 2, x, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoEulerAnglesYZ(this Transform transform, float y, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoEulerAnglesTwoAxis(transform, transform.gameObject, 1, 2, y, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoEulerAnglesYZ(this Transform transform, GameObject owner, float y, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoEulerAnglesTwoAxis(transform, owner, 1, 2, y, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoEulerAngles
        public static Tween<Vector3, TweakVector3> DoEulerAngles(this Transform transform, float x, float y, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoEulerAngles(transform, transform.gameObject, new Vector3(x, y, z), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoEulerAngles(this Transform transform, GameObject owner, float x, float y, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoEulerAngles(transform, owner, new Vector3(x, y, z), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoEulerAngles(this Transform transform, Vector3 angles, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoEulerAngles(transform, transform.gameObject, angles, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoEulerAngles(this Transform transform, GameObject owner, Vector3 angles, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Vector3(owner, owner.name, transform.eulerAngles, angles, a => transform.eulerAngles = a, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        private static void SetLocalEulerAngle(this Transform transform, int axis, float angle)
        {
            var angles = transform.localEulerAngles;
            angles[axis] = angle;
            transform.localEulerAngles = angles;
        }

        #region DoLocalEulerAnglesOneAxis
        private static Tween<float, TweakFloat> DoLocalEulerAnglesOneAxis(Transform transform, GameObject owner, int axis, float angle, float duration, FormulaBase formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(owner, owner.name, transform.localEulerAngles[axis], angle, a => transform.SetLocalEulerAngle(axis, a), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLocalEulerAnglesX(this Transform transform, float x, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalEulerAnglesOneAxis(transform, transform.gameObject, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLocalEulerAnglesX(this Transform transform, GameObject owner, float x, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalEulerAnglesOneAxis(transform, owner, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLocalEulerAnglesY(this Transform transform, float y, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalEulerAnglesOneAxis(transform, transform.gameObject, 1, y, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLocalEulerAnglesY(this Transform transform, GameObject owner, float y, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalEulerAnglesOneAxis(transform, owner, 1, y, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLocalEulerAnglesZ(this Transform transform, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalEulerAnglesOneAxis(transform, transform.gameObject, 2, z, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLocalEulerAnglesZ(this Transform transform, GameObject owner, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalEulerAnglesOneAxis(transform, owner, 2, z, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoLocalEulerAnglesTwoAxes
        private static Sequence DoLocalEulerAnglesTwoAxis(Transform transform, GameObject owner, int axis1, int axis2, float angle1, float angle2, float duration, FormulaBase formula, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            var sequence = new Sequence(owner, owner.name, formula, loopsCount, loopType, loopResetBehaviour, direction);

            sequence.Insert(0f, Tween.Float(owner, owner.name, transform.localEulerAngles[axis1], angle1, a => transform.SetLocalEulerAngle(axis1, a), duration));
            sequence.Insert(0f, Tween.Float(owner, owner.name, transform.localEulerAngles[axis2], angle2, a => transform.SetLocalEulerAngle(axis2, a), duration));

            return sequence;
        }

        public static Sequence DoLocalEulerAnglesXY(this Transform transform, float x, float y, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalEulerAnglesTwoAxis(transform, transform.gameObject, 0, 1, x, y, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoLocalEulerAnglesXY(this Transform transform, GameObject owner, float x, float y, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalEulerAnglesTwoAxis(transform, owner, 0, 1, x, y, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoLocalEulerAnglesXZ(this Transform transform, float x, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalEulerAnglesTwoAxis(transform, transform.gameObject, 0, 2, x, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoLocalEulerAnglesXZ(this Transform transform, GameObject owner, float x, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalEulerAnglesTwoAxis(transform, owner, 0, 2, x, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoLocalEulerAnglesYZ(this Transform transform, float y, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalEulerAnglesTwoAxis(transform, transform.gameObject, 1, 2, y, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoLocalEulerAnglesYZ(this Transform transform, GameObject owner, float y, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalEulerAnglesTwoAxis(transform, owner, 1, 2, y, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoLocalEulerAngles
        public static Tween<Vector3, TweakVector3> DoLocalEulerAngles(this Transform transform, float x, float y, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalEulerAngles(transform, transform.gameObject, new Vector3(x, y, z), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoLocalEulerAngles(this Transform transform, GameObject owner, float x, float y, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalEulerAngles(transform, owner, new Vector3(x, y, z), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoLocalEulerAngles(this Transform transform, Vector3 angles, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalEulerAngles(transform, transform.gameObject, angles, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoLocalEulerAngles(this Transform transform, GameObject owner, Vector3 angles, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Vector3(owner, owner.name, transform.localEulerAngles, angles, a => transform.eulerAngles = a, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoRotation
        public static Tween<Quaternion, TweakQuaternion> DoRotation(this Transform transform, Quaternion rotation, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoRotation(transform, transform.gameObject, rotation, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Quaternion, TweakQuaternion> DoRotation(this Transform transform, GameObject owner, Quaternion rotation, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Quaternion(owner, owner.name, transform.rotation, rotation, r => transform.rotation = r, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoLocalRotation
        public static Tween<Quaternion, TweakQuaternion> DoLocalRotation(this Transform transform, Quaternion rotation, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalRotation(transform, transform.gameObject, rotation, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Quaternion, TweakQuaternion> DoLocalRotation(this Transform transform, GameObject owner, Quaternion rotation, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Quaternion(owner, owner.name, transform.localRotation, rotation, r => transform.localRotation = r, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        private static void SetLocalScale(this Transform transform, int axis, float scale)
        {
            var locScale = transform.localScale;
            locScale[axis] = scale;
            transform.localScale = locScale;
        }

        #region DoLocalScaleOneAxis
        private static Tween<float, TweakFloat> DoLocalScaleOneAxis(Transform transform, GameObject owner, int axis, float scale, float duration, FormulaBase formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(owner, owner.name, transform.localScale[axis], scale, s => transform.SetLocalScale(axis, s), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLocalScaleX(this Transform transform, float x, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalScaleOneAxis(transform, transform.gameObject, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLocalScaleX(this Transform transform, GameObject owner, float x, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalScaleOneAxis(transform, owner, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLocalScaleY(this Transform transform, float y, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalScaleOneAxis(transform, transform.gameObject, 1, y, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLocalScaleY(this Transform transform, GameObject owner, float y, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalScaleOneAxis(transform, owner, 1, y, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLocalScaleZ(this Transform transform, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalScaleOneAxis(transform, transform.gameObject, 2, z, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLocalScaleZ(this Transform transform, GameObject owner, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalScaleOneAxis(transform, owner, 2, z, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoLocalScaleTwoAxes
        private static Sequence DoLocalScaleTwoAxes(Transform transform, GameObject owner, int axis1, int axis2, float scale1, float scale2, float duration, FormulaBase formula, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            var sequence = new Sequence(owner, owner.name, formula, loopsCount, loopType, loopResetBehaviour, direction);

            sequence.Insert(0f, Tween.Float(owner, owner.name, transform.localScale[axis1], scale1, s => transform.SetLocalScale(axis1, s), duration));
            sequence.Insert(0f, Tween.Float(owner, owner.name, transform.localScale[axis2], scale2, s => transform.SetLocalScale(axis2, s), duration));

            return sequence;
        }

        public static Sequence DoLocalScaleXY(this Transform transform, float x, float y, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalScaleTwoAxes(transform, transform.gameObject, 0, 1, x, y, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoLocalScaleXY(this Transform transform, GameObject owner, float x, float y, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalScaleTwoAxes(transform, owner, 0, 1, x, y, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoLocalScaleXZ(this Transform transform, float x, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalScaleTwoAxes(transform, transform.gameObject, 0, 2, x, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoLocalScaleXZ(this Transform transform, GameObject owner, float x, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalScaleTwoAxes(transform, owner, 0, 2, x, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoLocalScaleYZ(this Transform transform, float y, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalScaleTwoAxes(transform, transform.gameObject, 1, 2, y, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoLocalScaleYZ(this Transform transform, GameObject owner, float y, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalScaleTwoAxes(transform, owner, 1, 2, y, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoLocalScale
        public static Tween<Vector3, TweakVector3> DoLocalScale(this Transform transform, float scale, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalScale(transform, transform.gameObject, new Vector3(scale, scale, scale), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoLocalScale(this Transform transform, GameObject owner, float scale, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalScale(transform, owner, new Vector3(scale, scale, scale), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoLocalScale(this Transform transform, float x, float y, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalScale(transform, transform.gameObject, new Vector3(x, y, z), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoLocalScale(this Transform transform, GameObject owner, float x, float y, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalScale(transform, owner, new Vector3(x, y, z), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoLocalScale(this Transform transform, Vector3 scale, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalScale(transform, transform.gameObject, scale, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoLocalScale(this Transform transform, GameObject owner, Vector3 scale, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Vector3(owner, owner.name, transform.localScale, scale, s => transform.localScale = s, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        //Sequence Shake(this Transform transform, GameObject owner, string name, float duration, int count, float strenght, float randomness)
        //{
            
        //}
    }
}