using Redcode.Extensions;
using Redcode.Paths;
using Redcode.Tweens.Extensions;
using Redcode.Tweens.Tweaks;
using UnityEngine;

namespace Redcode.Tweens
{
    public static class TransformExtensions
	{
        /// <summary>
        /// Create tween which animates transform's position and rotation along path.
        /// </summary>
        /// <param name="transform">Target transform.</param>
        /// <param name="path">Path to follow.</param>
        /// <param name="duration">Sequence's duration.</param>
        /// <param name="pathFollowOptions">Following options.</param>
        /// <returns>The sequence.</returns>
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

        /// <summary>
        /// Create tween and path which animates transform's position along path, so that it looks like a jump.
        /// </summary>
        /// <param name="transform">Target transform.</param>
        /// <param name="height">Jump height.</param>
        /// <param name="endPoint">Jump end point.</param>
        /// <param name="duration">Sequence's duration.</param>
        /// <returns>The sequence.</returns>
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