using Redcode.Tweens.Tweaks;
using UnityEngine;

namespace Redcode.Tweens
{
    public static class TextMeshExtensions
	{
        #region DoCharacterSize
        public static Tween<float, TweakFloat> DoCharacterSize(this TextMesh text, float size, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return DoCharacterSize(text, text.gameObject, size, duration, formula, loopsCount, loopType, direction);
		}

		public static Tween<float, TweakFloat> DoCharacterSize(this TextMesh text, GameObject owner, float size, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(owner, owner.name, text.characterSize, size, s => text.characterSize = s, duration, formula, loopsCount, loopType, direction);
		}
		#endregion

		#region DoLineSpacing
		public static Tween<float, TweakFloat> DoLineSpacing(this TextMesh text, float spacing, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return DoLineSpacing(text, text.gameObject, spacing, duration, formula, loopsCount, loopType, direction);
		}

		public static Tween<float, TweakFloat> DoLineSpacing(this TextMesh text, GameObject owner, float spacing, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Float(owner, owner.name, text.lineSpacing, spacing, ls => text.lineSpacing = ls, duration, formula, loopsCount, loopType, direction);
		}
		#endregion

		#region DoFontSize
		public static Tween<int, TweakInt> DoFontSize(this TextMesh text, int size, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return DoFontSize(text, text.gameObject, size, duration, formula, loopsCount, loopType, direction);
		}

		public static Tween<int, TweakInt> DoFontSize(this TextMesh text, GameObject owner, int size, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
		{
			return Tween.Int(owner, owner.name, text.fontSize, size, fs => text.fontSize = fs, duration, formula, loopsCount, loopType, direction);
		}
        #endregion

        #region DoColor
        private static void SetColor(this TextMesh text, int axis, float color)
        {
            var col = text.color;
            col[axis] = color;
            text.color = col;
        }

        #region DoColorOneAxis
        private static Tween<float, TweakFloat> DoColorOneAxis(TextMesh text, GameObject owner, int axis, float color, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(owner, owner.name, text.color[axis], color, c => text.SetColor(axis, c), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorR(this TextMesh text, float r, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(text, text.gameObject, 0, r, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorR(this TextMesh text, GameObject owner, float r, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(text, owner, 0, r, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorG(this TextMesh text, float g, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(text, text.gameObject, 1, g, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorG(this TextMesh text, GameObject owner, float g, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(text, owner, 1, g, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorB(this TextMesh text, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(text, text.gameObject, 2, b, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorB(this TextMesh text, GameObject owner, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(text, owner, 2, b, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorA(this TextMesh text, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(text, text.gameObject, 3, a, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorA(this TextMesh text, GameObject owner, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(text, owner, 3, a, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoColorTwoAxes
        private static Sequence DoColorTwoAxes(TextMesh text, GameObject owner, int axis1, int axis2, float color1, float color2, float duration, Ease formula, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            var sequence = new Sequence(owner, owner.name, formula, loopsCount, loopType, loopResetBehaviour, direction);

            sequence.Insert(0f, Tween.Float(owner, owner.name, text.color[axis1], color1, c => text.SetColor(axis1, c), duration, formula, loopsCount, loopType, direction));
            sequence.Insert(0f, Tween.Float(owner, owner.name, text.color[axis2], color2, c => text.SetColor(axis2, c), duration, formula, loopsCount, loopType, direction));

            return sequence;
        }

        public static Sequence DoColorRG(this TextMesh text, float r, float g, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(text, text.gameObject, 0, 1, r, g, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorRG(this TextMesh text, GameObject owner, float r, float g, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(text, owner, 0, 1, r, g, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorRB(this TextMesh text, float r, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(text, text.gameObject, 0, 2, r, b, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorRB(this TextMesh text, GameObject owner, float r, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(text, owner, 0, 2, r, b, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorRA(this TextMesh text, float r, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(text, text.gameObject, 0, 3, r, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorRA(this TextMesh text, GameObject owner, float r, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(text, owner, 0, 3, r, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorGB(this TextMesh text, float g, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(text, text.gameObject, 1, 2, g, b, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorGB(this TextMesh text, GameObject owner, float g, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(text, owner, 1, 2, g, b, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorGA(this TextMesh text, float g, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(text, text.gameObject, 1, 3, g, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorGA(this TextMesh text, GameObject owner, float g, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(text, owner, 1, 3, g, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorBA(this TextMesh text, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(text, text.gameObject, 2, 3, b, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorBA(this TextMesh text, GameObject owner, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(text, owner, 2, 3, b, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoColorThreeAxes
        private static Sequence DoColorThreeAxes(TextMesh text, GameObject owner, int axis1, int axis2, int axis3, float color1, float color2, float color3, float duration, Ease formula, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            var sequence = new Sequence(owner, owner.name, formula, loopsCount, loopType, loopResetBehaviour, direction);

            sequence.Insert(0f, Tween.Float(owner, owner.name, text.color[axis1], color1, c => text.SetColor(axis1, c), duration, formula, loopsCount, loopType, direction));
            sequence.Insert(0f, Tween.Float(owner, owner.name, text.color[axis2], color2, c => text.SetColor(axis2, c), duration, formula, loopsCount, loopType, direction));
            sequence.Insert(0f, Tween.Float(owner, owner.name, text.color[axis3], color3, c => text.SetColor(axis3, c), duration, formula, loopsCount, loopType, direction));

            return sequence;
        }

        public static Sequence DoColorRGB(this TextMesh text, float r, float g, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeAxes(text, text.gameObject, 0, 1, 2, r, g, b, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorRGB(this TextMesh text, GameObject owner, float r, float g, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeAxes(text, owner, 0, 1, 2, r, g, b, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorRGA(this TextMesh text, float r, float g, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeAxes(text, text.gameObject, 0, 1, 3, r, g, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorRGA(this TextMesh text, GameObject owner, float r, float g, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeAxes(text, owner, 0, 1, 3, r, g, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorRBA(this TextMesh text, float r, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeAxes(text, text.gameObject, 0, 2, 3, r, b, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorRBA(this TextMesh text, GameObject owner, float r, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeAxes(text, owner, 0, 2, 3, r, b, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorGBA(this TextMesh text, float g, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeAxes(text, text.gameObject, 1, 2, 3, g, b, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorGBA(this TextMesh text, GameObject owner, float g, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeAxes(text, owner, 1, 2, 3, g, b, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        public static Tween<Color, TweakColor> DoColor(this TextMesh text, float r, float g, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColor(text, text.gameObject, new Color(r, g, b, a), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Color, TweakColor> DoColor(this TextMesh text, GameObject owner, float r, float g, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColor(text, owner, new Color(r, g, b, a), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Color, TweakColor> DoColor(this TextMesh text, Color color, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColor(text, text.gameObject, color, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Color, TweakColor> DoColor(this TextMesh text, GameObject owner, Color color, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Color(owner, owner.name, text.color, color, c => text.color = color, duration, formula, loopsCount, loopType, direction);
        }
        #endregion
    }
}