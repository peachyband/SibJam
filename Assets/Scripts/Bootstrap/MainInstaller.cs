// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using SibJam.Features.Info.Installers;
using SibJam.Features.Level.Installers;
using SibJam.Features.Player.Installers;
using SibJam.Features.UI;
using SibJam.Features.Weapon.Installers;
using UnityEngine;
using Zenject;

namespace SibJam.Bootstrap
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private CanvasPresenter _canvasPresenter;
        //[SerializeField] private Camera _mainCamera;
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            Container.Install<PlayerInstaller>();
            Container.Install<LevelInstaller>();
            Container.Install<WeaponInstaller>();
            Container.Install<InfoInstaller>();
            InstallInstances();
        }

        private void InstallInstances()
        {
            Container.Bind<CanvasPresenter>().FromInstance(_canvasPresenter);
           // Container.Bind<Camera>().FromInstance(_mainCamera);
        }
    }
}