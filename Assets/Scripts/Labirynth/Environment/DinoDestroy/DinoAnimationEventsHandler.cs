using System;
using UnityEngine;

namespace Labirynth.Environment.DinoDestroy
{
    public class DinoAnimationEventsHandler : MonoBehaviour
    {
        public static event Action OnCheck;
        
        public void InvokeCheckEvent()
        {
            OnCheck?.Invoke();
        }
    }
}