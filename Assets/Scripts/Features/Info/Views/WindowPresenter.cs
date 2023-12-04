// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using System;
using UniRx;
using UnityEngine;

namespace SibJam.Features.Info.Views
{
    public abstract class WindowPresenter : MonoBehaviour
    {
        [SerializeField] private RectTransform _rectTransform;
        
        public abstract IObservable<Unit> OnClick();

        public void Dispose()
        {
            Destroy(gameObject);
        }

        public RectTransform RectTransform => _rectTransform;
    }
}