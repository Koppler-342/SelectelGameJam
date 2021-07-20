using System.Collections;
using Labirynth.GameLoop;
using UnityEngine;

namespace Cutscenes
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(SceneLoader))]
    public class CutsceneEndChecker : MonoBehaviour
    {
        [SerializeField] private float delay;
        
        private SceneLoader sceneLoader;

        private WaitForSeconds waitForSeconds;
        
        private void Awake()
        {
            sceneLoader = GetComponent<SceneLoader>();
            
            waitForSeconds = new WaitForSeconds(delay);
        }

        private void Start()
        {
            StartCoroutine(LoadNextSceneOnDelay());
        }

        private IEnumerator LoadNextSceneOnDelay()
        {
            yield return waitForSeconds;
            
            sceneLoader.LoadScene();
        }
    }
}