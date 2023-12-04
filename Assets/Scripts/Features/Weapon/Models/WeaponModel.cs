// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using System;
using Cysharp.Threading.Tasks;
using SibJam.Features.Level.Models;
using SibJam.Features.Weapon.Data;
using SibJam.Features.Weapon.Data.Config;
using UniRx;
using UnityEngine;
using Zenject;

namespace SibJam.Features.Weapon.Models
{
    public class WeaponModel : IInitializable
    {
        public WeaponData Data { get; private set; }
        public int Ammo => _ammoProperty.Value;
        private readonly ReactiveProperty<int> _ammoProperty = new ();

        public delegate void WeaponHandler();
        public delegate void WeaponController(Vector2 direction);
        public event WeaponHandler OnReload;
        public event WeaponController OnAttack;
        private readonly LevelModel _levelModel;

        private UniTask.Awaiter _reloadAwaiter;

        private WeaponModel(WeaponData data, LevelModel levelModel)
        {
            Data = data;
            _levelModel = levelModel;
        }
        
        public void Initialize()
        {
            OnReload += Reload;
        }
        
        public void Attack()
        {
            if (!_reloadAwaiter.IsCompleted) return;
            _ammoProperty.Value -= 1;
            OnAttack?.Invoke(_levelModel.GetCentre());
            if (Ammo <= 0) 
                OnReload?.Invoke();
        }

        private void Reload()
        {
            _reloadAwaiter = UniTask.Delay(TimeSpan.FromSeconds(Data.ReloadTime)).GetAwaiter();
        }
    }
}