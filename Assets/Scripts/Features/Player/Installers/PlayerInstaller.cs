// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using SibJam.Features.Player.Base;
using SibJam.Features.Player.Data;
using SibJam.Features.Player.Factories;
using SibJam.Features.Player.Models;
using SibJam.Features.Player.Signals;
using SibJam.Features.Player.States;
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
            InstallSignals();
            InstallModels();
        }

        private void InstallFactories()
        {
            Container.Bind<PlayerStateFactory>().AsSingle();
        }
        
        private void InstallModels()
        {
            Container.BindInterfacesAndSelfTo<PlayerModel>().AsSingle();
        }

        private void InstallStates()
        {
            Container.Bind<BasePlayerState>()
                .WithId(PlayerState.Hurt)
                .To<HurtState>();
        }
        
        private void InstallSignals()
        {
            Container.DeclareSignal<PlayerSignal.LevelUp>();
        }
    }
}