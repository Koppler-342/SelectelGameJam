using UnityEngine;
using UnityEngine.Assertions;
using Utils;

namespace Labirynth.Environment.PakusChallenge.Entity
{
    [DisallowMultipleComponent]
    public class PakusRotator : MonoBehaviour
    {
        private PakusTargetHandler targetHandler;

        private void Awake()
        {
            targetHandler = GetComponentInParent<PakusTargetHandler>();

            Assert.IsNotNull(targetHandler);
        }

        private void OnEnable()
        {
            targetHandler.OnNewPointPicked += RotateToTarget;
        }

        private void OnDisable()
        {
            targetHandler.OnNewPointPicked -= RotateToTarget;
        }

        private void RotateToTarget(Vector2 _target)
        {
            transform.rotation = RotationToTarget.GetRotationToTarget(transform.position, _target);
        }
    }
}