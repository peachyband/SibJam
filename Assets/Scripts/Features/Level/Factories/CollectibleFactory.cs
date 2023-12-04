// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using System.Linq;
using SibJam.Features.Level.Data.Config;
using SibJam.Features.Level.Views;
using UnityEngine;
using Zenject;

namespace SibJam.Features.Level.Factories
{
    public class CollectibleFactory : IFactory<Vector2, CollectibleView>
    {
        private readonly DiContainer _container;
        private readonly LevelConfig _levelConfig;

        private CollectibleFactory(DiContainer container, LevelConfig levelConfig)
        {
            _levelConfig = levelConfig;
            _container = container;
        }
        
        public CollectibleView Create(Vector2 position)
        {
            return _container.InstantiatePrefabForComponent<CollectibleView>(
                _levelConfig.CollectiblePool.First(), new object[] { position });
        }
    }
}