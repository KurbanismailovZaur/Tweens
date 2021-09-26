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

namespace Tweens.Scenes.Tests.LoopTypeContinueWaitForPlay
{
	public class Test : MonoBehaviour
	{
        [SerializeField]
        private Transform _target;

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(1f);

            var tween =  new Tween<float, FloatTweak>(0f, 1f, _target.SetPositionX, 1f, Formula.CircOut, 2, LoopType.Continue);
            Coroutine.Run(Routines.Delay(1f, () => tween.Play()));
            
            yield return tween.WaitForPlay();
            print("Awaited");
        }
    }
}