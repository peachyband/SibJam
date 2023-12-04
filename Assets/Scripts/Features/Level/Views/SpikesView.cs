// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using System;
using Cysharp.Threading.Tasks;
using SibJam.Features.Player.Views;
using UnityEngine;

namespace SibJam.Features.Level.Views
{
    public class SpikesView : MonoBehaviour
    {
        [SerializeField] private int _damage;
        [SerializeField] private float _damageCooldown;

        private float _damageTimer;
        
        private void Update()
        {
            _damageTimer += Time.deltaTime;
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            var player = other.GetComponent<PlayerBase>();
            if (player == null) return;

            if (!(_damageTimer >= _damageCooldown)) return;
            player.TakeDamage(_damage);
            _damageTimer = 0f;
        }
    }
}