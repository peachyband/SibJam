// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using SibJam.Features.Info.Factories;
using SibJam.Features.Info.Services;
using Zenject;

namespace SibJam.Features.Info.Installers
{
    public class InfoInstaller : Installer
    {
        public override void InstallBindings()
        {
            InstallServices();
            InstallFactories();
        }

        private void InstallServices()
        {
            Container.Bind<InfoService>().AsSingle();
        }

        private void InstallFactories()
        {
            Container.Bind<WindowFactory>().AsSingle();
        }
    }
}