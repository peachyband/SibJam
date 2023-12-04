// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using UnityEngine;

namespace SibJam.Features.Weapon.Data.Config
{
    [CreateAssetMenu(fileName = "WeaponConfig", menuName = "Config/Weapon config")]
    public class WeaponConfig : ScriptableObject
    {
        [SerializeField] private WeaponData _data;

        public WeaponData Data => _data;
    }
}