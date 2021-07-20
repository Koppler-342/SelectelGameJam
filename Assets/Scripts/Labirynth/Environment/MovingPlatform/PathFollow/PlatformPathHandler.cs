using UnityEngine;

namespace Labirynth.Environment.MovingPlatform.PathFollow
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(EdgeCollider2D))]
    public class PlatformPathHandler : MonoBehaviour
    {
        private EdgeCollider2D edgeCollider;
        
        public Vector2[] Path => edgeCollider.points;

        private void Awake()
        {
            edgeCollider = GetComponent<EdgeCollider2D>();
        }
    }
}