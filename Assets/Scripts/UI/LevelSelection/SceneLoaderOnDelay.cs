using System.Collections;
using Labirynth.GameLoop;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.LevelSelection
{
    public class SceneLoaderOnDelay : SceneLoader
    {
        [SerializeField] private float delay = 1f;
        private WaitForSeconds waitForDelay;

        private void Awake()
        {
            waitForDelay = new WaitForSeconds(delay);
        }

        public void LoadSceneOnDelay()
        {
            StartCoroutine(LoadNextScene());
        }

        private IEnumerator LoadNextScene()
        {
            yield return waitForDelay;

            LoadScene();
        }
    }
}