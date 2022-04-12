using Redcode.Extensions;
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

        /// <summary>
		/// Tweens rigidbody's position x.
		/// </summary>
		/// <param name="rigidbody">Target rigidbody.</param>
		/// <param name="x">Target position x.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<float, TweakFloat> DoPositionX(this Rigidbody rigidbody, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPositionOneAxis(rigidbody.gameObject, rigidbody, 0, x, duration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
		/// Tweens rigidbody's position y.
		/// </summary>
		/// <param name="rigidbody">Target rigidbody.</param>
		/// <param name="y">Target position y.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<float, TweakFloat> DoPositionY(this Rigidbody rigidbody, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPositionOneAxis(rigidbody.gameObject, rigidbody, 1, y, duration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
		/// Tweens rigidbody's position z.
		/// </summary>
		/// <param name="rigidbody">Target rigidbody.</param>
		/// <param name="z">Target position z.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
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

        /// <summary>
		/// Tweens rigidbody's position x and y.
		/// </summary>
		/// <param name="rigidbody">Target rigidbody.</param>
		/// <param name="x">Target position x.</param>
		/// <param name="y">Target position y.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Vector2, TweakVector2> DoPositionXY(this Rigidbody rigidbody, float x, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoPositionTwoAxes(rigidbody.gameObject, rigidbody, 0, 1, x, y, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        /// <summary>
		/// Tweens rigidbody's position x and z.
		/// </summary>
		/// <param name="rigidbody">Target rigidbody.</param>
		/// <param name="x">Target position x.</param>
		/// <param name="z">Target position z.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Vector2, TweakVector2> DoPositionXZ(this Rigidbody rigidbody, float x, float z, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoPositionTwoAxes(rigidbody.gameObject, rigidbody, 0, 2, x, z, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        /// <summary>
		/// Tweens rigidbody's position y and z.
		/// </summary>
		/// <param name="rigidbody">Target rigidbody.</param>
		/// <param name="y">Target position y.</param>
		/// <param name="z">Target position z.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Vector2, TweakVector2> DoPositionYZ(this Rigidbody rigidbody, float y, float z, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoPositionTwoAxes(rigidbody.gameObject, rigidbody, 1, 2, y, z, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoPosition
        /// <summary>
		/// Tweens rigidbody's position.
		/// </summary>
		/// <param name="rigidbody">Target rigidbody.</param>
		/// <param name="x">Target position x.</param>
		/// <param name="y">Target position y.</param>
		/// <param name="z">Target position z.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Vector3, TweakVector3> DoPosition(this Rigidbody rigidbody, float x, float y, float z, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPosition(rigidbody, new Vector3(x, y, z), duration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
		/// Tweens rigidbody's position.
		/// </summary>
		/// <param name="rigidbody">Target rigidbody.</param>
		/// <param name="position">Target position.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Vector3, TweakVector3> DoPosition(this Rigidbody rigidbody, Vector3 position, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Vector3(rigidbody.position, position, p => rigidbody.position = p, duration, ease, loopsCount, loopType, direction).SetOwner(rigidbody).SetName(rigidbody.name);
        }
        #endregion

        /// <summary>
		/// Tweens rigidbody's position.
		/// </summary>
		/// <param name="rigidbody">Target rigidbody.</param>
		/// <param name="rotation">Target rotation.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Quaternion, TweakQuaternion> DoRotation(this Rigidbody rigidbody, Quaternion rotation, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Quaternion(rigidbody.rotation, rotation, r => rigidbody.rotation = r, duration, ease, loopsCount, loopType, direction).SetOwner(rigidbody).SetName(rigidbody.name);
        }

        #region DoLookAt
        /// <summary>
		/// Tweens rigidbody's position.
		/// </summary>
		/// <param name="rigidbody">Target rigidbody.</param>
		/// <param name="gameObject">Target object.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Quaternion, TweakQuaternion> DoLookAt(this Rigidbody rigidbody, GameObject gameObject, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLookAt(rigidbody, gameObject.transform.position, duration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
		/// Tweens rigidbody's position.
		/// </summary>
		/// <param name="rigidbody">Target rigidbody.</param>
		/// <param name="target">Target target.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Quaternion, TweakQuaternion> DoLookAt(this Rigidbody rigidbody, Transform target, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoLookAt(rigidbody, target.position, duration, ease, loopsCount, loopType, direction);
        }

        /// <summary>
		/// Tweens rigidbody's position.
		/// </summary>
		/// <param name="rigidbody">Target rigidbody.</param>
		/// <param name="point">Target point.</param>
		/// <param name="duration">Tween's duration.</param>
		/// <param name="ease">Tween's ease formula.</param>
		/// <param name="loopsCount">Tweenls loops count.</param>
		/// <param name="loopType">Tween's loop type.</param>
		/// <param name="direction">Tween's direction.</param>
		/// <returns>The tween.</returns>
        public static Tween<Quaternion, TweakQuaternion> DoLookAt(this Rigidbody rigidbody, Vector3 point, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoRotation(rigidbody, Quaternion.LookRotation(point - rigidbody.position), duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoShake
        #region DoShakePosition
        /// <summary>
        /// Create sequence which shakes rigidbody's position.
        /// </summary>
        /// <param name="rigidbody">Target rigidbody.</param>
        /// <param name="count">Shakes count.</param>
        /// <param name="strenght">Shakes strenght.</param>
        /// <param name="duration">Sequence's duration.</param>
        /// <param name="leftSmoothness">Smothness from start.</param>
        /// <param name="rightSmoothness">Smothness at end.</param>
        /// <returns>The sequence.</returns>
        public static Sequence DoShakePosition(this Rigidbody rigidbody, int count = 10, float strenght = 1f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakePosition(rigidbody, new Vector3Int(count, count, count), strenght, duration, leftSmoothness, rightSmoothness);
        }

        /// <summary>
        /// Create sequence which shakes rigidbody's position.
        /// </summary>
        /// <param name="rigidbody">Target rigidbody.</param>
        /// <param name="count">Shakes count.</param>
        /// <param name="strenght">Shakes strenght.</param>
        /// <param name="duration">Sequence's duration.</param>
        /// <param name="leftSmoothness">Smothness from start.</param>
        /// <param name="rightSmoothness">Smothness at end.</param>
        /// <returns>The sequence.</returns>
        public static Sequence DoShakePosition(this Rigidbody rigidbody, Vector3Int count, float strenght = 1f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakePosition(rigidbody, count, new Vector3(strenght, strenght, strenght), duration, leftSmoothness, rightSmoothness);
        }

        /// <summary>
        /// Create sequence which shakes rigidbody's position.
        /// </summary>
        /// <param name="rigidbody">Target rigidbody.</param>
        /// <param name="count">Shakes count.</param>
        /// <param name="strenght">Shakes strenght.</param>
        /// <param name="duration">Sequence's duration.</param>
        /// <param name="leftSmoothness">Smothness from start.</param>
        /// <param name="rightSmoothness">Smothness at end.</param>
        /// <returns>The sequence.</returns>
        public static Sequence DoShakePosition(this Rigidbody rigidbody, int count, Vector3 strenght, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakePosition(rigidbody, new Vector3Int(count, count, count), strenght, duration, leftSmoothness, rightSmoothness);
        }

        /// <summary>
        /// Create sequence which shakes rigidbody's position.
        /// </summary>
        /// <param name="rigidbody">Target rigidbody.</param>
        /// <param name="count">Shakes count.</param>
        /// <param name="strenght">Shakes strenght.</param>
        /// <param name="duration">Sequence's duration.</param>
        /// <param name="leftSmoothness">Smothness from start.</param>
        /// <param name="rightSmoothness">Smothness at end.</param>
        /// <returns>The sequence.</returns>
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
        /// <summary>
        /// Create sequence which shakes rigidbody's euler angles.
        /// </summary>
        /// <param name="rigidbody">Target rigidbody.</param>
        /// <param name="count">Shakes count.</param>
        /// <param name="angles">Shakes rotation.</param>
        /// <param name="duration">Sequence's duration.</param>
        /// <param name="leftSmoothness">Smothness from start.</param>
        /// <param name="rightSmoothness">Smothness at end.</param>
        /// <returns>The sequence.</returns>
        public static Sequence DoShakeEulerAngles(this Rigidbody rigidbody, int count = 8, float angles = 45f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeEulerAngles(rigidbody, new Vector3Int(count, count, count), angles, duration, leftSmoothness, rightSmoothness);
        }

        /// <summary>
        /// Create sequence which shakes rigidbody's euler angles.
        /// </summary>
        /// <param name="rigidbody">Target rigidbody.</param>
        /// <param name="count">Shakes count.</param>
        /// <param name="angles">Shakes rotation.</param>
        /// <param name="duration">Sequence's duration.</param>
        /// <param name="leftSmoothness">Smothness from start.</param>
        /// <param name="rightSmoothness">Smothness at end.</param>
        /// <returns>The sequence.</returns>
        public static Sequence DoShakeEulerAngles(this Rigidbody rigidbody, Vector3Int count, float angles = 45f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeEulerAngles(rigidbody, count, new Vector3(angles, angles, angles), duration, leftSmoothness, rightSmoothness);
        }

        /// <summary>
        /// Create sequence which shakes rigidbody's euler angles.
        /// </summary>
        /// <param name="rigidbody">Target rigidbody.</param>
        /// <param name="count">Shakes count.</param>
        /// <param name="angles">Shakes rotation.</param>
        /// <param name="duration">Sequence's duration.</param>
        /// <param name="leftSmoothness">Smothness from start.</param>
        /// <param name="rightSmoothness">Smothness at end.</param>
        /// <returns>The sequence.</returns>
        public static Sequence DoShakeEulerAngles(this Rigidbody rigidbody, int count, Vector3 angles, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeEulerAngles(rigidbody, new Vector3Int(count, count, count), angles, duration, leftSmoothness, rightSmoothness);
        }

        /// <summary>
        /// Create sequence which shakes rigidbody's euler angles.
        /// </summary>
        /// <param name="rigidbody">Target rigidbody.</param>
        /// <param name="count">Shakes count.</param>
        /// <param name="angles">Shakes rotation.</param>
        /// <param name="duration">Sequence's duration.</param>
        /// <param name="leftSmoothness">Smothness from start.</param>
        /// <param name="rightSmoothness">Smothness at end.</param>
        /// <returns>The sequence.</returns>
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
        /// <summary>
        /// Create sequence which bounce rigidbody's position.
        /// </summary>
        /// <param name="rigidbody">Target rigidbody.</param>
        /// <param name="vector">Bounce rotation.</param>
        /// <param name="count">Bounce count.</param>
        /// <param name="duration">Sequence's duration.</param>
        /// <param name="leftSmoothness">Smothness from start.</param>
        /// <param name="rightSmoothness">Smothness at end.</param>
        /// <returns>The sequence.</returns>
        public static Sequence DoPunchPosition(this Rigidbody rigidbody, Vector3 vector, int count, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            var sequence = new Sequence(rigidbody.gameObject, rigidbody.name);

            sequence.Insert(0f, Tween.Punch(rigidbody.position.x, count, vector.x, duration, x => rigidbody.position = rigidbody.position.WithX(x), leftSmoothness, rightSmoothness).SetOwner(rigidbody).SetName(rigidbody.name));
            sequence.Insert(0f, Tween.Punch(rigidbody.position.y, count, vector.y, duration, y => rigidbody.position = rigidbody.position.WithY(y), leftSmoothness, rightSmoothness).SetOwner(rigidbody).SetName(rigidbody.name));
            sequence.Insert(0f, Tween.Punch(rigidbody.position.z, count, vector.z, duration, z => rigidbody.position = rigidbody.position.WithZ(z), leftSmoothness, rightSmoothness).SetOwner(rigidbody).SetName(rigidbody.name));

            return sequence;
        }

        /// <summary>
        /// Create tween which bounce rigidbody's euler angles.
        /// </summary>
        /// <param name="rigidbody">Target rigidbody.</param>
        /// <param name="count">Bounce count.</param>
        /// <param name="angles">Bounce angles values.</param>
        /// <param name="duration">Sequence's duration.</param>
        /// <param name="leftSmoothness">Smothness from start.</param>
        /// <param name="rightSmoothness">Smothness at end.</param>
        /// <returns>The sequence.</returns>
        public static Sequence DoPunchEulerAngles(this Rigidbody rigidbody, Vector3 angles, int count, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            var sequence = new Sequence(rigidbody.gameObject, rigidbody.name);

            sequence.Insert(0f, Tween.Punch(rigidbody.rotation.eulerAngles.x, count, angles.x, duration, x => rigidbody.rotation = Quaternion.Euler(rigidbody.rotation.eulerAngles.WithX(x)), leftSmoothness, rightSmoothness).SetOwner(rigidbody).SetName(rigidbody.name));
            sequence.Insert(0f, Tween.Punch(rigidbody.rotation.eulerAngles.y, count, angles.y, duration, y => rigidbody.rotation = Quaternion.Euler(rigidbody.rotation.eulerAngles.WithY(y)), leftSmoothness, rightSmoothness).SetOwner(rigidbody).SetName(rigidbody.name));
            sequence.Insert(0f, Tween.Punch(rigidbody.rotation.eulerAngles.z, count, angles.z, duration, z => rigidbody.rotation = Quaternion.Euler(rigidbody.rotation.eulerAngles.WithZ(z)), leftSmoothness, rightSmoothness).SetOwner(rigidbody).SetName(rigidbody.name));

            return sequence;
        }

        #region DoPunchRotation
        /// <summary>
        /// Create tween which bounce rigidbody's rotation.
        /// </summary>
        /// <param name="rigidbody">Target rigidbody.</param>
        /// <param name="count">Bounce count.</param>
        /// <param name="direction">Bounce direction.</param>
        /// <param name="duration">Sequence's duration.</param>
        /// <param name="leftSmoothness">Smothness from start.</param>
        /// <param name="rightSmoothness">Smothness at end.</param>
        /// <returns>The sequence.</returns>
        public static Tween<float, TweakFloat> DoPunchRotation(this Rigidbody rigidbody, Vector3 direction, int count = 4, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            return DoPunchRotation(rigidbody, Quaternion.LookRotation(direction), count, duration, leftSmoothness, rightSmoothness);
        }

        /// <summary>
        /// Create tween which bounce rigidbody's rotation.
        /// </summary>
        /// <param name="rigidbody">Target rigidbody.</param>
        /// <param name="count">Bounce count.</param>
        /// <param name="rotation">Bounce rotation.</param>
        /// <param name="duration">Sequence's duration.</param>
        /// <param name="leftSmoothness">Smothness from start.</param>
        /// <param name="rightSmoothness">Smothness at end.</param>
        /// <returns>The sequence.</returns>
        public static Tween<float, TweakFloat> DoPunchRotation(this Rigidbody rigidbody, Quaternion rotation, int count = 4, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            return Tween.Punch(rigidbody.rotation, count, rotation, duration, rot => rigidbody.rotation = rot, leftSmoothness, rightSmoothness).SetOwner(rigidbody).SetName(rigidbody.name);
        }
        #endregion
        #endregion
    }
}