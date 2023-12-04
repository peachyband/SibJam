// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using System;
using SibJam.Features.Weapon.Views;
using UnityEngine;

namespace SibJam.Features.Weapon.Data
{
    [Serializable]
    public class WeaponData
    {
        [SerializeField] private WeaponType _type;
        [SerializeField] private WeaponBase _prefab;
        [SerializeField] private float _reloadTime;
        [SerializeField] private int _ammoCapacity;
        
        public WeaponType Type => _type;
        public WeaponBase Prefab => _prefab;
        public float ReloadTime => _reloadTime;
        public int AmmoCapacity => _ammoCapacity;
    }
}