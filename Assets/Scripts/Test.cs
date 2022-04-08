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

        private void Start()
        {
            var sequence = new Sequence();
            sequence.Append(_target.DoPositionX(1f, 1f));
            sequence.Append(_target.DoPositionX(2f, 1f));
            sequence.Play();
        }
    }
}