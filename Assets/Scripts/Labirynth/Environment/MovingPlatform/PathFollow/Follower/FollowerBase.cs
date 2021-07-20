using UnityEngine;
using UnityEngine.Assertions;

namespace Labirynth.Environment.MovingPlatform.PathFollow.Follower
{
    public class FollowerBase : MonoBehaviour
    {
        private PlatformPathHandler pathHandler;
        
        protected int currentIndex;
        protected int maxIndex;

        public Vector2 CurrentTarget => (pathHandler.Path[currentIndex] + (Vector2)pathHandler.transform.position);
        
        private void Awake()
        {
            pathHandler = GetComponentInParent<PlatformPathHandler>();            
            
            Assert.IsNotNull(pathHandler);
            
            OnAwake();
        }

        private void Start()
        {
            currentIndex = 0;
            maxIndex = pathHandler.Path.Length;
        }
        
        private void Update()
        {
            if (PlatformPathDestinationChecker.Checkdestination(
                transform.position, CurrentTarget) == true)
                IncreaseIndex();
        }
        
        protected virtual void IncreaseIndex() {}
        
        protected virtual void OnAwake() {}
    }
}