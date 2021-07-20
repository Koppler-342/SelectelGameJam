using Labirynth.Environment.TriggerPath.Base;
using Labirynth.GameLoop;
using UnityEngine.Assertions;

namespace Labirynth.Environment.TriggerPath
{
    public class ExitTrigger : PathSwitcherTriggerBase
    {
        private PathVisibilitySwitcher visibilitySwitcher;
        private TriggerPathSoundsPlayer pathSoundsPlayer;
        
        private bool triggered;

        protected override void OnAwake()
        {
            visibilitySwitcher = FindObjectOfType<PathVisibilitySwitcher>();
            pathSoundsPlayer = FindObjectOfType<TriggerPathSoundsPlayer>();
            
            Assert.IsNotNull(visibilitySwitcher);
            Assert.IsNotNull(pathSoundsPlayer);
        }

        protected override void OnTrigger()
        {
            if (LabirynthGameLoop.Alive == true && triggered == false)
            {
                visibilitySwitcher.ShowPath();
                pathSoundsPlayer.PlayDragonSound();
                triggered = true;
            }
        }

        protected override void OnExit()
        {
            triggered = false;
        }
    }
}