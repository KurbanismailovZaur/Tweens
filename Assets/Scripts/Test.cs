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

            yield return _target.DoJump(2f, new Vector3(0f, 5f, 3f), 0.7f).tween.SetLoopCount(int.MaxValue).SetLoopType(LoopType.Mirror).Play().WaitForComplete();

            print("Completed");
        }
    }
}