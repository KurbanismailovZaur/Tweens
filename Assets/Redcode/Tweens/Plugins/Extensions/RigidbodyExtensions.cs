using Redcode.Extensions;
using Redcode.Paths;
using Redcode.Tweens.Extensions;
using Redcode.Tweens.Tweaks;
using UnityEngine;

namespace Redcode.Tweens
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
        private static Tween<float, TweakFloat> DoPositionOneAxis(GameObject owner, Rigidbody rigidbody, int axis, float position, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(owner, owner.name, rigidbody.position[axis], position, p => rigidbody.SetPosition(axis, p), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPositionX(this Rigidbody rigidbody, float x, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPositionOneAxis(rigidbody.gameObject, rigidbody, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPositionX(this Rigidbody rigidbody, GameObject owner, float x, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPositionOneAxis(owner, rigidbody, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPositionY(this Rigidbody rigidbody, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPositionOneAxis(rigidbody.gameObject, rigidbody, 1, y, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPositionY(this Rigidbody rigidbody, GameObject owner, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPositionOneAxis(owner, rigidbody, 1, y, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPositionZ(this Rigidbody rigidbody, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPositionOneAxis(rigidbody.gameObject, rigidbody, 2, z, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPositionZ(this Rigidbody rigidbody, GameObject owner, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPositionOneAxis(owner, rigidbody, 2, z, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoPositionTwoAxes
        private static Sequence DoPositionTwoAxes(GameObject owner, Rigidbody rigidbody, int axis1, int axis2, float position1, float position2, float duration, Ease formula, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            var sequence = new Sequence(owner, owner.name, formula, loopsCount, loopType, loopResetBehaviour, direction);

            sequence.Insert(0f, Tween.Float(owner, owner.name, rigidbody.position[axis1], position1, p => rigidbody.SetPosition(axis1, p), duration));
            sequence.Insert(0f, Tween.Float(owner, owner.name, rigidbody.position[axis2], position2, p => rigidbody.SetPosition(axis2, p), duration));

            return sequence;
        }

        public static Sequence DoPositionXY(this Rigidbody rigidbody, float x, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoPositionTwoAxes(rigidbody.gameObject, rigidbody, 0, 1, x, y, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoPositionXY(this Rigidbody rigidbody, GameObject owner, float x, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoPositionTwoAxes(owner, rigidbody, 0, 1, x, y, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoPositionXZ(this Rigidbody rigidbody, float x, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoPositionTwoAxes(rigidbody.gameObject, rigidbody, 0, 2, x, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoPositionXZ(this Rigidbody rigidbody, GameObject owner, float x, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoPositionTwoAxes(owner, rigidbody, 0, 2, x, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoPositionYZ(this Rigidbody rigidbody, float y, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoPositionTwoAxes(rigidbody.gameObject, rigidbody, 1, 2, y, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoPositionYZ(this Rigidbody rigidbody, GameObject owner, float y, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoPositionTwoAxes(owner, rigidbody, 1, 2, y, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoPosition
        public static Tween<Vector3, TweakVector3> DoPosition(this Rigidbody rigidbody, float x, float y, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPosition(rigidbody, rigidbody.gameObject, new Vector3(x, y, z), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoPosition(this Rigidbody rigidbody, GameObject owner, float x, float y, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPosition(rigidbody, owner, new Vector3(x, y, z), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoPosition(this Rigidbody rigidbody, Vector3 position, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPosition(rigidbody, rigidbody.gameObject, position, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoPosition(this Rigidbody rigidbody, GameObject owner, Vector3 position, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Vector3(owner, owner.name, rigidbody.position, position, p => rigidbody.position = p, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoRotation
        public static Tween<Quaternion, TweakQuaternion> DoRotation(this Rigidbody rigidbody, Quaternion rotation, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoRotation(rigidbody, rigidbody.gameObject, rotation, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Quaternion, TweakQuaternion> DoRotation(this Rigidbody rigidbody, GameObject owner, Quaternion rotation, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Quaternion(owner, owner.name, rigidbody.rotation, rotation, r => rigidbody.rotation = r, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoLookAt
        public static Tween<Quaternion, TweakQuaternion> DoLookAt(this Rigidbody rigidbody, GameObject gameObject, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLookAt(rigidbody, rigidbody.gameObject, gameObject.transform.position, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Quaternion, TweakQuaternion> DoLookAt(this Rigidbody rigidbody, GameObject owner, GameObject gameObject, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLookAt(rigidbody, owner, gameObject.transform.position, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Quaternion, TweakQuaternion> DoLookAt(this Rigidbody rigidbody, Transform target, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLookAt(rigidbody, rigidbody.gameObject, target.position, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Quaternion, TweakQuaternion> DoLookAt(this Rigidbody rigidbody, GameObject owner, Transform target, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLookAt(rigidbody, owner, target.position, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Quaternion, TweakQuaternion> DoLookAt(this Rigidbody rigidbody, Vector3 point, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLookAt(rigidbody, rigidbody.gameObject, point, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Quaternion, TweakQuaternion> DoLookAt(this Rigidbody rigidbody, GameObject owner, Vector3 point, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoRotation(rigidbody, owner, Quaternion.LookRotation(point - rigidbody.position), duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoShake
        #region DoShakePosition
        public static Sequence DoShakePosition(this Rigidbody rigidbody, int count = 10, float strenght = 1f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakePosition(rigidbody, rigidbody.gameObject, count, strenght, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakePosition(this Rigidbody rigidbody, Vector3Int count, float strenght = 1f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakePosition(rigidbody, rigidbody.gameObject, count, strenght, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakePosition(this Rigidbody rigidbody, int count, Vector3 strenght, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakePosition(rigidbody, rigidbody.gameObject, count, strenght, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakePosition(this Rigidbody rigidbody, Vector3Int count, Vector3 strenght, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakePosition(rigidbody, rigidbody.gameObject, count, strenght, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakePosition(this Rigidbody rigidbody, GameObject owner, int count = 10, float strenght = 1f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakePosition(rigidbody, owner, new Vector3Int(count, count, count), new Vector3(strenght, strenght, strenght), duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakePosition(this Rigidbody rigidbody, GameObject owner, Vector3Int count, float strenght = 1f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakePosition(rigidbody, owner, count, new Vector3(strenght, strenght, strenght), duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakePosition(this Rigidbody rigidbody, GameObject owner, int count, Vector3 strenght, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakePosition(rigidbody, owner, new Vector3Int(count, count, count), strenght, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakePosition(this Rigidbody rigidbody, GameObject owner, Vector3Int count, Vector3 strenght, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            var sequence = new Sequence(owner, owner.name);

            sequence.Insert(0f, Tween.Shake(owner, owner.name, rigidbody.position.x, count.x, strenght.x, duration, x => rigidbody.position = rigidbody.position.WithX(x), leftSmoothness, rightSmoothness));
            sequence.Insert(0f, Tween.Shake(owner, owner.name, rigidbody.position.y, count.y, strenght.y, duration, y => rigidbody.position = rigidbody.position.WithY(y), leftSmoothness, rightSmoothness));
            sequence.Insert(0f, Tween.Shake(owner, owner.name, rigidbody.position.z, count.z, strenght.z, duration, z => rigidbody.position = rigidbody.position.WithZ(z), leftSmoothness, rightSmoothness));

            return sequence;
        }
        #endregion

        #region DoShakeEulerAngles
        public static Sequence DoShakeEulerAngles(this Rigidbody rigidbody, int count = 8, float angles = 45f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeEulerAngles(rigidbody, rigidbody.gameObject, count, angles, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeEulerAngles(this Rigidbody rigidbody, Vector3Int count, float angles = 45f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeEulerAngles(rigidbody, rigidbody.gameObject, count, angles, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeEulerAngles(this Rigidbody rigidbody, int count, Vector3 angles, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeEulerAngles(rigidbody, rigidbody.gameObject, count, angles, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeEulerAngles(this Rigidbody rigidbody, Vector3Int count, Vector3 angles, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeEulerAngles(rigidbody, rigidbody.gameObject, count, angles, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeEulerAngles(this Rigidbody rigidbody, GameObject owner, int count = 8, float angles = 45f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeEulerAngles(rigidbody, owner, new Vector3Int(count, count, count), new Vector3(angles, angles, angles), duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeEulerAngles(this Rigidbody rigidbody, GameObject owner, Vector3Int count, float angles = 45f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeEulerAngles(rigidbody, owner, count, new Vector3(angles, angles, angles), duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeEulerAngles(this Rigidbody rigidbody, GameObject owner, int count, Vector3 angles, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeEulerAngles(rigidbody, owner, new Vector3Int(count, count, count), angles, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeEulerAngles(this Rigidbody rigidbody, GameObject owner, Vector3Int count, Vector3 angles, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            var sequence = new Sequence(owner, owner.name);

            sequence.Insert(0f, Tween.Shake(owner, owner.name, rigidbody.rotation.eulerAngles.x, count.x, angles.x, duration, x => rigidbody.rotation = Quaternion.Euler(rigidbody.rotation.eulerAngles.WithX(x)), leftSmoothness, rightSmoothness));
            sequence.Insert(0f, Tween.Shake(owner, owner.name, rigidbody.rotation.eulerAngles.y, count.y, angles.y, duration, y => rigidbody.rotation = Quaternion.Euler(rigidbody.rotation.eulerAngles.WithY(y)), leftSmoothness, rightSmoothness));
            sequence.Insert(0f, Tween.Shake(owner, owner.name, rigidbody.rotation.eulerAngles.z, count.z, angles.z, duration, z => rigidbody.rotation = Quaternion.Euler(rigidbody.rotation.eulerAngles.WithZ(z)), leftSmoothness, rightSmoothness));

            return sequence;
        }
        #endregion
        #endregion

        #region DoPunch
        #region DoPunchPosition
        public static Sequence DoPunchPosition(this Rigidbody rigidbody, Vector3 vector, int count = 10, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            return DoPunchPosition(rigidbody, rigidbody.gameObject, vector, count, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoPunchPosition(this Rigidbody rigidbody, GameObject owner, Vector3 vector, int count, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            var sequence = new Sequence(owner, owner.name);

            sequence.Insert(0f, Tween.Punch(owner, owner.name, rigidbody.position.x, count, vector.x, duration, x => rigidbody.position = rigidbody.position.WithX(x), leftSmoothness, rightSmoothness));
            sequence.Insert(0f, Tween.Punch(owner, owner.name, rigidbody.position.y, count, vector.y, duration, y => rigidbody.position = rigidbody.position.WithY(y), leftSmoothness, rightSmoothness));
            sequence.Insert(0f, Tween.Punch(owner, owner.name, rigidbody.position.z, count, vector.z, duration, z => rigidbody.position = rigidbody.position.WithZ(z), leftSmoothness, rightSmoothness));

            return sequence;
        }
        #endregion

        #region DoPunchEulerAngles
        public static Sequence DoPunchEulerAngles(this Rigidbody rigidbody, Vector3 angles, int count = 10, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            return DoPunchEulerAngles(rigidbody, rigidbody.gameObject, angles, count, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoPunchEulerAngles(this Rigidbody rigidbody, GameObject owner, Vector3 angles, int count, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            var sequence = new Sequence(owner, owner.name);

            sequence.Insert(0f, Tween.Punch(owner, owner.name, rigidbody.rotation.eulerAngles.x, count, angles.x, duration, x => rigidbody.rotation = Quaternion.Euler(rigidbody.rotation.eulerAngles.WithX(x)), leftSmoothness, rightSmoothness));
            sequence.Insert(0f, Tween.Punch(owner, owner.name, rigidbody.rotation.eulerAngles.y, count, angles.y, duration, y => rigidbody.rotation = Quaternion.Euler(rigidbody.rotation.eulerAngles.WithY(y)), leftSmoothness, rightSmoothness));
            sequence.Insert(0f, Tween.Punch(owner, owner.name, rigidbody.rotation.eulerAngles.z, count, angles.z, duration, z => rigidbody.rotation = Quaternion.Euler(rigidbody.rotation.eulerAngles.WithZ(z)), leftSmoothness, rightSmoothness));

            return sequence;
        }
        #endregion

        #region DoPunchRotation
        public static Tween<float, TweakFloat> DoPunchRotation(this Rigidbody rigidbody, Vector3 direction, int count = 4, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            return DoPunchRotation(rigidbody, rigidbody.gameObject, Quaternion.LookRotation(direction), count, duration, leftSmoothness, rightSmoothness);
        }

        public static Tween<float, TweakFloat> DoPunchRotation(this Rigidbody rigidbody, GameObject owner, Vector3 direction, int count = 4, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            return DoPunchRotation(rigidbody, owner, Quaternion.LookRotation(direction), count, duration, leftSmoothness, rightSmoothness);
        }

        public static Tween<float, TweakFloat> DoPunchRotation(this Rigidbody rigidbody, Quaternion rotation, int count = 4, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            return DoPunchRotation(rigidbody, rigidbody.gameObject, rotation, count, duration, leftSmoothness, rightSmoothness);
        }

        public static Tween<float, TweakFloat> DoPunchRotation(this Rigidbody rigidbody, GameObject owner, Quaternion rotation, int count = 4, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            return Tween.Punch(owner, owner.name, rigidbody.rotation, count, rotation, duration, rot => rigidbody.rotation = rot, leftSmoothness, rightSmoothness);
        }
        #endregion
        #endregion

        public static Tween<float, TweakFloat> DoMoveAlongPath(this Rigidbody rigidbody, Path path, float duration, PathFollowOptions pathFollowOptions = PathFollowOptions.UsePathDirection) => DoMoveAlongPath(rigidbody, path, duration, pathFollowOptions);

        public static Tween<float, TweakFloat> DoMoveAlongPath(this Rigidbody rigidbody, GameObject owner, Path path, float duration, PathFollowOptions pathFollowOptions = PathFollowOptions.UsePathDirection)
        {
            return Tween.Float(owner, 0f, 1f, p =>
            {
                var pointData = path.GetPointAtDistance(p);

                rigidbody.position = pointData.Position;
                if (pathFollowOptions != PathFollowOptions.None)
                    rigidbody.rotation = pathFollowOptions == PathFollowOptions.UsePointRotation ? pointData.Rotation : Quaternion.LookRotation(pointData.Direction);
            }, duration);
        }

        public static (Tween<float, TweakFloat> tween, Path path) DoJump(this Rigidbody rigidbody, float height, Vector3 endPoint, float duration) => DoJump(rigidbody, null, height, endPoint, duration);

        public static (Tween<float, TweakFloat> tween, Path path) DoJump(this Rigidbody rigidbody, GameObject owner, float height, Vector3 endPoint, float duration)
        {
            height = Mathf.Max(endPoint.y - rigidbody.position.y, 0f) + height;
            var path = Path.Create(rigidbody.position, true, Vector3.zero, Vector3.zero, Vector3.Lerp(rigidbody.position, endPoint, 0.5f).WithY(height), endPoint, endPoint);
            path.Optimize();

            var tween = Tween.Float(owner, 0f, 1f, p => rigidbody.position = path.GetPointAtDistance(p).Position, duration, Ease.InOutQuad);
            return (tween, path);
        }
    }
}