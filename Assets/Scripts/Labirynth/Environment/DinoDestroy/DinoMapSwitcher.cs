using System.Collections;
using UnityEngine;

namespace Labirynth.Environment.DinoDestroy
{
    public class DinoMapSwitcher : MonoBehaviour
    {
        [SerializeField] private float mapRebuildDelay = 4f;
        [SerializeField] private GameObject normalPath = null;
        [SerializeField] private GameObject destroyedPath = null;

        private WaitForSeconds waitForMapRebuild;

        private void Awake()
        {
            waitForMapRebuild = new WaitForSeconds(mapRebuildDelay);
        }

        private void OnEnable()
        {
            DinoPlayerMovementCheck.OnDinoRage += DestroyMap;
        }

        private void OnDisable()
        {
            DinoPlayerMovementCheck.OnDinoRage -= DestroyMap;
        }

        private void DestroyMap()
        {
            normalPath.SetActive(false);
            destroyedPath.SetActive(true);

            StartCoroutine(RebuildMapOnDelay());
        }
        
        private IEnumerator RebuildMapOnDelay()
        {
            yield return waitForMapRebuild;

            normalPath.SetActive(true);
            destroyedPath.SetActive(false);
        }
    }
}