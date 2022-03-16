using Redcode.Tweens.Tweaks;
using UnityEngine;
using UnityEngine.UI;

namespace Redcode.Tweens
{
    public static class GraphicExtensions
    {
        #region DoColor
        private static void SetColor(this Graphic graphic, int axis, float color)
        {
            var col = graphic.color;
            col[axis] = color;
            graphic.color = col;
        }

        #region DoColorOneAxis
        private static Tween<float, TweakFloat> DoColorOneAxis(Graphic graphic, GameObject owner, int axis, float color, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(owner, owner.name, graphic.color[axis], color, c => graphic.SetColor(axis, c), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorR(this Graphic graphic, float r, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(graphic, graphic.gameObject, 0, r, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorR(this Graphic graphic, GameObject owner, float r, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(graphic, owner, 0, r, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorG(this Graphic graphic, float g, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(graphic, graphic.gameObject, 1, g, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorG(this Graphic graphic, GameObject owner, float g, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(graphic, owner, 1, g, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorB(this Graphic graphic, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(graphic, graphic.gameObject, 2, b, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorB(this Graphic graphic, GameObject owner, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(graphic, owner, 2, b, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorA(this Graphic graphic, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(graphic, graphic.gameObject, 3, a, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorA(this Graphic graphic, GameObject owner, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(graphic, owner, 3, a, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoColorTwoAxes
        private static Sequence DoColorTwoAxes(Graphic graphic, GameObject owner, int axis1, int axis2, float color1, float color2, float duration, Ease formula, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            var sequence = new Sequence(owner, owner.name, formula, loopsCount, loopType, loopResetBehaviour, direction);

            sequence.Insert(0f, Tween.Float(owner, owner.name, graphic.color[axis1], color1, c => graphic.SetColor(axis1, c), duration, formula, loopsCount, loopType, direction));
            sequence.Insert(0f, Tween.Float(owner, owner.name, graphic.color[axis2], color2, c => graphic.SetColor(axis2, c), duration, formula, loopsCount, loopType, direction));

            return sequence;
        }

        public static Sequence DoColorRG(this Graphic graphic, float r, float g, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(graphic, graphic.gameObject, 0, 1, r, g, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorRG(this Graphic graphic, GameObject owner, float r, float g, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(graphic, owner, 0, 1, r, g, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorRB(this Graphic graphic, float r, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(graphic, graphic.gameObject, 0, 2, r, b, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorRB(this Graphic graphic, GameObject owner, float r, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(graphic, owner, 0, 2, r, b, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorRA(this Graphic graphic, float r, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(graphic, graphic.gameObject, 0, 3, r, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorRA(this Graphic graphic, GameObject owner, float r, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(graphic, owner, 0, 3, r, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorGB(this Graphic graphic, float g, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(graphic, graphic.gameObject, 1, 2, g, b, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorGB(this Graphic graphic, GameObject owner, float g, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(graphic, owner, 1, 2, g, b, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorGA(this Graphic graphic, float g, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(graphic, graphic.gameObject, 1, 3, g, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorGA(this Graphic graphic, GameObject owner, float g, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(graphic, owner, 1, 3, g, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorBA(this Graphic graphic, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(graphic, graphic.gameObject, 2, 3, b, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorBA(this Graphic graphic, GameObject owner, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(graphic, owner, 2, 3, b, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoColorThreeAxes
        private static Sequence DoColorThreeAxes(Graphic graphic, GameObject owner, int axis1, int axis2, int axis3, float color1, float color2, float color3, float duration, Ease formula, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            var sequence = new Sequence(owner, owner.name, formula, loopsCount, loopType, loopResetBehaviour, direction);

            sequence.Insert(0f, Tween.Float(owner, owner.name, graphic.color[axis1], color1, c => graphic.SetColor(axis1, c), duration, formula, loopsCount, loopType, direction));
            sequence.Insert(0f, Tween.Float(owner, owner.name, graphic.color[axis2], color2, c => graphic.SetColor(axis2, c), duration, formula, loopsCount, loopType, direction));
            sequence.Insert(0f, Tween.Float(owner, owner.name, graphic.color[axis3], color3, c => graphic.SetColor(axis3, c), duration, formula, loopsCount, loopType, direction));

            return sequence;
        }

        public static Sequence DoColorRGB(this Graphic graphic, float r, float g, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeAxes(graphic, graphic.gameObject, 0, 1, 2, r, g, b, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorRGB(this Graphic graphic, GameObject owner, float r, float g, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeAxes(graphic, owner, 0, 1, 2, r, g, b, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorRGA(this Graphic graphic, float r, float g, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeAxes(graphic, graphic.gameObject, 0, 1, 3, r, g, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorRGA(this Graphic graphic, GameObject owner, float r, float g, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeAxes(graphic, owner, 0, 1, 3, r, g, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorRBA(this Graphic graphic, float r, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeAxes(graphic, graphic.gameObject, 0, 2, 3, r, b, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorRBA(this Graphic graphic, GameObject owner, float r, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeAxes(graphic, owner, 0, 2, 3, r, b, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorGBA(this Graphic graphic, float g, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeAxes(graphic, graphic.gameObject, 1, 2, 3, g, b, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorGBA(this Graphic graphic, GameObject owner, float g, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeAxes(graphic, owner, 1, 2, 3, g, b, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        public static Tween<Color, TweakColor> DoColor(this Graphic graphic, float r, float g, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColor(graphic, graphic.gameObject, new Color(r, g, b, a), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Color, TweakColor> DoColor(this Graphic graphic, GameObject owner, float r, float g, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColor(graphic, owner, new Color(r, g, b, a), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Color, TweakColor> DoColor(this Graphic graphic, Color color, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColor(graphic, graphic.gameObject, color, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Color, TweakColor> DoColor(this Graphic graphic, GameObject owner, Color color, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Color(owner, owner.name, graphic.color, color, c => graphic.color = color, duration, formula, loopsCount, loopType, direction);
        }
        #endregion
    }
}