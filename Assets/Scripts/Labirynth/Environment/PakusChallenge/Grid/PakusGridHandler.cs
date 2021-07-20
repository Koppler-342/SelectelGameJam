using UnityEngine;
using UnityEngine.Assertions;

namespace Labirynth.Environment.PakusChallenge.Grid
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(PakusGridScanner))]
    public class PakusGridHandler : MonoBehaviour
    {
        [SerializeField] private PakusPoint[] points;

        public PakusPoint[] PakusPoints => points;

        private PakusGridScanner scanner;

        public void InitializeGridHandler()
        {
            scanner = GetComponent<PakusGridScanner>();
            
            Assert.IsNotNull(scanner);
            
            points = scanner.Scan();
        }
    }
}