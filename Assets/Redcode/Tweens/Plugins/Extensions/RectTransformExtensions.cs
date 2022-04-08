using Redcode.Extensions;
using Redcode.Tweens.Tweaks;
using UnityEngine;

namespace Redcode.Tweens
{
    public static class RectTransformExtensions
    {
        #region DoAnchoredPositionOneAxis
        private static Tween<float, TweakFloat> DoAnchoredPositionOneAxis(RectTransform rectTransform, GameObject owner, int axis, float position, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(owner, owner.name, rectTransform.anchoredPosition[axis], position, p => rectTransform.anchoredPosition = rectTransform.anchoredPosition.With(axis, p), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoAnchoredPositionX(this RectTransform rectTransform, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoredPositionOneAxis(rectTransform, rectTransform.gameObject, 0, x, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoAnchoredPositionX(this RectTransform rectTransform, GameObject owner, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoredPositionOneAxis(rectTransform, owner, 0, x, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoAnchoredPositionY(this RectTransform rectTransform, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoredPositionOneAxis(rectTransform, rectTransform.gameObject, 1, y, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoAnchoredPositionY(this RectTransform rectTransform, GameObject owner, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoredPositionOneAxis(rectTransform, owner, 1, y, duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoAnchoredPosition
        public static Tween<Vector2, TweakVector2> DoAnchoredPosition(this RectTransform rectTransform, float x, float y, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoAnchoredPosition(rectTransform, rectTransform.gameObject, new Vector2(x, y), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoAnchoredPosition(this RectTransform rectTransform, GameObject owner, float x, float y, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoAnchoredPosition(rectTransform, owner, new Vector2(x, y), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoAnchoredPosition(this RectTransform rectTransform, Vector2 position, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoAnchoredPosition(rectTransform, rectTransform.gameObject, position, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoAnchoredPosition(this RectTransform rectTransform, GameObject owner, Vector2 position, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Vector2(owner, owner.name, rectTransform.anchoredPosition, position, p => rectTransform.anchoredPosition = p, duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoAnchoredPosition3DOneAxis
        private static Tween<float, TweakFloat> DoAnchoredPosition3DOneAxis(RectTransform rectTransform, GameObject owner, int axis, float position, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(owner, owner.name, rectTransform.anchoredPosition3D[axis], position, p => rectTransform.anchoredPosition3D = rectTransform.anchoredPosition3D.With(axis, p), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoAnchoredPosition3DX(this RectTransform rectTransform, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoredPosition3DOneAxis(rectTransform, rectTransform.gameObject, 0, x, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoAnchoredPosition3DX(this RectTransform rectTransform, GameObject owner, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoredPosition3DOneAxis(rectTransform, owner, 0, x, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoAnchoredPosition3DY(this RectTransform rectTransform, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoredPosition3DOneAxis(rectTransform, rectTransform.gameObject, 1, y, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoAnchoredPosition3DY(this RectTransform rectTransform, GameObject owner, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoredPosition3DOneAxis(rectTransform, owner, 1, y, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoAnchoredPosition3DZ(this RectTransform rectTransform, float z, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoredPosition3DOneAxis(rectTransform, rectTransform.gameObject, 2, z, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoAnchoredPosition3DZ(this RectTransform rectTransform, GameObject owner, float z, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoredPosition3DOneAxis(rectTransform, owner, 2, z, duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoAnchoredPosition3DTwoAxis
        private static Tween<Vector2, TweakVector2> DoAnchoredPosition3DTwoAxis(RectTransform rectTransform, GameObject owner, int axis1, int axis2, float position1, float position2, float duration, Ease ease, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            return Tween.Vector2(owner, owner.name, rectTransform.anchoredPosition3D.With(axis1, axis2), new Vector2(position1, position2), p => rectTransform.anchoredPosition3D = rectTransform.anchoredPosition3D.With(axis1, p.x, axis2, p.y), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoAnchoredPosition3DXY(this RectTransform rectTransform, float x, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoAnchoredPosition3DTwoAxis(rectTransform, rectTransform.gameObject, 0, 1, x, y, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoAnchoredPosition3DXY(this RectTransform rectTransform, GameObject owner, float x, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoAnchoredPosition3DTwoAxis(rectTransform, owner, 0, 1, x, y, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoAnchoredPosition3DXZ(this RectTransform rectTransform, float x, float z, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoAnchoredPosition3DTwoAxis(rectTransform, rectTransform.gameObject, 0, 2, x, z, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoAnchoredPosition3DXZ(this RectTransform rectTransform, GameObject owner, float x, float z, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoAnchoredPosition3DTwoAxis(rectTransform, owner, 0, 2, x, z, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoAnchoredPosition3DYZ(this RectTransform rectTransform, float y, float z, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoAnchoredPosition3DTwoAxis(rectTransform, rectTransform.gameObject, 1, 2, y, z, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoAnchoredPosition3DYZ(this RectTransform rectTransform, GameObject owner, float y, float z, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoAnchoredPosition3DTwoAxis(rectTransform, owner, 1, 2, y, z, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoAnchoredPosition3D
        public static Tween<Vector3, TweakVector3> DoAnchoredPosition3D(this RectTransform rectTransform,  float x, float y, float z, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoAnchoredPosition3D(rectTransform, rectTransform.gameObject, new Vector3(x, y, z), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoAnchoredPosition3D(this RectTransform rectTransform, GameObject owner, float x, float y, float z, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoAnchoredPosition3D(rectTransform, owner, new Vector3(x, y, z), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoAnchoredPosition3D(this RectTransform rectTransform, Vector3 position, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoAnchoredPosition3D(rectTransform, rectTransform.gameObject, position, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoAnchoredPosition3D(this RectTransform rectTransform, GameObject owner, Vector3 position, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Vector3(owner, owner.name, rectTransform.anchoredPosition3D, position, p => rectTransform.anchoredPosition3D = p, duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoAnchoreMaxOneAxis
        private static Tween<float, TweakFloat> DoAnchoreMaxOneAxis(RectTransform rectTransform, GameObject owner, int axis, float normalizedPosition, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(owner, owner.name, rectTransform.anchorMax[axis], normalizedPosition, np => rectTransform.anchorMax = rectTransform.anchorMax.With(axis, np), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoAnchoreMaxX(this RectTransform rectTransform, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoreMaxOneAxis(rectTransform, rectTransform.gameObject, 0, x, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoAnchoreMaxX(this RectTransform rectTransform, GameObject owner, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoreMaxOneAxis(rectTransform, owner, 0, x, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoAnchoreMaxY(this RectTransform rectTransform, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoreMaxOneAxis(rectTransform, rectTransform.gameObject, 1, y, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoAnchoreMaxY(this RectTransform rectTransform, GameObject owner, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoreMaxOneAxis(rectTransform, owner, 1, y, duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoAnchoreMax
        public static Tween<Vector2, TweakVector2> DoAnchoreMax(this RectTransform rectTransform, float x, float y, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoAnchoreMax(rectTransform, rectTransform.gameObject, new Vector2(x, y), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoAnchoreMax(this RectTransform rectTransform, GameObject owner, float x, float y, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoAnchoreMax(rectTransform, owner, new Vector2(x, y), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoAnchoreMax(this RectTransform rectTransform, Vector2 normalizedPosition, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoAnchoreMax(rectTransform, rectTransform.gameObject, normalizedPosition, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoAnchoreMax(this RectTransform rectTransform, GameObject owner, Vector2 normalizedPosition, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Vector2(owner, owner.name, rectTransform.anchorMax, normalizedPosition, np => rectTransform.anchorMax = np, duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoAnchoreMinOneAxis
        private static Tween<float, TweakFloat> DoAnchoreMinOneAxis(RectTransform rectTransform, GameObject owner, int axis, float normalizedPosition, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(owner, owner.name, rectTransform.anchorMin[axis], normalizedPosition, np => rectTransform.anchorMax = rectTransform.anchorMax.With(axis, np), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoAnchoreMinX(this RectTransform rectTransform, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoreMinOneAxis(rectTransform, rectTransform.gameObject, 0, x, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoAnchoreMinX(this RectTransform rectTransform, GameObject owner, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoreMinOneAxis(rectTransform, owner, 0, x, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoAnchoreMinY(this RectTransform rectTransform, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoreMinOneAxis(rectTransform, rectTransform.gameObject, 1, y, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoAnchoreMinY(this RectTransform rectTransform, GameObject owner, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoreMinOneAxis(rectTransform, owner, 1, y, duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoAnchoreMin
        public static Tween<Vector2, TweakVector2> DoAnchoreMin(this RectTransform rectTransform, float x, float y, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoAnchoreMin(rectTransform, rectTransform.gameObject, new Vector2(x, y), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoAnchoreMin(this RectTransform rectTransform, GameObject owner, float x, float y, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoAnchoreMin(rectTransform, owner, new Vector2(x, y), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoAnchoreMin(this RectTransform rectTransform, Vector2 normalizedPosition, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoAnchoreMin(rectTransform, rectTransform.gameObject, normalizedPosition, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoAnchoreMin(this RectTransform rectTransform, GameObject owner, Vector2 normalizedPosition, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Vector2(owner, owner.name, rectTransform.anchorMin, normalizedPosition, np => rectTransform.anchorMin = np, duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoOffsetMaxOneAxis
        private static Tween<float, TweakFloat> DoOffsetMaxOneAxis(RectTransform rectTransform, GameObject owner, int axis, float offset, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(owner, owner.name, rectTransform.offsetMax[axis], offset, o => rectTransform.offsetMax = rectTransform.offsetMax.With(axis, o), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoOffsetMaxX(this RectTransform rectTransform, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoOffsetMaxOneAxis(rectTransform, rectTransform.gameObject, 0, x, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoOffsetMaxX(this RectTransform rectTransform, GameObject owner, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoOffsetMaxOneAxis(rectTransform, owner, 0, x, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoOffsetMaxY(this RectTransform rectTransform, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoOffsetMaxOneAxis(rectTransform, rectTransform.gameObject, 1, y, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoOffsetMaxY(this RectTransform rectTransform, GameObject owner, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoOffsetMaxOneAxis(rectTransform, owner, 1, y, duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoOffsetMax
        public static Tween<Vector2, TweakVector2> DoOffsetMax(this RectTransform rectTransform, float x, float y, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoOffsetMax(rectTransform, rectTransform.gameObject, new Vector2(x, y), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoOffsetMax(this RectTransform rectTransform, GameObject owner, float x, float y, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoOffsetMax(rectTransform, owner, new Vector2(x, y), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoOffsetMax(this RectTransform rectTransform, Vector2 offset, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoOffsetMax(rectTransform, rectTransform.gameObject, offset, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoOffsetMax(this RectTransform rectTransform, GameObject owner, Vector2 offset, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Vector2(owner, owner.name, rectTransform.offsetMax, offset, o => rectTransform.offsetMax = o, duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoOffsetMinOneAxis
        private static Tween<float, TweakFloat> DoOffsetMinOneAxis(RectTransform rectTransform, GameObject owner, int axis, float offset, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(owner, owner.name, rectTransform.offsetMin[axis], offset, o => rectTransform.offsetMax = rectTransform.offsetMax.With(axis, o), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoOffsetMinX(this RectTransform rectTransform, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoOffsetMinOneAxis(rectTransform, rectTransform.gameObject, 0, x, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoOffsetMinX(this RectTransform rectTransform, GameObject owner, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoOffsetMinOneAxis(rectTransform, owner, 0, x, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoOffsetMinY(this RectTransform rectTransform, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoOffsetMinOneAxis(rectTransform, rectTransform.gameObject, 1, y, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoOffsetMinY(this RectTransform rectTransform, GameObject owner, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoOffsetMinOneAxis(rectTransform, owner, 1, y, duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoOffsetMin
        public static Tween<Vector2, TweakVector2> DoOffsetMin(this RectTransform rectTransform, float x, float y, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoOffsetMin(rectTransform, rectTransform.gameObject, new Vector2(x, y), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoOffsetMin(this RectTransform rectTransform, GameObject owner, float x, float y, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoOffsetMin(rectTransform, owner, new Vector2(x, y), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoOffsetMin(this RectTransform rectTransform, Vector2 offset, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoOffsetMin(rectTransform, rectTransform.gameObject, offset, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoOffsetMin(this RectTransform rectTransform, GameObject owner, Vector2 offset, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Vector2(owner, owner.name, rectTransform.offsetMin, offset, o => rectTransform.offsetMin = o, duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoPivotOneAxis
        private static Tween<float, TweakFloat> DoPivotOneAxis(RectTransform rectTransform, GameObject owner, int axis, float normalizedPosition, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(owner, owner.name, rectTransform.pivot[axis], normalizedPosition, np => rectTransform.pivot = rectTransform.pivot.With(axis, np), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPivotX(this RectTransform rectTransform, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPivotOneAxis(rectTransform, rectTransform.gameObject, 0, x, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPivotX(this RectTransform rectTransform, GameObject owner, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPivotOneAxis(rectTransform, owner, 0, x, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPivotY(this RectTransform rectTransform, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPivotOneAxis(rectTransform, rectTransform.gameObject, 1, y, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPivotY(this RectTransform rectTransform, GameObject owner, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPivotOneAxis(rectTransform, owner, 1, y, duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoPivot
        private static Tween<Vector2, TweakVector2> DoPivot(this RectTransform rectTransform, float x, float y, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoPivot(rectTransform, rectTransform.gameObject, new Vector2(x, y), duration, ease, loopsCount, loopType, direction);
        }

        private static Tween<Vector2, TweakVector2> DoPivot(this RectTransform rectTransform, GameObject owner, float x, float y, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoPivot(rectTransform, owner, new Vector2(x, y), duration, ease, loopsCount, loopType, direction);
        }

        private static Tween<Vector2, TweakVector2> DoPivot(this RectTransform rectTransform, Vector2 normalizedPosition, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoPivot(rectTransform, rectTransform.gameObject, normalizedPosition, duration, ease, loopsCount, loopType, direction);
        }

        private static Tween<Vector2, TweakVector2> DoPivot(this RectTransform rectTransform, GameObject owner, Vector2 normalizedPosition, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Vector2(owner, owner.name, rectTransform.pivot, normalizedPosition, np => rectTransform.pivot = np, duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoPivotOnlyOneAxis
        private static Tween<float, TweakFloat> DoPivotOnlyOneAxis(RectTransform rectTransform, GameObject owner, int axis, float normalizedPosition, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(owner, owner.name, rectTransform.pivot[axis], normalizedPosition, np => rectTransform.SetPivotOnly(axis, np), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPivotOnlyX(this RectTransform rectTransform, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPivotOnlyOneAxis(rectTransform, rectTransform.gameObject, 0, x, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPivotOnlyX(this RectTransform rectTransform, GameObject owner, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPivotOnlyOneAxis(rectTransform, owner, 0, x, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPivotOnlyY(this RectTransform rectTransform, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPivotOnlyOneAxis(rectTransform, rectTransform.gameObject, 1, y, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPivotOnlyY(this RectTransform rectTransform, GameObject owner, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPivotOnlyOneAxis(rectTransform, owner, 1, y, duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoPivotOnly
        public static Tween<Vector2, TweakVector2> DoPivotOnly(this RectTransform rectTransform, float x, float y, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoPivotOnly(rectTransform, rectTransform.gameObject, new Vector2(x, y), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoPivotOnly(this RectTransform rectTransform, GameObject owner, float x, float y, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoPivotOnly(rectTransform, owner, new Vector2(x, y), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoPivotOnly(this RectTransform rectTransform, Vector2 normalizedPosition, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoPivotOnly(rectTransform, rectTransform.gameObject, normalizedPosition, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoPivotOnly(this RectTransform rectTransform, GameObject owner, Vector2 normalizedPosition, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Vector2(owner, owner.name, rectTransform.pivot, normalizedPosition, np => rectTransform.SetPivotOnly(np), duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoSizeDeltaOneAxis
        private static Tween<float, TweakFloat> DoSizeDeltaOneAxis(RectTransform rectTransform, GameObject owner, int axis, float size, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(owner, owner.name, rectTransform.sizeDelta[axis], size, s => rectTransform.sizeDelta = rectTransform.sizeDelta.With(axis, s), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoSizeDeltaX(this RectTransform rectTransform, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoSizeDeltaOneAxis(rectTransform, rectTransform.gameObject, 0, x, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoSizeDeltaX(this RectTransform rectTransform, GameObject owner, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoSizeDeltaOneAxis(rectTransform, owner, 0, x, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoSizeDeltaY(this RectTransform rectTransform, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoSizeDeltaOneAxis(rectTransform, rectTransform.gameObject, 1, y, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoSizeDeltaY(this RectTransform rectTransform, GameObject owner, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoSizeDeltaOneAxis(rectTransform, owner, 1, y, duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoSizeDelta
        public static Tween<Vector2, TweakVector2> DoSizeDelta(this RectTransform rectTransform, float x, float y, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoSizeDelta(rectTransform, rectTransform.gameObject, new Vector2(x, y), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoSizeDelta(this RectTransform rectTransform, GameObject owner, float x, float y, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoSizeDelta(rectTransform, owner, new Vector2(x, y), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoSizeDelta(this RectTransform rectTransform, Vector2 size, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoSizeDelta(rectTransform, rectTransform.gameObject, size, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoSizeDelta(this RectTransform rectTransform, GameObject owner, Vector2 size, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Vector2(owner, owner.name, rectTransform.sizeDelta, size, size => rectTransform.sizeDelta = size, duration, ease, loopsCount, loopType, direction);
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