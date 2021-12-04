using Extensions;
using Moroutines;
using System.Collections;
using UnityEngine;

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

            var tween = Tween.Float(0f, 10f, _target.SetPositionX, 1f).Play();

            yield return new WaitForSeconds(0.5f);

            tween.TimeType = TimeType.Unscaled;

            yield return new WaitForSecondsRealtime(0.25f);

            tween.TimeType = TimeType.Scaled;

            //_target.DoRotation(Quaternion.LookRotation(Vector3.right, Vector3.back), 1f, Formula.InBounce, 2, LoopType.Continue).SetTweakInterpolationType(InterpolationType.Spherical).Play();
        }
    }
}