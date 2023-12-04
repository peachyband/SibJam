// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using System.Collections.Generic;
using UnityEngine;

namespace SibJam.Features.Player.Data.Config
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Config/Player config")]
    public class PlayerConfig : ScriptableObject
    {
        [SerializeField] private List<PlayerSettingConfig> _settingConfigs;
        [SerializeField] private KeyCode _dashKey = KeyCode.Q;
        [SerializeField] private KeyCode _jumpKey = KeyCode.Space;
        [SerializeField] private KeyCode _interactionKey = KeyCode.E;
        [SerializeField] private KeyCode _fireKey = KeyCode.Mouse0;

        public List<PlayerSettingConfig> Settings => _settingConfigs;
        public KeyCode DashKey => _dashKey;
        public KeyCode JumpKey => _jumpKey;
        public KeyCode InteractionKey => _interactionKey;
        public KeyCode FireKey => _fireKey;
    }
}