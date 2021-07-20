using System;
using Labirynth.GameLoop;
using UnityEngine;
using Utils;

namespace Labirynth.Environment.Additional.FireBear
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(SpriteRenderer))]
    public class FireBearRotator : MonoBehaviour
    {
        private SpriteRenderer spriteRenderer;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        
        private void Update()
        {
            if (LabirynthGameLoop.Alive == false)
                return;

            if (MousePosition.GetWorldPosition().x > transform.position.x)
                spriteRenderer.flipX = false;
            else
                spriteRenderer.flipX = true;    
        }
    }
}