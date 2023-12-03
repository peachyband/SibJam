using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SibJam.Features.UI
{
    public sealed class PauseService : MonoBehaviour
    {
        [SerializeField]
        private PauseWindow _window;

        private bool _isActive = true;

        private bool _isPaused;
        
        public bool IsPaused => _isPaused;

        public void SetIsActive(bool value) 
        {
            _isActive = value;
        }

        // Start is called before the first frame update
        void Awake()
        {
            SceneManager.sceneUnloaded += OnSceneUnload;
        }

        private void Start()
        {
            _window.SetPauseService(this);
        }

        // Update is called once per frame
        void Update()
        {
            if (_isActive && Input.GetKeyDown(KeyCode.Escape)) 
            {
                Pause();
                _window.Open(_isPaused);
            }
        }

        private void OnSceneUnload(Scene scene) 
        {
            Time.timeScale = 1.0f;
        }

        public void Pause()         
        {
            _isPaused = !_isPaused;

            Time.timeScale = _isPaused 
                ? 0.0f 
                : 1.0f;
        }


        
    }
}
