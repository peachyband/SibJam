// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using System;
using DG.Tweening;
using SibJam.Features.Player.Models;
using UnityEngine;
using Zenject;

namespace SibJam.Features.Player.Views
{
    public class CameraView : MonoBehaviour
    {
        private PlayerModel _playerModel;
        
        [Inject]
        public void Construct(PlayerModel playerModel)
        {
            _playerModel = playerModel;
        }

        private void LateUpdate()
        {
            transform.DOMove(_playerModel.CurrentPosition.x * Vector3.right + 
                             _playerModel.CurrentPosition.y  * Vector3.up + Vector3.back * 10f, 0.3f);
        }
    }
}