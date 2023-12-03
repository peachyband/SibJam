// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

namespace SibJam.Features.Player.Signals
{
    public sealed class PlayerSignal
    {
        public class LevelUp
        {
            public int Level { get; }

            public LevelUp(int level)
            {
                Level = level;
            }
        }
    }
}