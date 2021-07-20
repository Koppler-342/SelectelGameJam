using UI.MusicButton;
using UnityEngine;

namespace Labirynth.Environment.Face
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(AudioSource))]
    public class FaceSoundsPlayer : MonoBehaviour
    {
        [SerializeField] private AudioClip shake = null;
        [SerializeField] private AudioClip flash = null;
        [SerializeField] private AudioClip shakeCentre = null;

        private AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void PlayShakeSound()
        {
            if (AudioStateHandler.instance.PlayMusic == false)
                return;

            audioSource.clip = shake;
            audioSource.Play();
        }
        
        public void PlayFlashSound()
        {
            if (AudioStateHandler.instance.PlayMusic == false)
                return;

            audioSource.clip = flash;
            audioSource.Play();
        }
        
        public void PlayShakeCentreSound()
        {
            if (AudioStateHandler.instance.PlayMusic == false)
                return;

            audioSource.clip = shakeCentre;
            audioSource.Play();
        }
    }
}