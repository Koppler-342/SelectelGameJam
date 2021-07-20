using UnityEngine;

namespace Utils
{
    public static class RotationToMouse
    {
        private static Camera camera = Camera.main;

        public static float GetNonNormalizedRotationToMouse(Vector2 _position)
        {
            if (camera == null)
                camera = Camera.main;
            
            Vector2 _mousePosition = MousePosition.GetWorldPosition();

            Vector2 _delta = _mousePosition - _position;
            _delta.Normalize();

            float _angle = Mathf.Atan2(_delta.y, _delta.x) * Mathf.Rad2Deg;

            return _angle;
        }
        
        public static float GetNormalizedRotationToMouse(Vector2 _position)
        {
            float _angle = GetNonNormalizedRotationToMouse(_position);

            if (_angle < 0)
                _angle += 360;
            
            return _angle;
        }
    }
}