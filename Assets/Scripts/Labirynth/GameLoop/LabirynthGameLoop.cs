using System;
using Labirynth.Player.Loop;
using UI;
using UI.LevelSelection;
using UnityEngine;
using UnityEngine.Assertions;

namespace Labirynth.GameLoop
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(SceneLoader))]
    public class LabirynthGameLoop : MonoBehaviour
    {
        private PlayerLoop playerLoop;
        private SceneLoader sceneLoader;

        private bool gameEnd;

        public static event Action OnRestart;
        public static event Action OnWin;
        public static event Action OnStart;

        public static bool Alive
        {
            private set;
            get;
        }

        private void Awake()
        {
            playerLoop = FindObjectOfType<PlayerLoop>();
            sceneLoader = GetComponent<SceneLoader>();
            
            Assert.IsNotNull(playerLoop);

            gameEnd = false;
        }

        private void OnEnable()
        {
            StartButton.StartButtonClicked += StartGame;
        }

        private void OnDisable()
        {
            StartButton.StartButtonClicked -= StartGame;
        }

        

        private void StartGame()
        {
            playerLoop.Respawn();
            Alive = true;
            OnStart?.Invoke();
        }
        
        public void Lose()
        {
            Debug.Log("lose");
            OnRestart?.Invoke();
            Alive = false;
        }

        public void Win()
        {
            if (gameEnd == true)
                return;

            OnWin?.Invoke();
            
            gameEnd = true;
            
            Debug.Log("Win");
            
            sceneLoader.LoadScene();
        }
    }
}