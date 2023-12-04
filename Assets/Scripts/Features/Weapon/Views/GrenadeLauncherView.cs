// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using SibJam.Features.Weapon.Models;
using UnityEngine;

namespace SibJam.Features.Weapon.Views
{
    public class GrenadeLauncherView : WeaponBase
    {
        [SerializeField] private GrenadeView _grenade;

        public GrenadeLauncherView(WeaponModel model) : base(model)
        { }

        protected override void Attack()
        {
            SpawnGrenade();
        }

        private void SpawnGrenade()
        {
            var grenade = Instantiate(_grenade);
            grenade.Launch();
        }
    }
}