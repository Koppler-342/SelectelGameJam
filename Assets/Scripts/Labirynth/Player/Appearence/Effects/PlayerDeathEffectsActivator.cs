using Labirynth.Player.Loop;
using UnityEngine;
using UnityEngine.Assertions;
using Utils;

namespace Labirynth.Player.Appearence.Effects
{
    public class PlayerDeathEffectsActivator : MonoBehaviour
    {
        private ParticleSystem particles;
        private PlayerLoop playerLoop;
        private PlayerDeathSoundsPlayer deathSoundsPlayer;

        private void Awake()
        {
            particles = GetComponentInChildren<ParticleSystem>();
            playerLoop = FindObjectOfType<PlayerLoop>();
            deathSoundsPlayer = GetComponentInChildren<PlayerDeathSoundsPlayer>();
            
            Assert.IsNotNull(particles);
            Assert.IsNotNull(playerLoop);
            Assert.IsNotNull(deathSoundsPlayer);
        }

        private void OnEnable()
        {
            playerLoop.OnDeath += ActivateEffects;
        }

        private void OnDisable()
        {
            playerLoop.OnDeath -= ActivateEffects;
        }

        private void ActivateEffects()
        {
            transform.position = MousePosition.GetWorldPosition();
            particles.transform.position = MousePosition.GetWorldPosition(); 
            particles.Play();
            deathSoundsPlayer.PlaySounds();
        }
    }
}