// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using SibJam.Features.Info.Data;
using SibJam.Features.Info.Factories;
using SibJam.Features.Info.Views;
using SibJam.Features.Player.Signals;
using SibJam.Features.UI;
using UniRx;
using UnityEngine;
using Zenject;

namespace SibJam.Features.Info.Services
{
    public class InfoService
    {
        private WindowPresenter _currentWindow;
        
        private readonly CanvasPresenter _canvasPresenter;
        private readonly WindowFactory _windowFactory;
        private readonly Camera _camera;

        private readonly SignalBus _signalBus;

        private InfoService(CanvasPresenter canvasPresenter,
            WindowFactory windowFactory,
            Camera camera, SignalBus signalBus)
        {
            _canvasPresenter = canvasPresenter;
            _windowFactory = windowFactory;
            _signalBus = signalBus;
            _camera = camera;
        }
        
        public void ShowWindow(WindowType type)
        {
            if (_currentWindow != null) return;
            var window = _windowFactory.Create(type, _canvasPresenter.InfoHolder);
            _signalBus.TryFire(new PlayerSignals.ToggleControls(false));
            _currentWindow = window;
            Time.timeScale = 0f;
            
            window.OnClick()
                .Subscribe(_ =>
                {
                    _currentWindow.Dispose();
                    _currentWindow = null;
                    Time.timeScale = 1f;
                    _signalBus.TryFire(new PlayerSignals.ToggleControls(true));
                });
        }
    }
}