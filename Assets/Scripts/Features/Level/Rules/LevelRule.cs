// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using System;
using SibJam.Features.Info.Data;
using SibJam.Features.Info.Services;
using SibJam.Features.Player.Signals;
using UniRx;
using Zenject;

namespace SibJam.Features.Level.Rules
{
    public class LevelRule : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly InfoService _infoService;
        private readonly CompositeDisposable _compositeDisposable = new ();

        private LevelRule(SignalBus signalBus, InfoService infoService)
        {
            _signalBus = signalBus;
            _infoService = infoService;
        }
        
        public void Initialize()
        {
            _signalBus.TryFire(new PlayerSignals.ToggleControls(true));
            _infoService.ShowWindow(WindowType.GreetingWindow);
        }

        public void Dispose()
        {
            _compositeDisposable?.Dispose();
        }
    }
}