// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using System;
using Cysharp.Threading.Tasks;
using SibJam.Features.Player.Models;
using UniRx;
using UnityEngine;
using Zenject;

namespace SibJam.Features.TV.Views
{
    public class TVView : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private PlayerModel _playerModel;
        
        private static readonly int Level1 = Animator.StringToHash("Level");

        [Inject]
        public void Construct(PlayerModel playerModel)
        {
            _playerModel = playerModel;
        }

        private void Start()
        {
            _playerModel
                .OnLevelChange()
                .Subscribe(level => _animator.SetInteger(Level1, level))
                .AddTo(this);
        }
    }
}