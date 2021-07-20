using System;
using UnityEngine;

namespace UI.MusicButton
{
    public class AudioStateHandler : MonoBehaviour
    {
        public static AudioStateHandler instance = null;

        private bool playMusic;

        public bool PlayMusic => playMusic;

        public event Action OnMusicDisabled;
        public  event Action OnMusicEnabled;
        
        private void Awake() 
        {
            if (instance == null)
                instance = this; 
            else if (instance == this)
                Destroy(gameObject); 
            
            DontDestroyOnLoad(gameObject);
            
            EnableMusic();
        }

        public void EnableMusic()
        {
            playMusic = true;
            OnMusicEnabled?.Invoke();
        }

        public void DisableMusic()
        {
            playMusic = false;
            OnMusicDisabled?.Invoke();
        }
    }
}