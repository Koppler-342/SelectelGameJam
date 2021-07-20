using System;
using Labirynth.GameLoop;
using UnityEngine;

namespace Labirynth.Player.Loop
{
    [DisallowMultipleComponent]
    public class PlayerLoop : MonoBehaviour
    {
        private bool alive = false;
        private bool cheated = false;
        
        private LabirynthGameLoop gameLoop;

        public event Action OnRespawn;
        public event Action OnDeath;

        public bool Alive => alive;

        private void Awake()
        {
            gameLoop = FindObjectOfType<LabirynthGameLoop>();
        }

        private void Start()
        {
            Death();
        }
        
        private void Update()
        {
            if (Input.GetKey(KeyCode.F1) == true)
                cheated = true;
            
            if (Input.GetKey(KeyCode.F2) == true)
               cheated = false;
        }

        public void Respawn()
        {
            alive = true;
            OnRespawn?.Invoke();
        }

        public void Death()
        {
            if (cheated ==  true)
                return;
            
            alive = false;
            gameLoop.Lose();
            OnDeath?.Invoke();
        }
    }
}