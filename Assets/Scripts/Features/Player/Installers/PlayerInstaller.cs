// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using SibJam.Features.Player.Models;
using SibJam.Features.Player.Rules;
using SibJam.Features.Player.Signals;
using SibJam.Features.Player.Views;
using UnityEngine;
using Zenject;

namespace SibJam.Features.Player.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerBase _player;

        public override void InstallBindings()
        {
            Container.Bind<PlayerBase>().FromInstance(_player);
            
            InstallModels();
            InstallSignals();
            InstallRules();
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