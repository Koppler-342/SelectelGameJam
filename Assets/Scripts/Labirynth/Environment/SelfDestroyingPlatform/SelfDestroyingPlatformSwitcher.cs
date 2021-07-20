using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;

namespace Labirynth.Environment.SelfDestroyingPlatform
{
    [DisallowMultipleComponent]
    public class SelfDestroyingPlatformSwitcher : MonoBehaviour
    {
        [SerializeField] private float enableDelay = 2f;
        [SerializeField] private float disableDelay = 2f;
        
        private GameObject path;

        private bool disabling;

        private WaitForSeconds waitToEnable;
        private WaitForSeconds waitToDisable; 
        
        public event Action OnDisablingBegun;
        public event Action OnPlatformDisabled;

        private void Awake()
        {
            path = GetComponentInChildren<SelfDestroyingPlatformPathTag>().gameObject;
            
            Assert.IsNotNull(path);

            disabling = false;

            waitToEnable = new WaitForSeconds(enableDelay);
            waitToDisable = new WaitForSeconds(disableDelay);
        }
        
        public void BeginDisabling()
        {
            if (disabling == true)
                return;

            disabling = true;
            
            OnDisablingBegun?.Invoke();

            StartCoroutine(DisableOnDelay());
        }

        private void Disable()
        {
            OnPlatformDisabled?.Invoke();
            
            path.SetActive(false);
            
            disabling = false;

            StartCoroutine(EnableOnDelay());
        }

        private void Enable()
        {
            path.SetActive(true);
        }

        private IEnumerator EnableOnDelay()
        {
            yield return waitToEnable;
            
            Enable();
        }

        private IEnumerator DisableOnDelay()
        {
            yield return waitToDisable;
            
            Disable();
        }
    }
}