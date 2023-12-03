// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using Zenject;

namespace SibJam.Bootstrap
{
    public class MainInstaller : MonoInstaller
    {

        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
        } 
    }
}