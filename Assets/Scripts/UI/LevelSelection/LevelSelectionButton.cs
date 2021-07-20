using Labirynth.GameLoop;
using UI.Base;
using UnityEngine;

namespace UI.LevelSelection
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(SceneLoader))]
    public class LevelSelectionButton : ActionButton
    {
        private SceneLoader sceneLoader;

        protected override void OnAwake()
        {
            sceneLoader = GetComponent<SceneLoader>();
        }

        protected override void OnClick()
        {
            sceneLoader.LoadScene();
        }
    }
}