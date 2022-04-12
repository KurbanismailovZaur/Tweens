using System.Collections;
using TMPro;
using UnityEngine;
using Redcode.Extensions;
using UnityEngine.UI;
using System;
using Redcode.Tweens.Tweaks;

namespace Redcode.Tweens
{
    public class FPSTest : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _framesText;

        private int _frames;

        [SerializeField]
        private TMP_InputField _countField;

        [SerializeField]
        private TextMeshProUGUI _statusText;

        private IEnumerator Start()
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                Application.targetFrameRate = 10000;
            }

            while (true)
            {
                yield return new WaitForSeconds(1f);
                _framesText.text = _frames.ToString();
                _frames = 0;
            }
        }

        private void Update() => _frames++;

        public void TestTweens() => StartCoroutine(TestTweensEnumerator());

        private IEnumerator TestTweensEnumerator()
        {
            var count = Convert.ToInt32(_countField.text);
            _statusText.text = "Tweens creating started!";

            var tweens = new Playable[count];
            for (int i = 0; i < tweens.Length; i++)
                tweens[i] = Tween.Float(0f, 1f, x => { }, 5f).Play();

            _statusText.text = "Tweens playing started!";
            yield return tweens[0].WaitForComplete();
            _statusText.text = "Tweens playing completed!";
        }        
    }
}