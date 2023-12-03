// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using System;
using Cysharp.Threading.Tasks;
using SibJam.Features.Player.Data.Config;
using SibJam.Features.Player.Models;
using UniRx;
using UnityEngine;
using Zenject;

namespace SibJam.Features.Player.Services
{
    public class PlayerControlRule : IInitializable, IDisposable
    {
        private readonly PlayerModel _playerModel;

        private readonly PlayerConfig _playerConfig;
        private readonly CompositeDisposable _compositeDisposable = new ();

        private PlayerControlRule(PlayerModel playerModel, PlayerConfig playerConfig)
        {
            _playerModel = playerModel;
            _playerConfig = playerConfig;
        }
        
        public void Initialize()
        {
            Observable
                .EveryUpdate()
                .Subscribe(_ =>
                {
                    var axis = Input.GetAxis("Horizontal");
                    _playerModel.SetMoveDirection(axis);
                })
                .AddTo(_compositeDisposable);

            Observable
                .EveryUpdate()
                .Where(_ => Input.GetKeyDown(_playerConfig.DashKey))
                .Subscribe(_ => _playerModel.Dash())
                .AddTo(_compositeDisposable);

            Observable
                .EveryUpdate()
                .Where(_ => Input.GetKeyDown(_playerConfig.JumpKey))
                .Subscribe(_ => _playerModel.Jump())
                .AddTo(_compositeDisposable);
        }

        public void Dispose()
        {
            _compositeDisposable?.Dispose();
        }
    }
}