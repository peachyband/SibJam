// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SibJam.Features.Weapon.Data.Config
{
    [CreateAssetMenu(fileName = "WeaponConfig", menuName = "Config/Weapon config")]
    public class WeaponConfig : ScriptableObject
    {
        [SerializeField] private List<WeaponData> _data;

        public WeaponData GetDataByType(WeaponType type)
        {
            return _data.First(data => data.Type == type);
        }
    }
}