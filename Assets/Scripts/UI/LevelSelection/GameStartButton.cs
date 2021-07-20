using UI.Appearence;
using UI.Base;
using UnityEngine;

namespace UI.LevelSelection
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(SceneLoaderOnDelay))]
    public class GameStartButton : ActionButton
    {
        [SerializeField] private MenuCutsceneAnimationPlayer animationPlayer = null;
        
        private SceneLoaderOnDelay sceneLoaderOnDelay;

        protected override void OnAwake()
        {
            sceneLoaderOnDelay = GetComponent<SceneLoaderOnDelay>();
        }

        protected override void OnClick()
        {
            animationPlayer.PlayAnimation();
            sceneLoaderOnDelay.LoadSceneOnDelay();
        }
    }
}