// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using System;
using Cysharp.Threading.Tasks;
using SibJam.Features.Info.Data;
using SibJam.Features.Info.Services;
using SibJam.Features.Level.Signals;
using SibJam.Features.Player.Data.Config;
using SibJam.Features.Player.Models;
using SibJam.Features.Player.Signals;
using UniRx;
using UnityEngine.SceneManagement;
using Zenject;

namespace SibJam.Features.Level.Rules
{
    public class LevelRule : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly InfoService _infoService;
        private readonly PlayerModel _playerModel;
        private readonly PlayerConfig _playerConfig;
        
        private readonly CompositeDisposable _compositeDisposable = new ();

        private LevelRule(SignalBus signalBus, InfoService infoService,
            PlayerModel playerModel, PlayerConfig playerConfig)
        {
            _signalBus = signalBus;
            _infoService = infoService;
            _playerModel = playerModel;
            _playerConfig = playerConfig;
        }

        public async void Initialize()
        {
            _signalBus.TryFire(new PlayerSignals.ToggleControls(true));
            _infoService.ShowWindow(WindowType.GreetingWindow);
            
            _playerModel.OnDeath += () => _infoService
                .ShowWindow(WindowType.GameOverWindow);

            _signalBus
                .GetStream<LevelSignals.RestartLevel>()
                .Subscribe(_ => SceneManager.LoadScene("PlayerTest"))
                .AddTo(_compositeDisposable);

            _signalBus
                .GetStream<LevelSignals.ToMenu>()
                .Subscribe(_ => SceneManager.LoadScene("MainMenu"))
                .AddTo(_compositeDisposable);

            _signalBus
                .GetStream<LevelSignals.LevelPassed>()
                .Subscribe(_ => _infoService.ShowWindow(WindowType.WinWindow))
                .AddTo(_compositeDisposable);

            _signalBus
                .GetStream<LevelSignals.GrassTouched>()
                .Subscribe(_ => _playerModel.UpgradeLevel())
                .AddTo(_compositeDisposable);

            _playerModel
                .OnLevelChange()
                .Subscribe(level =>
                {
                    if (level == 1)
                        _infoService.ShowWindow(WindowType.DashTutorialWindow);
                    else if (level == 2)
                        _infoService.ShowWindow(WindowType.GrenadeTutorialWindow);
                })
                .AddTo(_compositeDisposable);

            await UniTask.WaitUntil(() => !_infoService.IsPresenting());
            _infoService.ShowWindow(WindowType.MovementTutorialWindow);
        }

        public void Dispose()
        {
            _compositeDisposable?.Dispose();
        }
    }
}