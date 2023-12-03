// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using SibJam.Features.Player.Views;

namespace SibJam.Features.Player.Base
{
    public abstract class BasePlayerState
    {
        protected readonly PlayerBase Context; 
        public abstract void Move();
    }
}