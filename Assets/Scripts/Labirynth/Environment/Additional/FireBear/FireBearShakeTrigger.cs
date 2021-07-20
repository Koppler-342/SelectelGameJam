using System;
using Labirynth.Environment.TriggerPath.Base;

namespace Labirynth.Environment.Additional.FireBear
{
    public class FireBearShakeTrigger : ColliderTriggerBase
    {
        public static event Action OnShakeTrigger;

        protected override void OnTrigger()
        {
            OnShakeTrigger?.Invoke();
        }
    }
}