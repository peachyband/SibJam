// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using SibJam.Features.Level.Factories;
using SibJam.Features.Level.Models;
using SibJam.Features.Level.Rules;
using SibJam.Features.Level.Signals;
using Zenject;

namespace SibJam.Features.Level.Installers
{
    public class LevelInstaller : Installer
    {
        public override void InstallBindings()
        {
            InstallRules();
            InstallModels();
            InstallSignals();
            InstallFactories();
        }

        private void InstallRules()
        {
            Container.BindInterfacesTo<GrassRule>().AsSingle();
            Container.BindInterfacesTo<LevelRule>().AsSingle();
        }

        private void InstallFactories()
        {
            Container.Bind<CollectibleFactory>().AsSingle();
            Container.Bind<GrassFactory>().AsSingle();
        }

        private void InstallModels()
        {
            Container.Bind<LevelModel>().AsSingle();
        }
        
        private void InstallSignals()
        {
            Container.DeclareSignal<LevelSignals.LevelFailed>();
            Container.DeclareSignal<LevelSignals.LevelPassed>();
            Container.DeclareSignal<LevelSignals.PillCollected>();
            Container.DeclareSignal<LevelSignals.RestartLevel>();
            Container.DeclareSignal<LevelSignals.ToMenu>();
            Container.DeclareSignal<LevelSignals.GrassTouched>();
        }
    }
}