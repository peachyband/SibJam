// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using SibJam.Features.Weapon.Data.Config;
using SibJam.Features.Weapon.Models;
using SibJam.Features.Weapon.Views;
using Zenject;

namespace SibJam.Features.Weapon.Factories
{
    public class WeaponViewFactory : IFactory<WeaponModel, WeaponBase>
    {
        private readonly DiContainer _container;

        private WeaponViewFactory(DiContainer container)
        {
            _container = container;
        }
        
        public WeaponBase Create(WeaponModel model)
        {
            var presenter = _container.InstantiatePrefabForComponent<WeaponBase>(
                model.Data.Prefab, new object[] { model });
            return presenter;
        }
    }
}