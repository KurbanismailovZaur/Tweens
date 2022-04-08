using Redcode.Extensions;
using Redcode.Tweens.Tweaks;
using UnityEngine;

namespace Redcode.Tweens
{
    public static class MaterialExtensions
    {
        #region DoColor
        #region DoColorOneAxis
        private static Tween<float, TweakFloat> DoColorOneAxis(GameObject owner, Material material, int axis, float color, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(owner, owner == null ? null : owner.name, material.color[axis], color, c => material.color = material.color.With(axis, c), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorR(this Material material, float r, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(null, material, 0, r, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorR(this Material material, GameObject owner, float r, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(owner, material, 0, r, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorG(this Material material, float g, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(null, material, 1, g, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorG(this Material material, GameObject owner, float g, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(owner, material, 1, g, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorB(this Material material, float b, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(null, material, 2, b, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorB(this Material material, GameObject owner, float b, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(owner, material, 2, b, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorA(this Material material, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(null, material, 3, a, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorA(this Material material, GameObject owner, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(owner, material, 3, a, duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoColorTwoAxes
        private static Tween<Vector2, TweakVector2> DoColorTwoChannels(GameObject owner, Material material, int channel1, int channel2, float value1, float value2, float duration, Ease ease, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            return Tween.Vector2(owner, owner.name, material.color.Get(channel1, channel2), new Vector2(value1, value2), c => material.color = material.color.With(channel1, c.x, channel2, c.y), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoColorRG(this Material material, float r, float g, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoChannels(null, material, 0, 1, r, g, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoColorRG(this Material material, GameObject owner, float r, float g, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoChannels(owner, material, 0, 1, r, g, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoColorRB(this Material material, float r, float b, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoChannels(null, material, 0, 2, r, b, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoColorRB(this Material material, GameObject owner, float r, float b, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoChannels(owner, material, 0, 2, r, b, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoColorRA(this Material material, float r, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoChannels(null, material, 0, 3, r, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoColorRA(this Material material, GameObject owner, float r, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoChannels(owner, material, 0, 3, r, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoColorGB(this Material material, float g, float b, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoChannels(null, material, 1, 2, g, b, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoColorGB(this Material material, GameObject owner, float g, float b, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoChannels(owner, material, 1, 2, g, b, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoColorGA(this Material material, float g, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoChannels(null, material, 1, 3, g, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoColorGA(this Material material, GameObject owner, float g, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoChannels(owner, material, 1, 3, g, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoColorBA(this Material material, float b, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoChannels(null, material, 2, 3, b, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoColorBA(this Material material, GameObject owner, float b, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoChannels(owner, material, 2, 3, b, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoColorThreeAxes
        private static Tween<Vector3, TweakVector3> DoColorThreeChannels(GameObject owner, Material material, int channel1, int channel2, int channel3, float value1, float value2, float value3, float duration, Ease ease, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            return Tween.Vector3(owner, owner.name, material.color.Get(channel1, channel2, channel3), new Vector3(value1, value2, value3), c => material.color = material.color.With(channel1, c.x, channel2, c.y, channel3, c.z), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoColorRGB(this Material material, float r, float g, float b, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeChannels(null, material, 0, 1, 2, r, g, b, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector3, TweakVector3> DoColorRGB(this Material material, GameObject owner, float r, float g, float b, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeChannels(owner, material, 0, 1, 2, r, g, b, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector3, TweakVector3> DoColorRGA(this Material material, float r, float g, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeChannels(null, material, 0, 1, 3, r, g, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector3, TweakVector3> DoColorRGA(this Material material, GameObject owner, float r, float g, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeChannels(owner, material, 0, 1, 3, r, g, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector3, TweakVector3> DoColorRBA(this Material material, float r, float b, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeChannels(null, material, 0, 2, 3, r, b, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector3, TweakVector3> DoColorRBA(this Material material, GameObject owner, float r, float b, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeChannels(owner, material, 0, 2, 3, r, b, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector3, TweakVector3> DoColorGBA(this Material material, float g, float b, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeChannels(null, material, 1, 2, 3, g, b, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector3, TweakVector3> DoColorGBA(this Material material, GameObject owner, float g, float b, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeChannels(owner, material, 1, 2, 3, g, b, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoColor
        public static Tween<Color, TweakColor> DoColor(this Material material, float r, float g, float b, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColor(material, new Color(r, g, b, a), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Color, TweakColor> DoColor(this Material material, GameObject owner, float r, float g, float b, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColor(material, owner, new Color(r, g, b, a), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Color, TweakColor> DoColor(this Material material, Color color, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColor(material, null, color, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Color, TweakColor> DoColor(this Material material, GameObject owner, Color color, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Color(owner, owner == null ? null : owner.name, material.color, color, c => material.color = c, duration, ease, loopsCount, loopType, direction);
        }
        #endregion
        #endregion

        #region DoMainTextureOffset
        public static Tween<float, TweakFloat> DoMainTextureOffsetX(this Material material, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoMainTextureOffsetX(material, null, x, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoMainTextureOffsetX(this Material material, GameObject owner, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(owner, owner == null ? null : owner.name, material.mainTextureOffset.x, x, ox => material.mainTextureOffset = material.mainTextureOffset.WithX(ox), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoMainTextureOffsetY(this Material material, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoMainTextureOffsetY(material, null, y, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoMainTextureOffsetY(this Material material, GameObject owner, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(owner, owner == null ? null : owner.name, material.mainTextureOffset.y, y, oy => material.mainTextureOffset = material.mainTextureOffset.WithY(oy), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoMainTextureOffset(this Material material, float x, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoMainTextureOffset(material, new Vector2(x, y), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoMainTextureOffset(this Material material, Vector2 offset, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoMainTextureOffset(material, null, offset, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoMainTextureOffset(this Material material, GameObject owner, float x, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoMainTextureOffset(material, owner, new Vector2(x, y), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoMainTextureOffset(this Material material, GameObject owner, Vector2 offset, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Vector2(owner, owner == null ? null : owner.name, material.mainTextureOffset, offset, o => material.mainTextureOffset = o, duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoMainTextureScale
        public static Tween<float, TweakFloat> DoMainTextureScaleX(this Material material, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoMainTextureScaleX(material, null, x, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoMainTextureScaleX(this Material material, GameObject owner, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(owner, owner == null ? null : owner.name, material.mainTextureScale.x, x, ox => material.mainTextureScale = material.mainTextureScale.WithX(ox), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoMainTextureScaleY(this Material material, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoMainTextureScaleY(material, null, y, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoMainTextureScaleY(this Material material, GameObject owner, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(owner, owner == null ? null : owner.name, material.mainTextureScale.y, y, oy => material.mainTextureScale = material.mainTextureScale.WithY(oy), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoMainTextureScale(this Material material, float x, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoMainTextureScale(material, new Vector2(x, y), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoMainTextureScale(this Material material, Vector2 scale, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoMainTextureScale(material, null, scale, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoMainTextureScale(this Material material, GameObject owner, float x, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoMainTextureScale(material, owner, new Vector2(x, y), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoMainTextureScale(this Material material, GameObject owner, Vector2 scale, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Vector2(owner, owner == null ? null : owner.name, material.mainTextureScale, scale, s => material.mainTextureScale = s, duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoColorProperty
        #region DoColorPropertyOneAxis
        private static Tween<float, TweakFloat> DoColorPropertyOneChannel(GameObject owner, Material material, string property, int channel, float value, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(owner, owner == null ? null : owner.name, material.GetColor(property)[channel], value, c => material.SetColor(property, material.GetColor(property).With(channel, c)), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorPropertyR(this Material material, string property, float r, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorPropertyOneChannel(null, material, property, 0, r, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorPropertyR(this Material material, string property, GameObject owner, float r, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorPropertyOneChannel(owner, material, property, 0, r, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorPropertyG(this Material material, string property, float g, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorPropertyOneChannel(null, material, property, 1, g, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorPropertyG(this Material material, GameObject owner, string property, float g, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorPropertyOneChannel(owner, material, property, 1, g, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorPropertyB(this Material material, string property, float b, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorPropertyOneChannel(null, material, property, 2, b, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorPropertyB(this Material material, GameObject owner, string property, float b, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorPropertyOneChannel(owner, material, property, 2, b, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorPropertyA(this Material material, string property, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorPropertyOneChannel(null, material, property, 3, a, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorPropertyA(this Material material, GameObject owner, string property, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorPropertyOneChannel(owner, material, property, 3, a, duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoColorPropertyTwoAxes
        private static Tween<Vector2, TweakVector2> DoColorPropertyTwoChannels(GameObject owner, Material material, string property, int channel1, int channel2, float value1, float value2, float duration, Ease ease, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            return Tween.Vector2(owner, owner == null ? null : owner.name, material.GetColor(property).Get(channel1, channel2), new Vector2(value1, value2), c => material.SetColor(property, material.GetColor(property).With(channel1, c.x, channel2, c.y)), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoColorPropertyRG(this Material material, string property, float r, float g, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorPropertyTwoChannels(null, material, property, 0, 1, r, g, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoColorPropertyRG(this Material material, GameObject owner, string property, float r, float g, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorPropertyTwoChannels(owner, material, property, 0, 1, r, g, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoColorPropertyRB(this Material material, string property, float r, float b, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorPropertyTwoChannels(null, material, property, 0, 2, r, b, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoColorPropertyRB(this Material material, GameObject owner, string property, float r, float b, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorPropertyTwoChannels(owner, material, property, 0, 2, r, b, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoColorPropertyRA(this Material material, string property, float r, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorPropertyTwoChannels(null, material, property, 0, 3, r, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoColorPropertyRA(this Material material, GameObject owner, string property, float r, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorPropertyTwoChannels(owner, material, property, 0, 3, r, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoColorPropertyGB(this Material material, string property, float g, float b, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorPropertyTwoChannels(null, material, property, 1, 2, g, b, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoColorPropertyGB(this Material material, GameObject owner, string property, float g, float b, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorPropertyTwoChannels(owner, material, property, 1, 2, g, b, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoColorPropertyGA(this Material material, string property, float g, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorPropertyTwoChannels(null, material, property, 1, 3, g, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoColorPropertyGA(this Material material, GameObject owner, string property, float g, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorPropertyTwoChannels(owner, material, property, 1, 3, g, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoColorPropertyBA(this Material material, string property, float b, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorPropertyTwoChannels(null, material, property, 2, 3, b, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoColorPropertyBA(this Material material, GameObject owner, string property, float b, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorPropertyTwoChannels(owner, material, property, 2, 3, b, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoColorPropertyThreeAxes
        private static Tween<Vector3, TweakVector3> DoColorPropertyThreeChannels(GameObject owner, Material material, string property, int channel1, int channel2, int channel3, float value1, float value2, float value3, float duration, Ease ease, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            return Tween.Vector3(owner, owner == null ? null : owner.name, material.GetColor(property).Get(channel1, channel2, channel3), new Vector3(value1, value2, value3), c => material.SetColor(property, material.GetColor(property).With(channel1, c.x, channel2, c.y, channel3, c.z)), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoColorPropertyRGB(this Material material, string property, float r, float g, float b, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorPropertyThreeChannels(null, material, property, 0, 1, 2, r, g, b, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector3, TweakVector3> DoColorPropertyRGB(this Material material, GameObject owner, string property, float r, float g, float b, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorPropertyThreeChannels(owner, material, property, 0, 1, 2, r, g, b, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector3, TweakVector3> DoColorPropertyRGA(this Material material, string property, float r, float g, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorPropertyThreeChannels(null, material, property, 0, 1, 3, r, g, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector3, TweakVector3> DoColorPropertyRGA(this Material material, GameObject owner, string property, float r, float g, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorPropertyThreeChannels(owner, material, property, 0, 1, 3, r, g, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector3, TweakVector3> DoColorPropertyRBA(this Material material, string property, float r, float b, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorPropertyThreeChannels(null, material, property, 0, 2, 3, r, b, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector3, TweakVector3> DoColorPropertyRBA(this Material material, GameObject owner, string property, float r, float b, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorPropertyThreeChannels(owner, material, property, 0, 2, 3, r, b, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector3, TweakVector3> DoColorPropertyGBA(this Material material, string property, float g, float b, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorPropertyThreeChannels(null, material, property, 1, 2, 3, g, b, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector3, TweakVector3> DoColorPropertyGBA(this Material material, GameObject owner, string property, float g, float b, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorPropertyThreeChannels(owner, material, property, 1, 2, 3, g, b, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoColorProperty
        public static Tween<Color, TweakColor> DoColorProperty(this Material material, string property, float r, float g, float b, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorProperty(material, property, new Color(r, g, b, a), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Color, TweakColor> DoColorProperty(this Material material, GameObject owner, string property, float r, float g, float b, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorProperty(material, owner, property, new Color(r, g, b, a), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Color, TweakColor> DoColorProperty(this Material material, string property, Color color, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorProperty(material, null, property, color, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Color, TweakColor> DoColorProperty(this Material material, GameObject owner, string property, Color color, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Color(owner, owner == null ? null : owner.name, material.GetColor(property), color, c => material.SetColor(property, c), duration, ease, loopsCount, loopType, direction);
        }
        #endregion
        #endregion

        public static Tween<float, TweakFloat> DoFloatProperty(this Material material, GameObject owner, string property, float value, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(owner, owner.name, material.GetFloat(property), value, v => material.SetFloat(property, v), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<int, TweakInt> DoIntProperty(this Material material, GameObject owner, string property, int value, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Int(owner, owner.name, material.GetInt(property), value, v => material.SetInt(property, v), duration, ease, loopsCount, loopType, direction);
        }

        #region DoMainTextureOffsetProperty
        public static Tween<float, TweakFloat> DoMainTextureOffsetPropertyX(this Material material, string property, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoMainTextureOffsetPropertyX(material, null, property, x, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoMainTextureOffsetPropertyX(this Material material, GameObject owner,  string property, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(owner, owner == null ? null : owner.name, material.GetTextureOffset(property).x, x, ox => material.SetTextureOffset(property, material.GetTextureOffset(property).WithX(ox)), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoMainTextureOffsetPropertyY(this Material material, string property, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoMainTextureOffsetPropertyY(material, null, property, y, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoMainTextureOffsetPropertyY(this Material material, GameObject owner, string property, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(owner, owner == null ? null : owner.name, material.GetTextureOffset(property).y, y, oy => material.SetTextureOffset(property, material.GetTextureOffset(property).WithY(oy)), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoMainTextureOffsetProperty(this Material material, string property, float x, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoMainTextureOffsetProperty(material, property, new Vector2(x, y), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoMainTextureOffsetProperty(this Material material, string property, Vector2 offset, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoMainTextureOffsetProperty(material, null, property, offset, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoMainTextureOffsetProperty(this Material material, GameObject owner, string property, float x, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoMainTextureOffsetProperty(material, owner, property, new Vector2(x, y), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoMainTextureOffsetProperty(this Material material, GameObject owner, string property, Vector2 offset, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Vector2(owner, owner == null ? null : owner.name, material.GetTextureOffset(property), offset, o => material.SetTextureOffset(property, o), duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoMainTextureScaleProperty
        public static Tween<float, TweakFloat> DoMainTextureScalePropertyX(this Material material, string property, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoMainTextureScalePropertyX(material, null, property, x, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoMainTextureScalePropertyX(this Material material, GameObject owner, string property, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(owner, owner == null ? null : owner.name, material.GetTextureScale(property).x, x, ox => material.SetTextureScale(property, material.GetTextureScale(property).WithX(ox)), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoMainTextureScalePropertyY(this Material material, string property, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoMainTextureScalePropertyY(material, null, property, y, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoMainTextureScalePropertyY(this Material material, GameObject owner, string property, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(owner, owner == null ? null : owner.name, material.GetTextureScale(property).y, y, oy => material.SetTextureScale(property, material.GetTextureScale(property).WithY(oy)), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoMainTextureScaleProperty(this Material material, string property, float x, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoMainTextureScaleProperty(material, property, new Vector2(x, y), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoMainTextureScaleProperty(this Material material, string property, Vector2 offset, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoMainTextureScaleProperty(material, null, property, offset, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoMainTextureScaleProperty(this Material material, GameObject owner, string property, float x, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoMainTextureScaleProperty(material, owner, property, new Vector2(x, y), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoMainTextureScaleProperty(this Material material, GameObject owner, string property, Vector2 offset, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Vector2(owner, owner == null ? null : owner.name, material.GetTextureScale(property), offset, o => material.SetTextureScale(property, o), duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoVectorProperty
        #region DoVectorPropertyOneAxis
        private static Tween<float, TweakFloat> DoVectorPropertyOneAxis(GameObject owner, Material material, string property, int axis, float value, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(owner, owner == null ? null : owner.name, material.GetVector(property)[axis], value, v => material.SetVector(property, material.GetVector(property).With(axis, v)), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoVectorPropertyX(this Material material, string property, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyOneAxis(null, material, property, 0, x, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoVectorPropertyX(this Material material, string property, GameObject owner, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyOneAxis(owner, material, property, 0, x, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoVectorPropertyY(this Material material, string property, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyOneAxis(null, material, property, 1, y, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoVectorPropertyY(this Material material, GameObject owner, string property, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyOneAxis(owner, material, property, 1, y, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoVectorPropertyZ(this Material material, string property, float z, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyOneAxis(null, material, property, 2, z, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoVectorPropertyZ(this Material material, GameObject owner, string property, float z, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyOneAxis(owner, material, property, 2, z, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoVectorPropertyW(this Material material, string property, float w, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyOneAxis(null, material, property, 3, w, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoVectorPropertyW(this Material material, GameObject owner, string property, float w, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyOneAxis(owner, material, property, 3, w, duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoVectorPropertyTwoAxes
        private static Tween<Vector2, TweakVector2> DoVectorPropertyTwoAxes(GameObject owner, Material material, string property, int axis1, int axis2, float value1, float value2, float duration, Ease ease, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            return Tween.Vector2(owner, owner == null ? null : owner.name, material.GetVector(property).With(axis1, axis2), new Vector2(value1, value2), v => material.SetVector(property, material.GetVector(property).With(axis1, v.x, axis2, v.y)), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoVectorPropertyXY(this Material material, string property, float x, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyTwoAxes(null, material, property, 0, 1, x, y, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoVectorPropertyXY(this Material material, GameObject owner, string property, float x, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyTwoAxes(owner, material, property, 0, 1, x, y, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoVectorPropertyXZ(this Material material, string property, float x, float z, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyTwoAxes(null, material, property, 0, 2, x, z, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoVectorPropertyXZ(this Material material, GameObject owner, string property, float x, float z, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyTwoAxes(owner, material, property, 0, 2, x, z, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoVectorPropertyXW(this Material material, string property, float x, float w, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyTwoAxes(null, material, property, 0, 3, x, w, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoVectorPropertyXW(this Material material, GameObject owner, string property, float x, float w, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyTwoAxes(owner, material, property, 0, 3, x, w, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoVectorPropertyYZ(this Material material, string property, float y, float z, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyTwoAxes(null, material, property, 1, 2, y, z, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoVectorPropertyYZ(this Material material, GameObject owner, string property, float y, float z, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyTwoAxes(owner, material, property, 1, 2, y, z, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoVectorPropertyYW(this Material material, string property, float y, float w, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyTwoAxes(null, material, property, 1, 3, y, w, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoVectorPropertyYW(this Material material, GameObject owner, string property, float y, float w, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyTwoAxes(owner, material, property, 1, 3, y, w, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoVectorPropertyZW(this Material material, string property, float z, float w, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyTwoAxes(null, material, property, 2, 3, z, w, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoVectorPropertyZW(this Material material, GameObject owner, string property, float z, float w, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyTwoAxes(owner, material, property, 2, 3, z, w, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoVectorPropertyThreeAxes
        private static Tween<Vector3, TweakVector3> DoVectorPropertyThreeAxes(GameObject owner, Material material, string property, int axis1, int axis2, int axis3, float value1, float value2, float value3, float duration, Ease ease, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            return Tween.Vector3(owner, owner == null ? null : owner.name, material.GetVector(property).Get(axis1, axis2, axis3), new Vector3(value1, value2, value3), v => material.SetVector(property, material.GetVector(property).With(axis1, v.x, axis2, v.y, axis3, v.z)), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoVectorPropertyXYZ(this Material material, string property, float x, float y, float z, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyThreeAxes(null, material, property, 0, 1, 2, x, y, z, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector3, TweakVector3> DoVectorPropertyXYZ(this Material material, GameObject owner, string property, float x, float y, float z, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyThreeAxes(owner, material, property, 0, 1, 2, x, y, z, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector3, TweakVector3> DoVectorPropertyXYW(this Material material, string property, float x, float y, float w, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyThreeAxes(null, material, property, 0, 1, 3, x, y, w, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector3, TweakVector3> DoVectorPropertyXYW(this Material material, GameObject owner, string property, float x, float y, float w, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyThreeAxes(owner, material, property, 0, 1, 3, x, y, w, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector3, TweakVector3> DoVectorPropertyXZW(this Material material, string property, float x, float z, float w, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyThreeAxes(null, material, property, 0, 2, 3, x, z, w, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector3, TweakVector3> DoVectorPropertyXZW(this Material material, GameObject owner, string property, float x, float z, float w, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyThreeAxes(owner, material, property, 0, 2, 3, x, z, w, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector3, TweakVector3> DoVectorPropertyYZW(this Material material, string property, float y, float z, float w, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyThreeAxes(null, material, property, 1, 2, 3, y, z, w, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector3, TweakVector3> DoVectorPropertyYZW(this Material material, GameObject owner, string property, float y, float z, float w, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoVectorPropertyThreeAxes(owner, material, property, 1, 2, 3, y, z, w, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoVectorProperty
        public static Tween<Color, TweakColor> DoVectorProperty(this Material material, string property, float x, float y, float z, float w, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoVectorProperty(material, property, new Color(x, y, z, w), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Color, TweakColor> DoVectorProperty(this Material material, GameObject owner, string property, float x, float y, float z, float w, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoVectorProperty(material, owner, property, new Color(x, y, z, w), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Color, TweakColor> DoVectorProperty(this Material material, string property, Color color, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoVectorProperty(material, null, property, color, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Color, TweakColor> DoVectorProperty(this Material material, GameObject owner, string property, Color color, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Color(owner, owner == null ? null : owner.name, material.GetColor(property), color, c => material.SetColor(property, c), duration, ease, loopsCount, loopType, direction);
        }
        #endregion
        #endregion
    }
}