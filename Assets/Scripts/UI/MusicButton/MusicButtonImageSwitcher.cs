using UnityEngine;
using UnityEngine.UI;

namespace UI.MusicButton
{
    public class MusicButtonImageSwitcher : MonoBehaviour
    {
        [SerializeField] private Sprite on = null;
        [SerializeField] private Sprite off = null;

        private Image image;

        private void Awake()
        {
            image = GetComponent<Image>();
        }

        public void SetOnImage()
        {
            image.sprite = on;
        }

        public void SetOffImage()
        {
            image.sprite = off;
        }
    }
}