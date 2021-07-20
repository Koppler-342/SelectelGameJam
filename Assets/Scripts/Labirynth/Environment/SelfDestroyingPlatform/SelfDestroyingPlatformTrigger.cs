using Labirynth.Environment.TriggerPath.Base;
using Labirynth.GameLoop;
using UnityEngine;

namespace Labirynth.Environment.SelfDestroyingPlatform
{
    [DisallowMultipleComponent]
    public class SelfDestroyingPlatformTrigger : ColliderTriggerBase
    {
        private SelfDestroyingPlatformSwitcher switcher;

        private void Awake()
        {
            switcher = GetComponentInParent<SelfDestroyingPlatformSwitcher>();
        }
        
        protected override void OnTrigger()
        {
            if (LabirynthGameLoop.Alive == true)
                switcher.BeginDisabling();
        }
    }
}