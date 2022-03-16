using Redcode.Extensions;
using Redcode.Tweens.Tweaks;
using UnityEngine;

namespace Redcode.Tweens
{
    public static class MaterialExtensions
    {
        #region DoColor
        private static void SetColor(this Material material, int axis, float color)
        {
            var col = material.color;
            col[axis] = color;
            material.color = col;
        }

        #region DoColorOneAxis
        private static Tween<float, TweakFloat> DoColorOneAxis(GameObject owner, Material material, int axis, float color, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(owner, owner?.name, material.color[axis], color, c => material.SetColor(axis, c), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorR(this Material material, float r, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(null, material, 0, r, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorR(this Material material, GameObject owner, float r, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(owner, material, 0, r, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorG(this Material material, float g, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(null, material, 1, g, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorG(this Material material, GameObject owner, float g, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(owner, material, 1, g, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorB(this Material material, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(null, material, 2, b, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorB(this Material material, GameObject owner, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(owner, material, 2, b, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorA(this Material material, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(null, material, 3, a, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorA(this Material material, GameObject owner, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(owner, material, 3, a, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoColorTwoAxes
        private static Sequence DoColorTwoAxes(GameObject owner, Material material, int axis1, int axis2, float color1, float color2, float duration, Ease formula, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            var sequence = new Sequence(owner, owner?.name, formula, loopsCount, loopType, loopResetBehaviour, direction);

            sequence.Insert(0f, Tween.Float(owner.gameObject, owner?.name, material.color[axis1], color1, c => material.SetColor(axis1, c), duration, formula, loopsCount, loopType, direction));
            sequence.Insert(0f, Tween.Float(owner.gameObject, owner?.name, material.color[axis2], color2, c => material.SetColor(axis2, c), duration, formula, loopsCount, loopType, direction));

            return sequence;
        }

        public static Sequence DoColorRG(this Material material, float r, float g, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(null, material, 0, 1, r, g, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorRG(this Material material, GameObject owner, float r, float g, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(owner, material, 0, 1, r, g, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorRB(this Material material, float r, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(null, material, 0, 2, r, b, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorRB(this Material material, GameObject owner, float r, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(owner, material, 0, 2, r, b, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorRA(this Material material, float r, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(null, material, 0, 3, r, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorRA(this Material material, GameObject owner, float r, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(owner, material, 0, 3, r, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorGB(this Material material, float g, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(null, material, 1, 2, g, b, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorGB(this Material material, GameObject owner, float g, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(owner, material, 1, 2, g, b, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorGA(this Material material, float g, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(null, material, 1, 3, g, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorGA(this Material material, GameObject owner, float g, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(owner, material, 1, 3, g, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorBA(this Material material, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(null, material, 2, 3, b, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorBA(this Material material, GameObject owner, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(owner, material, 2, 3, b, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoColorThreeAxes
        private static Sequence DoColorThreeAxes(GameObject owner, Material material, int axis1, int axis2, int axis3, float color1, float color2, float color3, float duration, Ease formula, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            var sequence = new Sequence(owner, owner?.name, formula, loopsCount, loopType, loopResetBehaviour, direction);

            sequence.Insert(0f, Tween.Float(owner, owner?.name, material.color[axis1], color1, c => material.SetColor(axis1, c), duration, formula, loopsCount, loopType, direction));
            sequence.Insert(0f, Tween.Float(owner, owner?.name, material.color[axis2], color2, c => material.SetColor(axis2, c), duration, formula, loopsCount, loopType, direction));
            sequence.Insert(0f, Tween.Float(owner, owner?.name, material.color[axis3], color3, c => material.SetColor(axis3, c), duration, formula, loopsCount, loopType, direction));

            return sequence;
        }

        public static Sequence DoColorRGB(this Material material, float r, float g, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeAxes(null, material, 0, 1, 2, r, g, b, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorRGB(this Material material, GameObject owner, float r, float g, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeAxes(owner, material, 0, 1, 2, r, g, b, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorRGA(this Material material, float r, float g, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeAxes(null, material, 0, 1, 3, r, g, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorRGA(this Material material, GameObject owner, float r, float g, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeAxes(owner, material, 0, 1, 3, r, g, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorRBA(this Material material, float r, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeAxes(null, material, 0, 2, 3, r, b, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorRBA(this Material material, GameObject owner, float r, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeAxes(owner, material, 0, 2, 3, r, b, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorGBA(this Material material, float g, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeAxes(null, material, 1, 2, 3, g, b, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorGBA(this Material material, GameObject owner, float g, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeAxes(owner, material, 1, 2, 3, g, b, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoColor
        public static Tween<Color, TweakColor> DoColor(this Material material, float r, float g, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColor(material, new Color(r, g, b, a), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Color, TweakColor> DoColor(this Material material, GameObject owner, float r, float g, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColor(material, owner, new Color(r, g, b, a), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Color, TweakColor> DoColor(this Material material, Color color, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColor(material, null, color, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Color, TweakColor> DoColor(this Material material, GameObject owner, Color color, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Color(owner, owner?.name, material.color, color, c => material.color = c, duration, formula, loopsCount, loopType, direction);
        }
        #endregion
        #endregion

        #region DoMainTextureOffset
        public static Tween<float, TweakFloat> DoMainTextureOffsetX(this Material material, float x, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoMainTextureOffsetX(material, null, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoMainTextureOffsetX(this Material material, GameObject owner, float x, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(owner, owner?.name, material.mainTextureOffset.x, x, ox => material.mainTextureOffset = material.mainTextureOffset.WithX(ox), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoMainTextureOffsetY(this Material material, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoMainTextureOffsetY(material, null, y, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoMainTextureOffsetY(this Material material, GameObject owner, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(owner, owner?.name, material.mainTextureOffset.y, y, oy => material.mainTextureOffset = material.mainTextureOffset.WithY(oy), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoMainTextureOffset(this Material material, float x, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoMainTextureOffset(material, new Vector2(x, y), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoMainTextureOffset(this Material material, Vector2 offset, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoMainTextureOffset(material, null, offset, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoMainTextureOffset(this Material material, GameObject owner, float x, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoMainTextureOffset(material, owner, new Vector2(x, y), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoMainTextureOffset(this Material material, GameObject owner, Vector2 offset, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Vector2(owner, owner?.name, material.mainTextureOffset, offset, o => material.mainTextureOffset = o, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoMainTextureScale
        public static Tween<float, TweakFloat> DoMainTextureScaleX(this Material material, float x, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoMainTextureScaleX(material, null, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoMainTextureScaleX(this Material material, GameObject owner, float x, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(owner, owner?.name, material.mainTextureScale.x, x, ox => material.mainTextureScale = material.mainTextureScale.WithX(ox), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoMainTextureScaleY(this Material material, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoMainTextureScaleY(material, null, y, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoMainTextureScaleY(this Material material, GameObject owner, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(owner, owner?.name, material.mainTextureScale.y, y, oy => material.mainTextureScale = material.mainTextureScale.WithY(oy), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoMainTextureScale(this Material material, float x, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoMainTextureScale(material, new Vector2(x, y), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoMainTextureScale(this Material material, Vector2 scale, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoMainTextureScale(material, null, scale, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoMainTextureScale(this Material material, GameObject owner, float x, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoMainTextureScale(material, owner, new Vector2(x, y), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoMainTextureScale(this Material material, GameObject owner, Vector2 scale, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Vector2(owner, owner?.name, material.mainTextureScale, scale, s => material.mainTextureScale = s, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoColorProperty
        private static void SetColorProperty(this Material material, string property, int axis, float color)
        {
            var col = material.GetColor(property);
            col[axis] = color;
            material.SetColor(property, col);
        }

        #region DoColorPropertyOneAxis
        private static Tween<float, TweakFloat> DoColorPropertyOneAxis(GameObject owner, Material material, string property, int axis, float color, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(owner, owner?.name, material.GetColor(property)[axis], color, c => material.SetColorProperty(property, axis, c), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorPropertyR(this Material material, string property, float r, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorPropertyOneAxis(null, material, property, 0, r, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorPropertyR(this Material material, string property, GameObject owner, float r, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorPropertyOneAxis(owner, material, property, 0, r, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorPropertyG(this Material material, string property, float g, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorPropertyOneAxis(null, material, property, 1, g, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorPropertyG(this Material material, GameObject owner, string property, float g, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorPropertyOneAxis(owner, material, property, 1, g, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorPropertyB(this Material material, string property, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorPropertyOneAxis(null, material, property, 2, b, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorPropertyB(this Material material, GameObject owner, string property, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorPropertyOneAxis(owner, material, property, 2, b, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorPropertyA(this Material material, string property, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorPropertyOneAxis(null, material, property, 3, a, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorPropertyA(this Material material, GameObject owner, string property, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorPropertyOneAxis(owner, material, property, 3, a, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoColorPropertyTwoAxes
        private static Sequence DoColorPropertyTwoAxes(GameObject owner, Material material, string property, int axis1, int axis2, float color1, float color2, float duration, Ease formula, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            var sequence = new Sequence(owner, owner?.name, formula, loopsCount, loopType, loopResetBehaviour, direction);

            sequence.Insert(0f, Tween.Float(owner.gameObject, owner?.name, material.GetColor(property)[axis1], color1, c => material.SetColorProperty(property, axis1, c), duration, formula, loopsCount, loopType, direction));
            sequence.Insert(0f, Tween.Float(owner.gameObject, owner?.name, material.GetColor(property)[axis2], color2, c => material.SetColorProperty(property, axis2, c), duration, formula, loopsCount, loopType, direction));

            return sequence;
        }

        public static Sequence DoColorPropertyRG(this Material material, string property, float r, float g, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorPropertyTwoAxes(null, material, property, 0, 1, r, g, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorPropertyRG(this Material material, GameObject owner, string property, float r, float g, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorPropertyTwoAxes(owner, material, property, 0, 1, r, g, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorPropertyRB(this Material material, string property, float r, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorPropertyTwoAxes(null, material, property, 0, 2, r, b, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorPropertyRB(this Material material, GameObject owner, string property, float r, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorPropertyTwoAxes(owner, material, property, 0, 2, r, b, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorPropertyRA(this Material material, string property, float r, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorPropertyTwoAxes(null, material, property, 0, 3, r, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorPropertyRA(this Material material, GameObject owner, string property, float r, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorPropertyTwoAxes(owner, material, property, 0, 3, r, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorPropertyGB(this Material material, string property, float g, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorPropertyTwoAxes(null, material, property, 1, 2, g, b, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorPropertyGB(this Material material, GameObject owner, string property, float g, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorPropertyTwoAxes(owner, material, property, 1, 2, g, b, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorPropertyGA(this Material material, string property, float g, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorPropertyTwoAxes(null, material, property, 1, 3, g, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorPropertyGA(this Material material, GameObject owner, string property, float g, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorPropertyTwoAxes(owner, material, property, 1, 3, g, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorPropertyBA(this Material material, string property, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorPropertyTwoAxes(null, material, property, 2, 3, b, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorPropertyBA(this Material material, GameObject owner, string property, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorPropertyTwoAxes(owner, material, property, 2, 3, b, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoColorPropertyThreeAxes
        private static Sequence DoColorPropertyThreeAxes(GameObject owner, Material material, string property, int axis1, int axis2, int axis3, float color1, float color2, float color3, float duration, Ease formula, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            var sequence = new Sequence(owner, owner?.name, formula, loopsCount, loopType, loopResetBehaviour, direction);

            sequence.Insert(0f, Tween.Float(owner, owner?.name, material.GetColor(property)[axis1], color1, c => material.SetColorProperty(property, axis1, c), duration, formula, loopsCount, loopType, direction));
            sequence.Insert(0f, Tween.Float(owner, owner?.name, material.GetColor(property)[axis2], color2, c => material.SetColorProperty(property, axis2, c), duration, formula, loopsCount, loopType, direction));
            sequence.Insert(0f, Tween.Float(owner, owner?.name, material.GetColor(property)[axis3], color3, c => material.SetColorProperty(property, axis3, c), duration, formula, loopsCount, loopType, direction));

            return sequence;
        }

        public static Sequence DoColorPropertyRGB(this Material material, string property, float r, float g, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorPropertyThreeAxes(null, material, property, 0, 1, 2, r, g, b, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorPropertyRGB(this Material material, GameObject owner, string property, float r, float g, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorPropertyThreeAxes(owner, material, property, 0, 1, 2, r, g, b, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorPropertyRGA(this Material material, string property, float r, float g, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorPropertyThreeAxes(null, material, property, 0, 1, 3, r, g, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorPropertyRGA(this Material material, GameObject owner, string property, float r, float g, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorPropertyThreeAxes(owner, material, property, 0, 1, 3, r, g, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorPropertyRBA(this Material material, string property, float r, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorPropertyThreeAxes(null, material, property, 0, 2, 3, r, b, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorPropertyRBA(this Material material, GameObject owner, string property, float r, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorPropertyThreeAxes(owner, material, property, 0, 2, 3, r, b, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorPropertyGBA(this Material material, string property, float g, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorPropertyThreeAxes(null, material, property, 1, 2, 3, g, b, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorPropertyGBA(this Material material, GameObject owner, string property, float g, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorPropertyThreeAxes(owner, material, property, 1, 2, 3, g, b, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoColorProperty
        public static Tween<Color, TweakColor> DoColorProperty(this Material material, string property, float r, float g, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorProperty(material, property, new Color(r, g, b, a), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Color, TweakColor> DoColorProperty(this Material material, GameObject owner, string property, float r, float g, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorProperty(material, owner, property, new Color(r, g, b, a), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Color, TweakColor> DoColorProperty(this Material material, string property, Color color, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorProperty(material, null, property, color, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Color, TweakColor> DoColorProperty(this Material material, GameObject owner, string property, Color color, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Color(owner, owner?.name, material.GetColor(property), color, c => material.SetColor(property, c), duration, formula, loopsCount, loopType, direction);
        }
        #endregion
        #endregion

        public static Tween<float, TweakFloat> DoFloatProperty(this Material material, GameObject owner, string property, float value, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(owner, owner.name, material.GetFloat(property), value, v => material.SetFloat(property, v), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<int, TweakInt> DoIntProperty(this Material material, GameObject owner, string property, int value, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Int(owner, owner.name, material.GetInt(property), value, v => material.SetInt(property, v), duration, formula, loopsCount, loopType, direction);
        }

        #region DoMainTextureOffsetProperty
        public static Tween<float, TweakFloat> DoMainTextureOffsetPropertyX(this Material material, string property, float x, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoMainTextureOffsetPropertyX(material, null, property, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoMainTextureOffsetPropertyX(this Material material, GameObject owner,  string property, float x, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(owner, owner?.name, material.GetTextureOffset(property).x, x, ox => material.SetTextureOffset(property, material.GetTextureOffset(property).WithX(ox)), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoMainTextureOffsetPropertyY(this Material material, string property, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoMainTextureOffsetPropertyY(material, null, property, y, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoMainTextureOffsetPropertyY(this Material material, GameObject owner, string property, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(owner, owner?.name, material.GetTextureOffset(property).y, y, oy => material.SetTextureOffset(property, material.GetTextureOffset(property).WithY(oy)), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoMainTextureOffsetProperty(this Material material, string property, float x, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoMainTextureOffsetProperty(material, property, new Vector2(x, y), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoMainTextureOffsetProperty(this Material material, string property, Vector2 offset, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoMainTextureOffsetProperty(material, null, property, offset, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoMainTextureOffsetProperty(this Material material, GameObject owner, string property, float x, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoMainTextureOffsetProperty(material, owner, property, new Vector2(x, y), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoMainTextureOffsetProperty(this Material material, GameObject owner, string property, Vector2 offset, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Vector2(owner, owner?.name, material.GetTextureOffset(property), offset, o => material.SetTextureOffset(property, o), duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoMainTextureScaleProperty
        public static Tween<float, TweakFloat> DoMainTextureScalePropertyX(this Material material, string property, float x, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoMainTextureScalePropertyX(material, null, property, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoMainTextureScalePropertyX(this Material material, GameObject owner, string property, float x, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(owner, owner?.name, material.GetTextureScale(property).x, x, ox => material.SetTextureScale(property, material.GetTextureScale(property).WithX(ox)), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoMainTextureScalePropertyY(this Material material, string property, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoMainTextureScalePropertyY(material, null, property, y, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoMainTextureScalePropertyY(this Material material, GameObject owner, string property, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(owner, owner?.name, material.GetTextureScale(property).y, y, oy => material.SetTextureScale(property, material.GetTextureScale(property).WithY(oy)), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoMainTextureScaleProperty(this Material material, string property, float x, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoMainTextureScaleProperty(material, property, new Vector2(x, y), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoMainTextureScaleProperty(this Material material, string property, Vector2 offset, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoMainTextureScaleProperty(material, null, property, offset, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoMainTextureScaleProperty(this Material material, GameObject owner, string property, float x, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoMainTextureScaleProperty(material, owner, property, new Vector2(x, y), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoMainTextureScaleProperty(this Material material, GameObject owner, string property, Vector2 offset, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Vector2(owner, owner?.name, material.GetTextureScale(property), offset, o => material.SetTextureScale(property, o), duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoVectorProperty
        private static void DoVectorProperty(this Material material, string property, int axis, float value)
        {
            var vector = material.GetVector(property);
            vector[axis] = value;
            material.SetVector(property, vector);
        }

        #region DoVectorPropertyOneAxis
        private static Tween<float, TweakFloat> DoVectorPropertyOneAxis(GameObject owner, Material material, string property, int axis, float value, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(owner, owner?.name, material.GetVector(property)[axis], value, v => material.DoVectorProperty(property, axis, v), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoVectorPropertyX(this Material material, string property, float x, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyOneAxis(null, material, property, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoVectorPropertyX(this Material material, string property, GameObject owner, float x, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyOneAxis(owner, material, property, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoVectorPropertyY(this Material material, string property, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyOneAxis(null, material, property, 1, y, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoVectorPropertyY(this Material material, GameObject owner, string property, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyOneAxis(owner, material, property, 1, y, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoVectorPropertyZ(this Material material, string property, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyOneAxis(null, material, property, 2, z, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoVectorPropertyZ(this Material material, GameObject owner, string property, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyOneAxis(owner, material, property, 2, z, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoVectorPropertyW(this Material material, string property, float w, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyOneAxis(null, material, property, 3, w, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoVectorPropertyW(this Material material, GameObject owner, string property, float w, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyOneAxis(owner, material, property, 3, w, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoVectorPropertyTwoAxes
        private static Sequence DoVectorPropertyTwoAxes(GameObject owner, Material material, string property, int axis1, int axis2, float value1, float value2, float duration, Ease formula, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            var sequence = new Sequence(owner, owner?.name, formula, loopsCount, loopType, loopResetBehaviour, direction);

            sequence.Insert(0f, Tween.Float(owner.gameObject, owner?.name, material.GetVector(property)[axis1], value1, v => material.DoVectorProperty(property, axis1, v), duration, formula, loopsCount, loopType, direction));
            sequence.Insert(0f, Tween.Float(owner.gameObject, owner?.name, material.GetVector(property)[axis2], value2, v => material.DoVectorProperty(property, axis2, v), duration, formula, loopsCount, loopType, direction));

            return sequence;
        }

        public static Sequence DoVectorPropertyXY(this Material material, string property, float x, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyTwoAxes(null, material, property, 0, 1, x, y, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoVectorPropertyXY(this Material material, GameObject owner, string property, float x, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyTwoAxes(owner, material, property, 0, 1, x, y, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoVectorPropertyXZ(this Material material, string property, float x, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyTwoAxes(null, material, property, 0, 2, x, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoVectorPropertyXZ(this Material material, GameObject owner, string property, float x, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyTwoAxes(owner, material, property, 0, 2, x, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoVectorPropertyXW(this Material material, string property, float x, float w, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyTwoAxes(null, material, property, 0, 3, x, w, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoVectorPropertyXW(this Material material, GameObject owner, string property, float x, float w, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyTwoAxes(owner, material, property, 0, 3, x, w, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoVectorPropertyYZ(this Material material, string property, float y, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyTwoAxes(null, material, property, 1, 2, y, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoVectorPropertyYZ(this Material material, GameObject owner, string property, float y, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyTwoAxes(owner, material, property, 1, 2, y, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoVectorPropertyYW(this Material material, string property, float y, float w, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyTwoAxes(null, material, property, 1, 3, y, w, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoVectorPropertyYW(this Material material, GameObject owner, string property, float y, float w, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyTwoAxes(owner, material, property, 1, 3, y, w, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoVectorPropertyZW(this Material material, string property, float z, float w, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyTwoAxes(null, material, property, 2, 3, z, w, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoVectorPropertyZW(this Material material, GameObject owner, string property, float z, float w, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyTwoAxes(owner, material, property, 2, 3, z, w, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoVectorPropertyThreeAxes
        private static Sequence DoVectorPropertyThreeAxes(GameObject owner, Material material, string property, int axis1, int axis2, int axis3, float value1, float value2, float value3, float duration, Ease formula, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            var sequence = new Sequence(owner, owner?.name, formula, loopsCount, loopType, loopResetBehaviour, direction);

            sequence.Insert(0f, Tween.Float(owner, owner?.name, material.GetVector(property)[axis1], value1, v => material.DoVectorProperty(property, axis1, v), duration, formula, loopsCount, loopType, direction));
            sequence.Insert(0f, Tween.Float(owner, owner?.name, material.GetVector(property)[axis2], value2, v => material.DoVectorProperty(property, axis2, v), duration, formula, loopsCount, loopType, direction));
            sequence.Insert(0f, Tween.Float(owner, owner?.name, material.GetVector(property)[axis3], value3, v => material.DoVectorProperty(property, axis3, v), duration, formula, loopsCount, loopType, direction));

            return sequence;
        }

        public static Sequence DoVectorPropertyXYZ(this Material material, string property, float x, float y, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyThreeAxes(null, material, property, 0, 1, 2, x, y, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoVectorPropertyXYZ(this Material material, GameObject owner, string property, float x, float y, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyThreeAxes(owner, material, property, 0, 1, 2, x, y, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoVectorPropertyXYW(this Material material, string property, float x, float y, float w, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyThreeAxes(null, material, property, 0, 1, 3, x, y, w, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoVectorPropertyXYW(this Material material, GameObject owner, string property, float x, float y, float w, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyThreeAxes(owner, material, property, 0, 1, 3, x, y, w, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoVectorPropertyXZW(this Material material, string property, float x, float z, float w, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyThreeAxes(null, material, property, 0, 2, 3, x, z, w, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoVectorPropertyXZW(this Material material, GameObject owner, string property, float x, float z, float w, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyThreeAxes(owner, material, property, 0, 2, 3, x, z, w, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoVectorPropertyYZW(this Material material, string property, float y, float z, float w, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyThreeAxes(null, material, property, 1, 2, 3, y, z, w, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoVectorPropertyYZW(this Material material, GameObject owner, string property, float y, float z, float w, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyThreeAxes(owner, material, property, 1, 2, 3, y, z, w, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoVectorProperty
        public static Tween<Color, TweakColor> DoVectorProperty(this Material material, string property, float x, float y, float z, float w, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoVectorProperty(material, property, new Color(x, y, z, w), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Color, TweakColor> DoVectorProperty(this Material material, GameObject owner, string property, float x, float y, float z, float w, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoVectorProperty(material, owner, property, new Color(x, y, z, w), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Color, TweakColor> DoVectorProperty(this Material material, string property, Color color, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoVectorProperty(material, null, property, color, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Color, TweakColor> DoVectorProperty(this Material material, GameObject owner, string property, Color color, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Color(owner, owner?.name, material.GetColor(property), color, c => material.SetColor(property, c), duration, formula, loopsCount, loopType, direction);
        }
        #endregion
        #endregion
    }
}