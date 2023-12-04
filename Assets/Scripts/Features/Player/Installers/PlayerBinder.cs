// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using SibJam.Features.Player.Views;
using UnityEngine;
using Zenject;

namespace SibJam.Features.Player.Installers
{
    public class PlayerBinder : MonoInstaller
    {
        [SerializeField] private PlayerBase _player;

        public override void InstallBindings()
        {
            Container.Bind<PlayerBase>().FromInstance(_player);
        }
    }
}