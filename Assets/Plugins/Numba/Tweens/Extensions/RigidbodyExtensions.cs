using Extensions;
using Tweens.Formulas;
using Tweens.Tweaks;
using UnityEngine;

namespace Tweens
{
    public static class RigidbodyExtensions
    {
        private static void SetPosition(this Rigidbody rigidbody, int axis, float position)
        {
            var pos = rigidbody.position;
            pos[axis] = position;
            rigidbody.position = pos;
        }

        #region DoPositionOneAxis
        private static Tween<float, TweakFloat> DoPositionOneAxis(GameObject owner, Rigidbody rigidbody, int axis, float position, float duration, FormulaBase formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(owner, owner.name, rigidbody.position[axis], position, p => rigidbody.SetPosition(axis, p), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPositionX(this Rigidbody rigidbody, float x, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPositionOneAxis(rigidbody.gameObject, rigidbody, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPositionX(this Rigidbody rigidbody, GameObject owner, float x, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPositionOneAxis(owner, rigidbody, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPositionY(this Rigidbody rigidbody, float y, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPositionOneAxis(rigidbody.gameObject, rigidbody, 1, y, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPositionY(this Rigidbody rigidbody, GameObject owner, float y, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPositionOneAxis(owner, rigidbody, 1, y, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPositionZ(this Rigidbody rigidbody, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPositionOneAxis(rigidbody.gameObject, rigidbody, 2, z, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPositionZ(this Rigidbody rigidbody, GameObject owner, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPositionOneAxis(owner, rigidbody, 2, z, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoPositionTwoAxes
        private static Sequence DoPositionTwoAxes(GameObject owner, Rigidbody rigidbody, int axis1, int axis2, float position1, float position2, float duration, FormulaBase formula, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            var sequence = new Sequence(owner, owner.name, formula, loopsCount, loopType, loopResetBehaviour, direction);

            sequence.Insert(0f, Tween.Float(owner, owner.name, rigidbody.position[axis1], position1, p => rigidbody.SetPosition(axis1, p), duration));
            sequence.Insert(0f, Tween.Float(owner, owner.name, rigidbody.position[axis2], position2, p => rigidbody.SetPosition(axis2, p), duration));

            return sequence;
        }

        public static Sequence DoPositionXY(this Rigidbody rigidbody, float x, float y, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoPositionTwoAxes(rigidbody.gameObject, rigidbody, 0, 1, x, y, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoPositionXY(this Rigidbody rigidbody, GameObject owner, float x, float y, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoPositionTwoAxes(owner, rigidbody, 0, 1, x, y, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoPositionXZ(this Rigidbody rigidbody, float x, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoPositionTwoAxes(rigidbody.gameObject, rigidbody, 0, 2, x, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoPositionXZ(this Rigidbody rigidbody, GameObject owner, float x, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoPositionTwoAxes(owner, rigidbody, 0, 2, x, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoPositionYZ(this Rigidbody rigidbody, float y, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoPositionTwoAxes(rigidbody.gameObject, rigidbody, 1, 2, y, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoPositionYZ(this Rigidbody rigidbody, GameObject owner, float y, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoPositionTwoAxes(owner, rigidbody, 1, 2, y, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoPosition
        public static Tween<Vector3, TweakVector3> DoPosition(this Rigidbody rigidbody, float x, float y, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPosition(rigidbody, rigidbody.gameObject, new Vector3(x, y, z), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoPosition(this Rigidbody rigidbody, GameObject owner, float x, float y, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPosition(rigidbody, owner, new Vector3(x, y, z), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoPosition(this Rigidbody rigidbody, Vector3 position, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPosition(rigidbody, rigidbody.gameObject, position, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoPosition(this Rigidbody rigidbody, GameObject owner, Vector3 position, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Vector3(owner, owner.name, rigidbody.position, position, p => rigidbody.position = p, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoRotation
        public static Tween<Quaternion, TweakQuaternion> DoRotation(this Rigidbody rigidbody, Quaternion rotation, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoRotation(rigidbody, rigidbody.gameObject, rotation, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Quaternion, TweakQuaternion> DoRotation(this Rigidbody rigidbody, GameObject owner, Quaternion rotation, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Quaternion(owner, owner.name, rigidbody.rotation, rotation, r => rigidbody.rotation = r, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoLookAt
        public static Tween<Quaternion, TweakQuaternion> DoLookAt(this Rigidbody rigidbody, GameObject gameObject, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLookAt(rigidbody, rigidbody.gameObject, gameObject.transform.position, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Quaternion, TweakQuaternion> DoLookAt(this Rigidbody rigidbody, GameObject owner, GameObject gameObject, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLookAt(rigidbody, owner, gameObject.transform.position, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Quaternion, TweakQuaternion> DoLookAt(this Rigidbody rigidbody, Transform target, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLookAt(rigidbody, rigidbody.gameObject, target.position, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Quaternion, TweakQuaternion> DoLookAt(this Rigidbody rigidbody, GameObject owner, Transform target, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLookAt(rigidbody, owner, target.position, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Quaternion, TweakQuaternion> DoLookAt(this Rigidbody rigidbody, Vector3 point, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLookAt(rigidbody, rigidbody.gameObject, point, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Quaternion, TweakQuaternion> DoLookAt(this Rigidbody rigidbody, GameObject owner, Vector3 point, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoRotation(rigidbody, owner, Quaternion.LookRotation(point - rigidbody.position), duration, formula, loopsCount, loopType, direction);
        }
        #endregion
    }
}