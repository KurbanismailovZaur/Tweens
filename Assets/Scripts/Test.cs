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
        [ContextMenuItem("Evaluate", "Evaluate")]
        [SerializeField]
        [Range(0f, 3f)]
        private float _interpolation;

        private Tween<float, TweakFloat> _tween;

        private void Start()
        {
            _tween = Tween.Float(0f, 1f, v => { }, 0f, null, 3, LoopType.Mirror);
        }

        public void Evaluate()
        {
            print(_tween.Evaluate(_interpolation));
        }
    }
}