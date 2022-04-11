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
            return Tween.Float(rectTransform.anchoredPosition[axis], position, p => rectTransform.anchoredPosition = rectTransform.anchoredPosition.With(axis, p), duration, ease, loopsCount, loopType, direction).SetOwner(owner).SetName(owner.name);
        }

        public static Tween<float, TweakFloat> DoAnchoredPositionX(this RectTransform rectTransform, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoredPositionOneAxis(rectTransform, rectTransform.gameObject, 0, x, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoAnchoredPositionY(this RectTransform rectTransform, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoredPositionOneAxis(rectTransform, rectTransform.gameObject, 1, y, duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoAnchoredPosition
        public static Tween<Vector2, TweakVector2> DoAnchoredPosition(this RectTransform rectTransform, float x, float y, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoAnchoredPosition(rectTransform, new Vector2(x, y), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoAnchoredPosition(this RectTransform rectTransform, Vector2 position, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Vector2(rectTransform.anchoredPosition, position, p => rectTransform.anchoredPosition = p, duration, ease, loopsCount, loopType, direction).SetOwner(rectTransform).SetName(rectTransform.name);
        }
        #endregion

        #region DoAnchoredPosition3DOneAxis
        private static Tween<float, TweakFloat> DoAnchoredPosition3DOneAxis(RectTransform rectTransform, GameObject owner, int axis, float position, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(rectTransform.anchoredPosition3D[axis], position, p => rectTransform.anchoredPosition3D = rectTransform.anchoredPosition3D.With(axis, p), duration, ease, loopsCount, loopType, direction).SetOwner(owner).SetName(owner.name);
        }

        public static Tween<float, TweakFloat> DoAnchoredPosition3DX(this RectTransform rectTransform, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoredPosition3DOneAxis(rectTransform, rectTransform.gameObject, 0, x, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoAnchoredPosition3DY(this RectTransform rectTransform, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoredPosition3DOneAxis(rectTransform, rectTransform.gameObject, 1, y, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoAnchoredPosition3DZ(this RectTransform rectTransform, float z, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoredPosition3DOneAxis(rectTransform, rectTransform.gameObject, 2, z, duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoAnchoredPosition3DTwoAxis
        private static Tween<Vector2, TweakVector2> DoAnchoredPosition3DTwoAxis(RectTransform rectTransform, GameObject owner, int axis1, int axis2, float position1, float position2, float duration, Ease ease, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            return Tween.Vector2(rectTransform.anchoredPosition3D.With(axis1, axis2), new Vector2(position1, position2), p => rectTransform.anchoredPosition3D = rectTransform.anchoredPosition3D.With(axis1, p.x, axis2, p.y), duration, ease, loopsCount, loopType, direction).SetOwner(owner).SetName(owner.name);
        }

        public static Tween<Vector2, TweakVector2> DoAnchoredPosition3DXY(this RectTransform rectTransform, float x, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoAnchoredPosition3DTwoAxis(rectTransform, rectTransform.gameObject, 0, 1, x, y, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoAnchoredPosition3DXZ(this RectTransform rectTransform, float x, float z, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoAnchoredPosition3DTwoAxis(rectTransform, rectTransform.gameObject, 0, 2, x, z, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Tween<Vector2, TweakVector2> DoAnchoredPosition3DYZ(this RectTransform rectTransform, float y, float z, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoAnchoredPosition3DTwoAxis(rectTransform, rectTransform.gameObject, 1, 2, y, z, duration, ease, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoAnchoredPosition3D
        public static Tween<Vector3, TweakVector3> DoAnchoredPosition3D(this RectTransform rectTransform,  float x, float y, float z, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoAnchoredPosition3D(rectTransform, new Vector3(x, y, z), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector3, TweakVector3> DoAnchoredPosition3D(this RectTransform rectTransform, Vector3 position, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Vector3(rectTransform.anchoredPosition3D, position, p => rectTransform.anchoredPosition3D = p, duration, ease, loopsCount, loopType, direction).SetOwner(rectTransform).SetName(rectTransform.name);
        }
        #endregion

        #region DoAnchoreMaxOneAxis
        private static Tween<float, TweakFloat> DoAnchoreMaxOneAxis(RectTransform rectTransform, GameObject owner, int axis, float normalizedPosition, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(rectTransform.anchorMax[axis], normalizedPosition, np => rectTransform.anchorMax = rectTransform.anchorMax.With(axis, np), duration, ease, loopsCount, loopType, direction).SetOwner(owner).SetName(owner.name);
        }

        public static Tween<float, TweakFloat> DoAnchoreMaxX(this RectTransform rectTransform, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoreMaxOneAxis(rectTransform, rectTransform.gameObject, 0, x, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoAnchoreMaxY(this RectTransform rectTransform, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoreMaxOneAxis(rectTransform, rectTransform.gameObject, 1, y, duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoAnchoreMax
        public static Tween<Vector2, TweakVector2> DoAnchoreMax(this RectTransform rectTransform, float x, float y, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoAnchoreMax(rectTransform, new Vector2(x, y), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoAnchoreMax(this RectTransform rectTransform, Vector2 normalizedPosition, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Vector2(rectTransform.anchorMax, normalizedPosition, np => rectTransform.anchorMax = np, duration, ease, loopsCount, loopType, direction).SetOwner(rectTransform).SetName(rectTransform.name);
        }
        #endregion

        #region DoAnchoreMinOneAxis
        private static Tween<float, TweakFloat> DoAnchoreMinOneAxis(RectTransform rectTransform, GameObject owner, int axis, float normalizedPosition, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(rectTransform.anchorMin[axis], normalizedPosition, np => rectTransform.anchorMax = rectTransform.anchorMax.With(axis, np), duration, ease, loopsCount, loopType, direction).SetOwner(owner).SetName(owner.name);
        }

        public static Tween<float, TweakFloat> DoAnchoreMinX(this RectTransform rectTransform, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoreMinOneAxis(rectTransform, rectTransform.gameObject, 0, x, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoAnchoreMinY(this RectTransform rectTransform, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoreMinOneAxis(rectTransform, rectTransform.gameObject, 1, y, duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoAnchoreMin
        public static Tween<Vector2, TweakVector2> DoAnchoreMin(this RectTransform rectTransform, float x, float y, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoAnchoreMin(rectTransform, new Vector2(x, y), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoAnchoreMin(this RectTransform rectTransform, Vector2 normalizedPosition, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Vector2(rectTransform.anchorMin, normalizedPosition, np => rectTransform.anchorMin = np, duration, ease, loopsCount, loopType, direction).SetOwner(rectTransform).SetName(rectTransform.name);
        }
        #endregion

        #region DoOffsetMaxOneAxis
        private static Tween<float, TweakFloat> DoOffsetMaxOneAxis(RectTransform rectTransform, GameObject owner, int axis, float offset, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(rectTransform.offsetMax[axis], offset, o => rectTransform.offsetMax = rectTransform.offsetMax.With(axis, o), duration, ease, loopsCount, loopType, direction).SetOwner(owner).SetName(owner.name);
        }

        public static Tween<float, TweakFloat> DoOffsetMaxX(this RectTransform rectTransform, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoOffsetMaxOneAxis(rectTransform, rectTransform.gameObject, 0, x, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoOffsetMaxY(this RectTransform rectTransform, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoOffsetMaxOneAxis(rectTransform, rectTransform.gameObject, 1, y, duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoOffsetMax
        public static Tween<Vector2, TweakVector2> DoOffsetMax(this RectTransform rectTransform, float x, float y, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoOffsetMax(rectTransform, new Vector2(x, y), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoOffsetMax(this RectTransform rectTransform, Vector2 offset, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Vector2(rectTransform.offsetMax, offset, o => rectTransform.offsetMax = o, duration, ease, loopsCount, loopType, direction).SetOwner(rectTransform).SetName(rectTransform.name);
        }
        #endregion

        #region DoOffsetMinOneAxis
        private static Tween<float, TweakFloat> DoOffsetMinOneAxis(RectTransform rectTransform, GameObject owner, int axis, float offset, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(rectTransform.offsetMin[axis], offset, o => rectTransform.offsetMax = rectTransform.offsetMax.With(axis, o), duration, ease, loopsCount, loopType, direction).SetOwner(owner).SetName(owner.name);
        }

        public static Tween<float, TweakFloat> DoOffsetMinX(this RectTransform rectTransform, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoOffsetMinOneAxis(rectTransform, rectTransform.gameObject, 0, x, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoOffsetMinY(this RectTransform rectTransform, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoOffsetMinOneAxis(rectTransform, rectTransform.gameObject, 1, y, duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoOffsetMin
        public static Tween<Vector2, TweakVector2> DoOffsetMin(this RectTransform rectTransform, float x, float y, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoOffsetMin(rectTransform, new Vector2(x, y), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoOffsetMin(this RectTransform rectTransform, Vector2 offset, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Vector2(rectTransform.offsetMin, offset, o => rectTransform.offsetMin = o, duration, ease, loopsCount, loopType, direction).SetOwner(rectTransform).SetName(rectTransform.name);
        }
        #endregion

        #region DoPivotOneAxis
        private static Tween<float, TweakFloat> DoPivotOneAxis(RectTransform rectTransform, GameObject owner, int axis, float normalizedPosition, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(rectTransform.pivot[axis], normalizedPosition, np => rectTransform.pivot = rectTransform.pivot.With(axis, np), duration, ease, loopsCount, loopType, direction).SetOwner(owner).SetName(owner.name);
        }

        public static Tween<float, TweakFloat> DoPivotX(this RectTransform rectTransform, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPivotOneAxis(rectTransform, rectTransform.gameObject, 0, x, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPivotY(this RectTransform rectTransform, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPivotOneAxis(rectTransform, rectTransform.gameObject, 1, y, duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoPivot
        private static Tween<Vector2, TweakVector2> DoPivot(this RectTransform rectTransform, float x, float y, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoPivot(rectTransform, new Vector2(x, y), duration, ease, loopsCount, loopType, direction);
        }

        private static Tween<Vector2, TweakVector2> DoPivot(this RectTransform rectTransform, Vector2 normalizedPosition, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Vector2(rectTransform.pivot, normalizedPosition, np => rectTransform.pivot = np, duration, ease, loopsCount, loopType, direction).SetOwner(rectTransform).SetName(rectTransform.name);
        }
        #endregion

        #region DoPivotOnlyOneAxis
        private static Tween<float, TweakFloat> DoPivotOnlyOneAxis(RectTransform rectTransform, GameObject owner, int axis, float normalizedPosition, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(rectTransform.pivot[axis], normalizedPosition, np => rectTransform.SetPivotOnly(axis, np), duration, ease, loopsCount, loopType, direction).SetOwner(owner).SetName(owner.name);
        }

        public static Tween<float, TweakFloat> DoPivotOnlyX(this RectTransform rectTransform, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPivotOnlyOneAxis(rectTransform, rectTransform.gameObject, 0, x, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPivotOnlyY(this RectTransform rectTransform, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPivotOnlyOneAxis(rectTransform, rectTransform.gameObject, 1, y, duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoPivotOnly
        public static Tween<Vector2, TweakVector2> DoPivotOnly(this RectTransform rectTransform, float x, float y, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoPivotOnly(rectTransform, new Vector2(x, y), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoPivotOnly(this RectTransform rectTransform, Vector2 normalizedPosition, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Vector2(rectTransform.pivot, normalizedPosition, np => rectTransform.SetPivotOnly(np), duration, ease, loopsCount, loopType, direction).SetOwner(rectTransform).SetName(rectTransform.name);
        }
        #endregion

        #region DoSizeDeltaOneAxis
        private static Tween<float, TweakFloat> DoSizeDeltaOneAxis(RectTransform rectTransform, GameObject owner, int axis, float size, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(rectTransform.sizeDelta[axis], size, s => rectTransform.sizeDelta = rectTransform.sizeDelta.With(axis, s), duration, ease, loopsCount, loopType, direction).SetOwner(owner).SetName(owner.name);
        }

        public static Tween<float, TweakFloat> DoSizeDeltaX(this RectTransform rectTransform, float x, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoSizeDeltaOneAxis(rectTransform, rectTransform.gameObject, 0, x, duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoSizeDeltaY(this RectTransform rectTransform, float y, float duration, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoSizeDeltaOneAxis(rectTransform, rectTransform.gameObject, 1, y, duration, ease, loopsCount, loopType, direction);
        }
        #endregion

        #region DoSizeDelta
        public static Tween<Vector2, TweakVector2> DoSizeDelta(this RectTransform rectTransform, float x, float y, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoSizeDelta(rectTransform, new Vector2(x, y), duration, ease, loopsCount, loopType, direction);
        }

        public static Tween<Vector2, TweakVector2> DoSizeDelta(this RectTransform rectTransform, Vector2 size, float duration, Ease ease, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Vector2(rectTransform.sizeDelta, size, size => rectTransform.sizeDelta = size, duration, ease, loopsCount, loopType, direction).SetOwner(rectTransform).SetName(rectTransform.name);
        }
        #endregion

        #region DoShakeAnchoredPosition
        public static Sequence DoShakeAnchoredPosition(this RectTransform rectTransform, int count = 10, float strenght = 10f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeAnchoredPosition(rectTransform, count, strenght, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeAnchoredPosition(this RectTransform rectTransform, Vector2Int count, float strenght = 10f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeAnchoredPosition(rectTransform, count, strenght, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeAnchoredPosition(this RectTransform rectTransform, int count, Vector2 strenght, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeAnchoredPosition(rectTransform, count, strenght, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeAnchoredPosition(this RectTransform rectTransform, Vector2Int count, Vector2 strenght, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            var sequence = new Sequence(rectTransform.gameObject, rectTransform.name);

            sequence.Insert(0f, Tween.Shake(rectTransform.anchoredPosition.x, count.x, strenght.x, duration, x => rectTransform.anchoredPosition = rectTransform.anchoredPosition.WithX(x), leftSmoothness, rightSmoothness).SetOwner(rectTransform).SetName(rectTransform.name)); ; ;
            sequence.Insert(0f, Tween.Shake(rectTransform.anchoredPosition.y, count.y, strenght.y, duration, y => rectTransform.anchoredPosition = rectTransform.anchoredPosition.WithY(y), leftSmoothness, rightSmoothness).SetOwner(rectTransform).SetName(rectTransform.name));

            return sequence;
        }
        #endregion

        #region DoShakeAnchoredPosition3D
        public static Sequence DoShakeAnchoredPosition3D(this RectTransform rectTransform, int count = 10, float strenght = 10f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeAnchoredPosition3D(rectTransform, count, strenght, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeAnchoredPosition3D(this RectTransform rectTransform, Vector3Int count, float strenght = 10f, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeAnchoredPosition3D(rectTransform, count, strenght, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeAnchoredPosition3D(this RectTransform rectTransform, int count, Vector3 strenght, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            return DoShakeAnchoredPosition3D(rectTransform, count, strenght, duration, leftSmoothness, rightSmoothness);
        }

        public static Sequence DoShakeAnchoredPosition3D(this RectTransform rectTransform, Vector3Int count, Vector3 strenght, float duration = 1f, float leftSmoothness = 0.05f, float rightSmoothness = 0.5f)
        {
            var sequence = new Sequence(rectTransform.gameObject, rectTransform.name);

            sequence.Insert(0f, Tween.Shake(rectTransform.anchoredPosition3D.x, count.x, strenght.x, duration, x => rectTransform.anchoredPosition3D = rectTransform.anchoredPosition3D.WithX(x), leftSmoothness, rightSmoothness).SetOwner(rectTransform).SetName(rectTransform.name));
            sequence.Insert(0f, Tween.Shake(rectTransform.anchoredPosition3D.y, count.y, strenght.y, duration, y => rectTransform.anchoredPosition3D = rectTransform.anchoredPosition3D.WithY(y), leftSmoothness, rightSmoothness).SetOwner(rectTransform).SetName(rectTransform.name));
            sequence.Insert(0f, Tween.Shake(rectTransform.anchoredPosition3D.z, count.z, strenght.z, duration, z => rectTransform.anchoredPosition3D = rectTransform.anchoredPosition3D.WithZ(z), leftSmoothness, rightSmoothness).SetOwner(rectTransform).SetName(rectTransform.name));

            return sequence;
        }
        #endregion

        public static Sequence DoPunchAnchoredPosition(this RectTransform rectTransform, Vector2 vector, int count, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            var sequence = new Sequence().SetOwner(rectTransform).SetName(rectTransform.name);

            sequence.Insert(0f, Tween.Punch(rectTransform.anchoredPosition.x, count, vector.x, duration, x => rectTransform.anchoredPosition = rectTransform.anchoredPosition.WithX(x), leftSmoothness, rightSmoothness).SetOwner(rectTransform).SetName(rectTransform.name));
            sequence.Insert(0f, Tween.Punch(rectTransform.anchoredPosition.y, count, vector.y, duration, y => rectTransform.anchoredPosition = rectTransform.anchoredPosition.WithY(y), leftSmoothness, rightSmoothness).SetOwner(rectTransform).SetName(rectTransform.name));

            return sequence;
        }
        
        public static Sequence DoPunchAnchoredPosition3D(this RectTransform rectTransform, Vector3 vector, int count, float duration = 1f, float leftSmoothness = 0.1f, float rightSmoothness = 0.9f)
        {
            var sequence = new Sequence(rectTransform.gameObject, rectTransform.name);

            sequence.Insert(0f, Tween.Punch(rectTransform.anchoredPosition3D.x, count, vector.x, duration, x => rectTransform.anchoredPosition3D = rectTransform.anchoredPosition3D.WithX(x), leftSmoothness, rightSmoothness).SetOwner(rectTransform).SetName(rectTransform.name));
            sequence.Insert(0f, Tween.Punch(rectTransform.anchoredPosition3D.y, count, vector.y, duration, y => rectTransform.anchoredPosition3D = rectTransform.anchoredPosition3D.WithY(y), leftSmoothness, rightSmoothness).SetOwner(rectTransform).SetName(rectTransform.name));
            sequence.Insert(0f, Tween.Punch(rectTransform.anchoredPosition3D.z, count, vector.z, duration, z => rectTransform.anchoredPosition3D = rectTransform.anchoredPosition3D.WithZ(z), leftSmoothness, rightSmoothness).SetOwner(rectTransform).SetName(rectTransform.name));

            return sequence;
        }
    }
}