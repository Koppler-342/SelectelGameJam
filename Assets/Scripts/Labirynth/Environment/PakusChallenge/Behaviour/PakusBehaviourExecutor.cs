using UnityEngine;

namespace Labirynth.Environment.PakusChallenge.Behaviour
{
    public class PakusBehaviourExecutor : MonoBehaviour
    {
        private PakusBase[] behaviours = new PakusBase[0];

        public void ScanBehaviours()
        {
            behaviours = FindObjectsOfType<PakusBase>();
        }

        private void FixedUpdate()
        {
            for (int i = 0; i < behaviours.Length; i++) 
                behaviours[i].ExecuteBehaviour();
        }
    }
}