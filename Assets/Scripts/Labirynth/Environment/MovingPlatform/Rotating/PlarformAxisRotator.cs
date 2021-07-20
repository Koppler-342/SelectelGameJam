using UnityEngine;

namespace Labirynth.Environment.MovingPlatform.Rotating
{
    public class PlarformAxisRotator : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed = 2f;

        private float currentAngleZ = 0;
        
        private void FixedUpdate()
        {
            currentAngleZ += rotationSpeed * Time.fixedDeltaTime;
            
            Quaternion _newRotation = Quaternion.Euler(0, 0, currentAngleZ);
            transform.rotation = _newRotation;
        }
    }
}