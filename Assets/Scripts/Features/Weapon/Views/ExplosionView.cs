// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using System;
using Cysharp.Threading.Tasks;
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
            
            
            _audioSource.clip = _explosionSound;
            _audioSource.Play();
            _particleSystem.Play();

            await UniTask.Delay(TimeSpan.FromSeconds(1f));
            Destroy(gameObject);
        }
    }
}