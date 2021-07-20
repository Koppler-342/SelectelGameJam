using System.Collections;
using UnityEngine;
using Utils;

namespace Labirynth.Environment.Compas
{
    public class CompasRotationSquence : MonoBehaviour
    {
        [SerializeField] private float speed = 2f;
        [SerializeField] private float acceleration = 2f;
        [SerializeField] private float slowDownLimit = 0.3f;
        [SerializeField] private float slowDownSpeed = 1f;

        [SerializeField] private float constantDirectionChangeDelay = 6f;
        [SerializeField] private float deltaDelay = 2f;
        
        private int direction;
        private float currentSpeed;
        
        private CompasRotator rotator;

        private void Awake()
        {
            rotator = GetComponent<CompasRotator>();
        }

        private void Start()
        {
            currentSpeed = speed;
            direction = 1;
            QueueChangeDirectionCoroutine();
        }
        
        private void Update()
        {
            rotator.Rotate(currentSpeed * direction);
        }

        private void ChangeDirection()
        {
            StartCoroutine(SlowDown());
        }

        private void QueueChangeDirectionCoroutine()
        {
            float _randomDelay = constantDirectionChangeDelay + RandomFloatInRange.GetRandomFloatInRange(deltaDelay);

            StartCoroutine(QueueDirectionChange(_randomDelay));
        }

        private IEnumerator SlowDown()
        {
            while (currentSpeed > slowDownLimit)
            {
                currentSpeed -= slowDownSpeed * Time.deltaTime;
                yield return null;
            }

            direction *= -1;

            StartCoroutine(SpeedUp());

            QueueChangeDirectionCoroutine();
        }

        private IEnumerator SpeedUp()
        {
            while (currentSpeed < speed)
            {
                currentSpeed += acceleration * Time.deltaTime;
                yield return null;
            }
        }

        private IEnumerator QueueDirectionChange(float _delay)
        {
            yield return new WaitForSeconds(_delay);
            
            ChangeDirection();
        }
    }
}