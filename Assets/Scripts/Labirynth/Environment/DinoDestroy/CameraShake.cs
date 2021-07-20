using System.Collections;
using UnityEngine;
using Utils;

namespace Labirynth.Environment.DinoDestroy
{
    public class CameraShake : MonoBehaviour
    {
        [SerializeField] private float radius = 0.2f;
        [SerializeField] private float shakeDuration = 1f;
        
        private bool shake;
        private WaitForSeconds waitForEndOfShke;

        private Vector3 defaultPosition;

        private void Awake()
        {
            defaultPosition = transform.position;
            waitForEndOfShke = new WaitForSeconds(shakeDuration);
        }

        public void BeginShake()
        {
            shake = true;
            StartCoroutine(Shake());
            StartCoroutine(StopShakeOnDelay());
        }

        private void StopShake()
        {
            shake = false;
            ReturnToDefaultPosition();
        }

        private IEnumerator Shake()
        {
            while (shake == true)
            {
                float _shakeX = RandomFloatInRange.GetRandomFloatInRange(radius);
                float _shakeY = RandomFloatInRange.GetRandomFloatInRange(radius);

                Vector3 _newPosition = defaultPosition + new Vector3(_shakeX, _shakeY);
                transform.position = _newPosition;
                
                yield return null;
            }
        }

        private IEnumerator StopShakeOnDelay()
        {
            yield return waitForEndOfShke;
            
            StopShake();
        }

        private void ReturnToDefaultPosition()
        {
            transform.position = defaultPosition;
        }
    }
}