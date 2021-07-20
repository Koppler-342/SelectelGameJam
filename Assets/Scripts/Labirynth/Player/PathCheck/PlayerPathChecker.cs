using Labirynth.Player.Base;
using UnityEngine;
using UnityEngine.Assertions;

namespace Labirynth.Player.PathCheck
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(PlayerPathOverlapChecker))]
    public class PlayerPathChecker : PlayerBehaviour
    {
        private PlayerPathOverlapChecker playerPathOverlapChecker;

        protected override void OnAwake()
        {
            playerPathOverlapChecker = GetComponent<PlayerPathOverlapChecker>();

            Assert.IsNotNull(playerLoop);
        }

        private void Update()
        {
            if (alive == false)
                return;
            
            if (playerPathOverlapChecker.CheckPathOverlap() == false)
                playerLoop.Death();
        }
    }
}