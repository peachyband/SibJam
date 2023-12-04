// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using System.Collections.Generic;
using SibJam.Base;
using SibJam.Features.Level.Signals;
using UnityEngine;
using Zenject;

namespace SibJam.Features.Level.Views
{
    public class GrassView : MonoBehaviour, IInteractable
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private List<Sprite> _growPath;
        
        private SignalBus _signalBus;

        private int _growAge;
        
        [Inject]
        public void Construct(Vector2 position, SignalBus signalBus)
        {
            transform.position = position;
            _signalBus = signalBus;
        }

        public void Grow()
        {
            if (_growAge >= _growPath.Count - 1) return;
            _growAge += 1;
            _spriteRenderer.sprite = _growPath[_growAge];
        }
        
        public void Interact()
        {
            if (_growAge + 1 != _growPath.Count) return;
            _signalBus.TryFire<LevelSignals.GrassTouched>();
        }

        public int GrowCount => _growPath.Count;

        public void Dispose()
        {
            Destroy(gameObject);
        }
    }
}