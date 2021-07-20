using UnityEngine;

namespace UI.MusicButton
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(AudioSource))]
    public class AudioPlayer : MonoBehaviour
    {
        [SerializeField] private AudioClip clip = null;

        private AudioSource source;

        private void Awake()
        {
            source = GetComponent<AudioSource>();

            if (AudioStateHandler.instance.PlayMusic == false)
                DisableSource();

            source.clip = clip;
            source.Play();
            source.loop = true;
            source.volume = 0.25f;
        }

        private void OnEnable()
        {
            AudioStateHandler.instance.OnMusicEnabled += EnableSource;
            AudioStateHandler.instance.OnMusicDisabled += DisableSource;
        }

        private void OnDisable()
        {
            AudioStateHandler.instance.OnMusicEnabled -= EnableSource;
            AudioStateHandler.instance.OnMusicDisabled -= DisableSource;
        }

        private void DisableSource()
        {
            source.volume = 0;
        }

        private void EnableSource()
        {
            source.volume = 0.25f;
        }
    }
}