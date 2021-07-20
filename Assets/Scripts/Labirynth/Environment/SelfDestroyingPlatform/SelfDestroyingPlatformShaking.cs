using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;
using Utils;

namespace Labirynth.Environment.SelfDestroyingPlatform
{
    [DisallowMultipleComponent]
    public class SelfDestroyingPlatformShaking : MonoBehaviour
    {
        [SerializeField] private float radius = 0.2f;
        [SerializeField] private float shakingDelay = 0.3f;
        
        private SelfDestroyingPlatformSwitcher switcher;

        private Coroutine shakeCoroutine;
        private WaitForSeconds waitToShake;

        private bool shake;

        private Vector2 defaultPosition;

        private void Awake()
        {
            switcher = GetComponentInParent<SelfDestroyingPlatformSwitcher>();
            
            Assert.IsNotNull(switcher);

            defaultPosition = transform.position;
            waitToShake = new WaitForSeconds(shakingDelay);
        }

        private void OnEnable()
        {
            switcher.OnDisablingBegun += BeginShake;
            switcher.OnPlatformDisabled += StopShake;
        }

        private void OnDisable()
        {
            switcher.OnDisablingBegun -= BeginShake;
            switcher.OnPlatformDisabled -= StopShake;
        }

        private void BeginShake()
        {
            StartCoroutine(BeginShakeOnDelay());
        }

        private void StopShake()
        {
            shake = false;
            StopCoroutine(shakeCoroutine);
            ReturnToDefaultPosition();
        }

        private IEnumerator BeginShakeOnDelay()
        {
            yield return waitToShake;
            shake = true;
            shakeCoroutine = StartCoroutine(Shake());
        }

        private IEnumerator Shake()
        {
            while (shake == true)
            {
                float _shakeX = RandomFloatInRange.GetRandomFloatInRange(radius);
                float _shakeY = RandomFloatInRange.GetRandomFloatInRange(radius);

                Vector2 _newPosition = defaultPosition + new Vector2(_shakeX, _shakeY);
                transform.position = _newPosition;
                
                yield return null;
            }
        }

        private void ReturnToDefaultPosition()
        {
            transform.position = defaultPosition;
        }
    }
}