// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using SibJam.Features.Level.Signals;
using SibJam.Features.Player.Views;
using UnityEngine;
using Zenject;

namespace SibJam.Features.Level.Views
{
    public class CollectibleView : MonoBehaviour
    {
        [SerializeField] private float _amplitude;
        [SerializeField] private float _frequency;

        private SignalBus _signalBus;
        
        private Vector2 _originalPosition;
        private float _movementTimer;

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

        private void Update()
        {
            _movementTimer += Time.deltaTime;
            var offset = _amplitude * Mathf.Sin(_movementTimer * _frequency);
            transform.position = _originalPosition + offset * Vector2.up;
        }
    }
}