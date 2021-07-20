using UnityEngine;

namespace Utils
{
    public static class MousePosition
    {
        private static Camera camera = Camera.main;
    
        public static Vector2 GetWorldPosition()
        {
            Vector2 _mousePosition = Input.mousePosition;
            
            if (camera == null)
                camera = Camera.main;

            Vector2 _worldPosition = camera.ScreenToWorldPoint(_mousePosition);

            return _worldPosition;
        }
    }
}