using Extensions;
using Tweens.Formulas;
using Tweens.Tweaks;
using UnityEngine;

namespace Tweens
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
        private static Tween<float, TweakFloat> DoAnchoredPositionOneAxis(this RectTransform rectTransform, int axis, float position, float duration, FormulaBase formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(rectTransform.gameObject, rectTransform.name, rectTransform.anchoredPosition[axis], position, p => rectTransform.SetAnchoredPosition(axis, p), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoAnchoredPositionX(this RectTransform rectTransform, float x, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoredPositionOneAxis(rectTransform, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoAnchoredPositionY(this RectTransform rectTransform, float y, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoredPositionOneAxis(rectTransform, 1, y, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoAnchoredPosition
        private static Tween<Vector2, TweakVector2> DoAnchoredPosition(this RectTransform rectTransform, float x, float y, float duration, FormulaBase formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoAnchoredPosition(rectTransform, new Vector2(x, y), duration, formula, loopsCount, loopType, direction);
        }

        private static Tween<Vector2, TweakVector2> DoAnchoredPosition(this RectTransform rectTransform, Vector2 position, float duration, FormulaBase formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Vector2(rectTransform.gameObject, rectTransform.name, rectTransform.anchoredPosition, position, p => rectTransform.anchoredPosition = p, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        private static void SetAnchoredPosition3D(this RectTransform rectTransform, int axis, float position)
        {
            var pos = rectTransform.anchoredPosition3D;
            pos[axis] = position;
            rectTransform.anchoredPosition3D = pos;
        }

        #region DoAnchoredPosition3DOneAxis
        private static Tween<float, TweakFloat> DoAnchoredPosition3DOneAxis(this RectTransform rectTransform, int axis, float position, float duration, FormulaBase formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(rectTransform.gameObject, rectTransform.name, rectTransform.anchoredPosition3D[axis], position, p => rectTransform.SetAnchoredPosition3D(axis, p), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoAnchoredPosition3DX(this RectTransform rectTransform, float x, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoredPosition3DOneAxis(rectTransform, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoAnchoredPosition3DY(this RectTransform rectTransform, float y, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoredPosition3DOneAxis(rectTransform, 1, y, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoAnchoredPosition3DZ(this RectTransform rectTransform, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoredPosition3DOneAxis(rectTransform, 2, z, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoAnchoredPosition3DTwoAxis
        private static Sequence DoAnchoredPosition3DTwoAxis(this RectTransform rectTransform, int axis1, int axis2, float position1, float position2, float duration, FormulaBase formula, int loopsCount, LoopType loopType, LoopResetBehaviour loopResetBehaviour, Direction direction)
        {
            var sequence = new Sequence(rectTransform.gameObject, rectTransform.name, formula, loopsCount, loopType, loopResetBehaviour, direction);

            sequence.Insert(0f, Tween.Float(rectTransform.gameObject, rectTransform.name, rectTransform.anchoredPosition3D[axis1], position1, p => rectTransform.SetAnchoredPosition3D(axis1, p), duration));
            sequence.Insert(0f, Tween.Float(rectTransform.gameObject, rectTransform.name, rectTransform.anchoredPosition3D[axis2], position2, p => rectTransform.SetAnchoredPosition3D(axis2, p), duration));

            return sequence;
        }

        public static Sequence DoAnchoredPosition3DXY(this RectTransform rectTransform, float x, float y, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoAnchoredPosition3DTwoAxis(rectTransform, 0, 1, x, y, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoAnchoredPosition3DXZ(this RectTransform rectTransform, float x, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoAnchoredPosition3DTwoAxis(rectTransform, 0, 2, x, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }

        public static Sequence DoAnchoredPosition3DYZ(this RectTransform rectTransform, float y, float z, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward)
        {
            return DoAnchoredPosition3DTwoAxis(rectTransform, 1, 2, y, z, duration, formula, loopsCount, loopType, loopResetBehaviour, direction);
        }
        #endregion

        #region DoAnchoredPosition3D
        private static Tween<Vector3, TweakVector3> DoAnchoredPosition3D(this RectTransform rectTransform, float x, float y, float z, float duration, FormulaBase formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoAnchoredPosition3D(rectTransform, new Vector3(x, y, z), duration, formula, loopsCount, loopType, direction);
        }

        private static Tween<Vector3, TweakVector3> DoAnchoredPosition3D(this RectTransform rectTransform, Vector3 position, float duration, FormulaBase formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Vector3(rectTransform.gameObject, rectTransform.name, rectTransform.anchoredPosition3D, position, p => rectTransform.anchoredPosition3D = p, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoAnchoreMaxOneAxis
        private static Tween<float, TweakFloat> DoAnchoreMaxOneAxis(this RectTransform rectTransform, int axis, float normalizedPosition, float duration, FormulaBase formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(rectTransform.gameObject, rectTransform.name, rectTransform.anchorMax[axis], normalizedPosition, np => rectTransform.SetAnchoreMax(axis, np), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoAnchoreMaxX(this RectTransform rectTransform, float x, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoreMaxOneAxis(rectTransform, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoAnchoreMaxY(this RectTransform rectTransform, float y, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoreMaxOneAxis(rectTransform, 1, y, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        private static void SetAnchoreMax(this RectTransform rectTransform, int axis, float position)
        {
            var pos = rectTransform.anchorMax;
            pos[axis] = position;
            rectTransform.anchorMax = pos;
        }

        #region DoAnchoreMax
        private static Tween<Vector2, TweakVector2> DoAnchoreMax(this RectTransform rectTransform, float x, float y, float duration, FormulaBase formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoAnchoreMax(rectTransform, new Vector2(x, y), duration, formula, loopsCount, loopType, direction);
        }

        private static Tween<Vector2, TweakVector2> DoAnchoreMax(this RectTransform rectTransform, Vector2 normalizedPosition, float duration, FormulaBase formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Vector2(rectTransform.gameObject, rectTransform.name, rectTransform.anchorMax, normalizedPosition, np => rectTransform.anchorMax = np, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoAnchoreMinOneAxis
        private static Tween<float, TweakFloat> DoAnchoreMinOneAxis(this RectTransform rectTransform, int axis, float normalizedPosition, float duration, FormulaBase formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(rectTransform.gameObject, rectTransform.name, rectTransform.anchorMin[axis], normalizedPosition, np => rectTransform.SetAnchoreMin(axis, np), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoAnchoreMinX(this RectTransform rectTransform, float x, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoreMinOneAxis(rectTransform, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoAnchoreMinY(this RectTransform rectTransform, float y, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoAnchoreMinOneAxis(rectTransform, 1, y, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        private static void SetAnchoreMin(this RectTransform rectTransform, int axis, float position)
        {
            var pos = rectTransform.anchorMin;
            pos[axis] = position;
            rectTransform.anchorMin = pos;
        }

        #region DoAnchoreMin
        private static Tween<Vector2, TweakVector2> DoAnchoreMin(this RectTransform rectTransform, float x, float y, float duration, FormulaBase formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoAnchoreMin(rectTransform, new Vector2(x, y), duration, formula, loopsCount, loopType, direction);
        }

        private static Tween<Vector2, TweakVector2> DoAnchoreMin(this RectTransform rectTransform, Vector2 normalizedPosition, float duration, FormulaBase formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Vector2(rectTransform.gameObject, rectTransform.name, rectTransform.anchorMin, normalizedPosition, np => rectTransform.anchorMin = np, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoOffsetMaxOneAxis
        private static Tween<float, TweakFloat> DoOffsetMaxOneAxis(this RectTransform rectTransform, int axis, float offset, float duration, FormulaBase formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(rectTransform.gameObject, rectTransform.name, rectTransform.offsetMax[axis], offset, o => rectTransform.SetOffsetMax(axis, o), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoOffsetMaxX(this RectTransform rectTransform, float x, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoOffsetMaxOneAxis(rectTransform, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoOffsetMaxY(this RectTransform rectTransform, float y, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoOffsetMaxOneAxis(rectTransform, 1, y, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        private static void SetOffsetMax(this RectTransform rectTransform, int axis, float offset)
        {
            var offsetMax = rectTransform.offsetMax;
            offsetMax[axis] = offset;
            rectTransform.offsetMax = offsetMax;
        }

        #region DoOffsetMax
        private static Tween<Vector2, TweakVector2> DoOffsetMax(this RectTransform rectTransform, float x, float y, float duration, FormulaBase formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoOffsetMax(rectTransform, new Vector2(x, y), duration, formula, loopsCount, loopType, direction);
        }

        private static Tween<Vector2, TweakVector2> DoOffsetMax(this RectTransform rectTransform, Vector2 offset, float duration, FormulaBase formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Vector2(rectTransform.gameObject, rectTransform.name, rectTransform.offsetMax, offset, o => rectTransform.offsetMax = o, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoOffsetMinOneAxis
        private static Tween<float, TweakFloat> DoOffsetMinOneAxis(this RectTransform rectTransform, int axis, float offset, float duration, FormulaBase formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(rectTransform.gameObject, rectTransform.name, rectTransform.offsetMin[axis], offset, o => rectTransform.SetOffsetMin(axis, o), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoOffsetMinX(this RectTransform rectTransform, float x, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoOffsetMinOneAxis(rectTransform, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoOffsetMinY(this RectTransform rectTransform, float y, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoOffsetMinOneAxis(rectTransform, 1, y, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        private static void SetOffsetMin(this RectTransform rectTransform, int axis, float offset)
        {
            var offsetMin = rectTransform.offsetMin;
            offsetMin[axis] = offset;
            rectTransform.offsetMin = offsetMin;
        }

        #region DoOffsetMin
        private static Tween<Vector2, TweakVector2> DoOffsetMin(this RectTransform rectTransform, float x, float y, float duration, FormulaBase formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoOffsetMin(rectTransform, new Vector2(x, y), duration, formula, loopsCount, loopType, direction);
        }

        private static Tween<Vector2, TweakVector2> DoOffsetMin(this RectTransform rectTransform, Vector2 offset, float duration, FormulaBase formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Vector2(rectTransform.gameObject, rectTransform.name, rectTransform.offsetMin, offset, o => rectTransform.offsetMin = o, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        private static void SetPivot(this RectTransform rectTransform, int axis, float normalizedPosition)
        {
            var piv = rectTransform.pivot;
            piv[axis] = normalizedPosition;
            rectTransform.pivot = piv;
        }

        #region DoPivotOneAxis
        private static Tween<float, TweakFloat> DoPivotOneAxis(this RectTransform rectTransform, int axis, float normalizedPosition, float duration, FormulaBase formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(rectTransform.gameObject, rectTransform.name, rectTransform.pivot[axis], normalizedPosition, np => rectTransform.SetPivot(axis, np), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPivotX(this RectTransform rectTransform, float x, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPivotOneAxis(rectTransform, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPivotY(this RectTransform rectTransform, float y, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPivotOneAxis(rectTransform, 1, y, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoPivot
        private static Tween<Vector2, TweakVector2> DoPivot(this RectTransform rectTransform, float x, float y, float duration, FormulaBase formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoPivot(rectTransform, new Vector2(x, y), duration, formula, loopsCount, loopType, direction);
        }

        private static Tween<Vector2, TweakVector2> DoPivot(this RectTransform rectTransform, Vector2 normalizedPosition, float duration, FormulaBase formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Vector2(rectTransform.gameObject, rectTransform.name, rectTransform.pivot, normalizedPosition, np => rectTransform.pivot = np, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        private static void SetPivotOnly(this RectTransform rectTransform, int axis, float normalizedPosition)
        {
            var piv = rectTransform.pivot;
            piv[axis] = normalizedPosition;
            rectTransform.SetPivotOnly(piv);
        }

        #region DoPivotOnlyOneAxis
        private static Tween<float, TweakFloat> DoPivotOnlyOneAxis(this RectTransform rectTransform, int axis, float normalizedPosition, float duration, FormulaBase formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(rectTransform.gameObject, rectTransform.name, rectTransform.pivot[axis], normalizedPosition, np => rectTransform.SetPivotOnly(axis, np), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPivotOnlyX(this RectTransform rectTransform, float x, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPivotOnlyOneAxis(rectTransform, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoPivotOnlyY(this RectTransform rectTransform, float y, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoPivotOnlyOneAxis(rectTransform, 1, y, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoPivotOnly
        private static Tween<Vector2, TweakVector2> DoPivotOnly(this RectTransform rectTransform, float x, float y, float duration, FormulaBase formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoPivotOnly(rectTransform, new Vector2(x, y), duration, formula, loopsCount, loopType, direction);
        }

        private static Tween<Vector2, TweakVector2> DoPivotOnly(this RectTransform rectTransform, Vector2 normalizedPosition, float duration, FormulaBase formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Vector2(rectTransform.gameObject, rectTransform.name, rectTransform.pivot, normalizedPosition, np => rectTransform.SetPivotOnly(np), duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        private static void SetSizeDelta(this RectTransform rectTransform, int axis, float size)
        {
            var sizeDelta = rectTransform.sizeDelta;
            sizeDelta[axis] = size;
            rectTransform.sizeDelta = sizeDelta;
        }

        #region DoSizeDeltaOneAxis
        private static Tween<float, TweakFloat> DoSizeDeltaOneAxis(this RectTransform rectTransform, int axis, float size, float duration, FormulaBase formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Float(rectTransform.gameObject, rectTransform.name, rectTransform.sizeDelta[axis], size, s => rectTransform.SetSizeDelta(axis, s), duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoSizeDeltaX(this RectTransform rectTransform, float x, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoSizeDeltaOneAxis(rectTransform, 0, x, duration, formula, loopsCount, loopType, direction);
        }

        public static Tween<float, TweakFloat> DoSizeDeltaY(this RectTransform rectTransform, float y, float duration, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward)
        {
            return DoSizeDeltaOneAxis(rectTransform, 1, y, duration, formula, loopsCount, loopType, direction);
        }
        #endregion

        #region DoSizeDelta
        private static Tween<Vector2, TweakVector2> DoSizeDelta(this RectTransform rectTransform, float x, float y, float duration, FormulaBase formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return DoSizeDelta(rectTransform, new Vector2(x, y), duration, formula, loopsCount, loopType, direction);
        }

        private static Tween<Vector2, TweakVector2> DoSizeDelta(this RectTransform rectTransform, Vector2 size, float duration, FormulaBase formula, int loopsCount, LoopType loopType, Direction direction)
        {
            return Tween.Vector2(rectTransform.gameObject, rectTransform.name, rectTransform.sizeDelta, size, size => rectTransform.sizeDelta = size, duration, formula, loopsCount, loopType, direction);
        }
        #endregion
    }
}