using Labirynth.Environment.TriggerPath.Base;
using UnityEngine;
using UnityEngine.Assertions;

namespace Labirynth.Environment.MovingPlatform.PathFollow.Follower.Triggered
{
    [DisallowMultipleComponent]
    public class PlatformTriggeredStarter : ColliderTriggerBase
    {
        [SerializeField] private PlatformPathMover pathMover = null;

        private void Awake()
        {
            Assert.IsNotNull(pathMover);
        }

        protected override void OnTrigger()
        {
            pathMover.BeginMovement();   
        }
    }
}