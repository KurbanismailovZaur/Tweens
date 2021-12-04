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
        private Transform _target;

        public int MyProperty { get; set; }

        IEnumerator Start()
        {
            yield return new WaitForSeconds(1f);
            _target.DoPositionX(10f, 2f, Formula.InBounce).Play();

            yield return new WaitForSeconds(0.5f);
            Tween.Time.DoTimeScale(0.25f, 2f).SetTimeType(TimeType.Unscaled).Play();

            //_target.DoRotation(Quaternion.LookRotation(Vector3.right, Vector3.back), 1f, Formula.InBounce, 2, LoopType.Continue).SetTweakInterpolationType(InterpolationType.Spherical).Play();
        }
    }
}