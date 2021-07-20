using UnityEngine;

namespace Utils
{
    public static class VectorComparer
    {
        public static bool CheckVectorEquivalent(Vector2 _a, Vector2 _b)
        {
            if (CheckFloatEquivalent(_a.x, _b.x) == false)
                return false;
            
            if (CheckFloatEquivalent(_a.y, _b.y) == false)
                return false;

            return true;
        }

        private static bool CheckFloatEquivalent(float _a, float _b)
        {
            float _approximation = 0.01f;
            
            float _delta = Mathf.Abs(_a - _b);

            if (_delta < _approximation)
                return true;
            else
                return false;
        }
    }
}