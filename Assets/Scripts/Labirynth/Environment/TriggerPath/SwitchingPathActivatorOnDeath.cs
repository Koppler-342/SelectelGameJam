using Labirynth.Environment.TriggerPath.Base;
using Labirynth.GameLoop;
using UnityEngine;
using UnityEngine.Assertions;

namespace Labirynth.Environment.TriggerPath
{
    public class SwitchingPathActivatorOnDeath : MonoBehaviour
    {
        protected GameObject path;

        private void Awake()
        {
            path = FindObjectOfType<SwitchingPathTag>().gameObject;
            
            Assert.IsNotNull(path);
        }

        private void OnEnable()
        {
            LabirynthGameLoop.OnRestart += ActivatePath;
        }

        private void OnDisable()
        {
            LabirynthGameLoop.OnRestart -= ActivatePath;
        }
        
        private void ActivatePath()
        {
            path.SetActive(true);
        }
    }
}