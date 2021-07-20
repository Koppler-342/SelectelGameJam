using UI.MusicButton;
using UnityEngine;
using Utils;

namespace Labirynth.Environment.DinoDestroy
{
    public class DinoSoundsPlayer : MonoBehaviour
    {
        [SerializeField] private AudioClip[] wait = null;
        [SerializeField] private AudioClip[] wake = null;
        [SerializeField] private AudioClip[] smash = null;

        [SerializeField] private AudioSource dinoSource;
        [SerializeField] private AudioSource smashSource;


        public void PlayWaitSound()
        {
            if (AudioStateHandler.instance.PlayMusic == false)
                return;

            dinoSource.clip = RandomAudio.SelectRandomClip(wait);
            dinoSource.Play();
        }

        public void PlayDinoRage()
        {
            if (AudioStateHandler.instance.PlayMusic == false)
                return;
            
            PlayWakeSound();
            PlaySmashSound();
        }
        
        private void PlayWakeSound()
        {
            dinoSource.clip = RandomAudio.SelectRandomClip(wake);
            dinoSource.Play();
        }
        
        private void PlaySmashSound()
        {
            smashSource.clip = RandomAudio.SelectRandomClip(smash);
            smashSource.Play();
        }
    }
}