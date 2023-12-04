// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using SibJam.Features.Player.Models;
using SibJam.Features.Player.Services;
using SibJam.Features.Player.Signals;
using Zenject;

namespace SibJam.Features.Player.Installers
{
    public class PlayerInstaller : Installer
    {
        public override void InstallBindings()
        {
            InstallModels();
            InstallRules();
            InstallSignals();
        }
        
        private void InstallModels()
        {
            Container.BindInterfacesAndSelfTo<PlayerModel>().AsSingle();
        }

        private void InstallRules()
        {
            Container.BindInterfacesTo<PlayerControlRule>().AsSingle();
        }

        private void InstallSignals()
        {
            Container.DeclareSignal<PlayerSignals.ToggleControls>();
        }
    }
}