using UnityEngine;
using UnityEngine.Assertions;

namespace Labirynth.Environment.MovingPlatform.CirclePath
{
    [DisallowMultipleComponent]
    public class PlatformCirclePathMover : MonoBehaviour
    {
        [SerializeField] private float speed = 2f;
        
        [SerializeField] private float currentAngle = 0;

        private PlatformCirclePathHandler pathHandler;

        private void Awake()
        {
            pathHandler = GetComponentInParent<PlatformCirclePathHandler>();
            
            Assert.IsNotNull(pathHandler);
        }

        private void FixedUpdate()
        {
            currentAngle += speed * Time.fixedDeltaTime;
 
            Vector2 offset = new Vector2(Mathf.Sin(currentAngle), Mathf.Cos(currentAngle)) * pathHandler.Radius;
            transform.position = pathHandler.Centre + offset;    
        }
    }
}