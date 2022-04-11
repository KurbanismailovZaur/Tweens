using Redcode.Extensions;
using Redcode.Paths;
using Redcode.Tweens.Extensions;
using Redcode.Tweens.Tweaks;
using UnityEngine;

namespace Redcode.Tweens
{
    public static class RigidbodyExtensions
    {
        #region DoPositionOneAxis
        private static Tween<float, TweakFloat> DoPositionOneAxis(GameObject owner, Rigidbody rigidbody, int axis, float position, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(rigidbody.position[axis], position, p => rigidbody.position = rigidbody.position.With(axis, p), duration, ease, loopsCount, loopType, direction).SetOwner(owner).SetName(owner.name);
        }

        public static Tween<float, TweakFloat> DoPositionX(this Rigidbody rigidbody, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPositionOneAxis(rigidbody.gameObject, rigidbody, 0, x, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPositionY(this Rigidbody rigidbody, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPositionOneAxis(rigidbody.gameObject, rigidbody, 1, y, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPositionZ(this Rigidbody rigidbody, float z, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPositionOneAxis(rigidbody.gameObject, rigidbody, 2, z, duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoPositionTwoAxes
        private static Tween<Vector2, TweakVector2> DoPositionTwoAxes(GameObject owner, Rigidbody rigidbody, int axis1, int axis2, float position1, float position2, float duration, Ease ease, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            return Tween.Vector2(rigidbody.position.Get(axis1, axis2), new Vector2(position1, position2), p => rigidbody.position = rigidbody.position.With(axis1, p.x, axis2, p.y), duration).SetOwner(owner).SetName(owner.name);
        }

        public static Tween<Vector2, TweakVector2> DoPositionXY(this Rigidbody rigidbody, float x, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoPositionTwoAxes(rigidbody.gameObject, rigidbody, 0, 1, x, y, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoPositionXZ(this Rigidbody rigidbody, float x, float z, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoPositionTwoAxes(rigidbody.gameObject, rigidbody, 0, 2, x, z, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoPositionYZ(this Rigidbody rigidbody, float y, float z, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoPositionTwoAxes(rigidbody.gameObject, rigidbody, 1, 2, y, z, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoPosition
        public static Tween<Vector3, TweakVector3> DoPosition(this Rigidbody rigidbody, float x, float y, float z, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPosition(rigidbody, new Vector3(x, y, z), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoPosition(this Rigidbody rigidbody, Vector3 position, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Vector3(rigidbody.position, position, p => rigidbody.position = p, duration, ease, loopsCount, loopType, direction).SetOwner(rigidbody).SetName(rigidbody.name);
        }
        #endregion

        public static Tween<Quaternion, TweakQuaternion> DoRotation(this Rigidbody rigidbody, Quaternion rotation, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Quaternion(rigidbody.rotation, rotation, r => rigidbody.rotation = r, duration, ease, loopsCount, loopType, direction).SetOwner(rigidbody).SetName(rigidbody.name);
        }

        #region DoLookAt
        public static Tween<Quaternion, TweakQuaternion> DoLookAt(this Rigidbody rigidbody, GameObject gameObject, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLookAt(rigidbody, gameObject.transform.position, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Quaternion, TweakQuaternion> DoLookAt(this Rigidbody rigidbody, Transform target, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLookAt(rigidbody, target.position, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Quaternion, TweakQuaternion> DoLookAt(this Rigidbody rigidbody, Vector3 point, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoRotation(rigidbody, Quaternion.LookRotation(point - rigidbody.position), duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoShake
        #region DoShakePosition
        public static Sequence DoShakePosition(this Rigidbody rigidbody, int count = 10, float strenght = 1f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakePosition(rigidbody, count, strenght, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakePosition(this Rigidbody rigidbody, Vector3Int count, float strenght = 1f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakePosition(rigidbody, count, strenght, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakePosition(this Rigidbody rigidbody, int count, Vector3 strenght, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakePosition(rigidbody, count, strenght, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakePosition(this Rigidbody rigidbody, Vector3Int count, Vector3 strenght, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            var sequence = new Sequence(rigidbody.gameObject, rigidbody.name);

            sequence.Insert(0f, Tween.Shake(rigidbody.position.x, count.x, strenght.x, duration, x => rigidbody.position = rigidbody.position.WithX(x), leftSmoothness, rightSmoothness).SetOwner(rigidbody).SetName(rigidbody.name));
            sequence.Insert(0f, Tween.Shake(rigidbody.position.y, count.y, strenght.y, duration, y => rigidbody.position = rigidbody.position.WithY(y), leftSmoothness, rightSmoothness).SetOwner(rigidbody).SetName(rigidbody.name));
            sequence.Insert(0f, Tween.Shake(rigidbody.position.z, count.z, strenght.z, duration, z => rigidbody.position = rigidbody.position.WithZ(z), leftSmoothness, rightSmoothness).SetOwner(rigidbody).SetName(rigidbody.name));

            return sequence;
        }
        #endregion

        #region DoShakeEulerAngles
        public static Sequence DoShakeEulerAngles(this Rigidbody rigidbody, int count = 8, float angles = 45f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeEulerAngles(rigidbody, count, angles, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeEulerAngles(this Rigidbody rigidbody, Vector3Int count, float angles = 45f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeEulerAngles(rigidbody, count, angles, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeEulerAngles(this Rigidbody rigidbody, int count, Vector3 angles, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeEulerAngles(rigidbody, count, angles, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeEulerAngles(this Rigidbody rigidbody, Vector3Int count, Vector3 angles, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            var sequence = new Sequence(rigidbody.gameObject, rigidbody.name);

            sequence.Insert(0f, Tween.Shake(rigidbody.rotation.eulerAngles.x, count.x, angles.x, duration, x => rigidbody.rotation = Quaternion.Euler(rigidbody.rotation.eulerAngles.WithX(x)), leftSmoothness, rightSmoothness).SetOwner(rigidbody).SetName(rigidbody.name));
            sequence.Insert(0f, Tween.Shake(rigidbody.rotation.eulerAngles.y, count.y, angles.y, duration, y => rigidbody.rotation = Quaternion.Euler(rigidbody.rotation.eulerAngles.WithY(y)), leftSmoothness, rightSmoothness).SetOwner(rigidbody).SetName(rigidbody.name));
            sequence.Insert(0f, Tween.Shake(rigidbody.rotation.eulerAngles.z, count.z, angles.z, duration, z => rigidbody.rotation = Quaternion.Euler(rigidbody.rotation.eulerAngles.WithZ(z)), leftSmoothness, rightSmoothness).SetOwner(rigidbody).SetName(rigidbody.name));

            return sequence;
        }
        #endregion
        #endregion

        #region DoPunch
        public static Sequence DoPunchPosition(this Rigidbody rigidbody, Vector3 vector, int count, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            var sequence = new Sequence(rigidbody.gameObject, rigidbody.name);

            sequence.Insert(0f, Tween.Punch(rigidbody.position.x, count, vector.x, duration, x => rigidbody.position = rigidbody.position.WithX(x), leftSmoothness, rightSmoothness).SetOwner(rigidbody).SetName(rigidbody.name));
            sequence.Insert(0f, Tween.Punch(rigidbody.position.y, count, vector.y, duration, y => rigidbody.position = rigidbody.position.WithY(y), leftSmoothness, rightSmoothness).SetOwner(rigidbody).SetName(rigidbody.name));
            sequence.Insert(0f, Tween.Punch(rigidbody.position.z, count, vector.z, duration, z => rigidbody.position = rigidbody.position.WithZ(z), leftSmoothness, rightSmoothness).SetOwner(rigidbody).SetName(rigidbody.name));

            return sequence;
        }

        public static Sequence DoPunchEulerAngles(this Rigidbody rigidbody, Vector3 angles, int count, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            var sequence = new Sequence(rigidbody.gameObject, rigidbody.name);

            sequence.Insert(0f, Tween.Punch(rigidbody.rotation.eulerAngles.x, count, angles.x, duration, x => rigidbody.rotation = Quaternion.Euler(rigidbody.rotation.eulerAngles.WithX(x)), leftSmoothness, rightSmoothness).SetOwner(rigidbody).SetName(rigidbody.name));
            sequence.Insert(0f, Tween.Punch(rigidbody.rotation.eulerAngles.y, count, angles.y, duration, y => rigidbody.rotation = Quaternion.Euler(rigidbody.rotation.eulerAngles.WithY(y)), leftSmoothness, rightSmoothness).SetOwner(rigidbody).SetName(rigidbody.name));
            sequence.Insert(0f, Tween.Punch(rigidbody.rotation.eulerAngles.z, count, angles.z, duration, z => rigidbody.rotation = Quaternion.Euler(rigidbody.rotation.eulerAngles.WithZ(z)), leftSmoothness, rightSmoothness).SetOwner(rigidbody).SetName(rigidbody.name));

            return sequence;
        }

        #region DoPunchRotation
        public static Tween<float, TweakFloat> DoPunchRotation(this Rigidbody rigidbody, Vector3 direction, int count = 4, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            return DoPunchRotation(rigidbody, Quaternion.LookRotation(direction), count, duration, leftSmoothness, rightSmoothness);
        }

        public static Tween<float, TweakFloat> DoPunchRotation(this Rigidbody rigidbody, Quaternion rotation, int count = 4, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            return Tween.Punch(rigidbody.rotation, count, rotation, duration, rot => rigidbody.rotation = rot, leftSmoothness, rightSmoothness).SetOwner(rigidbody).SetName(rigidbody.name);
        }
        #endregion
        #endregion

        public static Tween<float, TweakFloat> DoMoveAlongPath(this Rigidbody rigidbody, Path path, float duration, PathFollowOptions pathFollowOptions = PathFollowOptions.UsePathDirection)
        {
            return Tween.Float(0f, 1f, p =>
            {
                var pointData = path.GetPointAtDistance(p);

                rigidbody.position = pointData.Position;

                if (pathFollowOptions != PathFollowOptions.None)
                    rigidbody.rotation = pathFollowOptions == PathFollowOptions.UsePointRotation ? pointData.Rotation : Quaternion.LookRotation(pointData.Direction);
            }, duration).SetOwner(rigidbody).SetName(rigidbody.name);
        }

        public static (Tween<float, TweakFloat> tween, Path path) DoJump(this Rigidbody rigidbody, float height, Vector3 endPoint, float duration)
        {
            height = Mathf.Max(endPoint.y - rigidbody.position.y, 0f) + height;
            var path = Path.Create(rigidbody.position, true, Vector3.zero, Vector3.zero, Vector3.Lerp(rigidbody.position, endPoint, 0.5f).WithY(height), endPoint, endPoint);
            path.Optimize();

            var tween = Tween.Float(0f, 1f, p => rigidbody.position = path.GetPointAtDistance(p).Position, duration, Ease.InOutQuad).SetOwner(rigidbody).SetName(rigidbody.name);
            return (tween, path);
        }
    }
}