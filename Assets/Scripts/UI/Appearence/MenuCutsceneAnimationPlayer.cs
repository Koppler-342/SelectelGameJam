using Spine.Unity;
using UnityEngine;

namespace UI.Appearence
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(AudioSource))]
    public class MenuCutsceneAnimationPlayer : MonoBehaviour
    {
        private AudioSource audioSource;
        
        private SkeletonGraphic skeletonAnimation;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            skeletonAnimation = GetComponent<SkeletonGraphic>();
        }
        
        public void PlayAnimation()
        {
            audioSource.Play();
            skeletonAnimation.AnimationState.AddAnimation(0, "animation", false, 0);
        }
    }
}