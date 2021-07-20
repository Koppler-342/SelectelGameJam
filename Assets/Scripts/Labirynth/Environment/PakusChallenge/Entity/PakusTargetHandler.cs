using System;
using Labirynth.Environment.PakusChallenge.Grid;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Labirynth.Environment.PakusChallenge.Entity
{
    public class PakusTargetHandler : MonoBehaviour
    {
        private PakusPoint currentTarget;

        private PakusDestinationChecker destinationChecker;
        private PakusGridHandler gridHandler;
        
        public PakusPoint PakusPoint => currentTarget;

        public event Action<Vector2> OnNewPointPicked;
        
        private void Awake()
        {
            destinationChecker = GetComponent<PakusDestinationChecker>();
            gridHandler = FindObjectOfType<PakusGridHandler>();
        }

        private void OnEnable()
        {
            destinationChecker.OnTargetReached += PickNextTarget;
        }

        private void OnDisable()
        {
            destinationChecker.OnTargetReached -= PickNextTarget;
        }

        private void PickNextTarget()
        {
            int _randomIndex = Random.Range(0, gridHandler.PakusPoints[currentTarget.Index].ClosestPoints.Length);
            SetTarget(gridHandler.PakusPoints[currentTarget.Index].ClosestPoints[_randomIndex]);
        }

        public void InitializePakus(PakusPoint _point)
        {
            SetTarget(_point);
        }

        private void SetTarget(PakusPoint _point)
        {
            currentTarget = _point;
            OnNewPointPicked?.Invoke(_point.PointTransform.position);
        }
    }
}