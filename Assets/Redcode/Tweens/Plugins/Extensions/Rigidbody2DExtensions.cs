using Redcode.Extensions;
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

        /// <summary>
		/// Tweens rigidbody's position x.
		/// </summary>
		/// <param name="rigidbody">Target material.</param>
		/// <param name="x">Target position x.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<float, TweakFloat> DoPositionX(this Rigidbody2D rigidbody, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPositionOneAxis(rigidbody.gameObject, rigidbody, 0, x, duration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
		/// Tweens rigidbody's position y.
		/// </summary>
		/// <param name="rigidbody">Target material.</param>
		/// <param name="y">Target position y.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<float, TweakFloat> DoPositionY(this Rigidbody2D rigidbody, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPositionOneAxis(rigidbody.gameObject, rigidbody, 1, y, duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoPosition
        /// <summary>
		/// Tweens rigidbody's position.
		/// </summary>
		/// <param name="rigidbody">Target material.</param>
		/// <param name="x">Target position x.</param>
		/// <param name="y">Target position y.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Vector2, TweakVector2> DoPosition(this Rigidbody2D rigidbody, float x, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPosition(rigidbody, new Vector2(x, y), duration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
		/// Tweens rigidbody's position.
		/// </summary>
		/// <param name="rigidbody">Target material.</param>
		/// <param name="position">Target position.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Vector2, TweakVector2> DoPosition(this Rigidbody2D rigidbody, Vector2 position, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Vector2(rigidbody.position, position, p => rigidbody.position = p, duration, ease, loopsCount, loopType, direction).SetOwner(rigidbody).SetName(rigidbody.name);
        }
        #endregion

        /// <summary>
		/// Tweens rigidbody's rotation.
		/// </summary>
		/// <param name="rigidbody">Target material.</param>
		/// <param name="rotation">Target rotation.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<float, TweakFloat> DoRotation(this Rigidbody2D rigidbody, float rotation, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(rigidbody.rotation, rotation, r => rigidbody.rotation = r, duration, ease, loopsCount, loopType, direction).SetOwner(rigidbody).SetName(rigidbody.name);
        }

        #region DoShake
        #region DoShakePosition
        /// <summary>
        /// Create sequence which shakes rigidbody's position.
        /// </summary>
        /// <param name="rigidbody">Target material.</param>
        /// <param name="count">Shakes count.</param>
        /// <param name="strenght">Shakes strenght.</param>
        /// <param name="duration">Sequence's duration.</param>
        /// <param name="leftSmoothness">Smothness from start.</param>
        /// <param name="rightSmoothness">Smothness at end.</param>
        /// <returns>The sequence.</returns>
        public static Sequence DoShakePosition(this Rigidbody2D rigidbody, int count = 10, float strenght = 1f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakePosition(rigidbody, new Vector2Int(count, count), strenght, duration, leftSmoothness, rightSmoothness);
        }

        /// <summary>
        /// Create sequence which shakes rigidbody's position.
        /// </summary>
        /// <param name="rigidbody">Target material.</param>
        /// <param name="count">Shakes count.</param>
        /// <param name="strenght">Shakes strenght.</param>
        /// <param name="duration">Sequence's duration.</param>
        /// <param name="leftSmoothness">Smothness from start.</param>
        /// <param name="rightSmoothness">Smothness at end.</param>
        /// <returns>The sequence.</returns>
        public static Sequence DoShakePosition(this Rigidbody2D rigidbody, Vector2Int count, float strenght = 1f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakePosition(rigidbody, count, new Vector2(strenght, strenght), duration, leftSmoothness, rightSmoothness);
        }

        /// <summary>
        /// Create sequence which shakes rigidbody's position.
        /// </summary>
        /// <param name="rigidbody">Target material.</param>
        /// <param name="count">Shakes count.</param>
        /// <param name="strenght">Shakes strenght.</param>
        /// <param name="duration">Sequence's duration.</param>
        /// <param name="leftSmoothness">Smothness from start.</param>
        /// <param name="rightSmoothness">Smothness at end.</param>
        /// <returns>The sequence.</returns>
        public static Sequence DoShakePosition(this Rigidbody2D rigidbody, int count, Vector2 strenght, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakePosition(rigidbody, new Vector2Int(count, count), strenght, duration, leftSmoothness, rightSmoothness);
        }

        /// <summary>
        /// Create sequence which shakes rigidbody's position.
        /// </summary>
        /// <param name="rigidbody">Target material.</param>
        /// <param name="count">Shakes count.</param>
        /// <param name="strenght">Shakes strenght.</param>
        /// <param name="duration">Sequence's duration.</param>
        /// <param name="leftSmoothness">Smothness from start.</param>
        /// <param name="rightSmoothness">Smothness at end.</param>
        /// <returns>The sequence.</returns>
        public static Sequence DoShakePosition(this Rigidbody2D rigidbody, Vector2Int count, Vector2 strenght, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            var sequence = new Sequence(rigidbody.gameObject, rigidbody.name);

            sequence.Insert(0f, Tween.Shake(rigidbody.position.x, count.x, strenght.x, duration, x => rigidbody.position = rigidbody.position.WithX(x), leftSmoothness, rightSmoothness).SetOwner(rigidbody).SetName(rigidbody.name));
            sequence.Insert(0f, Tween.Shake(rigidbody.position.y, count.y, strenght.y, duration, y => rigidbody.position = rigidbody.position.WithY(y), leftSmoothness, rightSmoothness).SetOwner(rigidbody).SetName(rigidbody.name));

            return sequence;
        }
        #endregion

        /// <summary>
        /// Create sequence which shakes rigidbody's euler angles.
        /// </summary>
        /// <param name="rigidbody">Target material.</param>
        /// <param name="count">Shakes count.</param>
        /// <param name="rotation">Shakes rotation.</param>
        /// <param name="duration">Sequence's duration.</param>
        /// <param name="leftSmoothness">Smothness from start.</param>
        /// <param name="rightSmoothness">Smothness at end.</param>
        /// <returns>The sequence.</returns>
        public static Tween<float, TweakFloat> DoShakeEulerAngles(this Rigidbody2D rigidbody, int count = 8, float rotation = 45f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return Tween.Shake(rigidbody.rotation, count, rotation, duration, rotation => rigidbody.rotation = rotation, leftSmoothness, rightSmoothness).SetOwner(rigidbody).SetName(rigidbody.name);
        }
        #endregion

        #region DoPunch
        /// <summary>
        /// Create sequence which bounce rigidbody's position.
        /// </summary>
        /// <param name="rigidbody">Target material.</param>
        /// <param name="count">Bounce count.</param>
        /// <param name="vector">Bounce rotation.</param>
        /// <param name="duration">Sequence's duration.</param>
        /// <param name="leftSmoothness">Smothness from start.</param>
        /// <param name="rightSmoothness">Smothness at end.</param>
        /// <returns>The sequence.</returns>
        public static Sequence DoPunchPosition(this Rigidbody2D rigidbody, Vector2 vector, int count, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            var sequence = new Sequence(rigidbody.gameObject, rigidbody.name);

            sequence.Insert(0f, Tween.Punch(rigidbody.position.x, count, vector.x, duration, x => rigidbody.position = rigidbody.position.WithX(x), leftSmoothness, rightSmoothness).SetOwner(rigidbody).SetName(rigidbody.name));
            sequence.Insert(0f, Tween.Punch(rigidbody.position.y, count, vector.y, duration, y => rigidbody.position = rigidbody.position.WithY(y), leftSmoothness, rightSmoothness).SetOwner(rigidbody).SetName(rigidbody.name));

            return sequence;
        }

        /// <summary>
        /// Create tween which bounce rigidbody's rotation.
        /// </summary>
        /// <param name="rigidbody">Target material.</param>
        /// <param name="count">Bounce count.</param>
        /// <param name="rotation">Bounce rotation.</param>
        /// <param name="duration">Sequence's duration.</param>
        /// <param name="leftSmoothness">Smothness from start.</param>
        /// <param name="rightSmoothness">Smothness at end.</param>
        /// <returns>The sequence.</returns>
        public static Tween<float, TweakFloat> DoPunchRotation(this Rigidbody2D rigidbody, float rotation, int count, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            return Tween.Punch(rigidbody.rotation, count, rotation, duration, rotation => rigidbody.rotation = rotation, leftSmoothness, rightSmoothness).SetOwner(rigidbody).SetName(rigidbody.name);
        }
        #endregion
    }
}