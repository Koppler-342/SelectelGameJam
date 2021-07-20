using System;
using Labirynth.Environment.PakusChallenge.Behaviour;
using UnityEngine;
using Utils;

namespace Labirynth.Environment.PakusChallenge.Entity
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(PakusTargetHandler))]
    public class PakusDestinationChecker : PakusBase
    {
        private PakusTargetHandler targetHandler;
        
        public event Action OnTargetReached;

        private void Awake()
        {
            targetHandler = GetComponent<PakusTargetHandler>();
        }

        public override void ExecuteBehaviour()
        {
            if (VectorComparer.CheckVectorEquivalent(
                transform.position, targetHandler.PakusPoint.PointTransform.position) == true)
                OnTargetReached?.Invoke();                
        }
    }
}