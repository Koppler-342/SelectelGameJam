using System;
using Spine.Unity;
using UnityEngine;

namespace Cutscenes
{
    [DisallowMultipleComponent]
    public class CutsceneAnimationsPlayer : MonoBehaviour
    {
        private SkeletonAnimation skeletonAnimation;

        private void Awake()
        {
            skeletonAnimation = GetComponent<SkeletonAnimation>();
        }

        private void Start()
        {
            skeletonAnimation.AnimationState.AddAnimation(0, "anim3", true, 0);
        }
    }
}