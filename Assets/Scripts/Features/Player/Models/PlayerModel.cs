// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using System;
using SibJam.Features.Player.Base;
using SibJam.Features.Player.Signals;
using UniRx;
using UnityEngine;
using Zenject;

namespace SibJam.Features.Player.Models
{
    public class PlayerModel : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private BasePlayerState _playerState;
        
        private readonly CompositeDisposable _compositeDisposable = new ();
        
        private PlayerModel(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }
        
        public void Initialize()
        {
            _signalBus
                .GetStream<PlayerSignal.LevelUp>()
                .Subscribe(level => Debug.Log($"{level}"))
                .AddTo(_compositeDisposable);
        }

        public void Move()
        {
            _playerState?.Move();
        }

        public void ChangeState(BasePlayerState state)
        {
            _playerState = state;
        }
        
        public void Death()
        {
            _signalBus.TryFire(new PlayerSignal.LevelUp(5));
        }

        public void Dispose()
        {
            _compositeDisposable?.Dispose();
        }
    }
}