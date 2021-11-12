using Moroutines;
using System.Collections;
using UnityEngine;

namespace Tweens
{
    public class Test : MonoBehaviour
    {
        [SerializeField]
        private Transform _target;

        [SerializeField]
        private Transform _sphere;

        [SerializeField]
        private Transform _target2;

        IEnumerator Start()
        {
            var tween = _target.DoMoveX(3f, 3f, Formula.InBounce, 2, LoopType.Mirror).Play();

            yield return new WaitForSeconds(1f);
            _target.gameObject.SetActive(false);

            yield return new WaitForSeconds(1f);
            _target.gameObject.SetActive(true);
            tween.Play();
        }
    }
}