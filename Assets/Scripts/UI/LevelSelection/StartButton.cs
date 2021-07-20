using System;
using Labirynth.GameLoop;
using UI.Base;

namespace UI.LevelSelection
{
    public class StartButton : ActionButton
    {
        public static event Action StartButtonClicked;


        protected override void OnButtonEnable()
        {
            LabirynthGameLoop.OnRestart += ShowButton;
        }

        protected override void OnButtonDisable()
        {
            LabirynthGameLoop.OnRestart -= ShowButton;
        }

        protected override void OnClick()
        {
            StartButtonClicked?.Invoke();
            HideButton();
        }
    }
}