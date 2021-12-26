using Extensions;
using Moroutines;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Tweens
{
    public class Test : MonoBehaviour
    {
        [SerializeField]
        private RectTransform _target;

        [SerializeField]
        [Range(0f, 90f)]
        private int _x;


        IEnumerator Start()
        {
            yield return new WaitForSeconds(1f);

            _target.DoPunchAnchoredPosition(Vector2.one * 100).Play();
        }
    }
}