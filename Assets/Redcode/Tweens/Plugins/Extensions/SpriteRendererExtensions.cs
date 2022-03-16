using Redcode.Tweens.Tweaks;
using UnityEngine;

namespace Redcode.Tweens
{
    public static class SpriteRendererExtensions
    {
        private static void SetColor(this SpriteRenderer sprite, int axis, float color)
        {
            var col = sprite.color;
            col[axis] = color;
            sprite.color = col;
        }

        #region DoColorOneAxis
        private static Tween<float, TweakFloat> DoColorOneAxis(SpriteRenderer sprite, GameObject owner, int axis, float color, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(owner, owner.name, sprite.color[axis], color, c => sprite.SetColor(axis, c), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorR(this SpriteRenderer sprite, float r, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(sprite, sprite.gameObject, 0, r, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorR(this SpriteRenderer sprite, GameObject owner, float r, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(sprite, owner, 0, r, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorG(this SpriteRenderer sprite, float g, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(sprite, sprite.gameObject, 1, g, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorG(this SpriteRenderer sprite, GameObject owner, float g, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(sprite, owner, 1, g, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorB(this SpriteRenderer sprite, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(sprite, sprite.gameObject, 2, b, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorB(this SpriteRenderer sprite, GameObject owner, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(sprite, owner, 2, b, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorA(this SpriteRenderer sprite, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(sprite, sprite.gameObject, 3, a, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorA(this SpriteRenderer sprite, GameObject owner, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(sprite, owner, 3, a, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoColorTwoAxes
        private static Sequence DoColorTwoAxes(SpriteRenderer sprite, GameObject owner, int axis1, int axis2, float color1, float color2, float duration, Ease formula, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            var sequence = new Sequence(owner, owner.name, formula, loopsCount, loopType, loopResetBehaviour, direction);

            sequence.Insert(0f, Tween.Float(owner, owner.name, sprite.color[axis1], color1, c => sprite.SetColor(axis1, c), duration, formula, loopsCount, loopType, direction));
            sequence.Insert(0f, Tween.Float(owner, owner.name, sprite.color[axis2], color2, c => sprite.SetColor(axis2, c), duration, formula, loopsCount, loopType, direction));

            return sequence;
        }

        public static Sequence DoColorRG(this SpriteRenderer sprite, float r, float g, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(sprite, sprite.gameObject, 0, 1, r, g, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorRG(this SpriteRenderer sprite, GameObject owner, float r, float g, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(sprite, owner, 0, 1, r, g, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorRB(this SpriteRenderer sprite, float r, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(sprite, sprite.gameObject, 0, 2, r, b, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorRB(this SpriteRenderer sprite, GameObject owner, float r, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(sprite, owner, 0, 2, r, b, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorRA(this SpriteRenderer sprite, float r, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(sprite, sprite.gameObject, 0, 3, r, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorRA(this SpriteRenderer sprite, GameObject owner, float r, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(sprite, owner, 0, 3, r, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorGB(this SpriteRenderer sprite, float g, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(sprite, sprite.gameObject, 1, 2, g, b, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorGB(this SpriteRenderer sprite, GameObject owner, float g, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(sprite, owner, 1, 2, g, b, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorGA(this SpriteRenderer sprite, float g, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(sprite, sprite.gameObject, 1, 3, g, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorGA(this SpriteRenderer sprite, GameObject owner, float g, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(sprite, owner, 1, 3, g, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorBA(this SpriteRenderer sprite, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(sprite, sprite.gameObject, 2, 3, b, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorBA(this SpriteRenderer sprite, GameObject owner, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(sprite, owner, 2, 3, b, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoColorThreeAxes
        private static Sequence DoColorThreeAxes(SpriteRenderer sprite, GameObject owner, int axis1, int axis2, int axis3, float color1, float color2, float color3, float duration, Ease formula, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            var sequence = new Sequence(owner, owner.name, formula, loopsCount, loopType, loopResetBehaviour, direction);

            sequence.Insert(0f, Tween.Float(owner, owner.name, sprite.color[axis1], color1, c => sprite.SetColor(axis1, c), duration, formula, loopsCount, loopType, direction));
            sequence.Insert(0f, Tween.Float(owner, owner.name, sprite.color[axis2], color2, c => sprite.SetColor(axis2, c), duration, formula, loopsCount, loopType, direction));
            sequence.Insert(0f, Tween.Float(owner, owner.name, sprite.color[axis3], color3, c => sprite.SetColor(axis3, c), duration, formula, loopsCount, loopType, direction));

            return sequence;
        }

        public static Sequence DoColorRGB(this SpriteRenderer sprite, float r, float g, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeAxes(sprite, sprite.gameObject, 0, 1, 2, r, g, b, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorRGB(this SpriteRenderer sprite, GameObject owner, float r, float g, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeAxes(sprite, owner, 0, 1, 2, r, g, b, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorRGA(this SpriteRenderer sprite, float r, float g, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeAxes(sprite, sprite.gameObject, 0, 1, 3, r, g, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorRGA(this SpriteRenderer sprite, GameObject owner, float r, float g, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeAxes(sprite, owner, 0, 1, 3, r, g, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorRBA(this SpriteRenderer sprite, float r, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeAxes(sprite, sprite.gameObject, 0, 2, 3, r, b, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorRBA(this SpriteRenderer sprite, GameObject owner, float r, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeAxes(sprite, owner, 0, 2, 3, r, b, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorGBA(this SpriteRenderer sprite, float g, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeAxes(sprite, sprite.gameObject, 1, 2, 3, g, b, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorGBA(this SpriteRenderer sprite, GameObject owner, float g, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeAxes(sprite, owner, 1, 2, 3, g, b, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoColor
        public static Tween<Color, TweakColor> DoColor(this SpriteRenderer sprite, float r, float g, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColor(sprite, sprite.gameObject, new Color(r, g, b, a), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Color, TweakColor> DoColor(this SpriteRenderer sprite, GameObject owner, float r, float g, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColor(sprite, owner, new Color(r, g, b, a), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Color, TweakColor> DoColor(this SpriteRenderer sprite, Color color, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColor(sprite, sprite.gameObject, color, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Color, TweakColor> DoColor(this SpriteRenderer sprite, GameObject owner, Color color, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Color(owner, owner.name, sprite.color, color, c => sprite.color = color, duration, formula, loopsCount, loopType, direction);
        }
        #endregion
    }
}