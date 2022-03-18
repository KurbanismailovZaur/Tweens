using Redcode.Extensions;
using Redcode.Paths;
using Redcode.Tweens.Extensions;
using Redcode.Tweens.Tweaks;
using UnityEngine;

namespace Redcode.Tweens
{
    public static class Rigidbody2DExtensions
    {
        private static void SetPosition(this Rigidbody2D rigidbody, int axis, float position)
        {
            var pos = rigidbody.position;
            pos[axis] = position;
            rigidbody.position = pos;
        }

        #region DoPositionOneAxis
        private static Tween<float, TweakFloat> DoPositionOneAxis(GameObject owner, Rigidbody2D rigidbody, int axis, float position, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(owner, owner.name, rigidbody.position[axis], position, p => rigidbody.SetPosition(axis, p), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPositionX(this Rigidbody2D rigidbody, float x, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPositionOneAxis(rigidbody.gameObject, rigidbody, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPositionX(this Rigidbody2D rigidbody, GameObject owner, float x, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPositionOneAxis(owner, rigidbody, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPositionY(this Rigidbody2D rigidbody, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPositionOneAxis(rigidbody.gameObject, rigidbody, 1, y, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPositionY(this Rigidbody2D rigidbody, GameObject owner, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPositionOneAxis(owner, rigidbody, 1, y, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoPosition
        public static Tween<Vector2, TweakVector2> DoPosition(this Rigidbody2D rigidbody, float x, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPosition(rigidbody, rigidbody.gameObject, new Vector2(x, y), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoPosition(this Rigidbody2D rigidbody, GameObject owner, float x, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPosition(rigidbody, owner, new Vector3(x, y), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoPosition(this Rigidbody2D rigidbody, Vector2 position, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPosition(rigidbody, rigidbody.gameObject, position, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoPosition(this Rigidbody2D rigidbody, GameObject owner, Vector2 position, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Vector2(owner, owner.name, rigidbody.position, position, p => rigidbody.position = p, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoRotation
        public static Tween<float, TweakFloat> DoRotation(this Rigidbody2D rigidbody, float rotation, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoRotation(rigidbody, rigidbody.gameObject, rotation, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoRotation(this Rigidbody2D rigidbody, GameObject owner, float rotation, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(owner, owner.name, rigidbody.rotation, rotation, r => rigidbody.rotation = r, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoShake
        #region DoShakePosition
        public static Sequence DoShakePosition(this Rigidbody2D rigidbody, int count = 10, float strenght = 1f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakePosition(rigidbody, rigidbody.gameObject, count, strenght, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakePosition(this Rigidbody2D rigidbody, Vector2Int count, float strenght = 1f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakePosition(rigidbody, rigidbody.gameObject, count, strenght, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakePosition(this Rigidbody2D rigidbody, int count, Vector2 strenght, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakePosition(rigidbody, rigidbody.gameObject, count, strenght, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakePosition(this Rigidbody2D rigidbody, Vector2Int count, Vector2 strenght, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakePosition(rigidbody, rigidbody.gameObject, count, strenght, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakePosition(this Rigidbody2D rigidbody, GameObject owner, int count = 10, float strenght = 1f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakePosition(rigidbody, owner, new Vector2Int(count, count), new Vector2(strenght, strenght), duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakePosition(this Rigidbody2D rigidbody, GameObject owner, Vector2Int count, float strenght = 1f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakePosition(rigidbody, owner, count, new Vector2(strenght, strenght), duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakePosition(this Rigidbody2D rigidbody, GameObject owner, int count, Vector2 strenght, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakePosition(rigidbody, owner, new Vector2Int(count, count), strenght, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakePosition(this Rigidbody2D rigidbody, GameObject owner, Vector2Int count, Vector2 strenght, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            var sequence = new Sequence(owner, owner.name);

            sequence.Insert(0f, Tween.Shake(owner, owner.name, rigidbody.position.x, count.x, strenght.x, duration, x => rigidbody.position = rigidbody.position.WithX(x), leftSmoothness, rightSmoothness));
            sequence.Insert(0f, Tween.Shake(owner, owner.name, rigidbody.position.y, count.y, strenght.y, duration, y => rigidbody.position = rigidbody.position.WithY(y), leftSmoothness, rightSmoothness));

            return sequence;
        }
        #endregion

        #region DoShakeEulerAngles
        public static Tween<float, TweakFloat> DoShakeEulerAngles(this Rigidbody2D rigidbody, int count = 8, float rotation = 45f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeEulerAngles(rigidbody, rigidbody.gameObject, count, rotation, duration, leftSmoothness, rightSmoothness);
        }

        public static Tween<float, TweakFloat> DoShakeEulerAngles(this Rigidbody2D rigidbody, GameObject owner, int count = 8, float rotation = 45f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return Tween.Shake(owner, owner.name, rigidbody.rotation, count, rotation, duration, rotation => rigidbody.rotation = rotation, leftSmoothness, rightSmoothness);
        }
        #endregion
        #endregion

        #region DoPunch
        #region DoPunchPosition
        public static Sequence DoPunchPosition(this Rigidbody2D rigidbody, Vector2 vector, int count = 10, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            return DoPunchPosition(rigidbody, rigidbody.gameObject, vector, count, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoPunchPosition(this Rigidbody2D rigidbody, GameObject owner, Vector2 vector, int count, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            var sequence = new Sequence(owner, owner.name);

            sequence.Insert(0f, Tween.Punch(owner, owner.name, rigidbody.position.x, count, vector.x, duration, x => rigidbody.position = rigidbody.position.WithX(x), leftSmoothness, rightSmoothness));
            sequence.Insert(0f, Tween.Punch(owner, owner.name, rigidbody.position.y, count, vector.y, duration, y => rigidbody.position = rigidbody.position.WithY(y), leftSmoothness, rightSmoothness));

            return sequence;
        }
        #endregion

        #region DoPunchRotation
        public static Tween<float, TweakFloat> DoPunchRotation(this Rigidbody2D rigidbody, float rotation, int count = 10, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            return DoPunchRotation(rigidbody, rigidbody.gameObject, rotation, count, duration, leftSmoothness, rightSmoothness);
        }

        public static Tween<float, TweakFloat> DoPunchRotation(this Rigidbody2D rigidbody, GameObject owner, float rotation, int count, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            return Tween.Punch(owner, owner.name, rigidbody.rotation, count, rotation, duration, rotation => rigidbody.rotation = rotation, leftSmoothness, rightSmoothness);
        }
        #endregion
        #endregion

        public static Tween<float, TweakFloat> DoMoveAlongPath(this Rigidbody2D rigidbody, Path path, float duration, PathFollowOptions pathFollowOptions = PathFollowOptions.UsePathDirection) => DoMoveAlongPath(rigidbody, null, duration, pathFollowOptions);

        public static Tween<float, TweakFloat> DoMoveAlongPath(this Rigidbody2D rigidbody, GameObject owner, Path path, float duration, PathFollowOptions pathFollowOptions = PathFollowOptions.UsePathDirection)
        {
            return Tween.Float(owner, 0f, 1f, p =>
            {
                var pointData = path.GetPointAtDistance(p);

                rigidbody.position = pointData.Position;
                if (pathFollowOptions == PathFollowOptions.UsePointRotation)
                    rigidbody.rotation = pointData.Rotation.eulerAngles.z;
                else if (pathFollowOptions == PathFollowOptions.UsePathDirection)
                    rigidbody.rotation = Vector2.SignedAngle(pointData.Direction.GetXY(), Vector2.right);
            }, duration);
        }

        public static (Tween<float, TweakFloat> tween, Path path) DoJump(this Rigidbody2D rigidbody, float height, Vector3 endPoint, float duration) => DoJump(rigidbody, null, height, endPoint, duration);

        public static (Tween<float, TweakFloat> tween, Path path) DoJump(this Rigidbody2D rigidbody, GameObject owner, float height, Vector3 endPoint, float duration)
        {
            height = Mathf.Max(endPoint.y - rigidbody.position.y, 0f) + height;
            var path = Path.Create(rigidbody.position, true, Vector3.zero, Vector3.zero, Vector3.Lerp(rigidbody.position, endPoint, 0.5f).WithY(height), endPoint, endPoint);
            path.Optimize();

            var tween = Tween.Float(owner, 0f, 1f, p => rigidbody.position = path.GetPointAtDistance(p).Position, duration, Ease.InOutQuad);
            return (tween, path);
        }
    }
}