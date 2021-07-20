using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Labirynth.Environment.Face
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Animator))]
    public class FaceAnimationPlayer : MonoBehaviour
    {
        [SerializeField] private float constantDelay = 8f;
        [SerializeField] private float randomizedDeltaBound = 3f;

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
            float _delay = constantDelay + Random.Range(-randomizedDeltaBound, randomizedDeltaBound);

            StartCoroutine(PlayAnimationOnDelay(_delay));
        }

        private IEnumerator PlayAnimationOnDelay(float _delay)
        {
            yield return new WaitForSeconds(_delay);
            
            animator.SetTrigger("Rage");
            
            QueueAnimation();
        }
    }
}