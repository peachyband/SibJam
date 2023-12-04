// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using System;
using System.Linq;
using Cysharp.Threading.Tasks;
using SibJam.Features.Enemies;
using UnityEngine;

namespace SibJam.Features.Weapon.Views
{
    public class ExplosionView : MonoBehaviour
    {
        [SerializeField] private AudioClip _explosionSound;
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private float _radius;

        public async void Explode()
        {
            var colliders = Physics2D.OverlapCircleAll(transform.position, _radius);
            var enemies = colliders
                .Select(other => other.GetComponent<EnemyBase>())
                .Where(other => other != null)
                .ToList();
            
            foreach (var enemy in enemies)
                enemy.Kill();

            _audioSource.clip = _explosionSound;
            _audioSource.Play();
            _particleSystem.Play();

            await UniTask.Delay(TimeSpan.FromSeconds(1f));
            Destroy(gameObject);
        }
    }
}