using Redcode.Paths;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Redcode.Tweens
{
    public class Test : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _text;

        private Material _material;

        [SerializeField]
        private float _softness;

        private void Start() => _material = _text.material;

        private void Update()
        {
            _material.SetFloat("_OutlineSoftness", _softness); 
        }
    }
}