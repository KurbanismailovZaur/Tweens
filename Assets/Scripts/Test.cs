using Redcode.Paths;
using System.Collections;
using UnityEngine;

namespace Redcode.Tweens
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

            yield return _target.DoMoveAlongPath(_path, 1f).SetLoopCount(int.MaxValue).SetLoopType(LoopType.Continue).Play().WaitForComplete();

            print("Completed");
        }
    }
}