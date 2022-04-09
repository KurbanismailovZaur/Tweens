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
            var tween = _target.DoPositionX(1f, 10f).Play();
            
            yield return new WaitForSeconds(2f);
            tween.SetOwner(this);
            print("THIS");

            yield return new WaitForSeconds(2f);
            tween.SetOwner(_target);
            print("TARGET");

            yield return new WaitForSeconds(2f);
            tween.MakeUnowned();
            print("NULL");
        }
    }
}