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

        [SerializeField]
        [Range(2, 50)]
        private int _count;

        public int MyProperty { get; set; }

        IEnumerator Start()
        {
            yield return new WaitForSeconds(1f);

            Tween.Shake(null, null, 0, 1f, _count, 0.5f, 0.5f, x => { _target.SetPositionX(x); print($"SETTED TO {x}"); })
                .OnPhaseUpdated(() => print("Updated"))
                .OnCompleted(() => print("Completed"))
                .Play();
        }
    }
}