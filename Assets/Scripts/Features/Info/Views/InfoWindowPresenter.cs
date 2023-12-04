// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace SibJam.Features.Info.Views
{
    public class InfoWindowPresenter : WindowPresenter
    {
        [SerializeField] private Button _agreeButton; 
        
        public override IObservable<Unit> OnClick()
        {
            return _agreeButton.OnClickAsObservable();
        }
    }
}