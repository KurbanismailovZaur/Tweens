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
            yield return new WaitForSeconds(1f);

            var tween = Tween.Float(0f, 1f, x => _target.SetPositionX(x), 1f, null, 2, LoopType.Mirror);
            
            var sequence = new Sequence(null, 3, LoopType.Continue);
            sequence.Append(tween);
            sequence.Play();
        }
    }
}