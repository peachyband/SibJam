// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using UnityEngine;
using UnityEngine.Serialization;

namespace SibJam.Features.Player.Data.Config
{
    [CreateAssetMenu(fileName = "PlayerSettingConfig", menuName = "Config/Player setting config")]
    public class PlayerSettingConfig : ScriptableObject
    {
        [SerializeField] private int _health;
        [SerializeField] private float _speed;
        [SerializeField] private float _dashTime;
        [SerializeField] private float _dashSpeed;
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _punchForce;
        [SerializeField] private float _damageCooldown;
        [SerializeField] private RuntimeAnimatorController _animatorController;

        [SerializeField] private AudioClip _dashSound;
        [SerializeField] private AudioClip _hurtSound;
        [SerializeField] private AudioClip _jumpSound;
        [SerializeField] private AudioClip _fallSound;
        [SerializeField] private AudioClip _levelUpSound;
        [SerializeField] private AudioClip _interactionSound;

        public int Health => _health;
        public float Speed => _speed;
        public float DashTime => _dashTime;
        public float DashSpeed => _dashSpeed;
        public float JumpForce => _jumpForce;
        public float PunchForce => _punchForce;
        public float DamageCooldown => _damageCooldown;
        public RuntimeAnimatorController AnimatorController => _animatorController;

        public AudioClip DashSound => _dashSound;
        public AudioClip JumpSound => _jumpSound;
        public AudioClip FallSound => _fallSound;
        public AudioClip HurtSound => _hurtSound;
        public AudioClip LevelUpSound => _levelUpSound;
        public AudioClip InteractionSound => _interactionSound;
    }
}