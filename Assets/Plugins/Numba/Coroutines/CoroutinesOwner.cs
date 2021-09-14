using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using NativeCoroutine = UnityEngine.Coroutine;

namespace Coroutines
{
    internal sealed class CoroutinesOwner : MonoBehaviour
    {
        internal static CoroutinesOwner Instance { get; private set; }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void CreateInstance()
        {
            Instance = new GameObject("CoroutinesOwner (Coroutines)").AddComponent<CoroutinesOwner>();
            Instance.gameObject.hideFlags = HideFlags.HideInHierarchy;

            DontDestroyOnLoad(Instance.gameObject);
        }
    }
}