using System.Collections;
using UnityEngine;

namespace UI.Appearence
{
    public class DynamicBackground : MonoBehaviour
    {
        [SerializeField] private float changeSpeed = 1f;
        [SerializeField] private float nextDelay = 2f;
        
        private SpriteRenderer[] layers = new SpriteRenderer[0];

        private int currentIndex;

        private void Awake()
        {
            layers = GetComponentsInChildren<SpriteRenderer>();
            
            for (int i = 0; i< layers.Length; i++)
                PermanentHide(layers[i]);

            currentIndex = 0;
            PermanentShow(layers[0]);
        }

        private void Start()
        {
            SwitchLayers();
        }

        private void SwitchLayers()
        {
            StopAllCoroutines();
            
            StartCoroutine(Hide(layers[currentIndex]));
            StartCoroutine(Show(layers[GetNextIndex()]));
            
            IncreaseIndex();
            
            StartCoroutine(QueueNext(nextDelay));
        }

        private int GetNextIndex()
        {
            int _nextIndex = currentIndex + 1;

            if (_nextIndex == layers.Length)
                _nextIndex = 0;

            return _nextIndex;
        }

        private void IncreaseIndex()
        {
            currentIndex++;

            if (currentIndex == layers.Length)
                currentIndex = 0;
        }

        private void PermanentHide(SpriteRenderer _spriteRenderer)
        {
            Color _color = _spriteRenderer.color;
            _color.a = 0;
            _spriteRenderer.color = _color;
        }

        private void PermanentShow(SpriteRenderer _spriteRenderer)
        {
            Color _color = _spriteRenderer.color;
            _color.a = 1;
            _spriteRenderer.color = _color;
        }

        private IEnumerator QueueNext(float _delay)
        {
            float progress = 0;
            
            while (progress < 1)
            {
                progress += changeSpeed * Time.deltaTime;
                yield return null;
            }
            
            yield return new WaitForSeconds(_delay);
            
            SwitchLayers();
        }
        
        private IEnumerator Hide(SpriteRenderer _spriteRenderer)
        {
            Color _color = _spriteRenderer.color;
            
            while (_color.a > 0)
            {
                _color.a -= changeSpeed * Time.deltaTime;
                
                if (_color.a < 0)
                    _color.a = 0;
                
                _spriteRenderer.color = _color;
                
                yield return null;
            }

            _color.a = 0;
            _spriteRenderer.color = _color;
        }
        
        private IEnumerator Show(SpriteRenderer _spriteRenderer)
        {
            Color _color = _spriteRenderer.color;

            while (_color.a < 1)
            {
                _color.a += changeSpeed * Time.deltaTime;
                
                if (_color.a > 1)
                    _color.a = 1;
                
                _spriteRenderer.color = _color;
                
                yield return null;
            }
            
            _color.a = 1;
            _spriteRenderer.color = _color;
        }
    }
}