// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using UnityEngine;

namespace SibJam.Features.Weapon.Views
{
    public class GrenadeLauncherView : WeaponBase
    {
        [SerializeField] private GrenadeView _grenade;

        protected override void Attack(Vector2 direction)
        {
            SpawnGrenade(direction);
        }

        private void SpawnGrenade(Vector2 direction)
        {
            var grenade = Instantiate(_grenade, transform.position, Quaternion.identity);
            grenade.Launch(direction);
        }
    }
}