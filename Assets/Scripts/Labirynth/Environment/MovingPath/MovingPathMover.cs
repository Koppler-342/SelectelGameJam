using System.Collections;
using Labirynth.GameLoop;
using UnityEngine;

namespace Labirynth.Environment.MovingPath
{
    public class MovingPathMover : MonoBehaviour
    {
        [SerializeField] private float speed = 1f;
        [SerializeField] private Transform endPoint = null;
        
        private void OnEnable()
        {
            LabirynthGameLoop.OnStart += BeginMovement;
            LabirynthGameLoop.OnRestart += Stop;
        }

        private void OnDisable()
        {
            LabirynthGameLoop.OnStart -= BeginMovement;
            LabirynthGameLoop.OnRestart -= Stop;
        }

        private void BeginMovement()
        {
            StartCoroutine(Move());
        }

        private void Stop()
        {
            StopAllCoroutines();
        }

        private IEnumerator Move()
        {
            while (transform.position.y > endPoint.position.y)
            {
                Vector3 _move = Vector2.down * speed * Time.deltaTime;
                transform.position += _move;
                yield return null;
            }
        }
    }
}