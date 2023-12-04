// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using System;
using System.Linq;
using Cysharp.Threading.Tasks;
using DG.Tweening;
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
        
        private LevelModel _levelModel;
        
        [Inject]
        public void Construct(LevelModel levelModel)
        {
            _levelModel = levelModel;
        }
        
        public async void Launch()
        {
            transform.DOMove(_levelModel.GetCentre(), 0.2f);
            await UniTask.Delay(TimeSpan.FromSeconds(_activationTimeout));
            var colliders = Physics2D.OverlapCircleAll(transform.position, _radius);

            var target = colliders.First();
            transform.DOMove(target.transform.position, 0.5f);
            _explosion.transform.SetParent(null);
            _explosion.gameObject.SetActive(true);
            _explosion.Explode();
            Destroy(gameObject);
        }
    }
}