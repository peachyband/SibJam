// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using SibJam.Features.Info.Data;
using SibJam.Features.Info.Factories;
using SibJam.Features.Info.Views;
using SibJam.Features.UI;
using UniRx;
using UnityEngine;

namespace SibJam.Features.Info.Services
{
    public class InfoService
    {
        private WindowPresenter _currentWindow;
        
        private readonly CanvasPresenter _canvasPresenter;
        private readonly WindowFactory _windowFactory;
        private readonly Camera _camera;

        private InfoService(CanvasPresenter canvasPresenter,
            WindowFactory windowFactory,
            Camera camera)
        {
            _canvasPresenter = canvasPresenter;
            _windowFactory = windowFactory;
            _camera = camera;
        }
        
        public void ShowWindow(WindowType type)
        {
            if (_currentWindow != null) return;
            var window = _windowFactory.Create(type, _canvasPresenter.InfoHolder);
            _currentWindow = window;
            Time.timeScale = 1f;
            
            window.OnClick()
                .Subscribe(_ =>
                {
                    Time.timeScale = 1f;
                    _currentWindow.Dispose();
                    _currentWindow = null;
                });
        }
    }
}