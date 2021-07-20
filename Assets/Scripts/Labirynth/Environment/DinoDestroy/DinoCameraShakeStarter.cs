using UnityEngine;

namespace Labirynth.Environment.DinoDestroy
{
    public class DinoCameraShakeStarter : MonoBehaviour
    {
        private CameraShake cameraShake;
        
        private void Awake()
        {
            cameraShake = FindObjectOfType<CameraShake>();
        }

        private void OnEnable()
        {
            DinoPlayerMovementCheck.OnDinoRage += StartShake;
        }

        private void OnDisable()
        {
            DinoPlayerMovementCheck.OnDinoRage -= StartShake;
        }

        private void StartShake()
        {
            cameraShake.BeginShake();
        }
    }
}