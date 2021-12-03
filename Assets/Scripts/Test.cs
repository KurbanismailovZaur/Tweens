using Extensions;
using Moroutines;
using System.Collections;
using UnityEngine;

namespace Tweens
{
    public class Test : MonoBehaviour
    {
        [SerializeField]
        private Camera _target;

        public int MyProperty { get; set; }

        IEnumerator Start()
        {
            yield return new WaitForSeconds(1f);
            
            //_target.DoRotation(Quaternion.LookRotation(Vector3.right, Vector3.back), 1f, Formula.InBounce, 2, LoopType.Continue).SetTweakInterpolationType(InterpolationType.Spherical).Play();
        }
    }
}