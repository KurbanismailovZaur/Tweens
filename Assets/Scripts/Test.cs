using Moroutines;
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

        void Start()
        {
            var tween = _target.DoMoveX(3f, 3f, Formula.InBounce, 2, LoopType.Mirror).Play();

            Moroutine.Run(Routines.Delay(5f, () => tween.Play()));
        }
    }
}