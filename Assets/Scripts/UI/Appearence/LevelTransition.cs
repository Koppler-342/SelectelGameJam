using System.Collections;
using Labirynth.GameLoop;
using UnityEngine;

namespace UI.Appearence
{
    public class LevelTransition : MonoBehaviour
    {
        [SerializeField] private float transitionSpeed;
        
        private SpriteRenderer spriteRenderer;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            
            PermanentShow();
            
            TransitFrom();
        }

        private void OnEnable()
        {
            SceneLoader.OnLoadNewLevel += TransitTo;
        }

        private void OnDisable()
        {
            SceneLoader.OnLoadNewLevel -= TransitTo;
        }

        private void TransitTo()
        {
            StartCoroutine(Show());
        }

        private void TransitFrom()
        {
            StartCoroutine(Hide());
        }
        
        private void PermanentShow()
        {
            Color _color = spriteRenderer.color;
            _color.a = 1;
            spriteRenderer.color = _color;
        }
        
        private IEnumerator Show()
        {
            Color _color = spriteRenderer.color;

            while (_color.a < 1)
            {
                _color.a += transitionSpeed * Time.deltaTime;
                
                if (_color.a > 1)
                    _color.a = 1;
                
                spriteRenderer.color = _color;
                
                yield return null;
            }
            
            _color.a = 1;
            spriteRenderer.color = _color;
        }
        
        private IEnumerator Hide()
        {
            Color _color = spriteRenderer.color;
            
            while (_color.a > 0)
            {
                _color.a -= transitionSpeed * Time.deltaTime;
                
                if (_color.a < 0)
                    _color.a = 0;
                
                spriteRenderer.color = _color;
                
                yield return null;
            }

            _color.a = 0;
            spriteRenderer.color = _color;
        }
    }
}