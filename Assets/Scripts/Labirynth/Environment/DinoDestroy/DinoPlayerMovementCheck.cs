using System;
using System.Collections;
using Labirynth.GameLoop;
using UnityEngine;
using UnityEngine.Assertions;
using Utils;

namespace Labirynth.Environment.DinoDestroy
{
    [DisallowMultipleComponent]
    public class DinoPlayerMovementCheck : MonoBehaviour
    {
        [SerializeField] private float allowableDistance = 0.01f;
        [SerializeField] private float checkTime = 1f;

        private bool check;
        private WaitForSeconds waitForEndOfCheck;
        private DinoDeathZoneCheck deathZoneCheck;
        
        private Vector2 previousPosition;

        public static event Action OnDinoRage;

        private void Awake()
        {
            waitForEndOfCheck = new WaitForSeconds(checkTime);

            deathZoneCheck = FindObjectOfType<DinoDeathZoneCheck>();
            
            Assert.IsNotNull(deathZoneCheck);
        }

        private void OnEnable()
        {
            DinoAnimationEventsHandler.OnCheck += StartCheck;
        }

        private void OnDisable()
        {
            DinoAnimationEventsHandler.OnCheck -= StartCheck;
        }
        
        private void StartCheck()
        {
            if (deathZoneCheck.CheckPlayerInDeathZone() == false || LabirynthGameLoop.Alive == false)
                return;
                        
            check = true;
            previousPosition = MousePosition.GetWorldPosition();
            StartCoroutine(CheckMovement());
            StartCoroutine(DisableCheckOnDelay());
        }

        private void StopCheck()
        {
            check = false;
        }

        private IEnumerator CheckMovement()
        {
            while (check)
            {
                if (CheckLongMove(previousPosition) == true)
                    ActivateRage();                    
                
                yield return null;
            }
        }

        private IEnumerator DisableCheckOnDelay()
        {
            yield return waitForEndOfCheck;
            
            StopCheck();
        }

        private void ActivateRage()
        {
            StopCheck();
            OnDinoRage?.Invoke();
        }

        private bool CheckLongMove(Vector2 _previousPosition)
        {
            Vector2 _mousePosition = MousePosition.GetWorldPosition();

            float _distance = Vector2.Distance(_previousPosition,_mousePosition);

            if (_distance > allowableDistance)
                return true;
            
            return false;
        }
    }
}