using Labirynth.GameLoop;
using UnityEngine;

namespace Labirynth.Environment.MovingPath
{
    public class MovingPathDefaultPositionSetter : MonoBehaviour
    {
        private Vector2 defaultPosition;

        private void Awake()
        {
            defaultPosition = transform.position;
        }

        private void OnEnable()
        {
            LabirynthGameLoop.OnRestart += MoveToDefaultPosition;
        }

        private void OnDisable()
        {
            LabirynthGameLoop.OnRestart -= MoveToDefaultPosition;
        }
        
        private void MoveToDefaultPosition()
        {
            transform.position = defaultPosition;
        }
    }
}