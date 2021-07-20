using UnityEngine;
using UnityEngine.Assertions;

namespace Labirynth.Environment.TriggerPath.Base
{
    public class PathSwitcherTriggerBase : ColliderTriggerBase
    {
        protected GameObject path;

        private void Awake()
        {
            path = FindObjectOfType<SwitchingPathTag>().gameObject;
            
            Assert.IsNotNull(path);
            
            OnAwake();
        }
        
        protected virtual void OnAwake() {}
    }
}