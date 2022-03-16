using Redcode.Extensions;
using Redcode.Tweens.Tweaks;
using UnityEngine;

namespace Redcode.Tweens
{
    public static class RectTransformExtensions
    {
        private static void SetAnchoredPosition(this RectTransform rectTransform, int axis, float position)
        {
            var pos = rectTransform.anchoredPosition;
            pos[axis] = position;
            rectTransform.anchoredPosition = pos;
        }

        #region DoAnchoredPositionOneAxis
        private static Tween<float, TweakFloat> DoAnchoredPositionOneAxis(RectTransform rectTransform, GameObject owner, int axis, float position, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(owner, owner.name, rectTransform.anchoredPosition[axis], position, p => rectTransform.SetAnchoredPosition(axis, p), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoAnchoredPositionX(this RectTransform rectTransform, float x, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoredPositionOneAxis(rectTransform, rectTransform.gameObject, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoAnchoredPositionX(this RectTransform rectTransform, GameObject owner, float x, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoredPositionOneAxis(rectTransform, owner, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoAnchoredPositionY(this RectTransform rectTransform, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoredPositionOneAxis(rectTransform, rectTransform.gameObject, 1, y, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoAnchoredPositionY(this RectTransform rectTransform, GameObject owner, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoredPositionOneAxis(rectTransform, owner, 1, y, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoAnchoredPosition
        private static Tween<Vector2, TweakVector2> DoAnchoredPosition(this RectTransform rectTransform, float x, float y, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoAnchoredPosition(rectTransform, rectTransform.gameObject, new Vector2(x, y), duration, formula, loopsCount, loopType, direction);
        }

        private static Tween<Vector2, TweakVector2> DoAnchoredPosition(this RectTransform rectTransform, GameObject owner, float x, float y, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoAnchoredPosition(rectTransform, owner, new Vector2(x, y), duration, formula, loopsCount, loopType, direction);
        }

        private static Tween<Vector2, TweakVector2> DoAnchoredPosition(this RectTransform rectTransform, Vector2 position, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoAnchoredPosition(rectTransform, rectTransform.gameObject, position, duration, formula, loopsCount, loopType, direction);
        }

        private static Tween<Vector2, TweakVector2> DoAnchoredPosition(this RectTransform rectTransform, GameObject owner, Vector2 position, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Vector2(owner, owner.name, rectTransform.anchoredPosition, position, p => rectTransform.anchoredPosition = p, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        private static void SetAnchoredPosition3D(this RectTransform rectTransform, int axis, float position)
        {
            var pos = rectTransform.anchoredPosition3D;
            pos[axis] = position;
            rectTransform.anchoredPosition3D = pos;
        }

        #region DoAnchoredPosition3DOneAxis
        private static Tween<float, TweakFloat> DoAnchoredPosition3DOneAxis(RectTransform rectTransform, GameObject owner, int axis, float position, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(owner, owner.name, rectTransform.anchoredPosition3D[axis], position, p => rectTransform.SetAnchoredPosition3D(axis, p), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoAnchoredPosition3DX(this RectTransform rectTransform, float x, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoredPosition3DOneAxis(rectTransform, rectTransform.gameObject, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoAnchoredPosition3DX(this RectTransform rectTransform, GameObject owner, float x, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoredPosition3DOneAxis(rectTransform, owner, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoAnchoredPosition3DY(this RectTransform rectTransform, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoredPosition3DOneAxis(rectTransform, rectTransform.gameObject, 1, y, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoAnchoredPosition3DY(this RectTransform rectTransform, GameObject owner, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoredPosition3DOneAxis(rectTransform, owner, 1, y, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoAnchoredPosition3DZ(this RectTransform rectTransform, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoredPosition3DOneAxis(rectTransform, rectTransform.gameObject, 2, z, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoAnchoredPosition3DZ(this RectTransform rectTransform, GameObject owner, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoredPosition3DOneAxis(rectTransform, owner, 2, z, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoAnchoredPosition3DTwoAxis
        private static Sequence DoAnchoredPosition3DTwoAxis(RectTransform rectTransform, GameObject owner, int axis1, int axis2, float position1, float position2, float duration, Ease formula, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            var sequence = new Sequence(owner, owner.name, formula, loopsCount, loopType, loopResetBehaviour, direction);

            sequence.Insert(0f, Tween.Float(owner, owner.name, rectTransform.anchoredPosition3D[axis1], position1, p => rectTransform.SetAnchoredPosition3D(axis1, p), duration));
            sequence.Insert(0f, Tween.Float(owner, owner.name, rectTransform.anchoredPosition3D[axis2], position2, p => rectTransform.SetAnchoredPosition3D(axis2, p), duration));

            return sequence;
        }

        public static Sequence DoAnchoredPosition3DXY(this RectTransform rectTransform, float x, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoAnchoredPosition3DTwoAxis(rectTransform, rectTransform.gameObject, 0, 1, x, y, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoAnchoredPosition3DXY(this RectTransform rectTransform, GameObject owner, float x, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoAnchoredPosition3DTwoAxis(rectTransform, owner, 0, 1, x, y, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoAnchoredPosition3DXZ(this RectTransform rectTransform, float x, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoAnchoredPosition3DTwoAxis(rectTransform, rectTransform.gameObject, 0, 2, x, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoAnchoredPosition3DXZ(this RectTransform rectTransform, GameObject owner, float x, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoAnchoredPosition3DTwoAxis(rectTransform, owner, 0, 2, x, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoAnchoredPosition3DYZ(this RectTransform rectTransform, float y, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoAnchoredPosition3DTwoAxis(rectTransform, rectTransform.gameObject, 1, 2, y, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoAnchoredPosition3DYZ(this RectTransform rectTransform, GameObject owner, float y, float z, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoAnchoredPosition3DTwoAxis(rectTransform, owner, 1, 2, y, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoAnchoredPosition3D
        private static Tween<Vector3, TweakVector3> DoAnchoredPosition3D(this RectTransform rectTransform,  float x, float y, float z, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoAnchoredPosition3D(rectTransform, rectTransform.gameObject, new Vector3(x, y, z), duration, formula, loopsCount, loopType, direction);
        }

        private static Tween<Vector3, TweakVector3> DoAnchoredPosition3D(this RectTransform rectTransform, GameObject owner, float x, float y, float z, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoAnchoredPosition3D(rectTransform, owner, new Vector3(x, y, z), duration, formula, loopsCount, loopType, direction);
        }

        private static Tween<Vector3, TweakVector3> DoAnchoredPosition3D(this RectTransform rectTransform, Vector3 position, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoAnchoredPosition3D(rectTransform, rectTransform.gameObject, position, duration, formula, loopsCount, loopType, direction);
        }

        private static Tween<Vector3, TweakVector3> DoAnchoredPosition3D(this RectTransform rectTransform, GameObject owner, Vector3 position, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Vector3(owner, owner.name, rectTransform.anchoredPosition3D, position, p => rectTransform.anchoredPosition3D = p, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoAnchoreMaxOneAxis
        private static Tween<float, TweakFloat> DoAnchoreMaxOneAxis(RectTransform rectTransform, GameObject owner, int axis, float normalizedPosition, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(owner, owner.name, rectTransform.anchorMax[axis], normalizedPosition, np => rectTransform.SetAnchoreMax(axis, np), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoAnchoreMaxX(this RectTransform rectTransform, float x, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoreMaxOneAxis(rectTransform, rectTransform.gameObject, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoAnchoreMaxX(this RectTransform rectTransform, GameObject owner, float x, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoreMaxOneAxis(rectTransform, owner, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoAnchoreMaxY(this RectTransform rectTransform, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoreMaxOneAxis(rectTransform, rectTransform.gameObject, 1, y, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoAnchoreMaxY(this RectTransform rectTransform, GameObject owner, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoreMaxOneAxis(rectTransform, owner, 1, y, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        private static void SetAnchoreMax(this RectTransform rectTransform, int axis, float position)
        {
            var pos = rectTransform.anchorMax;
            pos[axis] = position;
            rectTransform.anchorMax = pos;
        }

        #region DoAnchoreMax
        private static Tween<Vector2, TweakVector2> DoAnchoreMax(this RectTransform rectTransform, float x, float y, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoAnchoreMax(rectTransform, rectTransform.gameObject, new Vector2(x, y), duration, formula, loopsCount, loopType, direction);
        }

        private static Tween<Vector2, TweakVector2> DoAnchoreMax(this RectTransform rectTransform, GameObject owner, float x, float y, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoAnchoreMax(rectTransform, owner, new Vector2(x, y), duration, formula, loopsCount, loopType, direction);
        }

        private static Tween<Vector2, TweakVector2> DoAnchoreMax(this RectTransform rectTransform, Vector2 normalizedPosition, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoAnchoreMax(rectTransform, rectTransform.gameObject, normalizedPosition, duration, formula, loopsCount, loopType, direction);
        }

        private static Tween<Vector2, TweakVector2> DoAnchoreMax(this RectTransform rectTransform, GameObject owner, Vector2 normalizedPosition, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Vector2(owner, owner.name, rectTransform.anchorMax, normalizedPosition, np => rectTransform.anchorMax = np, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoAnchoreMinOneAxis
        private static Tween<float, TweakFloat> DoAnchoreMinOneAxis(RectTransform rectTransform, GameObject owner, int axis, float normalizedPosition, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(owner, owner.name, rectTransform.anchorMin[axis], normalizedPosition, np => rectTransform.SetAnchoreMin(axis, np), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoAnchoreMinX(this RectTransform rectTransform, float x, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoreMinOneAxis(rectTransform, rectTransform.gameObject, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoAnchoreMinX(this RectTransform rectTransform, GameObject owner, float x, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoreMinOneAxis(rectTransform, owner, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoAnchoreMinY(this RectTransform rectTransform, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoreMinOneAxis(rectTransform, rectTransform.gameObject, 1, y, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoAnchoreMinY(this RectTransform rectTransform, GameObject owner, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoreMinOneAxis(rectTransform, owner, 1, y, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        private static void SetAnchoreMin(this RectTransform rectTransform, int axis, float position)
        {
            var pos = rectTransform.anchorMin;
            pos[axis] = position;
            rectTransform.anchorMin = pos;
        }

        #region DoAnchoreMin
        private static Tween<Vector2, TweakVector2> DoAnchoreMin(this RectTransform rectTransform, float x, float y, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoAnchoreMin(rectTransform, rectTransform.gameObject, new Vector2(x, y), duration, formula, loopsCount, loopType, direction);
        }

        private static Tween<Vector2, TweakVector2> DoAnchoreMin(this RectTransform rectTransform, GameObject owner, float x, float y, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoAnchoreMin(rectTransform, owner, new Vector2(x, y), duration, formula, loopsCount, loopType, direction);
        }

        private static Tween<Vector2, TweakVector2> DoAnchoreMin(this RectTransform rectTransform, Vector2 normalizedPosition, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoAnchoreMin(rectTransform, rectTransform.gameObject, normalizedPosition, duration, formula, loopsCount, loopType, direction);
        }

        private static Tween<Vector2, TweakVector2> DoAnchoreMin(this RectTransform rectTransform, GameObject owner, Vector2 normalizedPosition, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Vector2(owner, owner.name, rectTransform.anchorMin, normalizedPosition, np => rectTransform.anchorMin = np, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoOffsetMaxOneAxis
        private static Tween<float, TweakFloat> DoOffsetMaxOneAxis(RectTransform rectTransform, GameObject owner, int axis, float offset, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(owner, owner.name, rectTransform.offsetMax[axis], offset, o => rectTransform.SetOffsetMax(axis, o), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoOffsetMaxX(this RectTransform rectTransform, float x, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoOffsetMaxOneAxis(rectTransform, rectTransform.gameObject, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoOffsetMaxX(this RectTransform rectTransform, GameObject owner, float x, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoOffsetMaxOneAxis(rectTransform, owner, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoOffsetMaxY(this RectTransform rectTransform, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoOffsetMaxOneAxis(rectTransform, rectTransform.gameObject, 1, y, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoOffsetMaxY(this RectTransform rectTransform, GameObject owner, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoOffsetMaxOneAxis(rectTransform, owner, 1, y, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        private static void SetOffsetMax(this RectTransform rectTransform, int axis, float offset)
        {
            var offsetMax = rectTransform.offsetMax;
            offsetMax[axis] = offset;
            rectTransform.offsetMax = offsetMax;
        }

        #region DoOffsetMax
        private static Tween<Vector2, TweakVector2> DoOffsetMax(this RectTransform rectTransform, float x, float y, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoOffsetMax(rectTransform, rectTransform.gameObject, new Vector2(x, y), duration, formula, loopsCount, loopType, direction);
        }

        private static Tween<Vector2, TweakVector2> DoOffsetMax(this RectTransform rectTransform, GameObject owner, float x, float y, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoOffsetMax(rectTransform, owner, new Vector2(x, y), duration, formula, loopsCount, loopType, direction);
        }

        private static Tween<Vector2, TweakVector2> DoOffsetMax(this RectTransform rectTransform, Vector2 offset, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoOffsetMax(rectTransform, rectTransform.gameObject, offset, duration, formula, loopsCount, loopType, direction);
        }

        private static Tween<Vector2, TweakVector2> DoOffsetMax(this RectTransform rectTransform, GameObject owner, Vector2 offset, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Vector2(owner, owner.name, rectTransform.offsetMax, offset, o => rectTransform.offsetMax = o, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoOffsetMinOneAxis
        private static Tween<float, TweakFloat> DoOffsetMinOneAxis(RectTransform rectTransform, GameObject owner, int axis, float offset, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(owner, owner.name, rectTransform.offsetMin[axis], offset, o => rectTransform.SetOffsetMin(axis, o), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoOffsetMinX(this RectTransform rectTransform, float x, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoOffsetMinOneAxis(rectTransform, rectTransform.gameObject, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoOffsetMinX(this RectTransform rectTransform, GameObject owner, float x, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoOffsetMinOneAxis(rectTransform, owner, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoOffsetMinY(this RectTransform rectTransform, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoOffsetMinOneAxis(rectTransform, rectTransform.gameObject, 1, y, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoOffsetMinY(this RectTransform rectTransform, GameObject owner, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoOffsetMinOneAxis(rectTransform, owner, 1, y, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        private static void SetOffsetMin(this RectTransform rectTransform, int axis, float offset)
        {
            var offsetMin = rectTransform.offsetMin;
            offsetMin[axis] = offset;
            rectTransform.offsetMin = offsetMin;
        }

        #region DoOffsetMin
        private static Tween<Vector2, TweakVector2> DoOffsetMin(this RectTransform rectTransform, float x, float y, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoOffsetMin(rectTransform, rectTransform.gameObject, new Vector2(x, y), duration, formula, loopsCount, loopType, direction);
        }

        private static Tween<Vector2, TweakVector2> DoOffsetMin(this RectTransform rectTransform, GameObject owner, float x, float y, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoOffsetMin(rectTransform, owner, new Vector2(x, y), duration, formula, loopsCount, loopType, direction);
        }

        private static Tween<Vector2, TweakVector2> DoOffsetMin(this RectTransform rectTransform, Vector2 offset, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoOffsetMin(rectTransform, rectTransform.gameObject, offset, duration, formula, loopsCount, loopType, direction);
        }

        private static Tween<Vector2, TweakVector2> DoOffsetMin(this RectTransform rectTransform, GameObject owner, Vector2 offset, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Vector2(owner, owner.name, rectTransform.offsetMin, offset, o => rectTransform.offsetMin = o, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        private static void SetPivot(this RectTransform rectTransform, int axis, float normalizedPosition)
        {
            var piv = rectTransform.pivot;
            piv[axis] = normalizedPosition;
            rectTransform.pivot = piv;
        }

        #region DoPivotOneAxis
        private static Tween<float, TweakFloat> DoPivotOneAxis(RectTransform rectTransform, GameObject owner, int axis, float normalizedPosition, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(owner, owner.name, rectTransform.pivot[axis], normalizedPosition, np => rectTransform.SetPivot(axis, np), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPivotX(this RectTransform rectTransform, float x, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPivotOneAxis(rectTransform, rectTransform.gameObject, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPivotX(this RectTransform rectTransform, GameObject owner, float x, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPivotOneAxis(rectTransform, owner, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPivotY(this RectTransform rectTransform, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPivotOneAxis(rectTransform, rectTransform.gameObject, 1, y, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPivotY(this RectTransform rectTransform, GameObject owner, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPivotOneAxis(rectTransform, owner, 1, y, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoPivot
        private static Tween<Vector2, TweakVector2> DoPivot(this RectTransform rectTransform, float x, float y, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoPivot(rectTransform, rectTransform.gameObject, new Vector2(x, y), duration, formula, loopsCount, loopType, direction);
        }

        private static Tween<Vector2, TweakVector2> DoPivot(this RectTransform rectTransform, GameObject owner, float x, float y, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoPivot(rectTransform, owner, new Vector2(x, y), duration, formula, loopsCount, loopType, direction);
        }

        private static Tween<Vector2, TweakVector2> DoPivot(this RectTransform rectTransform, Vector2 normalizedPosition, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoPivot(rectTransform, rectTransform.gameObject, normalizedPosition, duration, formula, loopsCount, loopType, direction);
        }

        private static Tween<Vector2, TweakVector2> DoPivot(this RectTransform rectTransform, GameObject owner, Vector2 normalizedPosition, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Vector2(owner, owner.name, rectTransform.pivot, normalizedPosition, np => rectTransform.pivot = np, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        private static void SetPivotOnly(this RectTransform rectTransform, int axis, float normalizedPosition)
        {
            var piv = rectTransform.pivot;
            piv[axis] = normalizedPosition;
            rectTransform.SetPivotOnly(piv);
        }

        #region DoPivotOnlyOneAxis
        private static Tween<float, TweakFloat> DoPivotOnlyOneAxis(RectTransform rectTransform, GameObject owner, int axis, float normalizedPosition, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(owner, owner.name, rectTransform.pivot[axis], normalizedPosition, np => rectTransform.SetPivotOnly(axis, np), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPivotOnlyX(this RectTransform rectTransform, float x, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPivotOnlyOneAxis(rectTransform, rectTransform.gameObject, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPivotOnlyX(this RectTransform rectTransform, GameObject owner, float x, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPivotOnlyOneAxis(rectTransform, owner, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPivotOnlyY(this RectTransform rectTransform, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPivotOnlyOneAxis(rectTransform, rectTransform.gameObject, 1, y, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPivotOnlyY(this RectTransform rectTransform, GameObject owner, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPivotOnlyOneAxis(rectTransform, owner, 1, y, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoPivotOnly
        private static Tween<Vector2, TweakVector2> DoPivotOnly(this RectTransform rectTransform, float x, float y, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoPivotOnly(rectTransform, rectTransform.gameObject, new Vector2(x, y), duration, formula, loopsCount, loopType, direction);
        }

        private static Tween<Vector2, TweakVector2> DoPivotOnly(this RectTransform rectTransform, GameObject owner, float x, float y, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoPivotOnly(rectTransform, owner, new Vector2(x, y), duration, formula, loopsCount, loopType, direction);
        }

        private static Tween<Vector2, TweakVector2> DoPivotOnly(this RectTransform rectTransform, Vector2 normalizedPosition, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoPivotOnly(rectTransform, rectTransform.gameObject, normalizedPosition, duration, formula, loopsCount, loopType, direction);
        }

        private static Tween<Vector2, TweakVector2> DoPivotOnly(this RectTransform rectTransform, GameObject owner, Vector2 normalizedPosition, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Vector2(owner, owner.name, rectTransform.pivot, normalizedPosition, np => rectTransform.SetPivotOnly(np), duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        private static void SetSizeDelta(this RectTransform rectTransform, int axis, float size)
        {
            var sizeDelta = rectTransform.sizeDelta;
            sizeDelta[axis] = size;
            rectTransform.sizeDelta = sizeDelta;
        }

        #region DoSizeDeltaOneAxis
        private static Tween<float, TweakFloat> DoSizeDeltaOneAxis(RectTransform rectTransform, GameObject owner, int axis, float size, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(owner, owner.name, rectTransform.sizeDelta[axis], size, s => rectTransform.SetSizeDelta(axis, s), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoSizeDeltaX(this RectTransform rectTransform, float x, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoSizeDeltaOneAxis(rectTransform, rectTransform.gameObject, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoSizeDeltaX(this RectTransform rectTransform, GameObject owner, float x, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoSizeDeltaOneAxis(rectTransform, owner, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoSizeDeltaY(this RectTransform rectTransform, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoSizeDeltaOneAxis(rectTransform, rectTransform.gameObject, 1, y, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoSizeDeltaY(this RectTransform rectTransform, GameObject owner, float y, float duration, Ease formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoSizeDeltaOneAxis(rectTransform, owner, 1, y, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoSizeDelta
        private static Tween<Vector2, TweakVector2> DoSizeDelta(this RectTransform rectTransform, float x, float y, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoSizeDelta(rectTransform, rectTransform.gameObject, new Vector2(x, y), duration, formula, loopsCount, loopType, direction);
        }

        private static Tween<Vector2, TweakVector2> DoSizeDelta(this RectTransform rectTransform, GameObject owner, float x, float y, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoSizeDelta(rectTransform, owner, new Vector2(x, y), duration, formula, loopsCount, loopType, direction);
        }

        private static Tween<Vector2, TweakVector2> DoSizeDelta(this RectTransform rectTransform, Vector2 size, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoSizeDelta(rectTransform, rectTransform.gameObject, size, duration, formula, loopsCount, loopType, direction);
        }

        private static Tween<Vector2, TweakVector2> DoSizeDelta(this RectTransform rectTransform, GameObject owner, Vector2 size, float duration, Ease formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Vector2(owner, owner.name, rectTransform.sizeDelta, size, size => rectTransform.sizeDelta = size, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoShakeAnchoredPosition
        public static Sequence DoShakeAnchoredPosition(this RectTransform rectTransform, int count = 10, float strenght = 10f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeAnchoredPosition(rectTransform, rectTransform.gameObject, count, strenght, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeAnchoredPosition(this RectTransform rectTransform, Vector2Int count, float strenght = 10f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeAnchoredPosition(rectTransform, rectTransform.gameObject, count, strenght, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeAnchoredPosition(this RectTransform rectTransform, int count, Vector2 strenght, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeAnchoredPosition(rectTransform, rectTransform.gameObject, count, strenght, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeAnchoredPosition(this RectTransform rectTransform, Vector2Int count, Vector2 strenght, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeAnchoredPosition(rectTransform, rectTransform.gameObject, count, strenght, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeAnchoredPosition(this RectTransform rectTransform, GameObject owner, int count = 10, float strenght = 10f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeAnchoredPosition(rectTransform, owner, new Vector2Int(count, count), new Vector2(strenght, strenght), duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeAnchoredPosition(this RectTransform rectTransform, GameObject owner, Vector2Int count, float strenght = 10f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeAnchoredPosition(rectTransform, owner, count, new Vector2(strenght, strenght), duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeAnchoredPosition(this RectTransform rectTransform, GameObject owner, int count, Vector2 strenght, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeAnchoredPosition(rectTransform, owner, new Vector2Int(count, count), strenght, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeAnchoredPosition(this RectTransform rectTransform, GameObject owner, Vector2Int count, Vector2 strenght, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            var sequence = new Sequence(owner, owner.name);

            sequence.Insert(0f, Tween.Shake(owner, owner.name, rectTransform.anchoredPosition.x, count.x, strenght.x, duration, x => rectTransform.anchoredPosition = rectTransform.anchoredPosition.WithX(x), leftSmoothness, rightSmoothness));
            sequence.Insert(0f, Tween.Shake(owner, owner.name, rectTransform.anchoredPosition.y, count.y, strenght.y, duration, y => rectTransform.anchoredPosition = rectTransform.anchoredPosition.WithY(y), leftSmoothness, rightSmoothness));

            return sequence;
        }
        #endregion

        #region DoShakeAnchoredPosition3D
        public static Sequence DoShakeAnchoredPosition3D(this RectTransform rectTransform, int count = 10, float strenght = 10f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeAnchoredPosition3D(rectTransform, rectTransform.gameObject, count, strenght, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeAnchoredPosition3D(this RectTransform rectTransform, Vector3Int count, float strenght = 10f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeAnchoredPosition3D(rectTransform, rectTransform.gameObject, count, strenght, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeAnchoredPosition3D(this RectTransform rectTransform, int count, Vector3 strenght, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeAnchoredPosition3D(rectTransform, rectTransform.gameObject, count, strenght, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeAnchoredPosition3D(this RectTransform rectTransform, Vector3Int count, Vector3 strenght, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeAnchoredPosition3D(rectTransform, rectTransform.gameObject, count, strenght, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeAnchoredPosition3D(this RectTransform rectTransform, GameObject owner, int count = 10, float strenght = 10f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeAnchoredPosition3D(rectTransform, owner, new Vector3Int(count, count, count), new Vector3(strenght, strenght, strenght), duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeAnchoredPosition3D(this RectTransform rectTransform, GameObject owner, Vector3Int count, float strenght = 10f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeAnchoredPosition3D(rectTransform, owner, count, new Vector3(strenght, strenght, strenght), duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeAnchoredPosition3D(this RectTransform rectTransform, GameObject owner, int count, Vector3 strenght, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeAnchoredPosition3D(rectTransform, owner, new Vector3Int(count, count, count), strenght, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeAnchoredPosition3D(this RectTransform rectTransform, GameObject owner, Vector3Int count, Vector3 strenght, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            var sequence = new Sequence(owner, owner.name);

            sequence.Insert(0f, Tween.Shake(owner, owner.name, rectTransform.anchoredPosition3D.x, count.x, strenght.x, duration, x => rectTransform.anchoredPosition3D = rectTransform.anchoredPosition3D.WithX(x), leftSmoothness, rightSmoothness));
            sequence.Insert(0f, Tween.Shake(owner, owner.name, rectTransform.anchoredPosition3D.y, count.y, strenght.y, duration, y => rectTransform.anchoredPosition3D = rectTransform.anchoredPosition3D.WithY(y), leftSmoothness, rightSmoothness));
            sequence.Insert(0f, Tween.Shake(owner, owner.name, rectTransform.anchoredPosition3D.z, count.z, strenght.z, duration, z => rectTransform.anchoredPosition3D = rectTransform.anchoredPosition3D.WithZ(z), leftSmoothness, rightSmoothness));

            return sequence;
        }
        #endregion

        #region DoPunchAnchoredPosition
        public static Sequence DoPunchAnchoredPosition(this RectTransform rectTransform, Vector2 vector, int count = 10, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            return DoPunchAnchoredPosition(rectTransform, rectTransform.gameObject, vector, count, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoPunchAnchoredPosition(this RectTransform rectTransform, GameObject owner, Vector2 vector, int count, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            var sequence = new Sequence(owner, owner.name);

            sequence.Insert(0f, Tween.Punch(owner, owner.name, rectTransform.anchoredPosition.x, count, vector.x, duration, x => rectTransform.anchoredPosition = rectTransform.anchoredPosition.WithX(x), leftSmoothness, rightSmoothness));
            sequence.Insert(0f, Tween.Punch(owner, owner.name, rectTransform.anchoredPosition.y, count, vector.y, duration, y => rectTransform.anchoredPosition = rectTransform.anchoredPosition.WithY(y), leftSmoothness, rightSmoothness));

            return sequence;
        }
        #endregion

        #region DoPunchAnchoredPosition3D
        public static Sequence DoPunchAnchoredPosition3D(this RectTransform rectTransform, Vector3 vector, int count = 10, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            return DoPunchAnchoredPosition3D(rectTransform, rectTransform.gameObject, vector, count, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoPunchAnchoredPosition3D(this RectTransform rectTransform, GameObject owner, Vector3 vector, int count, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            var sequence = new Sequence(owner, owner.name);

            sequence.Insert(0f, Tween.Punch(owner, owner.name, rectTransform.anchoredPosition3D.x, count, vector.x, duration, x => rectTransform.anchoredPosition3D = rectTransform.anchoredPosition3D.WithX(x), leftSmoothness, rightSmoothness));
            sequence.Insert(0f, Tween.Punch(owner, owner.name, rectTransform.anchoredPosition3D.y, count, vector.y, duration, y => rectTransform.anchoredPosition3D = rectTransform.anchoredPosition3D.WithY(y), leftSmoothness, rightSmoothness));
            sequence.Insert(0f, Tween.Punch(owner, owner.name, rectTransform.anchoredPosition3D.z, count, vector.z, duration, z => rectTransform.anchoredPosition3D = rectTransform.anchoredPosition3D.WithZ(z), leftSmoothness, rightSmoothness));

            return sequence;
        }
        #endregion
    }
}