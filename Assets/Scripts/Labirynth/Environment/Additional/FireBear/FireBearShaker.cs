using System.Collections;
using UnityEngine;
using Utils;

namespace Labirynth.Environment.Additional.FireBear
{
    public class FireBearShaker : MonoBehaviour
    {
        [SerializeField] private float radius = 0.2f;
        
        private bool shake;

        private Vector3 defaultPosition;

        private void Awake()
        {
            defaultPosition = transform.position;
        }

        public void BeginShake()
        {
            shake = true;
            StartCoroutine(Shake());
        }

        public void StopShake()
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

        private void ReturnToDefaultPosition()
        {
            transform.position = defaultPosition;
        }
    }
}