// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using SibJam.Features.Level.Data.Config;
using SibJam.Features.Level.Factories;
using SibJam.Features.Level.Models;
using SibJam.Features.Level.Signals;
using SibJam.Features.Level.Views;
using SibJam.Features.Player.Models;
using UniRx;
using Zenject;

namespace SibJam.Features.Level.Rules
{
    public class GrassRule : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly LevelModel _levelModel;
        private readonly LevelConfig _levelConfig;
        private readonly PlayerModel _playerModel;
        private readonly GrassFactory _grassFactory;
        private readonly CollectibleFactory _collectibleFactory;

        private readonly CompositeDisposable _compositeDisposable = new ();

        private int _collectionProgress;
        private readonly List<CollectibleView> _spawnedCollectibles = new ();

        private GrassRule(LevelConfig levelConfig, SignalBus signalBus, 
            GrassFactory grassFactory, CollectibleFactory collectibleFactory,
            LevelModel levelModel, PlayerModel playerModel)
        {
            _signalBus = signalBus;
            _levelModel = levelModel;
            _levelConfig = levelConfig;
            _playerModel = playerModel;
            _grassFactory = grassFactory;
            _collectibleFactory = collectibleFactory;
        }
        
        public void Initialize()
        {
            _signalBus
                .GetStream<LevelSignals.PillCollected>()
                .Subscribe(_ =>
                {
                    _collectionProgress += 1;

                    if (_collectionProgress < _spawnedCollectibles.Count) return;
                    _grassFactory.Create(_levelModel.GetCentre());
                    _spawnedCollectibles.Clear();
                })
                .AddTo(_compositeDisposable);

            _playerModel
                .OnLevelChange()
                .Subscribe(_ => SpawnPills())
                .AddTo(_compositeDisposable);
        }

        private async void SpawnPills()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(_levelConfig.PillsTimeout));
            for (var i = 0; i < _levelConfig.CollectiblesToGet; i++)
            {
                var collectible = _collectibleFactory.Create(_levelModel.GetRandomPositionInside());
                _spawnedCollectibles.Add(collectible);
            }
        }

        public void Dispose()
        {
            _compositeDisposable?.Dispose();
        }
    }
}