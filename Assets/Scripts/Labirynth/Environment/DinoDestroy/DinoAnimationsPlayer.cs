using UnityEngine;

namespace Labirynth.Environment.DinoDestroy
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Animator))]
    public class DinoAnimationsPlayer : MonoBehaviour
    {
        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            DinoCheckScheduler.OnInitCheck += PlayCheckAnimation;
            DinoPlayerMovementCheck.OnDinoRage += PlayDestroyAnimation;
        }

        private void OnDisable()
        {
            DinoCheckScheduler.OnInitCheck -= PlayCheckAnimation;
            DinoPlayerMovementCheck.OnDinoRage -= PlayDestroyAnimation;
        }

        private void PlayCheckAnimation()
        {
            animator.SetTrigger("Check");
        }

        private void PlayDestroyAnimation()
        {
            animator.SetTrigger("Rage");
        }
    }
}