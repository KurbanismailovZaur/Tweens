using UnityEngine;

namespace Redcode.Moroutines
{
    internal sealed class MoroutinesExecuter : MonoBehaviour
    {
        internal static MoroutinesExecuter Instance { get; private set; }

        internal Owner Owner { get; private set; }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void CreateInstance()
        {
            Instance = new GameObject("[Redcode] MoroutinesExecuter").AddComponent<MoroutinesExecuter>();
            Instance.Owner = Instance.gameObject.AddComponent<Owner>();

            Instance.gameObject.hideFlags = HideFlags.HideInHierarchy;
            DontDestroyOnLoad(Instance.gameObject);
        }
    }
}