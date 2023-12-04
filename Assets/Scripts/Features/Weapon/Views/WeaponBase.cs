// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using SibJam.Features.Weapon.Models;
using UnityEngine;
using Zenject;

namespace SibJam.Features.Weapon.Views
{
    public abstract class WeaponBase : MonoBehaviour
    {
        protected WeaponModel Model;

        [Inject]
        public void Construct(WeaponModel model)
        {
            Model = model;
        }

        private void Start()
        {
            Model.OnAttack += Attack;
        }

        protected abstract void Attack(Vector2 direction);

        public void Dispose()
        {
            Destroy(gameObject);
        }
    }
}