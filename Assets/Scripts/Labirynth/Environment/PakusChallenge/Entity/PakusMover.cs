using Labirynth.Environment.PakusChallenge.Behaviour;
using UnityEngine;

namespace Labirynth.Environment.PakusChallenge.Entity
{
    public class PakusMover : PakusBase
    {
        [SerializeField] private float speed = 2f;
        
        private PakusTargetHandler targetHandler;
        
        private void Awake()
        {
            targetHandler = GetComponent<PakusTargetHandler>();
        }

        public override void ExecuteBehaviour()
        {
            Vector2 _nextPosition = Vector2.MoveTowards(
                transform.position,
                targetHandler.PakusPoint.PointTransform.position,
                speed * Time.fixedDeltaTime);

            transform.position = _nextPosition;
        }
    }
}