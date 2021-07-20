using UI.MusicButton;
using UnityEngine;

namespace Labirynth.Player.Appearence.Effects
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(AudioSource))]
    public class PlayerDeathSoundsPlayer : MonoBehaviour
    {
        [SerializeField] private AudioClip[] clips;
        
        private AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void PlaySounds()
        {
            audioSource.clip = SelectRandomClip();
            
            if (AudioStateHandler.instance.PlayMusic == false)
                return;
            
            audioSource.Play();
        }
        
        private AudioClip SelectRandomClip()
        {
            int _randomIndex = Random.Range(0, clips.Length);

            return clips[_randomIndex];
        }
    }
}