using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Labirynth.Environment.PakusChallenge.Entity
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Animator))]
    public class PakusBlinkAnimationPlayer : MonoBehaviour
    {
        [SerializeField] private float constantDelay = 5f;
        [SerializeField] private float randomDelta = 2f;

        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        private void Start()
        {
            QueueAnimation();
        }

        private void QueueAnimation()
        {
            float _randomDelay = constantDelay + Random.Range(-randomDelta, randomDelta);

            StartCoroutine(PlayAnimationOnDelay(_randomDelay));
        }

        private IEnumerator PlayAnimationOnDelay(float _delay)
        {
            yield return new WaitForSeconds(_delay);
            
            animator.SetTrigger("Blink");
            
            QueueAnimation();
        }
    }
}