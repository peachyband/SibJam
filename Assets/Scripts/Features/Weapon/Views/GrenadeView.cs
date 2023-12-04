// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using System;
using System.Linq;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using SibJam.Features.Enemies;
using SibJam.Features.Level.Models;
using UnityEngine;
using Zenject;

namespace SibJam.Features.Weapon.Views
{
    public class GrenadeView : MonoBehaviour
    {
        [SerializeField] private ExplosionView _explosion;
        [SerializeField] private float _activationTimeout;
        [SerializeField] private float _radius;

        public async void Launch(Vector2 direction)
        {
            transform.DOMove(direction, 0.2f);
            await UniTask.Delay(TimeSpan.FromSeconds(_activationTimeout));
            var colliders = Physics2D.OverlapCircleAll(transform.position, _radius);
            var enemies = colliders
                .Select(other => other.GetComponent<EnemyBase>())
                .Where(other => other != null)
                .ToList();
            if (!enemies.Any()) return;
            
            var target = enemies.First();
            transform.DOMove(target.transform.position, 0.1f);
            await UniTask.Delay(TimeSpan.FromSeconds(0.15f));
            _explosion.transform.SetParent(null);
            _explosion.gameObject.SetActive(true);
            _explosion.Explode();
            Destroy(gameObject);
        }
    }
}