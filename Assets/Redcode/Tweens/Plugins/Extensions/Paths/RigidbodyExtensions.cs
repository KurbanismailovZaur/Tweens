using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Redcode.Extensions;
using Redcode.Tweens;
using Redcode.Tweens.Extensions;
using Redcode.Tweens.Tweaks;
using Redcode.Paths;

namespace Redcode.Tweens
{
	public static class RigidbodyExtensions
	{
        /// <summary>
        /// Create tween which animates rigidbody's position and rotation along path.
        /// </summary>
        /// <param name="rigidbody">Target rigidbody.</param>
        /// <param name="path">Path to follow.</param>
        /// <param name="duration">Sequence's duration.</param>
        /// <param name="pathFollowOptions">Following options.</param>
        /// <returns>The sequence.</returns>
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

        /// <summary>
        /// Create tween and path which animates rigidbody's position along path, so that it looks like a jump.
        /// </summary>
        /// <param name="rigidbody">Target rigidbody.</param>
        /// <param name="height">Jump height.</param>
        /// <param name="endPoint">Jump end point.</param>
        /// <param name="duration">Sequence's duration.</param>
        /// <returns>The sequence.</returns>
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