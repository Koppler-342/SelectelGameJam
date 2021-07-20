using UnityEngine;
using UnityEngine.UI;

namespace UI.Base
{
    public class ActionButton : MonoBehaviour
    {
        private Button button;

        private void Awake()
        {
            button = GetComponentInChildren<Button>();
            
            OnAwake();
        }

        private void OnEnable()
        {
            button.onClick.AddListener(OnClick);
            
            OnButtonEnable();
        }

        private void OnDisable()
        {
            button.onClick.RemoveListener(OnClick);
            
            OnButtonDisable();
        }

        public void HideButton()
        {
            button.gameObject.SetActive(false);
        }

        public void ShowButton()
        {
            button.gameObject.SetActive(true);
        }

        protected virtual void OnAwake() {}
        
        protected virtual void OnButtonEnable() {}
        
        protected virtual void OnButtonDisable() {}
        
        protected virtual void OnClick() {}
    }
}