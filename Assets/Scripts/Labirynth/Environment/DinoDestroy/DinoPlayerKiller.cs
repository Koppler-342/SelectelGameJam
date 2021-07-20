using Labirynth.Player.Loop;
using UnityEngine;
using UnityEngine.Assertions;

namespace Labirynth.Environment.DinoDestroy
{
    public class DinoPlayerKiller : MonoBehaviour
    {
        private PlayerLoop playerLoop;
        
        private void Awake()
        {
            playerLoop = FindObjectOfType<PlayerLoop>();

            Assert.IsNotNull(playerLoop);
        }

        private void OnEnable()
        {
            DinoPlayerMovementCheck.OnDinoRage += KillPlayer;
        }

        private void OnDisable()
        {
            DinoPlayerMovementCheck.OnDinoRage -= KillPlayer;
        }

        private void KillPlayer()
        {
            playerLoop.Death();   
        }
    }
}