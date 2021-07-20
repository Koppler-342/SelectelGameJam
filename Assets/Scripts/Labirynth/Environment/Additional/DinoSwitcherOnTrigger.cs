using Labirynth.Environment.TriggerPath.Base;
using Labirynth.GameLoop;
using UI.MusicButton;
using UnityEngine;

namespace Labirynth.Environment.Additional
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(AudioSource))]
    public class DinoSwitcherOnTrigger : ColliderTriggerBase
    {
        [SerializeField] private Sprite normal = null;
        [SerializeField] private Sprite attack = null;

        [SerializeField] private AudioClip[] clips;
        
        private SpriteRenderer spriteRenderer;
        private AudioSource audioSource;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            audioSource = GetComponent<AudioSource>();
        }

        protected override void OnTrigger()
        {
            spriteRenderer.sprite = attack;
            
            PlaySound();
        }

        protected override void OnExit()
        {
            spriteRenderer.sprite = normal;
        }

        private void PlaySound()
        {
            if (audioSource.isPlaying == true || LabirynthGameLoop.Alive == false)
                return;

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