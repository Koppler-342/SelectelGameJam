using UnityEngine;

namespace Utils
{
    public static class RandomFloatInRange
    {
        public static float GetRandomFloatInRange(float _range)
        {
            float _value = Random.Range(-_range, _range);

            return _value;
        }
    }
}