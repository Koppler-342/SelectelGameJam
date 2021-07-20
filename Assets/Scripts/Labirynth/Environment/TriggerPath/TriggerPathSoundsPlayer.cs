using UI.MusicButton;
using UnityEngine;
using Utils;

namespace Labirynth.Environment.TriggerPath
{
    public class TriggerPathSoundsPlayer : MonoBehaviour
    {
        [SerializeField] private AudioClip[] shadows = new AudioClip[0];
        [SerializeField] private AudioClip[] dragons = new AudioClip[0];

        private AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void PlayShadowSound()
        {
            if (AudioStateHandler.instance.PlayMusic == false || audioSource.isPlaying == true)
                return;

            audioSource.clip = RandomAudio.SelectRandomClip(shadows);
            audioSource.Play();
        }

        public void PlayDragonSound()
        {
            if (AudioStateHandler.instance.PlayMusic == false  || audioSource.isPlaying == true)
                return;
            
            audioSource.clip = RandomAudio.SelectRandomClip(dragons);
            audioSource.Play();
        }
        
        
    }
}