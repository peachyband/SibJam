// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using SibJam.Features.Level.Data.Config;
using SibJam.Features.Level.Views;
using UnityEngine;
using Zenject;

namespace SibJam.Features.Level.Factories
{
    public class GrassFactory : IFactory<Vector2, GrassView>
    {
        private readonly DiContainer _container;
        private readonly LevelConfig _levelConfig;

        private GrassFactory(DiContainer container, LevelConfig levelConfig)
        {
            _levelConfig = levelConfig;
            _container = container;
        }
        
        public GrassView Create(Vector2 position)
        {
            return _container.InstantiatePrefabForComponent<GrassView>(
                _levelConfig.GrassView, new object[] {position});
        }
    }
}