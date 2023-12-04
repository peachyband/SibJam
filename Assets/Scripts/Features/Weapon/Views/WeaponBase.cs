// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using System;
using SibJam.Features.Weapon.Models;
using UnityEngine;

namespace SibJam.Features.Weapon.Views
{
    public abstract class WeaponBase : MonoBehaviour
    {
        protected readonly WeaponModel Model;

        protected WeaponBase(WeaponModel model)
        {
            Model = model;
        }

        private void Start()
        {
            Model.OnAttack += Attack;
        }

        protected abstract void Attack();
    }
}