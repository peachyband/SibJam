// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using SibJam.Features.Level.Signals;

namespace SibJam.Features.Info.Views
{
    public class EndChoiceWindow : ChoiceWindowPresenter
    {
        public override void OnPositive()
        {
            SignalBus.TryFire<LevelSignals.RestartLevel>();
        }

        public override void OnNegative()
        {
            SignalBus.TryFire<LevelSignals.ToMenu>();
        }
    }
}