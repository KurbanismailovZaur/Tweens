using Redcode.Extensions;
using Redcode.Moroutines;
using Redcode.Paths;
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
        private Path _path;

        IEnumerator Start()
        {
            yield return new WaitForSeconds(1f);

            yield return _target.DoMoveByPath(_path, 8f, Redcode.Tweens.Extensions.PathFollowOptions.UsePointRotation).SetFormula(Formula.InBounce).Repeat().WaitForStop();
            print("Completed");
        }
    }
}