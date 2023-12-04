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

        private async void OnTriggerStay2D(Collider2D other)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(_damageCooldown));
            var player = other.transform.GetComponent<PlayerBase>();

            if (player != null) 
                player.TakeDamage(_damage);
        }
    }
}