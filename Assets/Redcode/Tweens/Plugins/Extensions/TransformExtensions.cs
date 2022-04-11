using Redcode.Extensions;
using Redcode.Paths;
using Redcode.Tweens.Extensions;
using Redcode.Tweens.Tweaks;
using UnityEngine;

namespace Redcode.Tweens
{
    public static class TransformExtensions
    {
        #region DoPositionOneAxis
        private static Tween<float, TweakFloat> DoPositionOneAxis(GameObject owner, Transform transform, int axis, float position, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(transform.position[axis], position, p => transform.position = transform.position.With(axis, p), duration, ease, loopsCount, loopType, direction).SetOwner(owner).SetName(owner.name);
        }

        public static Tween<float, TweakFloat> DoPositionX(this Transform transform, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPositionOneAxis(transform.gameObject, transform, 0, x, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPositionY(this Transform transform, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPositionOneAxis(transform.gameObject, transform, 1, y, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPositionZ(this Transform transform, float z, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPositionOneAxis(transform.gameObject, transform, 2, z, duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoPositionTwoAxes
        private static Tween<Vector2, TweakVector2> DoPositionTwoAxes(GameObject owner, Transform transform, int axis1, int axis2, float value1, float value2, float duration, Ease ease, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            return Tween.Vector2(transform.position.Get(axis1, axis2), new Vector2(value1, value2), c => transform.position = transform.position.With(axis1, c.x, axis2, c.y), duration, ease, loopsCount, loopType, direction).SetOwner(owner).SetName(owner.name);
        }

        public static Tween<Vector2, TweakVector2> DoPositionXY(this Transform transform, float x, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoPositionTwoAxes(transform.gameObject, transform, 0, 1, x, y, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoPositionXZ(this Transform transform, float x, float z, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoPositionTwoAxes(transform.gameObject, transform, 0, 2, x, z, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoPositionYZ(this Transform transform, float y, float z, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoPositionTwoAxes(transform.gameObject, transform, 1, 2, y, z, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoPosition
        public static Tween<Vector3, TweakVector3> DoPosition(this Transform transform, float x, float y, float z, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPosition(transform, new Vector3(x, y, z), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoPosition(this Transform transform, Vector3 position, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Vector3(transform.position, position, p => transform.position = p, duration, ease, loopsCount, loopType, direction).SetOwner(transform).SetName(transform.name);
        }
        #endregion

        #region DoLocalPositionOneAxis
        private static Tween<float, TweakFloat> DoLocalPositionOneAxis(Transform transform, GameObject owner, int axis, float position, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(transform.localPosition[axis], position, p => transform.localPosition = transform.localPosition.With(axis, p), duration, ease, loopsCount, loopType, direction).SetOwner(owner).SetName(owner.name);
        }

        public static Tween<float, TweakFloat> DoLocalPositionX(this Transform transform, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalPositionOneAxis(transform, transform.gameObject, 0, x, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLocalPositionY(this Transform transform, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalPositionOneAxis(transform, transform.gameObject, 1, y, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLocalPositionZ(this Transform transform, float z, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalPositionOneAxis(transform, transform.gameObject, 2, z, duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoLocalPositionTwoAxes
        private static Tween<Vector2, TweakVector2> DoLocalPositionTwoAxes(Transform transform, GameObject owner, int axis1, int axis2, float value1, float value2, float duration, Ease ease, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            return Tween.Vector2(transform.localPosition.Get(axis1, axis2), new Vector2(value1, value2), c => transform.localPosition = transform.localPosition.With(axis1, c.x, axis2, c.y), duration, ease, loopsCount, loopType, direction).SetOwner(owner).SetName(owner.name);
        }

        public static Tween<Vector2, TweakVector2> DoLocalPositionXY(this Transform transform, float x, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalPositionTwoAxes(transform, transform.gameObject, 0, 1, x, y, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoLocalPositionXZ(this Transform transform, float x, float z, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalPositionTwoAxes(transform, transform.gameObject, 0, 2, x, z, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoLocalPositionYZ(this Transform transform, float y, float z, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalPositionTwoAxes(transform, transform.gameObject, 1, 2, y, z, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoLocalPosition
        public static Tween<Vector3, TweakVector3> DoLocalPosition(this Transform transform, float x, float y, float z, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalPosition(transform, new Vector3(x, y, z), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoLocalPosition(this Transform transform, Vector3 position, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Vector3(transform.localPosition, position, p => transform.localPosition = p, duration, ease, loopsCount, loopType, direction).SetOwner(transform).SetName(transform.name);
        }
        #endregion

        #region DoEulerAnglesOneAxis
        private static Tween<float, TweakFloat> DoEulerAnglesOneAxis(Transform transform, GameObject owner, int axis, float angle, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(transform.eulerAngles[axis], angle, a => transform.eulerAngles = transform.eulerAngles.With(axis, a), duration, ease, loopsCount, loopType, direction).SetOwner(owner).SetName(owner.name);
        }

        public static Tween<float, TweakFloat> DoEulerAnglesX(this Transform transform, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoEulerAnglesOneAxis(transform, transform.gameObject, 0, x, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoEulerAnglesY(this Transform transform, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoEulerAnglesOneAxis(transform, transform.gameObject, 1, y, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoEulerAnglesZ(this Transform transform, float z, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoEulerAnglesOneAxis(transform, transform.gameObject, 2, z, duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoEulerAnglesTwoAxes
        private static Tween<Vector2, TweakVector2> DoEulerAnglesTwoAxis(Transform transform, GameObject owner, int axis1, int axis2, float angle1, float angle2, float duration, Ease ease, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            return Tween.Vector2(transform.eulerAngles.Get(axis1, axis2), new Vector2(angle1, angle2), c => transform.eulerAngles = transform.eulerAngles.With(axis1, c.x, axis2, c.y), duration, ease, loopsCount, loopType, direction).SetOwner(owner).SetName(owner.name);
        }

        public static Tween<Vector2, TweakVector2> DoEulerAnglesXY(this Transform transform, float x, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoEulerAnglesTwoAxis(transform, transform.gameObject, 0, 1, x, y, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoEulerAnglesXZ(this Transform transform, float x, float z, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoEulerAnglesTwoAxis(transform, transform.gameObject, 0, 2, x, z, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoEulerAnglesYZ(this Transform transform, float y, float z, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoEulerAnglesTwoAxis(transform, transform.gameObject, 1, 2, y, z, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoEulerAngles
        public static Tween<Vector3, TweakVector3> DoEulerAngles(this Transform transform, float x, float y, float z, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoEulerAngles(transform, new Vector3(x, y, z), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoEulerAngles(this Transform transform, Vector3 angles, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Vector3(transform.eulerAngles, angles, a => transform.eulerAngles = a, duration, ease, loopsCount, loopType, direction).SetOwner(transform).SetName(transform.name);
        }
        #endregion

        #region DoLocalEulerAnglesOneAxis
        private static Tween<float, TweakFloat> DoLocalEulerAnglesOneAxis(Transform transform, GameObject owner, int axis, float angle, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(transform.localEulerAngles[axis], angle, a => transform.localEulerAngles = transform.localEulerAngles.With(axis, a), duration, ease, loopsCount, loopType, direction).SetOwner(owner).SetName(owner.name);
        }

        public static Tween<float, TweakFloat> DoLocalEulerAnglesX(this Transform transform, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalEulerAnglesOneAxis(transform, transform.gameObject, 0, x, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLocalEulerAnglesY(this Transform transform, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalEulerAnglesOneAxis(transform, transform.gameObject, 1, y, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLocalEulerAnglesZ(this Transform transform, float z, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalEulerAnglesOneAxis(transform, transform.gameObject, 2, z, duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoLocalEulerAnglesTwoAxes
        private static Tween<Vector2, TweakVector2> DoLocalEulerAnglesTwoAxis(Transform transform, GameObject owner, int axis1, int axis2, float angle1, float angle2, float duration, Ease ease, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            return Tween.Vector2(transform.localEulerAngles.Get(axis1, axis2), new Vector2(angle1, angle2), c => transform.localEulerAngles = transform.localEulerAngles.With(axis1, c.x, axis2, c.y), duration, ease, loopsCount, loopType, direction).SetOwner(owner).SetName(owner.name);
        }

        public static Tween<Vector2, TweakVector2> DoLocalEulerAnglesXY(this Transform transform, float x, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalEulerAnglesTwoAxis(transform, transform.gameObject, 0, 1, x, y, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoLocalEulerAnglesXZ(this Transform transform, float x, float z, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalEulerAnglesTwoAxis(transform, transform.gameObject, 0, 2, x, z, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoLocalEulerAnglesYZ(this Transform transform, float y, float z, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalEulerAnglesTwoAxis(transform, transform.gameObject, 1, 2, y, z, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoLocalEulerAngles
        public static Tween<Vector3, TweakVector3> DoLocalEulerAngles(this Transform transform, float x, float y, float z, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalEulerAngles(transform, new Vector3(x, y, z), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoLocalEulerAngles(this Transform transform, Vector3 angles, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Vector3(transform.localEulerAngles, angles, a => transform.eulerAngles = a, duration, ease, loopsCount, loopType, direction).SetOwner(transform).SetName(transform.name);
        }
        #endregion

        public static Tween<Quaternion, TweakQuaternion> DoRotation(this Transform transform, Quaternion rotation, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Quaternion(transform.rotation, rotation, r => transform.rotation = r, duration, ease, loopsCount, loopType, direction).SetOwner(transform).SetName(transform.name);
        }

        
        public static Tween<Quaternion, TweakQuaternion> DoLocalRotation(this Transform transform, Quaternion rotation, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Quaternion(transform.localRotation, rotation, r => transform.localRotation = r, duration, ease, loopsCount, loopType, direction).SetOwner(transform).SetName(transform.name);
        }

        #region DoLocalScaleOneAxis
        private static Tween<float, TweakFloat> DoLocalScaleOneAxis(Transform transform, GameObject owner, int axis, float scale, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(transform.localScale[axis], scale, s => transform.localScale = transform.localScale.With(axis, s), duration, ease, loopsCount, loopType, direction).SetOwner(owner).SetName(owner.name);
        }

        public static Tween<float, TweakFloat> DoLocalScaleX(this Transform transform, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalScaleOneAxis(transform, transform.gameObject, 0, x, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLocalScaleY(this Transform transform, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalScaleOneAxis(transform, transform.gameObject, 1, y, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoLocalScaleZ(this Transform transform, float z, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalScaleOneAxis(transform, transform.gameObject, 2, z, duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoLocalScaleTwoAxes
        private static Tween<Vector2, TweakVector2> DoLocalScaleTwoAxes(Transform transform, GameObject owner, int axis1, int axis2, float scale1, float scale2, float duration, Ease ease, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            return Tween.Vector2(transform.localScale.Get(axis1, axis2), new Vector2(scale1, scale2), c => transform.localScale = transform.localScale.With(axis1, c.x, axis2, c.y), duration, ease, loopsCount, loopType, direction).SetOwner(owner).SetName(owner.name);
        }

        public static Tween<Vector2, TweakVector2> DoLocalScaleXY(this Transform transform, float x, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalScaleTwoAxes(transform, transform.gameObject, 0, 1, x, y, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoLocalScaleXZ(this Transform transform, float x, float z, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalScaleTwoAxes(transform, transform.gameObject, 0, 2, x, z, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoLocalScaleYZ(this Transform transform, float y, float z, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoLocalScaleTwoAxes(transform, transform.gameObject, 1, 2, y, z, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoLocalScale
        public static Tween<Vector3, TweakVector3> DoLocalScale(this Transform transform, float scale, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalScale(transform, new Vector3(scale, scale, scale), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoLocalScale(this Transform transform, float x, float y, float z, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLocalScale(transform, new Vector3(x, y, z), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoLocalScale(this Transform transform, Vector3 scale, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Vector3(transform.localScale, scale, s => transform.localScale = s, duration, ease, loopsCount, loopType, direction).SetOwner(transform).SetName(transform.name);
        }
        #endregion

        #region DoLookAt
        public static Tween<Quaternion, TweakQuaternion> DoLookAt(this Transform transform, GameObject gameObject, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLookAt(transform, gameObject.transform.position, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Quaternion, TweakQuaternion> DoLookAt(this Transform transform, Transform target, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLookAt(transform, target.position, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Quaternion, TweakQuaternion> DoLookAt(this Transform transform, Vector3 point, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoRotation(transform, Quaternion.LookRotation(point - transform.position), duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoShake
        #region DoShakePosition
        public static Sequence DoShakePosition(this Transform transform, int count = 10, float strenght = 1f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakePosition(transform, count, strenght, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakePosition(this Transform transform, Vector3Int count, float strenght = 1f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakePosition(transform, count, strenght, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakePosition(this Transform transform, int count, Vector3 strenght, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakePosition(transform, count, strenght, duration, leftSmoothness, rightSmoothness);
        }
        
        public static Sequence DoShakePosition(this Transform transform, Vector3Int count, Vector3 strenght, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            var sequence = new Sequence(transform.gameObject, transform.name);

            sequence.Insert(0f, Tween.Shake(transform.position.x, count.x, strenght.x, duration, x => transform.position = transform.position.WithX(x), leftSmoothness, rightSmoothness).SetOwner(transform).SetName(transform.name));
            sequence.Insert(0f, Tween.Shake(transform.position.y, count.y, strenght.y, duration, y => transform.position = transform.position.WithY(y), leftSmoothness, rightSmoothness).SetOwner(transform).SetName(transform.name));
            sequence.Insert(0f, Tween.Shake(transform.position.z, count.z, strenght.z, duration, z => transform.position = transform.position.WithZ(z), leftSmoothness, rightSmoothness).SetOwner(transform).SetName(transform.name));

            return sequence;
        }
        #endregion

        #region DoShakeLocalPosition
        public static Sequence DoShakeLocalPosition(this Transform transform, int count = 10, float strenght = 1f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeLocalPosition(transform, count, strenght, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeLocalPosition(this Transform transform, Vector3Int count, float strenght = 1f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeLocalPosition(transform, count, strenght, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeLocalPosition(this Transform transform, int count, Vector3 strenght, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeLocalPosition(transform, count, strenght, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeLocalPosition(this Transform transform, Vector3Int count, Vector3 strenght, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            var sequence = new Sequence(transform.gameObject, transform.name);

            sequence.Insert(0f, Tween.Shake(transform.localPosition.x, count.x, strenght.x, duration, x => transform.localPosition = transform.localPosition.WithX(x), leftSmoothness, rightSmoothness).SetOwner(transform).SetName(transform.name));
            sequence.Insert(0f, Tween.Shake(transform.localPosition.y, count.y, strenght.y, duration, y => transform.localPosition = transform.localPosition.WithY(y), leftSmoothness, rightSmoothness).SetOwner(transform).SetName(transform.name));
            sequence.Insert(0f, Tween.Shake(transform.localPosition.z, count.z, strenght.z, duration, z => transform.localPosition = transform.localPosition.WithZ(z), leftSmoothness, rightSmoothness).SetOwner(transform).SetName(transform.name));

            return sequence;
        }
        #endregion

        #region DoShakeEulerAngles
        public static Sequence DoShakeEulerAngles(this Transform transform, int count = 8, float angles = 45f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeEulerAngles(transform, count, angles, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeEulerAngles(this Transform transform, Vector3Int count, float angles = 45f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeEulerAngles(transform, count, angles, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeEulerAngles(this Transform transform, int count, Vector3 angles, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeEulerAngles(transform, count, angles, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeEulerAngles(this Transform transform, Vector3Int count, Vector3 angles, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            var sequence = new Sequence(transform.gameObject, transform.name);

            sequence.Insert(0f, Tween.Shake(transform.eulerAngles.x, count.x, angles.x, duration, x => transform.eulerAngles = transform.eulerAngles.WithX(x), leftSmoothness, rightSmoothness).SetOwner(transform).SetName(transform.name));
            sequence.Insert(0f, Tween.Shake(transform.eulerAngles.y, count.y, angles.y, duration, y => transform.eulerAngles = transform.eulerAngles.WithY(y), leftSmoothness, rightSmoothness).SetOwner(transform).SetName(transform.name));
            sequence.Insert(0f, Tween.Shake(transform.eulerAngles.z, count.z, angles.z, duration, z => transform.eulerAngles = transform.eulerAngles.WithZ(z), leftSmoothness, rightSmoothness).SetOwner(transform).SetName(transform.name));

            return sequence;
        }
        #endregion

        #region DoShakeLocalEulerAngles
        public static Sequence DoShakeLocalEulerAngles(this Transform transform, int count = 8, float angles = 45f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeLocalEulerAngles(transform, count, angles, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeLocalEulerAngles(this Transform transform, Vector3Int count, float angles = 45f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeLocalEulerAngles(transform, count, angles, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeLocalEulerAngles(this Transform transform, int count, Vector3 angles, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeLocalEulerAngles(transform, count, angles, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeLocalEulerAngles(this Transform transform, Vector3Int count, Vector3 angles, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            var sequence = new Sequence(transform.gameObject, transform.name);

            sequence.Insert(0f, Tween.Shake(transform.localEulerAngles.x, count.x, angles.x, duration, x => transform.localEulerAngles = transform.localEulerAngles.WithX(x), leftSmoothness, rightSmoothness).SetOwner(transform).SetName(transform.name));
            sequence.Insert(0f, Tween.Shake(transform.localEulerAngles.y, count.y, angles.y, duration, y => transform.localEulerAngles = transform.localEulerAngles.WithY(y), leftSmoothness, rightSmoothness).SetOwner(transform).SetName(transform.name));
            sequence.Insert(0f, Tween.Shake(transform.localEulerAngles.z, count.z, angles.z, duration, z => transform.localEulerAngles = transform.localEulerAngles.WithZ(z), leftSmoothness, rightSmoothness).SetOwner(transform).SetName(transform.name));

            return sequence;
        }
        #endregion

        #region DoShakeLocalScale
        public static Sequence DoShakeLocalScale(this Transform transform, int count = 10, float scale = 1f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeLocalScale(transform, count, scale, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeLocalScale(this Transform transform, Vector3Int count, float scale = 1f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeLocalScale(transform, count, scale, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeLocalScale(this Transform transform, int count, Vector3 scale, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeLocalScale(transform, count, scale, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeLocalScale(this Transform transform, Vector3Int count, Vector3 scale, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            var sequence = new Sequence(transform.gameObject, transform.name);

            sequence.Insert(0f, Tween.Shake(transform.localScale.x, count.x, scale.x, duration, x => transform.localScale = transform.localScale.WithX(x), leftSmoothness, rightSmoothness).SetOwner(transform).SetName(transform.name));
            sequence.Insert(0f, Tween.Shake(transform.localScale.y, count.y, scale.y, duration, y => transform.localScale = transform.localScale.WithY(y), leftSmoothness, rightSmoothness).SetOwner(transform).SetName(transform.name));
            sequence.Insert(0f, Tween.Shake(transform.localScale.z, count.z, scale.z, duration, z => transform.localScale = transform.localScale.WithZ(z), leftSmoothness, rightSmoothness).SetOwner(transform).SetName(transform.name));

            return sequence;
        }
        #endregion
        #endregion

        public static Sequence DoPunchPosition(this Transform transform, Vector3 vector, int count, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            var sequence = new Sequence(transform.gameObject, transform.name);

            sequence.Insert(0f, Tween.Punch(transform.position.x, count, vector.x, duration, x => transform.position = transform.position.WithX(x), leftSmoothness, rightSmoothness).SetOwner(transform).SetName(transform.name));
            sequence.Insert(0f, Tween.Punch(transform.position.y, count, vector.y, duration, y => transform.position = transform.position.WithY(y), leftSmoothness, rightSmoothness).SetOwner(transform).SetName(transform.name));
            sequence.Insert(0f, Tween.Punch(transform.position.z, count, vector.z, duration, z => transform.position = transform.position.WithZ(z), leftSmoothness, rightSmoothness).SetOwner(transform).SetName(transform.name));

            return sequence;
        }

        public static Sequence DoPunchLocalPosition(this Transform transform, Vector3 vector, int count, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            var sequence = new Sequence(transform.gameObject, transform.name);

            sequence.Insert(0f, Tween.Punch(transform.localPosition.x, count, vector.x, duration, x => transform.localPosition = transform.localPosition.WithX(x), leftSmoothness, rightSmoothness).SetOwner(transform).SetName(transform.name));
            sequence.Insert(0f, Tween.Punch(transform.localPosition.y, count, vector.y, duration, y => transform.localPosition = transform.localPosition.WithY(y), leftSmoothness, rightSmoothness).SetOwner(transform).SetName(transform.name));
            sequence.Insert(0f, Tween.Punch(transform.localPosition.z, count, vector.z, duration, z => transform.localPosition = transform.localPosition.WithZ(z), leftSmoothness, rightSmoothness).SetOwner(transform).SetName(transform.name));

            return sequence;
        }

        public static Sequence DoPunchEulerAngles(this Transform transform, Vector3 angles, int count, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            var sequence = new Sequence(transform.gameObject, transform.name);

            sequence.Insert(0f, Tween.Punch(transform.eulerAngles.x, count, angles.x, duration, x => transform.eulerAngles = transform.eulerAngles.WithX(x), leftSmoothness, rightSmoothness).SetOwner(transform).SetName(transform.name));
            sequence.Insert(0f, Tween.Punch(transform.eulerAngles.y, count, angles.y, duration, y => transform.eulerAngles = transform.eulerAngles.WithY(y), leftSmoothness, rightSmoothness).SetOwner(transform).SetName(transform.name));
            sequence.Insert(0f, Tween.Punch(transform.eulerAngles.z, count, angles.z, duration, z => transform.eulerAngles = transform.eulerAngles.WithZ(z), leftSmoothness, rightSmoothness).SetOwner(transform).SetName(transform.name));

            return sequence;
        }

        public static Sequence DoPunchLocalEulerAngles(this Transform transform, Vector3 angles, int count, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            var sequence = new Sequence(transform.gameObject, transform.name);

            sequence.Insert(0f, Tween.Punch(transform.localEulerAngles.x, count, angles.x, duration, x => transform.localEulerAngles = transform.localEulerAngles.WithX(x), leftSmoothness, rightSmoothness).SetOwner(transform).SetName(transform.name));
            sequence.Insert(0f, Tween.Punch(transform.localEulerAngles.y, count, angles.y, duration, y => transform.localEulerAngles = transform.localEulerAngles.WithY(y), leftSmoothness, rightSmoothness).SetOwner(transform).SetName(transform.name));
            sequence.Insert(0f, Tween.Punch(transform.localEulerAngles.z, count, angles.z, duration, z => transform.localEulerAngles = transform.localEulerAngles.WithZ(z), leftSmoothness, rightSmoothness).SetOwner(transform).SetName(transform.name));

            return sequence;
        }

        #region DoPunchRotation
        public static Tween<float, TweakFloat> DoPunchRotation(this Transform transform, Vector3 direction, int count = 4, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            return DoPunchRotation(transform, Quaternion.LookRotation(direction), count, duration, leftSmoothness, rightSmoothness);
        }

        public static Tween<float, TweakFloat> DoPunchRotation(this Transform transform, Quaternion rotation, int count = 4, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            return Tween.Punch(transform.rotation, count, rotation, duration, rot => transform.rotation = rot, leftSmoothness, rightSmoothness).SetOwner(transform).SetName(transform.name);
        }
        #endregion

        #region DoPunchLocalRotation
        public static Tween<float, TweakFloat> DoPunchLocalRotation(this Transform transform, Vector3 direction, int count = 4, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            return DoPunchLocalRotation(transform, Quaternion.LookRotation(direction), count, duration, leftSmoothness, rightSmoothness);
        }

        public static Tween<float, TweakFloat> DoPunchLocalRotation(this Transform transform, Quaternion rotation, int count = 4, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            return Tween.Punch(transform.localRotation, count, rotation, duration, rot => transform.localRotation = rot, leftSmoothness, rightSmoothness).SetOwner(transform).SetName(transform.name);
        }
        #endregion

        #region DoPunchLocalScale
        public static Sequence DoPunchLocalScale(this Transform transform, float scale = 0.5f, int count = 10, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            return DoPunchLocalScale(transform, new Vector3(scale, scale, scale), count, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoPunchLocalScale(this Transform transform, Vector3 scale, int count, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            var sequence = new Sequence(transform.gameObject, transform.name);

            sequence.Insert(0f, Tween.Punch(transform.localScale.x, count, scale.x, duration, x => transform.localScale = transform.localScale.WithX(x), leftSmoothness, rightSmoothness).SetOwner(transform).SetName(transform.name));
            sequence.Insert(0f, Tween.Punch(transform.localScale.y, count, scale.y, duration, y => transform.localScale = transform.localScale.WithY(y), leftSmoothness, rightSmoothness).SetOwner(transform).SetName(transform.name));
            sequence.Insert(0f, Tween.Punch(transform.localScale.z, count, scale.z, duration, z => transform.localScale = transform.localScale.WithZ(z), leftSmoothness, rightSmoothness).SetOwner(transform).SetName(transform.name));

            return sequence;
        }
        #endregion

        public static Tween<float, TweakFloat> DoMoveAlongPath(this Transform transform, Path path, float duration, PathFollowOptions pathFollowOptions = PathFollowOptions.UsePathDirection)
        {
            return Tween.Float(0f, 1f, p =>
            {
                var pointData = path.GetPointAtDistance(p);

                transform.position = pointData.Position;
                if (pathFollowOptions != PathFollowOptions.None)
                    transform.rotation = pathFollowOptions == PathFollowOptions.UsePointRotation ? pointData.Rotation : Quaternion.LookRotation(pointData.Direction);
            }, duration).SetOwner(transform).SetName(transform.name);
        }

        public static (Tween<float, TweakFloat> tween, Path path) DoJump(this Transform transform, float height, Vector3 endPoint, float duration)
        {
            height = Mathf.Max(endPoint.y - transform.position.y, 0f) + height;
            var path = Path.Create(transform.position, true, Vector3.zero.WithY(transform.position.y - 5f), Vector3.zero, Vector3.Lerp(transform.position, endPoint, 0.5f).WithY(height), endPoint, endPoint.WithY(endPoint.y - 5f));
            path.Resolution = 10;

            var tween = Tween.Float(0f, 1f, p => transform.position = path.GetPointAtDistance(p).Position, duration, Ease.InOutQuad).SetOwner(transform).SetName(transform.name);
            return (tween, path);
        }
    }
}