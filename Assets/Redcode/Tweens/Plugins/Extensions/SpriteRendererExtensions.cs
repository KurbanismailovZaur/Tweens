using Redcode.Tweens.Tweaks;
using UnityEngine;
using Redcode.Extensions;

namespace Redcode.Tweens
{
    public static class SpriteRendererExtensions
    {
        #region DoColorOneAxis
        private static Tween<float, TweakFloat> DoColorOneAxis(SpriteRenderer sprite, GameObject owner, int axis, float color, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(sprite.color[axis], color, c => sprite.color = sprite.color.With(axis, c), duration, ease, loopsCount, loopType, direction).SetOwner(owner).SetName(owner.name);
        }

        public static Tween<float, TweakFloat> DoColorR(this SpriteRenderer sprite, float r, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(sprite, sprite.gameObject, 0, r, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorG(this SpriteRenderer sprite, float g, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(sprite, sprite.gameObject, 1, g, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorB(this SpriteRenderer sprite, float b, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(sprite, sprite.gameObject, 2, b, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorA(this SpriteRenderer sprite, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(sprite, sprite.gameObject, 3, a, duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoColorTwoAxes
        private static Tween<Vector2, TweakVector2> DoColorTwoChannels(SpriteRenderer sprite, GameObject owner, int channel1, int channel2, float value1, float value2, float duration, Ease ease, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            return Tween.Vector2(sprite.color.Get(channel1, channel2), new Vector2(value1, value2), c => sprite.color = sprite.color.With(channel1, c.x, channel2, c.y), duration, ease, loopsCount, loopType, direction).SetOwner(owner).SetName(owner.name);
        }

        public static Tween<Vector2, TweakVector2> DoColorRG(this SpriteRenderer sprite, float r, float g, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoChannels(sprite, sprite.gameObject, 0, 1, r, g, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoColorRB(this SpriteRenderer sprite, float r, float b, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoChannels(sprite, sprite.gameObject, 0, 2, r, b, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoColorRA(this SpriteRenderer sprite, float r, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoChannels(sprite, sprite.gameObject, 0, 3, r, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoColorGB(this SpriteRenderer sprite, float g, float b, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoChannels(sprite, sprite.gameObject, 1, 2, g, b, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoColorGA(this SpriteRenderer sprite, float g, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoChannels(sprite, sprite.gameObject, 1, 3, g, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoColorBA(this SpriteRenderer sprite, float b, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoChannels(sprite, sprite.gameObject, 2, 3, b, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoColorThreeAxes
        private static Tween<Vector3, TweakVector3> DoColorThreeChannels(SpriteRenderer sprite, GameObject owner, int channel1, int channel2, int channel3, float value1, float value2, float value3, float duration, Ease ease, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            return Tween.Vector3(sprite.color.Get(channel1, channel2, channel3), new Vector3(value1, value2, value3), c => sprite.color = sprite.color.With(channel1, c.x, channel2, c.y, channel3, c.z), duration, ease, loopsCount, loopType, direction).SetOwner(owner).SetName(owner.name);
        }

        public static Tween<Vector3, TweakVector3> DoColorRGB(this SpriteRenderer sprite, float r, float g, float b, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeChannels(sprite, sprite.gameObject, 0, 1, 2, r, g, b, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector3, TweakVector3> DoColorRGA(this SpriteRenderer sprite, float r, float g, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeChannels(sprite, sprite.gameObject, 0, 1, 3, r, g, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector3, TweakVector3> DoColorRBA(this SpriteRenderer sprite, float r, float b, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeChannels(sprite, sprite.gameObject, 0, 2, 3, r, b, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector3, TweakVector3> DoColorGBA(this SpriteRenderer sprite, float g, float b, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeChannels(sprite, sprite.gameObject, 1, 2, 3, g, b, a, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoColor
        public static Tween<Color, TweakColor> DoColor(this SpriteRenderer sprite, float r, float g, float b, float a, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColor(sprite, new Color(r, g, b, a), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Color, TweakColor> DoColor(this SpriteRenderer sprite, Color color, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Color(sprite.color, color, c => sprite.color = color, duration, ease, loopsCount, loopType, direction).SetOwner(sprite).SetName(sprite.name);
        }
        #endregion
    }
}