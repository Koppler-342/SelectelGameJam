using Labirynth.Player.Loop;
using UnityEngine;
using UnityEngine.Assertions;

namespace Labirynth.Player.Base
{
    public class PlayerBehaviour : MonoBehaviour
    {
        protected PlayerLoop playerLoop;

        protected bool alive => playerLoop.Alive;

        private void Awake()
        {
            playerLoop = GetComponentInParent<PlayerLoop>();
            
            Assert.IsNotNull(playerLoop);
            
            OnAwake();
        }

        private void OnEnable()
        {
            playerLoop.OnRespawn += OnRespawn;
            playerLoop.OnDeath += OnDeath;
            
            OnPlayerEnable();
        }

        private void OnDisable()
        {
            playerLoop.OnRespawn -= OnRespawn;
            playerLoop.OnDeath -= OnDeath;
            
            OnPlayerDisable();
        }
        
        protected virtual void OnAwake() {}
        
        protected virtual void OnDeath() {}
        
        protected virtual void OnRespawn() {}
        
        protected virtual void OnPlayerEnable() {}
        
        protected virtual void OnPlayerDisable() {}
    }
}