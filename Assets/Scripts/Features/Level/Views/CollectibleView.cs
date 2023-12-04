// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using System.Collections;
using DG.Tweening;
using SibJam.Features.Level.Signals;
using SibJam.Features.Player.Views;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace SibJam.Features.Level.Views
{
    public class CollectibleView : MonoBehaviour
    {
        [SerializeField] private Vector2 _movementThreshold;
        [SerializeField] private float _time;
        [SerializeField] private float _movementDelay;

        private SignalBus _signalBus;
        
        private Vector2 _originalPosition;

        [Inject]
        public void Construct(SignalBus signalBus, Vector2 position)
        {
            _signalBus = signalBus;
            transform.position = position;
            _originalPosition = position;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var player = other.GetComponent<PlayerBase>();
            if (player == null) return;
            
            _signalBus.TryFire<LevelSignals.PillCollected>();
            Destroy(gameObject);
        }

        private void FixedUpdate()
        {
            StartCoroutine(RandomMovement());
        }

        private IEnumerator RandomMovement()
        {
            var newPosition = new Vector2(Random.Range(_originalPosition.x, _movementThreshold.x),
                Random.Range(_originalPosition.y, _movementThreshold.y));
            
            transform.DOMove(newPosition, _time);
            yield return new WaitForSeconds(_movementDelay);
            transform.DOMove(_originalPosition, _time);
        }
    }
}