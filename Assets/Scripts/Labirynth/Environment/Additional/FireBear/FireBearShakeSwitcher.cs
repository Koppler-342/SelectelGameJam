using Labirynth.GameLoop;
using UnityEngine;

namespace Labirynth.Environment.Additional.FireBear
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(FireBearShaker))]
    public class FireBearShakeSwitcher : MonoBehaviour
    {
        private FireBearShaker shaker;

        private void Awake()
        {
            shaker = GetComponent<FireBearShaker>();
        }
        
        private void OnEnable()
        {
            FireBearShakeTrigger.OnShakeTrigger += BeginShake;
            LabirynthGameLoop.OnRestart += StopShake;
        }

        private void OnDisable()
        {
            FireBearShakeTrigger.OnShakeTrigger -= BeginShake;
            LabirynthGameLoop.OnRestart -= StopShake;
        }
        
        private void BeginShake()
        {
            if (LabirynthGameLoop.Alive == false)
                return;
            
            shaker.BeginShake();
        }

        private void StopShake()
        {
            shaker.StopShake();
        }
    }
}