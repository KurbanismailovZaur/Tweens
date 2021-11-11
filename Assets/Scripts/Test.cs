using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Extensions;
using Coroutines;
using Coroutines.Extensions;
using Object = UnityEngine.Object;
using Coroutine = Coroutines.Coroutine;
using Tweens.Tweaks;
using Tweens;
using Tweens.Formulas;

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

            Coroutine.Run(Routines.Delay(5f, () => tween.Play()));
        }
    }
}