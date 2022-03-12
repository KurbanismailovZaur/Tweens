using Redcode.Extensions;
using Redcode.Moroutines;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Tweens
{
    public class Test : MonoBehaviour
    {
        [SerializeField]
        private Transform _target;

        [SerializeField]
        [Range(0f, 90f)]
        private int _x;

        IEnumerator Start()
        {
            print("");
            yield return new WaitForSeconds(1f);

            _target.DoPunchEulerAngles(new Vector3(0f, 90f, 0f), 6).Play();
        }
    }
}