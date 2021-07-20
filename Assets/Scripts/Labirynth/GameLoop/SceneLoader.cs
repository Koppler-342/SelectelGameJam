using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Labirynth.GameLoop
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private string sceneName;

        public static event Action OnLoadNewLevel;

        public void LoadScene()
        {
            OnLoadNewLevel?.Invoke();
            StartCoroutine(WaitForTransition());
        }

        private IEnumerator WaitForTransition()
        {
            yield return new WaitForSeconds(1);
            SceneManager.LoadSceneAsync(sceneName);
        }
    }
}