using UnityEngine;
using Utils;

namespace Labirynth.Player.PathCheck
{
    [DisallowMultipleComponent]
    public class PlayerPathOverlapChecker : MonoBehaviour
    {
        [SerializeField] private LayerMask layerMask = 0;

        public bool CheckPathOverlap()
        {
            return OverlapCheck.CheckCursorOverlapLayer(layerMask);
        }
    }
}