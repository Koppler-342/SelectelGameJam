using UnityEngine;
using UnityEngine.Assertions;
using Utils;

namespace Labirynth.Environment.TriggerPath.Base
{
    [DisallowMultipleComponent]
    public class ColliderTriggerBase : MonoBehaviour
    {
        [SerializeField] private LayerMask layerMask = 0;

       private void Update()
        {
            if (OverlapCheck.CheckCursorOverlapObject(layerMask, transform) == true)
                OnTrigger();
            else
                OnExit();
        }
        
        protected virtual void OnTrigger() {}
        
        protected virtual void OnExit() {}
    }
}