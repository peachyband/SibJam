// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using System;
using Cysharp.Threading.Tasks;
using SibJam.Features.Player.Data.Config;
using SibJam.Features.Player.Models;
using SibJam.Features.Player.Signals;
using UniRx;
using UnityEngine;
using Zenject;

namespace SibJam.Features.Player.Services
{
    public class PlayerControlRule : IInitializable, IDisposable
    {
        private readonly PlayerModel _playerModel;
        private readonly PlayerConfig _playerConfig;

        private readonly SignalBus _signalBus;
        
        private readonly CompositeDisposable _controlsDisposable = new ();
        private readonly CompositeDisposable _compositeDisposable = new ();

        private PlayerControlRule(PlayerModel playerModel, 
            PlayerConfig playerConfig, SignalBus signalBus)
        {
            _playerModel = playerModel;
            _playerConfig = playerConfig;
            _signalBus = signalBus;
        }
        
        public void Initialize()
        {
            _signalBus
                .GetStream<PlayerSignals
                    .ToggleControls>()
                .Subscribe(signal =>
                {
                    if (signal.Value)
                        EnableControls();
                    else
                        DisableControls();
                })
                .AddTo(_compositeDisposable);
        }

        private void EnableControls()
        {
            Observable
                .EveryUpdate()
                .Subscribe(_ =>
                {
                    var axis = Input.GetAxis("Horizontal");
                    _playerModel.SetMoveDirection(axis);
                })
                .AddTo(_controlsDisposable);

            Observable
                .EveryUpdate()
                .Where(_ => Input.GetKeyDown(_playerConfig.DashKey))
                .Subscribe(_ => _playerModel.Dash())
                .AddTo(_controlsDisposable);

            Observable
                .EveryUpdate()
                .Where(_ => Input.GetKeyDown(_playerConfig.JumpKey))
                .Subscribe(_ => _playerModel.Jump())
                .AddTo(_controlsDisposable);
            
            Observable
                .EveryUpdate()
                .Where(_ => Input.GetKeyDown(_playerConfig.InteractionKey))
                .Subscribe(_ => _playerModel.Interact())
                .AddTo(_controlsDisposable);
        }

        private void DisableControls()
        {
            _controlsDisposable?.Clear();
        }
        
        public void Dispose()
        {
            _controlsDisposable?.Dispose();
            _compositeDisposable?.Dispose();
        }
    }
}