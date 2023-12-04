// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using System;
using Cysharp.Threading.Tasks;
using SibJam.Features.Weapon.Data;
using SibJam.Features.Weapon.Data.Config;
using UniRx;
using Zenject;

namespace SibJam.Features.Weapon.Models
{
    public class WeaponModel : IInitializable
    {
        public WeaponData Data { get; private set; }
        public int Ammo => _ammoProperty.Value;
        private readonly ReactiveProperty<int> _ammoProperty = new ();

        public delegate void WeaponHandler();
        public event WeaponHandler OnReload;
        public event WeaponHandler OnAttack;

        private UniTask.Awaiter _reloadAwaiter;

        private WeaponModel(WeaponData data)
        {
            Data = data;
        }
        
        public void Initialize()
        {
            OnReload += Reload;
        }
        
        public void Attack()
        {
            if (!_reloadAwaiter.IsCompleted) return;
            _ammoProperty.Value -= 1;
            OnAttack?.Invoke();
            if (Ammo <= 0) 
                OnReload?.Invoke();
        }

        private void Reload()
        {
            _reloadAwaiter = UniTask.Delay(TimeSpan.FromSeconds(Data.ReloadTime)).GetAwaiter();
        }
    }
}