using Redcode.Extensions;
using Redcode.Paths;
using Redcode.Tweens.Extensions;
using Redcode.Tweens.Tweaks;
using UnityEngine;

namespace Redcode.Tweens
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
        private static Tween<float, TweakFloat> DoPositionOneAxis(GameObject owner, Transform transform, int axis, float position, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(owner, owner.name, transform.position[axis], position, p => transform.SetPosition(axis, p), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPositionX(this Transform transform, float x, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPositionOneAxis(transform.gameObject, transform, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPositionX(this Transform transform, GameObject owner, float x, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPositionOneAxis(owner, transform, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPositionY(this Transform transform, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPositionOneAxis(transform.gameObject, transform, 1, y, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPositionY(this Transform transform, GameObject owner, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPositionOneAxis(owner, transform, 1, y, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPositionZ(this Transform transform, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPositionOneAxis(transform.gameObject, transform, 2, z, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPositionZ(this Transform transform, GameObject owner, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPositionOneAxis(owner, transform, 2, z, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoPositionTwoAxes
        private static Sequence DoPositionTwoAxes(GameObject owner, Transform transform, int axis1, int axis2, float position1, float position2, float duration, Ease formula, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            var sequence = new Sequence(owner, owner.name, formula, loopsCount, loopType, loopResetBehaviour, direction);

            sequence.Insert(0f, Tween.Float(owner, owner.name, transform.position[axis1], position1, p => transform.SetPosition(axis1, p), duration));
            sequence.Insert(0f, Tween.Float(owner, owner.name, transform.position[axis2], position2, p => transform.SetPosition(axis2, p), duration));

            return sequence;
        }

        public static Sequence DoPositionXY(this Transform transform, float x, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoPositionTwoAxes(transform.gameObject, transform, 0, 1, x, y, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoPositionXY(this Transform transform, GameObject owner, float x, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoPositionTwoAxes(owner, transform, 0, 1, x, y, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoPositionXZ(this Transform transform, float x, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoPositionTwoAxes(transform.gameObject, transform, 0, 2, x, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoPositionXZ(this Transform transform, GameObject owner, float x, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoPositionTwoAxes(owner, transform, 0, 2, x, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoPositionYZ(this Transform transform, float y, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoPositionTwoAxes(transform.gameObject, transform, 1, 2, y, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoPositionYZ(this Transform transform, GameObject owner, float y, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoPositionTwoAxes(owner, transform, 1, 2, y, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoPosition
        public static Tween<Vector3, TweakVector3> DoPosition(this Transform transform, float x, float y, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPosition(transform, transform.gameObject, new Vector3(x, y, z), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoPosition(this Transform transform, GameObject owner, float x, float y, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPosition(transform, owner, new Vector3(x, y, z), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoPosition(this Transform transform, Vector3 position, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPosition(transform, transform.gameObject, position, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoPosition(this Transform transform, GameObject owner, Vector3 position, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
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
        private static Tween<float, TweakFloat> DoLocalPositionOneAxis(Transform transform, GameObject owner, int axis, float position, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(owner, owner.name, transform.localPosition[axis], position, p => transform.SetLocalPosition(axis, p), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLocalPositionX(this Transform transform, float x, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalPositionOneAxis(transform, transform.gameObject, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLocalPositionX(this Transform transform, GameObject owner, float x, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalPositionOneAxis(transform, owner, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLocalPositionY(this Transform transform, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalPositionOneAxis(transform, transform.gameObject, 1, y, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLocalPositionY(this Transform transform, GameObject owner, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalPositionOneAxis(transform, owner, 1, y, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLocalPositionZ(this Transform transform, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalPositionOneAxis(transform, transform.gameObject, 2, z, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLocalPositionZ(this Transform transform, GameObject owner, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalPositionOneAxis(transform, owner, 2, z, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoLocalPositionTwoAxes
        private static Sequence DoLocalPositionTwoAxes(Transform transform, GameObject owner, int axis1, int axis2, float position1, float position2, float duration, Ease formula, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            var sequence = new Sequence(owner, owner.name, formula, loopsCount, loopType, loopResetBehaviour, direction);

            sequence.Insert(0f, Tween.Float(owner, owner.name, transform.localPosition[axis1], position1, p => transform.SetLocalPosition(axis1, p), duration));
            sequence.Insert(0f, Tween.Float(owner, owner.name, transform.localPosition[axis2], position2, p => transform.SetLocalPosition(axis2, p), duration));

            return sequence;
        }

        public static Sequence DoLocalPositionXY(this Transform transform, float x, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalPositionTwoAxes(transform, transform.gameObject, 0, 1, x, y, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoLocalPositionXY(this Transform transform, GameObject owner, float x, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalPositionTwoAxes(transform, owner, 0, 1, x, y, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoLocalPositionXZ(this Transform transform, float x, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalPositionTwoAxes(transform, transform.gameObject, 0, 2, x, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoLocalPositionXZ(this Transform transform, GameObject owner, float x, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalPositionTwoAxes(transform, owner, 0, 2, x, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoLocalPositionYZ(this Transform transform, float y, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalPositionTwoAxes(transform, transform.gameObject, 1, 2, y, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoLocalPositionYZ(this Transform transform, GameObject owner, float y, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalPositionTwoAxes(transform, owner, 1, 2, y, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoLocalPosition
        public static Tween<Vector3, TweakVector3> DoLocalPosition(this Transform transform, float x, float y, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalPosition(transform, transform.gameObject, new Vector3(x, y, z), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoLocalPosition(this Transform transform, GameObject owner, float x, float y, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalPosition(transform, owner, new Vector3(x, y, z), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoLocalPosition(this Transform transform, Vector3 position, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalPosition(transform, transform.gameObject, position, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoLocalPosition(this Transform transform, GameObject owner, Vector3 position, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
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
        private static Tween<float, TweakFloat> DoEulerAnglesOneAxis(Transform transform, GameObject owner, int axis, float angle, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(owner, owner.name, transform.eulerAngles[axis], angle, a => transform.SetEulerAngle(axis, a), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoEulerAnglesX(this Transform transform, float x, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoEulerAnglesOneAxis(transform, transform.gameObject, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoEulerAnglesX(this Transform transform, GameObject owner, float x, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoEulerAnglesOneAxis(transform, owner, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoEulerAnglesY(this Transform transform, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoEulerAnglesOneAxis(transform, transform.gameObject, 1, y, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoEulerAnglesY(this Transform transform, GameObject owner, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoEulerAnglesOneAxis(transform, owner, 1, y, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoEulerAnglesZ(this Transform transform, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoEulerAnglesOneAxis(transform, transform.gameObject, 2, z, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoEulerAnglesZ(this Transform transform, GameObject owner, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoEulerAnglesOneAxis(transform, owner, 2, z, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoEulerAnglesTwoAxes
        private static Sequence DoEulerAnglesTwoAxis(Transform transform, GameObject owner, int axis1, int axis2, float angle1, float angle2, float duration, Ease formula, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            var sequence = new Sequence(owner, owner.name, formula, loopsCount, loopType, loopResetBehaviour, direction);

            sequence.Insert(0f, Tween.Float(owner, owner.name, transform.eulerAngles[axis1], angle1, a => transform.SetEulerAngle(axis1, a), duration));
            sequence.Insert(0f, Tween.Float(owner, owner.name, transform.eulerAngles[axis2], angle2, a => transform.SetEulerAngle(axis2, a), duration));

            return sequence;
        }

        public static Sequence DoEulerAnglesXY(this Transform transform, float x, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoEulerAnglesTwoAxis(transform, transform.gameObject, 0, 1, x, y, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoEulerAnglesXY(this Transform transform, GameObject owner, float x, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoEulerAnglesTwoAxis(transform, owner, 0, 1, x, y, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoEulerAnglesXZ(this Transform transform, float x, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoEulerAnglesTwoAxis(transform, transform.gameObject, 0, 2, x, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoEulerAnglesXZ(this Transform transform, GameObject owner, float x, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoEulerAnglesTwoAxis(transform, owner, 0, 2, x, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoEulerAnglesYZ(this Transform transform, float y, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoEulerAnglesTwoAxis(transform, transform.gameObject, 1, 2, y, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoEulerAnglesYZ(this Transform transform, GameObject owner, float y, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoEulerAnglesTwoAxis(transform, owner, 1, 2, y, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoEulerAngles
        public static Tween<Vector3, TweakVector3> DoEulerAngles(this Transform transform, float x, float y, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoEulerAngles(transform, transform.gameObject, new Vector3(x, y, z), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoEulerAngles(this Transform transform, GameObject owner, float x, float y, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoEulerAngles(transform, owner, new Vector3(x, y, z), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoEulerAngles(this Transform transform, Vector3 angles, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoEulerAngles(transform, transform.gameObject, angles, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoEulerAngles(this Transform transform, GameObject owner, Vector3 angles, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
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
        private static Tween<float, TweakFloat> DoLocalEulerAnglesOneAxis(Transform transform, GameObject owner, int axis, float angle, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(owner, owner.name, transform.localEulerAngles[axis], angle, a => transform.SetLocalEulerAngle(axis, a), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLocalEulerAnglesX(this Transform transform, float x, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalEulerAnglesOneAxis(transform, transform.gameObject, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLocalEulerAnglesX(this Transform transform, GameObject owner, float x, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalEulerAnglesOneAxis(transform, owner, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLocalEulerAnglesY(this Transform transform, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalEulerAnglesOneAxis(transform, transform.gameObject, 1, y, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLocalEulerAnglesY(this Transform transform, GameObject owner, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalEulerAnglesOneAxis(transform, owner, 1, y, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLocalEulerAnglesZ(this Transform transform, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalEulerAnglesOneAxis(transform, transform.gameObject, 2, z, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLocalEulerAnglesZ(this Transform transform, GameObject owner, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalEulerAnglesOneAxis(transform, owner, 2, z, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoLocalEulerAnglesTwoAxes
        private static Sequence DoLocalEulerAnglesTwoAxis(Transform transform, GameObject owner, int axis1, int axis2, float angle1, float angle2, float duration, Ease formula, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            var sequence = new Sequence(owner, owner.name, formula, loopsCount, loopType, loopResetBehaviour, direction);

            sequence.Insert(0f, Tween.Float(owner, owner.name, transform.localEulerAngles[axis1], angle1, a => transform.SetLocalEulerAngle(axis1, a), duration));
            sequence.Insert(0f, Tween.Float(owner, owner.name, transform.localEulerAngles[axis2], angle2, a => transform.SetLocalEulerAngle(axis2, a), duration));

            return sequence;
        }

        public static Sequence DoLocalEulerAnglesXY(this Transform transform, float x, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalEulerAnglesTwoAxis(transform, transform.gameObject, 0, 1, x, y, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoLocalEulerAnglesXY(this Transform transform, GameObject owner, float x, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalEulerAnglesTwoAxis(transform, owner, 0, 1, x, y, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoLocalEulerAnglesXZ(this Transform transform, float x, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalEulerAnglesTwoAxis(transform, transform.gameObject, 0, 2, x, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoLocalEulerAnglesXZ(this Transform transform, GameObject owner, float x, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalEulerAnglesTwoAxis(transform, owner, 0, 2, x, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoLocalEulerAnglesYZ(this Transform transform, float y, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalEulerAnglesTwoAxis(transform, transform.gameObject, 1, 2, y, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoLocalEulerAnglesYZ(this Transform transform, GameObject owner, float y, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalEulerAnglesTwoAxis(transform, owner, 1, 2, y, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoLocalEulerAngles
        public static Tween<Vector3, TweakVector3> DoLocalEulerAngles(this Transform transform, float x, float y, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalEulerAngles(transform, transform.gameObject, new Vector3(x, y, z), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoLocalEulerAngles(this Transform transform, GameObject owner, float x, float y, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalEulerAngles(transform, owner, new Vector3(x, y, z), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoLocalEulerAngles(this Transform transform, Vector3 angles, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalEulerAngles(transform, transform.gameObject, angles, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoLocalEulerAngles(this Transform transform, GameObject owner, Vector3 angles, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Vector3(owner, owner.name, transform.localEulerAngles, angles, a => transform.eulerAngles = a, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoRotation
        public static Tween<Quaternion, TweakQuaternion> DoRotation(this Transform transform, Quaternion rotation, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoRotation(transform, transform.gameObject, rotation, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Quaternion, TweakQuaternion> DoRotation(this Transform transform, GameObject owner, Quaternion rotation, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Quaternion(owner, owner.name, transform.rotation, rotation, r => transform.rotation = r, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoLocalRotation
        public static Tween<Quaternion, TweakQuaternion> DoLocalRotation(this Transform transform, Quaternion rotation, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalRotation(transform, transform.gameObject, rotation, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Quaternion, TweakQuaternion> DoLocalRotation(this Transform transform, GameObject owner, Quaternion rotation, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
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
        private static Tween<float, TweakFloat> DoLocalScaleOneAxis(Transform transform, GameObject owner, int axis, float scale, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(owner, owner.name, transform.localScale[axis], scale, s => transform.SetLocalScale(axis, s), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLocalScaleX(this Transform transform, float x, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalScaleOneAxis(transform, transform.gameObject, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLocalScaleX(this Transform transform, GameObject owner, float x, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalScaleOneAxis(transform, owner, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLocalScaleY(this Transform transform, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalScaleOneAxis(transform, transform.gameObject, 1, y, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLocalScaleY(this Transform transform, GameObject owner, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalScaleOneAxis(transform, owner, 1, y, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLocalScaleZ(this Transform transform, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalScaleOneAxis(transform, transform.gameObject, 2, z, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLocalScaleZ(this Transform transform, GameObject owner, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalScaleOneAxis(transform, owner, 2, z, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoLocalScaleTwoAxes
        private static Sequence DoLocalScaleTwoAxes(Transform transform, GameObject owner, int axis1, int axis2, float scale1, float scale2, float duration, Ease formula, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            var sequence = new Sequence(owner, owner.name, formula, loopsCount, loopType, loopResetBehaviour, direction);

            sequence.Insert(0f, Tween.Float(owner, owner.name, transform.localScale[axis1], scale1, s => transform.SetLocalScale(axis1, s), duration));
            sequence.Insert(0f, Tween.Float(owner, owner.name, transform.localScale[axis2], scale2, s => transform.SetLocalScale(axis2, s), duration));

            return sequence;
        }

        public static Sequence DoLocalScaleXY(this Transform transform, float x, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalScaleTwoAxes(transform, transform.gameObject, 0, 1, x, y, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoLocalScaleXY(this Transform transform, GameObject owner, float x, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalScaleTwoAxes(transform, owner, 0, 1, x, y, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoLocalScaleXZ(this Transform transform, float x, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalScaleTwoAxes(transform, transform.gameObject, 0, 2, x, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoLocalScaleXZ(this Transform transform, GameObject owner, float x, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalScaleTwoAxes(transform, owner, 0, 2, x, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoLocalScaleYZ(this Transform transform, float y, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalScaleTwoAxes(transform, transform.gameObject, 1, 2, y, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoLocalScaleYZ(this Transform transform, GameObject owner, float y, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalScaleTwoAxes(transform, owner, 1, 2, y, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoLocalScale
        public static Tween<Vector3, TweakVector3> DoLocalScale(this Transform transform, float scale, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalScale(transform, transform.gameObject, new Vector3(scale, scale, scale), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoLocalScale(this Transform transform, GameObject owner, float scale, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalScale(transform, owner, new Vector3(scale, scale, scale), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoLocalScale(this Transform transform, float x, float y, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalScale(transform, transform.gameObject, new Vector3(x, y, z), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoLocalScale(this Transform transform, GameObject owner, float x, float y, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalScale(transform, owner, new Vector3(x, y, z), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoLocalScale(this Transform transform, Vector3 scale, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalScale(transform, transform.gameObject, scale, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoLocalScale(this Transform transform, GameObject owner, Vector3 scale, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Vector3(owner, owner.name, transform.localScale, scale, s => transform.localScale = s, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoLookAt
        public static Tween<Quaternion, TweakQuaternion> DoLookAt(this Transform transform, GameObject gameObject, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLookAt(transform, transform.gameObject, gameObject.transform.position, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Quaternion, TweakQuaternion> DoLookAt(this Transform transform, GameObject owner, GameObject gameObject, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLookAt(transform, owner, gameObject.transform.position, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Quaternion, TweakQuaternion> DoLookAt(this Transform transform, Transform target, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLookAt(transform, transform.gameObject, target.position, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Quaternion, TweakQuaternion> DoLookAt(this Transform transform, GameObject owner, Transform target, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLookAt(transform, owner, target.position, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Quaternion, TweakQuaternion> DoLookAt(this Transform transform, Vector3 point, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLookAt(transform, transform.gameObject, point, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Quaternion, TweakQuaternion> DoLookAt(this Transform transform, GameObject owner, Vector3 point, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoRotation(transform, owner, Quaternion.LookRotation(point - transform.position), duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoShake
        #region DoShakePosition
        public static Sequence DoShakePosition(this Transform transform, int count = 10, float strenght = 1f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakePosition(transform, transform.gameObject, count, strenght, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakePosition(this Transform transform, Vector3Int count, float strenght = 1f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakePosition(transform, transform.gameObject, count, strenght, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakePosition(this Transform transform, int count, Vector3 strenght, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakePosition(transform, transform.gameObject, count, strenght, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakePosition(this Transform transform, Vector3Int count, Vector3 strenght, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakePosition(transform, transform.gameObject, count, strenght, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakePosition(this Transform transform, GameObject owner, int count = 10, float strenght = 1f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakePosition(transform, owner, new Vector3Int(count, count, count), new Vector3(strenght, strenght, strenght), duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakePosition(this Transform transform, GameObject owner, Vector3Int count, float strenght = 1f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakePosition(transform, owner, count, new Vector3(strenght, strenght, strenght), duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakePosition(this Transform transform, GameObject owner, int count, Vector3 strenght, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakePosition(transform, owner, new Vector3Int(count, count, count), strenght, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakePosition(this Transform transform, GameObject owner, Vector3Int count, Vector3 strenght, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            var sequence = new Sequence(owner, owner.name);

            sequence.Insert(0f, Tween.Shake(owner, owner.name, transform.position.x, count.x, strenght.x, duration, x => transform.position = transform.position.WithX(x), leftSmoothness, rightSmoothness));
            sequence.Insert(0f, Tween.Shake(owner, owner.name, transform.position.y, count.y, strenght.y, duration, y => transform.position = transform.position.WithY(y), leftSmoothness, rightSmoothness));
            sequence.Insert(0f, Tween.Shake(owner, owner.name, transform.position.z, count.z, strenght.z, duration, z => transform.position = transform.position.WithZ(z), leftSmoothness, rightSmoothness));

            return sequence;
        }
        #endregion

        #region DoShakeLocalPosition
        public static Sequence DoShakeLocalPosition(this Transform transform, int count = 10, float strenght = 1f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeLocalPosition(transform, transform.gameObject, count, strenght, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeLocalPosition(this Transform transform, Vector3Int count, float strenght = 1f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeLocalPosition(transform, transform.gameObject, count, strenght, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeLocalPosition(this Transform transform, int count, Vector3 strenght, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeLocalPosition(transform, transform.gameObject, count, strenght, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeLocalPosition(this Transform transform, Vector3Int count, Vector3 strenght, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeLocalPosition(transform, transform.gameObject, count, strenght, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeLocalPosition(this Transform transform, GameObject owner, int count = 10, float strenght = 1f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeLocalPosition(transform, owner, new Vector3Int(count, count, count), new Vector3(strenght, strenght, strenght), duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeLocalPosition(this Transform transform, GameObject owner, Vector3Int count, float strenght = 1f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeLocalPosition(transform, owner, count, new Vector3(strenght, strenght, strenght), duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeLocalPosition(this Transform transform, GameObject owner, int count, Vector3 strenght, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeLocalPosition(transform, owner, new Vector3Int(count, count, count), strenght, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeLocalPosition(this Transform transform, GameObject owner, Vector3Int count, Vector3 strenght, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            var sequence = new Sequence(owner, owner.name);

            sequence.Insert(0f, Tween.Shake(owner, owner.name, transform.localPosition.x, count.x, strenght.x, duration, x => transform.localPosition = transform.localPosition.WithX(x), leftSmoothness, rightSmoothness));
            sequence.Insert(0f, Tween.Shake(owner, owner.name, transform.localPosition.y, count.y, strenght.y, duration, y => transform.localPosition = transform.localPosition.WithY(y), leftSmoothness, rightSmoothness));
            sequence.Insert(0f, Tween.Shake(owner, owner.name, transform.localPosition.z, count.z, strenght.z, duration, z => transform.localPosition = transform.localPosition.WithZ(z), leftSmoothness, rightSmoothness));

            return sequence;
        }
        #endregion

        #region DoShakeEulerAngles
        public static Sequence DoShakeEulerAngles(this Transform transform, int count = 8, float angles = 45f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeEulerAngles(transform, transform.gameObject, count, angles, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeEulerAngles(this Transform transform, Vector3Int count, float angles = 45f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeEulerAngles(transform, transform.gameObject, count, angles, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeEulerAngles(this Transform transform, int count, Vector3 angles, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeEulerAngles(transform, transform.gameObject, count, angles, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeEulerAngles(this Transform transform, Vector3Int count, Vector3 angles, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeEulerAngles(transform, transform.gameObject, count, angles, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeEulerAngles(this Transform transform, GameObject owner, int count = 8, float angles = 45f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeEulerAngles(transform, owner, new Vector3Int(count, count, count), new Vector3(angles, angles, angles), duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeEulerAngles(this Transform transform, GameObject owner, Vector3Int count, float angles = 45f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeEulerAngles(transform, owner, count, new Vector3(angles, angles, angles), duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeEulerAngles(this Transform transform, GameObject owner, int count, Vector3 angles, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeEulerAngles(transform, owner, new Vector3Int(count, count, count), angles, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeEulerAngles(this Transform transform, GameObject owner, Vector3Int count, Vector3 angles, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            var sequence = new Sequence(owner, owner.name);

            sequence.Insert(0f, Tween.Shake(owner, owner.name, transform.eulerAngles.x, count.x, angles.x, duration, x => transform.eulerAngles = transform.eulerAngles.WithX(x), leftSmoothness, rightSmoothness));
            sequence.Insert(0f, Tween.Shake(owner, owner.name, transform.eulerAngles.y, count.y, angles.y, duration, y => transform.eulerAngles = transform.eulerAngles.WithY(y), leftSmoothness, rightSmoothness));
            sequence.Insert(0f, Tween.Shake(owner, owner.name, transform.eulerAngles.z, count.z, angles.z, duration, z => transform.eulerAngles = transform.eulerAngles.WithZ(z), leftSmoothness, rightSmoothness));

            return sequence;
        }
        #endregion

        #region DoShakeLocalEulerAngles
        public static Sequence DoShakeLocalEulerAngles(this Transform transform, int count = 8, float angles = 45f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeLocalEulerAngles(transform, transform.gameObject, count, angles, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeLocalEulerAngles(this Transform transform, Vector3Int count, float angles = 45f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeLocalEulerAngles(transform, transform.gameObject, count, angles, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeLocalEulerAngles(this Transform transform, int count, Vector3 angles, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeLocalEulerAngles(transform, transform.gameObject, count, angles, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeLocalEulerAngles(this Transform transform, Vector3Int count, Vector3 angles, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeLocalEulerAngles(transform, transform.gameObject, count, angles, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeLocalEulerAngles(this Transform transform, GameObject owner, int count = 8, float angles = 45f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeLocalEulerAngles(transform, owner, new Vector3Int(count, count, count), new Vector3(angles, angles, angles), duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeLocalEulerAngles(this Transform transform, GameObject owner, Vector3Int count, float angles = 45f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeLocalEulerAngles(transform, owner, count, new Vector3(angles, angles, angles), duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeLocalEulerAngles(this Transform transform, GameObject owner, int count, Vector3 angles, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeLocalEulerAngles(transform, owner, new Vector3Int(count, count, count), angles, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeLocalEulerAngles(this Transform transform, GameObject owner, Vector3Int count, Vector3 angles, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            var sequence = new Sequence(owner, owner.name);

            sequence.Insert(0f, Tween.Shake(owner, owner.name, transform.localEulerAngles.x, count.x, angles.x, duration, x => transform.localEulerAngles = transform.localEulerAngles.WithX(x), leftSmoothness, rightSmoothness));
            sequence.Insert(0f, Tween.Shake(owner, owner.name, transform.localEulerAngles.y, count.y, angles.y, duration, y => transform.localEulerAngles = transform.localEulerAngles.WithY(y), leftSmoothness, rightSmoothness));
            sequence.Insert(0f, Tween.Shake(owner, owner.name, transform.localEulerAngles.z, count.z, angles.z, duration, z => transform.localEulerAngles = transform.localEulerAngles.WithZ(z), leftSmoothness, rightSmoothness));

            return sequence;
        }
        #endregion

        #region DoShakeLocalScale
        public static Sequence DoShakeLocalScale(this Transform transform, int count = 10, float scale = 1f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeLocalScale(transform, transform.gameObject, count, scale, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeLocalScale(this Transform transform, Vector3Int count, float scale = 1f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeLocalScale(transform, transform.gameObject, count, scale, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeLocalScale(this Transform transform, int count, Vector3 scale, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeLocalScale(transform, transform.gameObject, count, scale, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeLocalScale(this Transform transform, Vector3Int count, Vector3 scale, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeLocalScale(transform, transform.gameObject, count, scale, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeLocalScale(this Transform transform, GameObject owner, int count = 10, float scale = 1f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeLocalScale(transform, owner, new Vector3Int(count, count, count), new Vector3(scale, scale, scale), duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeLocalScale(this Transform transform, GameObject owner, Vector3Int count, float scale = 1f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeLocalScale(transform, owner, count, new Vector3(scale, scale, scale), duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeLocalScale(this Transform transform, GameObject owner, int count, Vector3 scale, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeLocalScale(transform, owner, new Vector3Int(count, count, count), scale, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeLocalScale(this Transform transform, GameObject owner, Vector3Int count, Vector3 scale, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            var sequence = new Sequence(owner, owner.name);

            sequence.Insert(0f, Tween.Shake(owner, owner.name, transform.localScale.x, count.x, scale.x, duration, x => transform.localScale = transform.localScale.WithX(x), leftSmoothness, rightSmoothness));
            sequence.Insert(0f, Tween.Shake(owner, owner.name, transform.localScale.y, count.y, scale.y, duration, y => transform.localScale = transform.localScale.WithY(y), leftSmoothness, rightSmoothness));
            sequence.Insert(0f, Tween.Shake(owner, owner.name, transform.localScale.z, count.z, scale.z, duration, z => transform.localScale = transform.localScale.WithZ(z), leftSmoothness, rightSmoothness));

            return sequence;
        }
        #endregion
        #endregion

        #region DoPunch
        #region DoPunchPosition
        public static Sequence DoPunchPosition(this Transform transform, Vector3 vector, int count = 10, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            return DoPunchPosition(transform, transform.gameObject, vector, count, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoPunchPosition(this Transform transform, GameObject owner, Vector3 vector, int count, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            var sequence = new Sequence(owner, owner.name);

            sequence.Insert(0f, Tween.Punch(owner, owner.name, transform.position.x, count, vector.x, duration, x => transform.position = transform.position.WithX(x), leftSmoothness, rightSmoothness));
            sequence.Insert(0f, Tween.Punch(owner, owner.name, transform.position.y, count, vector.y, duration, y => transform.position = transform.position.WithY(y), leftSmoothness, rightSmoothness));
            sequence.Insert(0f, Tween.Punch(owner, owner.name, transform.position.z, count, vector.z, duration, z => transform.position = transform.position.WithZ(z), leftSmoothness, rightSmoothness));

            return sequence;
        }
        #endregion

        #region DoPunchLocalPosition
        public static Sequence DoPunchLocalPosition(this Transform transform, Vector3 vector, int count = 10, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            return DoPunchLocalPosition(transform, transform.gameObject, vector, count, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoPunchLocalPosition(this Transform transform, GameObject owner, Vector3 vector, int count, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            var sequence = new Sequence(owner, owner.name);

            sequence.Insert(0f, Tween.Punch(owner, owner.name, transform.localPosition.x, count, vector.x, duration, x => transform.localPosition = transform.localPosition.WithX(x), leftSmoothness, rightSmoothness));
            sequence.Insert(0f, Tween.Punch(owner, owner.name, transform.localPosition.y, count, vector.y, duration, y => transform.localPosition = transform.localPosition.WithY(y), leftSmoothness, rightSmoothness));
            sequence.Insert(0f, Tween.Punch(owner, owner.name, transform.localPosition.z, count, vector.z, duration, z => transform.localPosition = transform.localPosition.WithZ(z), leftSmoothness, rightSmoothness));

            return sequence;
        }
        #endregion

        #region DoPunchEulerAngles
        public static Sequence DoPunchEulerAngles(this Transform transform, Vector3 angles, int count = 10, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            return DoPunchEulerAngles(transform, transform.gameObject, angles, count, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoPunchEulerAngles(this Transform transform, GameObject owner, Vector3 angles, int count, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            var sequence = new Sequence(owner, owner.name);

            sequence.Insert(0f, Tween.Punch(owner, owner.name, transform.eulerAngles.x, count, angles.x, duration, x => transform.eulerAngles = transform.eulerAngles.WithX(x), leftSmoothness, rightSmoothness));
            sequence.Insert(0f, Tween.Punch(owner, owner.name, transform.eulerAngles.y, count, angles.y, duration, y => transform.eulerAngles = transform.eulerAngles.WithY(y), leftSmoothness, rightSmoothness));
            sequence.Insert(0f, Tween.Punch(owner, owner.name, transform.eulerAngles.z, count, angles.z, duration, z => transform.eulerAngles = transform.eulerAngles.WithZ(z), leftSmoothness, rightSmoothness));

            return sequence;
        }
        #endregion

        #region DoPunchLocalEulerAngles
        public static Sequence DoPunchLocalEulerAngles(this Transform transform, Vector3 angles, int count = 10, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            return DoPunchLocalEulerAngles(transform, transform.gameObject, angles, count, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoPunchLocalEulerAngles(this Transform transform, GameObject owner, Vector3 angles, int count, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            var sequence = new Sequence(owner, owner.name);

            sequence.Insert(0f, Tween.Punch(owner, owner.name, transform.localEulerAngles.x, count, angles.x, duration, x => transform.localEulerAngles = transform.localEulerAngles.WithX(x), leftSmoothness, rightSmoothness));
            sequence.Insert(0f, Tween.Punch(owner, owner.name, transform.localEulerAngles.y, count, angles.y, duration, y => transform.localEulerAngles = transform.localEulerAngles.WithY(y), leftSmoothness, rightSmoothness));
            sequence.Insert(0f, Tween.Punch(owner, owner.name, transform.localEulerAngles.z, count, angles.z, duration, z => transform.localEulerAngles = transform.localEulerAngles.WithZ(z), leftSmoothness, rightSmoothness));

            return sequence;
        }
        #endregion

        #region DoPunchRotation
        public static Tween<float, TweakFloat> DoPunchRotation(this Transform transform, Vector3 direction, int count = 4, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            return DoPunchRotation(transform, transform.gameObject, Quaternion.LookRotation(direction), count, duration, leftSmoothness, rightSmoothness);
        }

        public static Tween<float, TweakFloat> DoPunchRotation(this Transform transform, GameObject owner, Vector3 direction, int count = 4, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            return DoPunchRotation(transform, owner, Quaternion.LookRotation(direction), count, duration, leftSmoothness, rightSmoothness);
        }

        public static Tween<float, TweakFloat> DoPunchRotation(this Transform transform, Quaternion rotation, int count = 4, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            return DoPunchRotation(transform, transform.gameObject, rotation, count, duration, leftSmoothness, rightSmoothness);
        }

        public static Tween<float, TweakFloat> DoPunchRotation(this Transform transform, GameObject owner, Quaternion rotation, int count = 4, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            return Tween.Punch(owner, owner.name, transform.rotation, count, rotation, duration, rot => transform.rotation = rot, leftSmoothness, rightSmoothness);
        }
        #endregion

        #region DoPunchLocalRotation
        public static Tween<float, TweakFloat> DoPunchLocalRotation(this Transform transform, Vector3 direction, int count = 4, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            return DoPunchLocalRotation(transform, transform.gameObject, Quaternion.LookRotation(direction), count, duration, leftSmoothness, rightSmoothness);
        }

        public static Tween<float, TweakFloat> DoPunchLocalRotation(this Transform transform, GameObject owner, Vector3 direction, int count = 4, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            return DoPunchLocalRotation(transform, owner, Quaternion.LookRotation(direction), count, duration, leftSmoothness, rightSmoothness);
        }

        public static Tween<float, TweakFloat> DoPunchLocalRotation(this Transform transform, Quaternion rotation, int count = 4, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            return DoPunchLocalRotation(transform, transform.gameObject, rotation, count, duration, leftSmoothness, rightSmoothness);
        }

        public static Tween<float, TweakFloat> DoPunchLocalRotation(this Transform transform, GameObject owner, Quaternion rotation, int count = 4, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            return Tween.Punch(owner, owner.name, transform.localRotation, count, rotation, duration, rot => transform.localRotation = rot, leftSmoothness, rightSmoothness);
        }
        #endregion

        #region DoPunchLocalScale
        public static Sequence DoPunchLocalScale(this Transform transform, float scale = 0.5f, int count = 10, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            return DoPunchLocalScale(transform, transform.gameObject, new Vector3(scale, scale, scale), count, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoPunchLocalScale(this Transform transform, Vector3 scale, int count = 10, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            return DoPunchLocalScale(transform, transform.gameObject, scale, count, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoPunchLocalScale(this Transform transform, GameObject owner, Vector3 scale, int count, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            var sequence = new Sequence(owner, owner.name);

            sequence.Insert(0f, Tween.Punch(owner, owner.name, transform.localScale.x, count, scale.x, duration, x => transform.localScale = transform.localScale.WithX(x), leftSmoothness, rightSmoothness));
            sequence.Insert(0f, Tween.Punch(owner, owner.name, transform.localScale.y, count, scale.y, duration, y => transform.localScale = transform.localScale.WithY(y), leftSmoothness, rightSmoothness));
            sequence.Insert(0f, Tween.Punch(owner, owner.name, transform.localScale.z, count, scale.z, duration, z => transform.localScale = transform.localScale.WithZ(z), leftSmoothness, rightSmoothness));

            return sequence;
        }
        #endregion
        #endregion

        public static Tween<float, TweakFloat> DoMoveAlongPath(this Transform transform, Path path, float duration, PathFollowOptions pathFollowOptions = PathFollowOptions.UsePathDirection) => DoMoveAlongPath(transform, null, path, duration, pathFollowOptions);

        public static Tween<float, TweakFloat> DoMoveAlongPath(this Transform transform, GameObject owner, Path path, float duration, PathFollowOptions pathFollowOptions = PathFollowOptions.UsePathDirection)
        {
            return Tween.Float(owner, 0f, 1f, p =>
            {
                var pointData = path.GetPointAtDistance(p);

                transform.position = pointData.Position;
                if (pathFollowOptions != PathFollowOptions.None)
                    transform.rotation = pathFollowOptions == PathFollowOptions.UsePointRotation ? pointData.Rotation : Quaternion.LookRotation(pointData.Direction);
            }, duration);
        }

        public static (Tween<float, TweakFloat> tween, Path path) DoJump(this Transform transform, float height, Vector3 endPoint, float duration) => DoJump(transform, null, height, endPoint, duration);

        public static (Tween<float, TweakFloat> tween, Path path) DoJump(this Transform transform, GameObject owner, float height, Vector3 endPoint, float duration)
        {
            height = Mathf.Max(endPoint.y - transform.position.y, 0f) + height;
            var path = Path.Create(transform.position, true, Vector3.zero.WithY(transform.position.y - 5f), Vector3.zero, Vector3.Lerp(transform.position, endPoint, 0.5f).WithY(height), endPoint, endPoint.WithY(endPoint.y - 5f));
            path.Resolution = 10;

            var tween = Tween.Float(owner, 0f, 1f, p => transform.position = path.GetPointAtDistance(p).Position, duration, Ease.InOutQuad);
            return (tween, path);
        }
    }
}