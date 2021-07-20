using UnityEngine;

namespace Utils
{
    public static class RotationToTarget
    {
        public static Quaternion GetRotationToTarget(Vector2 _from, Vector2 _to)
        {
            Vector2 _delta = _to - _from;
            _delta.Normalize();

            float _angle = Mathf.Atan2(_delta.y, _delta.x) * Mathf.Rad2Deg;
            
            if (_angle < 0)
                _angle += 360;
            
            Quaternion _rotation = Quaternion.Euler(0, 0, _angle);

            return _rotation;
        }
    }
}