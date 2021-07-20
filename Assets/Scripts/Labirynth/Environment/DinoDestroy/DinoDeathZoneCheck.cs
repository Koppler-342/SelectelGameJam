using UnityEngine;
using Utils;

namespace Labirynth.Environment.DinoDestroy
{
    [DisallowMultipleComponent]
    public class DinoDeathZoneCheck : MonoBehaviour
    {
        [SerializeField] private LayerMask layerMask = 0;
        public bool CheckPlayerInDeathZone()
        {
            if (OverlapCheck.CheckCursorOverlapObject(layerMask, transform) == true)
                return true;

            return false;
        }
    }
}