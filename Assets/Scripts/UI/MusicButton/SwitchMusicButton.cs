using UI.Base;
using UnityEngine.Assertions;

namespace UI.MusicButton
{
    public class SwitchMusicButton : ActionButton
    {
        private MusicButtonImageSwitcher imageSwitcher;

        protected override void OnAwake()
        {
            imageSwitcher = GetComponentInChildren<MusicButtonImageSwitcher>();

            Assert.IsNotNull(imageSwitcher);
        }

        protected override void OnClick()
        {
            if (AudioStateHandler.instance.PlayMusic == true)
            {
                AudioStateHandler.instance.DisableMusic();
                imageSwitcher.SetOffImage();
            }
            else
            {
                AudioStateHandler.instance.EnableMusic();
                imageSwitcher.SetOnImage();
            }
        }
    }
}