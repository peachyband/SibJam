using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace SibJam.Features.UI
{
    public sealed class MainMenu : MonoBehaviour
    {
        [SerializeField]
        private CanvasGroup _canvasGroup;

        [SerializeField]
        private Button _playButton;
        [SerializeField]
        private Button _settingsButton;
        [SerializeField]
        private Button _creditsButton;
        [SerializeField]
        private Button _quitButton;


        [SerializeField]
        private SubWindow _settingsWindow;
        [SerializeField]
        private SubWindow _creditsWindow;

        // Start is called before the first frame update
        void Start()
        {
            _playButton.onClick.AddListener(Play);
            _settingsButton.onClick.AddListener(Settings);
            _creditsButton.onClick.AddListener(Credits);
            _quitButton.onClick.AddListener(Quit);
        }

        private void Play() 
        {
            print("Play!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        private void Settings() 
        {
            _settingsWindow.Open(_canvasGroup);
        }

        private void Credits() 
        {
            _creditsWindow.Open(_canvasGroup);
        }

        private void Quit() 
        {
            print("Quit");

            Application.Quit();

        }
    }
}
