using Redcode.Tweens.Tweaks;
using UnityEngine;

namespace Redcode.Tweens
{
    public static class LightExtensions
    {
        private static void SetColor(this Light light, int axis, float color)
        {
            var col = light.color;
            col[axis] = color;
            light.color = col;
        }

        #region DoColorOneAxis
        private static Tween<float, TweakFloat> DoColorOneAxis(Light light, GameObject owner, int axis, float color, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(owner, owner.name, light.color[axis], color, c => light.SetColor(axis, c), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorR(this Light light, float r, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(light, light.gameObject, 0, r, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorR(this Light light, GameObject owner, float r, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(light, owner, 0, r, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorG(this Light light, float g, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(light, light.gameObject, 1, g, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorG(this Light light, GameObject owner, float g, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(light, owner, 1, g, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorB(this Light light, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(light, light.gameObject, 2, b, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorB(this Light light, GameObject owner, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(light, owner, 2, b, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorA(this Light light, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(light, light.gameObject, 3, a, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorA(this Light light, GameObject owner, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorOneAxis(light, owner, 3, a, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoColorTwoAxes
        private static Sequence DoColorTwoAxes(Light light, GameObject owner, int axis1, int axis2, float color1, float color2, float duration, Ease formula, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            var sequence = new Sequence(owner, owner.name, formula, loopsCount, loopType, loopResetBehaviour, direction);

            sequence.Insert(0f, Tween.Float(owner, owner.name, light.color[axis1], color1, c => light.SetColor(axis1, c), duration, formula, loopsCount, loopType, direction));
            sequence.Insert(0f, Tween.Float(owner, owner.name, light.color[axis2], color2, c => light.SetColor(axis2, c), duration, formula, loopsCount, loopType, direction));

            return sequence;
        }

        public static Sequence DoColorRG(this Light light, float r, float g, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(light, light.gameObject, 0, 1, r, g, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorRG(this Light light, GameObject owner, float r, float g, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(light, owner, 0, 1, r, g, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorRB(this Light light, float r, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(light, light.gameObject, 0, 2, r, b, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorRB(this Light light, GameObject owner, float r, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(light, owner, 0, 2, r, b, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorRA(this Light light, float r, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(light, light.gameObject, 0, 3, r, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorRA(this Light light, GameObject owner, float r, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(light, owner, 0, 3, r, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorGB(this Light light, float g, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(light, light.gameObject, 1, 2, g, b, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorGB(this Light light, GameObject owner, float g, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(light, owner, 1, 2, g, b, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorGA(this Light light, float g, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(light, light.gameObject, 1, 3, g, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorGA(this Light light, GameObject owner, float g, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(light, owner, 1, 3, g, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorBA(this Light light, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(light, light.gameObject, 2, 3, b, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorBA(this Light light, GameObject owner, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorTwoAxes(light, owner, 2, 3, b, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoColorThreeAxes
        private static Sequence DoColorThreeAxes(Light light, GameObject owner, int axis1, int axis2, int axis3, float color1, float color2, float color3, float duration, Ease formula, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            var sequence = new Sequence(owner, owner.name, formula, loopsCount, loopType, loopResetBehaviour, direction);

            sequence.Insert(0f, Tween.Float(owner, owner.name, light.color[axis1], color1, c => light.SetColor(axis1, c), duration, formula, loopsCount, loopType, direction));
            sequence.Insert(0f, Tween.Float(owner, owner.name, light.color[axis2], color2, c => light.SetColor(axis2, c), duration, formula, loopsCount, loopType, direction));
            sequence.Insert(0f, Tween.Float(owner, owner.name, light.color[axis3], color3, c => light.SetColor(axis3, c), duration, formula, loopsCount, loopType, direction));

            return sequence;
        }

        public static Sequence DoColorRGB(this Light light, float r, float g, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeAxes(light, light.gameObject, 0, 1, 2, r, g, b, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorRGB(this Light light, GameObject owner, float r, float g, float b, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeAxes(light, owner, 0, 1, 2, r, g, b, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorRGA(this Light light, float r, float g, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeAxes(light, light.gameObject, 0, 1, 3, r, g, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorRGA(this Light light, GameObject owner, float r, float g, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeAxes(light, owner, 0, 1, 3, r, g, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorRBA(this Light light, float r, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeAxes(light, light.gameObject, 0, 2, 3, r, b, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorRBA(this Light light, GameObject owner, float r, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeAxes(light, owner, 0, 2, 3, r, b, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorGBA(this Light light, float g, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeAxes(light, light.gameObject, 1, 2, 3, g, b, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoColorGBA(this Light light, GameObject owner, float g, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoColorThreeAxes(light, owner, 1, 2, 3, g, b, a, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoColor
        public static Tween<Color, TweakColor> DoColor(this Light light, float r, float g, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColor(light, light.gameObject, new Color(r, g, b, a), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Color, TweakColor> DoColor(this Light light, GameObject owner, float r, float g, float b, float a, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColor(light, owner, new Color(r, g, b, a), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Color, TweakColor> DoColor(this Light light, Color color, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColor(light, light.gameObject, color, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<Color, TweakColor> DoColor(this Light light, GameObject owner, Color color, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Color(owner, owner.name, light.color, color, c => light.color = color, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoColorTemperature
        public static Tween<float, TweakFloat> DoColorTemperature(this Light light, float temperature, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoColorTemperature(light, light.gameObject, temperature, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoColorTemperature(this Light light, GameObject owner, float temperature, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(owner, owner.name, light.colorTemperature, temperature, t => light.colorTemperature = t, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoInnerSpotAngle
        public static Tween<float, TweakFloat> DoInnerSpotAngle(this Light light, float angle, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoInnerSpotAngle(light, light.gameObject, angle, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoInnerSpotAngle(this Light light, GameObject owner, float angle, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(owner, owner.name, light.innerSpotAngle, angle, a => light.innerSpotAngle = a, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoSpotAngle
        public static Tween<float, TweakFloat> DoSpotAngle(this Light light, float angle, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoSpotAngle(light, light.gameObject, angle, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoSpotAngle(this Light light, GameObject owner, float angle, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(owner, owner.name, light.spotAngle, angle, a => light.spotAngle = a, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoIntensity
        public static Tween<float, TweakFloat> DoIntensity(this Light light, float intensity, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoIntensity(light, light.gameObject, intensity, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoIntensity(this Light light, GameObject owner, float intensity, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(owner, owner.name, light.intensity, intensity, i => light.intensity = i, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoRange
        public static Tween<float, TweakFloat> DoRange(this Light light, float range, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoRange(light, light.gameObject, range, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoRange(this Light light, GameObject owner, float range, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return Tween.Float(owner, owner.name, light.range, range, r => light.range = r, duration, formula, loopsCount, loopType, direction);
        }
        #endregion
    }
}