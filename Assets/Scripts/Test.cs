using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Redcode.Extensions;
using Redcode.Moroutines;
using Redcode.Moroutines.Extensions;
using Redcode.Tweens;
using Redcode.Tweens.Extensions;
using Redcode.Tweens.Tweaks;

namespace Tweens
{
	public class Test : MonoBehaviour
	{
        [SerializeField]
        private Transform _target;

        private IEnumerator Start()
        { 
            yield return null;

            var tween = Tween.Float(0f, 1f, _target.SetPositionX, 1f);
            tween.SkipToEnd().PlayBackward();
        }
    }
}