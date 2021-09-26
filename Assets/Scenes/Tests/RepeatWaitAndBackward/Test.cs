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

namespace Tweens.Scenes.Tests.RepeatWaitAndBackward
{
    public class Test : MonoBehaviour
    {
        [SerializeField]
        private Transform _target;

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(1f);

            var repeater = ((Playable)new Tween<float, FloatTweak>("Slide", 0f, 1f, _target.SetPositionX, 1f)).Repeat();
            Coroutine.Run(Routines.Delay(1.5f, () => repeater.Stop()));

            yield return repeater.WaitForStop();
            yield return new WaitForSeconds(1f);

            repeater.PlayBackward();
        }
    }
}