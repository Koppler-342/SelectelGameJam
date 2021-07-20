using Labirynth.Player.Base;
using UnityEngine;

namespace Labirynth.Player.Loop
{
    public class PlayerUndertaker : PlayerBehaviour
    {
        private Vector2 startPosition;

        protected override void OnAwake()
        {
            startPosition = transform.position;
        }

        protected override void OnDeath()
        {
            transform.position = startPosition;
        }
    }
}