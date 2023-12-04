// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using System;
using SibJam.Features.Info.Views;
using UnityEngine;

namespace SibJam.Features.Info.Data
{
    [Serializable]
    public class WindowData
    {
        [SerializeField] private WindowType _type;
        [SerializeField] private WindowPresenter _window;

        public WindowType Type => _type;
        public WindowPresenter Window => _window;
    }
}