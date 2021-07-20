using UnityEngine;
using UnityEngine.Assertions;

namespace Labirynth.Environment.MovingPlatform.PathFollow
{
    [DisallowMultipleComponent]
    public class PlatformPathStarter : MonoBehaviour
    {
        private void Awake()
        {
            EdgeCollider2D _edgeCollider = GetComponentInParent<EdgeCollider2D>();

            Assert.IsNotNull(_edgeCollider);
            
            transform.position = transform.position + (Vector3)_edgeCollider.points[0];
        }
    }
}