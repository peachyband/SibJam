using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace SibJam.Features.UI
{
    public class SubWindow : MonoBehaviour
    {

        [SerializeField]
        private bool _closeOnAwake = false;

        [SerializeField]
        private Button _closeButton;

        private CanvasGroup _parent;
        private bool _closeParent = false;
        private System.Action _closeAction;


        protected virtual void Start()
        {
            _closeButton.onClick.AddListener(Close);

            if (_closeOnAwake) 
            {
                gameObject.SetActive(false);
            }
        }

        public void Open(CanvasGroup parent, bool closeParent=false, 
            System.Action closeAction=null) 
        {
            _parent = parent;
            _closeParent = closeParent;

            gameObject.SetActive(true);

            _parent.interactable = false;
            _parent.blocksRaycasts = false;

            if (_closeParent) 
            {
                _parent.gameObject.SetActive(false);
            }

            _closeAction = closeAction;
            
        }

        public void Close() 
        {
            if (_parent != null) 
            {
                _parent.interactable = true;
                _parent.blocksRaycasts = true;

                if (_closeParent) 
                {
                    _parent.gameObject.SetActive(true);
                    _closeParent = false;
                }

                _parent = null;

            }

            if (_closeAction != null) 
            {
                _closeAction.Invoke();
                _closeAction= null;
            }

            gameObject.SetActive(false);

            
        }

    }
}
