using UnityEngine;

namespace Labirynth.Environment.MovingPlatform.CirclePath
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(CircleCollider2D))]
    public class PlatformCirclePathHandler : MonoBehaviour
    {
        private CircleCollider2D circleCollider;

        public float Radius => circleCollider.radius;
        public Vector2 Centre => transform.position;
        
        private void Awake()
        {
            circleCollider = GetComponent<CircleCollider2D>();
        }
    }
}