using UnityEngine;

namespace Utils
{
    public static class OverlapCheck
    {
        private static Collider2D[] result = new Collider2D[1];
        
        public static bool CheckCursorOverlapLayer(LayerMask _layerMask)
        {
            Vector2 _checkPosition = MousePosition.GetWorldPosition();
            result[0] = null;

            int _resultCount = Physics2D.OverlapPointNonAlloc(_checkPosition, result, _layerMask);

            if (_resultCount == 0)
                return false;

            return true;
        }

        public static bool CheckCursorOverlapObject(LayerMask _layerMask, Transform _object)
        {
            Vector2 _checkPosition = MousePosition.GetWorldPosition();
            result[0] = null;

            int _resultCount = Physics2D.OverlapPointNonAlloc(_checkPosition, result, _layerMask);

            if (_resultCount == 0)
                return false;

            if (result[0].transform == _object)
                return true;

            return false;
        }
    }
}