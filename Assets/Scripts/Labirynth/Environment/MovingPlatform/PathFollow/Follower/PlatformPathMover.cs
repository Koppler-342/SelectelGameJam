using Labirynth.Environment.MovingPlatform.PathFollow.Follower.Loop;
using UnityEngine;

namespace Labirynth.Environment.MovingPlatform.PathFollow.Follower
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(FollowerBase))]
    public class PlatformPathMover : MonoBehaviour
    {
        [SerializeField] private float speed = 1f;

        private bool move = false;
        
        private FollowerBase pathFollower;

        private void Awake()
        {
            pathFollower = GetComponent<FollowerBase>();
        }

        private void FixedUpdate()
        {
            if (move == false)
                return;
            
            Vector2 _moveDelta = Vector2.MoveTowards(
                    transform.position,
                    pathFollower.CurrentTarget,
                    speed * Time.fixedDeltaTime);

            transform.position = _moveDelta;
        }

        public void BeginMovement()
        {
            move = true;
        }

        public void StopMovement()
        {
            move = false;
        }
    }
}