// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

namespace SibJam.Features.Player.Signals
{
    public sealed class PlayerSignals
    {
        public class ToggleControls
        {
            public bool Value { get; }

            public ToggleControls(bool value)
            {
                Value = value;
            }
        }
    }
}