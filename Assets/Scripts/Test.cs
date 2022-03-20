using Redcode.Paths;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Redcode.Tweens
{
    public class Test : MonoBehaviour
    {
        private int _lineIndex = 1;

        [SerializeField]
        private Transform _linePoints;

        [SerializeField]
        private float _animationDuration;

        private Playable _animation;

        private void HandleInput(KeyCode key, int direction)
        {
            if (Input.GetKeyDown(key) && (_animation?.IsCompleted ?? true))
            {
                _lineIndex = Mathf.Clamp(_lineIndex + direction, 0, _linePoints.childCount - 1);
                var point = _linePoints.GetChild(_lineIndex);
                _animation = transform.DoPositionX(point.position.x, _animationDuration, Ease.InOutCirc).Play();
            }
        }

        private void Update()
        {
            HandleInput(KeyCode.A, -1);
            HandleInput(KeyCode.D, 1);

            print(_animation.IsCompleted);
        }
    }
}