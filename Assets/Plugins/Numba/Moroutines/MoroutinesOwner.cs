using UnityEngine;


namespace Moroutines
{
    internal sealed class MoroutinesOwner : MonoBehaviour
    {
        internal static MoroutinesOwner Instance { get; private set; }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void CreateInstance()
        {
            Instance = new GameObject("CoroutinesOwner (Coroutines)").AddComponent<MoroutinesOwner>();
            Instance.gameObject.hideFlags = HideFlags.HideInHierarchy;

            DontDestroyOnLoad(Instance.gameObject);
        }
    }
}