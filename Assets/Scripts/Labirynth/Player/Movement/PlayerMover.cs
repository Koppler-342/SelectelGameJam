using Labirynth.Player.Base;
using UnityEngine;
using Utils;

namespace Labirynth.Player.Movement
{
    public class PlayerMover : PlayerBehaviour
    {
        private void LateUpdate()
        {
            if (alive == false)
                return;
            
            Vector2 _movePosition = MousePosition.GetWorldPosition();

            transform.position = _movePosition;
        }
    }
}