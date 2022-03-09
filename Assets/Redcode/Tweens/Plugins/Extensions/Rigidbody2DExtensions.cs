using Redcode.Extensions;
using Tweens.Formulas;
using Tweens.Tweaks;
using UnityEngine;

namespace Tweens
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
        private static Tween<float, TweakFloat> DoPositionOneAxis(GameObject owner, Rigidbody2D rigidbody, int axis, float position, float duration, FormulaBase formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(owner, owner.name, rigidbody.position[axis], position, p => rigidbody.SetPosition(axis, p), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPositionX(this Rigidbody2D rigidbody, float x, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPositionOneAxis(rigidbody.gameObject, rigidbody, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPositionX(this Rigidbody2D rigidbody, GameObject owner, float x, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPositionOneAxis(owner, rigidbody, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPositionY(this Rigidbody2D rigidbody, float y, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPositionOneAxis(rigidbody.gameObject, rigidbody, 1, y, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPositionY(this Rigidbody2D rigidbody, GameObject owner, float y, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPositionOneAxis(owner, rigidbody, 1, y, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoPosition
        public static Tween<Vector2, TweakVector2> DoPosition(this Rigidbody2D rigidbody, float x, float y, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPosition(rigidbody, rigidbody.gameObject, new Vector2(x, y), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoPosition(this Rigidbody2D rigidbody, GameObject owner, float x, float y, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPosition(rigidbody, owner, new Vector3(x, y), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoPosition(this Rigidbody2D rigidbody, Vector2 position, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPosition(rigidbody, rigidbody.gameObject, position, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoPosition(this Rigidbody2D rigidbody, GameObject owner, Vector2 position, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Vector2(owner, owner.name, rigidbody.position, position, p => rigidbody.position = p, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoRotation
        public static Tween<float, TweakFloat> DoRotation(this Rigidbody2D rigidbody, float rotation, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoRotation(rigidbody, rigidbody.gameObject, rotation, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoRotation(this Rigidbody2D rigidbody, GameObject owner, float rotation, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(owner, owner.name, rigidbody.rotation, rotation, r => rigidbody.rotation = r, duration, formula, loopsCount, loopType, direction);
        }
        #endregion
    }
}