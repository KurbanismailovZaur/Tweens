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

namespace Tweens
{
    public class Test : MonoBehaviour
    {
        [SerializeField]
        private Transform _target;

        IEnumerator Start()
        {
            var tween = new Tween<float, FloatTweak>(0f, 2f, _target.SetPositionX, 1f, Formula.CircOut, 2, LoopType.Reset, Direction.Backward).Play();
            //yield return new WaitForSeconds(1.5f);
            //tween.LoopDuration = 1f;

            //yield return tween.WaitForComplete();

            yield return new WaitForSeconds(1f);
            tween.PlayForward();
            yield return new WaitForSeconds(1f);
            yield return tween.PlayBackward().WaitForComplete();
            print(1);
        }
    }
}