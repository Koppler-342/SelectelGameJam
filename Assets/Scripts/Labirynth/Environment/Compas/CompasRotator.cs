using UnityEngine;

namespace Labirynth.Environment.Compas
{
    public class CompasRotator : MonoBehaviour
    {
        private float currentAngle;

        private void Start()
        {
            currentAngle = transform.rotation.z;
        }
        
        public void Rotate(float _speed)
        {
            currentAngle += _speed * Time.deltaTime;
            
            Quaternion _rotation = Quaternion.Euler(0, 0, currentAngle);

            transform.rotation = _rotation;
        }
    }
}