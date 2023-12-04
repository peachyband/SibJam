// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SibJam.Features.Info.Views
{
    public abstract class ChoiceWindowPresenter : WindowPresenter
    {
        [SerializeField] private Button _positiveAnswerButton;
        [SerializeField] private Button _negativeAnswerButton;

        protected SignalBus SignalBus;

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            SignalBus = signalBus;
        }
        
        public abstract void OnPositive();

        public abstract void OnNegative();
        
        public override IObservable<Unit> OnClick()
        {
            return _positiveAnswerButton.OnClickAsObservable()
                .Merge(_negativeAnswerButton.OnClickAsObservable());
        }
    }
}