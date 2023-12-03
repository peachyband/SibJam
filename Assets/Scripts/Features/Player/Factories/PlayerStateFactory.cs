// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using SibJam.Features.Player.Base;
using SibJam.Features.Player.Data;
using Zenject;

namespace SibJam.Features.Player.Factories
{
    public class PlayerStateFactory : IFactory<PlayerState, BasePlayerState>
    {
        private readonly DiContainer _container;

        private PlayerStateFactory(DiContainer container)
        {
            _container = container;
        }
        public BasePlayerState Create(PlayerState stateType)
        {
            return _container.ResolveId<BasePlayerState>(stateType);
        }
    }
}