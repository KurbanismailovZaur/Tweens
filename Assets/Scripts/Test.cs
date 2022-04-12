using System.Collections;
using UnityEngine;
using Redcode.Tweens;
using Redcode.Paths;
using Redcode.Extensions;

namespace Tweens
{
    public class Test : MonoBehaviour
	{
        [SerializeField]
        private Transform _target;

        private IEnumerator Start()
        { 
            yield return null;
            transform.DoJump(10f, Vector3.one, 1f).tween.Play();
        }
    }
}