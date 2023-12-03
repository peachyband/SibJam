// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using UnityEngine;

namespace SibJam.Features.Player.Data.Config
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Config/Player config")]
    public class PlayerConfig : ScriptableObject
    {
        [field: SerializeField]
        public float Health { get; private set; }
        
        [SerializeField] private float _speed;

        public float Speed => _speed;
    }
}