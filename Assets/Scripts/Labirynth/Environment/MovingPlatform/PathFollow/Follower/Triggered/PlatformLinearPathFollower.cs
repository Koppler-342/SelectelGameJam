using UnityEngine;

namespace Labirynth.Environment.MovingPlatform.PathFollow.Follower.Triggered
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(PlatformPathMover))]
    public class PlatformLinearPathFollower : FollowerBase
    {
        private bool moveToMax;

        private PlatformPathMover pathMover;

        protected override void OnAwake()
        {
            moveToMax = true;
            
            pathMover = GetComponent<PlatformPathMover>();
        }

        protected override void IncreaseIndex()
        {
            if (currentIndex == 0 && moveToMax == false)
            {
                pathMover.StopMovement();
                moveToMax = true;
            }
            
            if (moveToMax == true)
                currentIndex++;
            else
                currentIndex--;

            if (currentIndex == maxIndex)
            {
                moveToMax = false;
                currentIndex--;
            }

            
        }
    }
}