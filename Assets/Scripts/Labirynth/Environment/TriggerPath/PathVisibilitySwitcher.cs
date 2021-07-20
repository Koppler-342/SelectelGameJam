using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;

namespace Labirynth.Environment.TriggerPath
{
    public class PathVisibilitySwitcher : MonoBehaviour
    {
        private SpriteRenderer spriteRenderer;

        private bool hideInProcess;
        private bool showInProcess;

        private void Awake()
        {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();

            hideInProcess = false;
            showInProcess = false;
            
            Assert.IsNotNull(spriteRenderer);
        }

        public void HidePath()
        {
            StartCoroutine(Hide());
        }

        public void ShowPath()
        {
            StartCoroutine(Show());
        }

        private IEnumerator Hide()
        {
            if (hideInProcess == true)
                yield return null;

            hideInProcess = true;

            Color _color = spriteRenderer.color;
            
            while (_color.a > 0)
            {
                _color.a -= Time.deltaTime;
                
                if (_color.a < 0)
                    _color.a = 0;
                
                spriteRenderer.color = _color;
                
                yield return null;
            }

            _color.a = 0;
            spriteRenderer.color = _color;
            hideInProcess = false;
        }
        
        private IEnumerator Show()
        {
            if (showInProcess == true)
                yield return null;

            showInProcess = true;
            
            Color _color = spriteRenderer.color;

            while (_color.a < 1)
            {
                _color.a += Time.deltaTime;
                
                if (_color.a > 1)
                    _color.a = 1;
                
                spriteRenderer.color = _color;
                
                yield return null;
            }
            
            _color.a = 1;
            spriteRenderer.color = _color;
            showInProcess = false;
        }
    }
}