// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using System;
using System.Collections;
using Cysharp.Threading.Tasks;
using SibJam.Features.Player.Data.Config;
using SibJam.Features.Weapon.Models;
using UniRx;
using UnityEngine;
using Zenject;

namespace SibJam.Features.Player.Models
{
    public class PlayerModel : IInitializable, IDisposable
    {
        public bool Invincible { get; private set; }
        public PlayerSettingConfig PlayerSetting { get; private set; }
        public float MoveDirection => _moveDirectionProperty.Value;
        
        private readonly SignalBus _signalBus;

        private readonly ReactiveProperty<int> _levelProperty = new (-1);
        private readonly ReactiveProperty<float> _speedProperty = new ();
        private readonly ReactiveProperty<int> _healthProperty = new ();
        private readonly ReactiveProperty<WeaponModel> _weaponProperty = new ();
        private readonly ReactiveProperty<float> _moveDirectionProperty = new ();

        private readonly CompositeDisposable _compositeDisposable = new ();

        private readonly PlayerConfig _playerConfig;

        public delegate void PlayerHandler();

        public event PlayerHandler OnJump;
        public event PlayerHandler OnDash;
        public event PlayerHandler OnDeath;
        
        private PlayerModel(SignalBus signalBus, PlayerConfig playerConfig)
        {
            _signalBus = signalBus;
            _playerConfig = playerConfig;
        }
        
        public void Initialize()
        {
            UpgradeLevel();
        }

        public void SetMoveDirection(float direction)
        {
            _moveDirectionProperty.Value = direction;
        }

        public void Attack()
        {
            _weaponProperty.Value?.Attack();
        }

        public void Jump()
        {
            OnJump?.Invoke();
        }

        public void Dash()
        {
            OnDash?.Invoke();
        }

        public void UpgradeLevel()
        {
            var newLevel = GetLevel() + 1;
            if (newLevel <= _playerConfig.Settings.Count)
                PlayerSetting = _playerConfig.Settings[newLevel];
            
            SetHealth(_playerConfig.Settings[newLevel].Health);
            SetSpeed(_playerConfig.Settings[newLevel].Speed);
            
            _levelProperty.Value = newLevel;
        }

        public async UniTask TakeDamage(int damage)
        {
            Invincible = true;
            _healthProperty.Value -= damage;
            await UniTask.Delay(TimeSpan.FromSeconds(PlayerSetting.DamageCooldown));
            Invincible = false;
        }

        public void Kill()
        {
            OnDeath?.Invoke();
        }
        
        public IObservable<int> OnLevelChange()
        {
            return _levelProperty.AsObservable();
        }
        
        public IObservable<float> OnDirectionChange()
        {
            return _moveDirectionProperty.AsObservable();
        }
        
        public IObservable<int> OnHealthChange()
        {
            return _healthProperty.AsObservable();
        }

        public float GetSpeed()
        {
            return _speedProperty.Value;
        }

        public int GetLevel()
        {
            return _levelProperty.Value;
        }

        public void SetSpeed(float speed)
        {
            _speedProperty.Value = speed;
        }

        public void SetHealth(int health)
        {
            _healthProperty.Value = health;
        }

        public void Dispose()
        {
            _compositeDisposable?.Dispose();
            _moveDirectionProperty?.Dispose();
        }
    }
}