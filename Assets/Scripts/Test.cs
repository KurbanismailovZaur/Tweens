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

            _target.DoMoveAlongPath(Path.Create(), 8f, Redcode.Tweens.Extensions.PathFollowOptions.UsePathDirection).Play().OnCompleted(() => Destroy(_path.gameObject));
            print("Completed");
        }
    }
}