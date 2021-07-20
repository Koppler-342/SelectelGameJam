using UnityEngine;
using UnityEngine.SceneManagement;

namespace Labirynth.GameLoop
{
    public class MenuLoaderOnEsc : MonoBehaviour
    {
        private bool pressed;

        private void Start()
        {
            pressed = false;
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Escape) == true && pressed == false)
            {
                SceneManager.LoadSceneAsync("Menu");
                pressed = true;
            }
        }
    }
}