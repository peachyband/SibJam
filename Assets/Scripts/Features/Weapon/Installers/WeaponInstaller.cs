// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using SibJam.Features.Weapon.Data;
using SibJam.Features.Weapon.Factories;
using SibJam.Features.Weapon.Models;
using Zenject;

namespace SibJam.Features.Weapon.Installers
{
    public class WeaponInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindFactory<WeaponData, WeaponModel, WeaponModelFactory>().AsSingle();
            Container.Bind<WeaponViewFactory>().AsSingle();
        }
    }
}