using UnityEngine;

namespace Utils
{
    public static class RandomAudio
    {
        public static AudioClip SelectRandomClip(AudioClip[] _clips)
        {
            int _randomIndex = Random.Range(0, _clips.Length);

            return _clips[_randomIndex];
        }
    }
}