using System;
using System.Collections;
using UnityEngine;
using Utils;

namespace Labirynth.Environment.DinoDestroy
{
    [DisallowMultipleComponent]
    public class DinoCheckScheduler : MonoBehaviour
    {
        [SerializeField] private float constantDelay = 5f;
        [SerializeField] private float randomDelta = 2f;

        public static event Action OnInitCheck;

        private void Awake()
        {
            QueueCheck();
        }

        private void QueueCheck()
        {
            float _randomDelay = constantDelay + RandomFloatInRange.GetRandomFloatInRange(randomDelta);
            StartCoroutine(CheckOnDelay(_randomDelay));
        }

        private IEnumerator CheckOnDelay(float _delay)
        {
            yield return new WaitForSeconds(_delay);
            
            OnInitCheck?.Invoke();

            QueueCheck();
        }
    }
}