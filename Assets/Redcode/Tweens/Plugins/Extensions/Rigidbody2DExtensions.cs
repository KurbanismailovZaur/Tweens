using Redcode.Extensions;
using Redcode.Paths;
using Redcode.Tweens.Extensions;
using Redcode.Tweens.Tweaks;
using UnityEngine;

namespace Redcode.Tweens
{
    public static class Rigidbody2DExtensions
    {
        #region DoPositionOneAxis
        private static Tween<float, TweakFloat> DoPositionOneAxis(GameObject owner, Rigidbody2D rigidbody, int axis, float position, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(rigidbody.position[axis], position, p => rigidbody.position = rigidbody.position.With(axis, p), duration, ease, loopsCount, loopType, direction).SetOwner(owner).SetName(owner.name);
        }

        public static Tween<float, TweakFloat> DoPositionX(this Rigidbody2D rigidbody, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPositionOneAxis(rigidbody.gameObject, rigidbody, 0, x, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPositionY(this Rigidbody2D rigidbody, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPositionOneAxis(rigidbody.gameObject, rigidbody, 1, y, duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoPosition
        public static Tween<Vector2, TweakVector2> DoPosition(this Rigidbody2D rigidbody, float x, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPosition(rigidbody, new Vector2(x, y), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoPosition(this Rigidbody2D rigidbody, Vector2 position, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Vector2(rigidbody.position, position, p => rigidbody.position = p, duration, ease, loopsCount, loopType, direction).SetOwner(rigidbody).SetName(rigidbody.name);
        }
        #endregion

        public static Tween<float, TweakFloat> DoRotation(this Rigidbody2D rigidbody, float rotation, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(rigidbody.rotation, rotation, r => rigidbody.rotation = r, duration, ease, loopsCount, loopType, direction).SetOwner(rigidbody).SetName(rigidbody.name);
        }

        #region DoShake
        #region DoShakePosition
        public static Sequence DoShakePosition(this Rigidbody2D rigidbody, int count = 10, float strenght = 1f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakePosition(rigidbody, count, strenght, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakePosition(this Rigidbody2D rigidbody, Vector2Int count, float strenght = 1f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakePosition(rigidbody, count, strenght, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakePosition(this Rigidbody2D rigidbody, int count, Vector2 strenght, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakePosition(rigidbody, count, strenght, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakePosition(this Rigidbody2D rigidbody, Vector2Int count, Vector2 strenght, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            var sequence = new Sequence(rigidbody.gameObject, rigidbody.name);

            sequence.Insert(0f, Tween.Shake(rigidbody.position.x, count.x, strenght.x, duration, x => rigidbody.position = rigidbody.position.WithX(x), leftSmoothness, rightSmoothness).SetOwner(rigidbody).SetName(rigidbody.name));
            sequence.Insert(0f, Tween.Shake(rigidbody.position.y, count.y, strenght.y, duration, y => rigidbody.position = rigidbody.position.WithY(y), leftSmoothness, rightSmoothness).SetOwner(rigidbody).SetName(rigidbody.name));

            return sequence;
        }
        #endregion

        public static Tween<float, TweakFloat> DoShakeEulerAngles(this Rigidbody2D rigidbody, int count = 8, float rotation = 45f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return Tween.Shake(rigidbody.rotation, count, rotation, duration, rotation => rigidbody.rotation = rotation, leftSmoothness, rightSmoothness).SetOwner(rigidbody).SetName(rigidbody.name);
        }
        #endregion

        #region DoPunch
        public static Sequence DoPunchPosition(this Rigidbody2D rigidbody, Vector2 vector, int count, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            var sequence = new Sequence(rigidbody.gameObject, rigidbody.name);

            sequence.Insert(0f, Tween.Punch(rigidbody.position.x, count, vector.x, duration, x => rigidbody.position = rigidbody.position.WithX(x), leftSmoothness, rightSmoothness).SetOwner(rigidbody).SetName(rigidbody.name));
            sequence.Insert(0f, Tween.Punch(rigidbody.position.y, count, vector.y, duration, y => rigidbody.position = rigidbody.position.WithY(y), leftSmoothness, rightSmoothness).SetOwner(rigidbody).SetName(rigidbody.name));

            return sequence;
        }

        public static Tween<float, TweakFloat> DoPunchRotation(this Rigidbody2D rigidbody, float rotation, int count, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            return Tween.Punch(rigidbody.rotation, count, rotation, duration, rotation => rigidbody.rotation = rotation, leftSmoothness, rightSmoothness).SetOwner(rigidbody).SetName(rigidbody.name);
        }
        #endregion

        public static Tween<float, TweakFloat> DoMoveAlongPath(this Rigidbody2D rigidbody, Path path, float duration, PathFollowOptions pathFollowOptions = PathFollowOptions.UsePathDirection)
        {
            return Tween.Float(0f, 1f, p =>
            {
                var pointData = path.GetPointAtDistance(p);

                rigidbody.position = pointData.Position;

                if (pathFollowOptions == PathFollowOptions.UsePointRotation)
                    rigidbody.rotation = pointData.Rotation.eulerAngles.z;
                else if (pathFollowOptions == PathFollowOptions.UsePathDirection)
                    rigidbody.rotation = Vector2.SignedAngle(pointData.Direction.GetXY(), Vector2.right);
            }, duration).SetOwner(rigidbody).SetName(rigidbody.name);
        }

        public static (Tween<float, TweakFloat> tween, Path path) DoJump(this Rigidbody2D rigidbody, float height, Vector3 endPoint, float duration)
        {
            height = Mathf.Max(endPoint.y - rigidbody.position.y, 0f) + height;
            var path = Path.Create(rigidbody.position, true, Vector3.zero, Vector3.zero, Vector3.Lerp(rigidbody.position, endPoint, 0.5f).WithY(height), endPoint, endPoint);
            path.Optimize();

            var tween = Tween.Float(0f, 1f, p => rigidbody.position = path.GetPointAtDistance(p).Position, duration, Ease.InOutQuad).SetOwner(rigidbody).SetName(rigidbody.name);
            return (tween, path);
        }
    }
}