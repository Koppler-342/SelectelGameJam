using UnityEngine;
using Utils;

namespace Labirynth.GameLoop.EndField
{
    [DisallowMultipleComponent]
    public class EndFieldEterChecker : MonoBehaviour
    {
        [SerializeField] private LayerMask layerMask = 0;
        
        private LabirynthGameLoop gameLoop;

        private void Awake()
        {
            gameLoop = FindObjectOfType<LabirynthGameLoop>();
        }
        
        private void Update()
        {
            if (LabirynthGameLoop.Alive == true && OverlapCheck.CheckCursorOverlapLayer(layerMask) == true)
                gameLoop.Win();
        }
    }
}