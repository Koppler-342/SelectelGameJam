using UnityEngine;
using Utils;

namespace Labirynth.Environment.MovingPlatform.PathFollow
{
    public static class PlatformPathDestinationChecker
    {
        public static bool Checkdestination(Vector2 _currentPosition, Vector2 _targetPosition)
        {
            if (VectorComparer.CheckVectorEquivalent(_currentPosition, _targetPosition) == true)
                return true;
            else
                return false;
        }
    }
}