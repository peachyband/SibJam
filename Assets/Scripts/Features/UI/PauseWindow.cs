using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace SibJam.Features.UI
{
    public class PauseWindow : MonoBehaviour
    {
        [SerializeField]
        private CanvasGroup _canvasGroup;

        [SerializeField]
        private SettingsSubWindow _settingsWindow;

        [SerializeField]
        private Button _continueButton;
        [SerializeField]
        private Button _settingsButton;
        [SerializeField]
        private Button _mainMenuButton;

        private PauseService _pauseService;

        public void SetPauseService(PauseService service) 
        {
            _pauseService = service;
        }

        // Start is called before the first frame update
        void Start()
        {
            _continueButton.onClick.AddListener(Continue);
            _settingsButton.onClick.AddListener(Settings);
            _mainMenuButton.onClick.AddListener(MainMenu);
        }


        private void Continue() 
        {
            _pauseService.SetIsActive(true);
            gameObject.SetActive(false);

            _pauseService.Pause();
        }

        private void Settings() 
        {
            _settingsWindow.Open(_canvasGroup, true,
                () => _pauseService.SetIsActive(true));

            _pauseService.SetIsActive(false);
        }

        private void MainMenu() 
        {
            SceneManager.LoadScene("MainMenu");
        }

        public void Open(bool openWindow=true) 
        {
            gameObject.SetActive(openWindow);
        }
    }
}
