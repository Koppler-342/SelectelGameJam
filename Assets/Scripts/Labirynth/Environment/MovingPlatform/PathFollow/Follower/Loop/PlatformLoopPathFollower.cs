using UnityEngine;

namespace Labirynth.Environment.MovingPlatform.PathFollow.Follower.Loop
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(PlatformPathMover))]
    public class PlatformLoopPathFollower : FollowerBase
    {
        private PlatformPathMover pathMover;
        
        protected override void OnAwake()
        {
            pathMover = GetComponent<PlatformPathMover>();
            
            pathMover.BeginMovement();
        }

        protected override void IncreaseIndex()
        {
            currentIndex++;

            if (currentIndex == maxIndex)
                currentIndex = 0;
        }
    }
}