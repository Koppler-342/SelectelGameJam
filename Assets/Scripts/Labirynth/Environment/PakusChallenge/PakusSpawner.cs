using Labirynth.Environment.PakusChallenge.Behaviour;
using Labirynth.Environment.PakusChallenge.Entity;
using Labirynth.Environment.PakusChallenge.Grid;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Labirynth.Environment.PakusChallenge
{
    [DisallowMultipleComponent]
    public class PakusSpawner : MonoBehaviour
    {
        [SerializeField] private int entitiesCount = 100;
        [SerializeField] private GameObject[] pakusPrefabs = null;
        
        private PakusGridHandler gridHandler;
        private PakusBehaviourExecutor behaviourExecutor;

        private void Awake()
        {
            gridHandler = FindObjectOfType<PakusGridHandler>();
            behaviourExecutor = FindObjectOfType<PakusBehaviourExecutor>();
            
            gridHandler.InitializeGridHandler();
        }

        private void Start()
        {
            Spawn();
        }

        private void Spawn()
        {
            for (int i = 0; i < entitiesCount; i++)
            {
                GameObject _pakus = Instantiate(
                    PickRandomPrefab(), 
                    gridHandler.PakusPoints[i].PointTransform.position,
                    Quaternion.identity);

                _pakus.GetComponent<PakusTargetHandler>().InitializePakus(gridHandler.PakusPoints[i]);
            }
            
            behaviourExecutor.ScanBehaviours();
        }

        private GameObject PickRandomPrefab()
        {
            int _randomIndex = Random.Range(0, pakusPrefabs.Length);
            GameObject _prefab = pakusPrefabs[_randomIndex];

            return _prefab;
        }
    }
}