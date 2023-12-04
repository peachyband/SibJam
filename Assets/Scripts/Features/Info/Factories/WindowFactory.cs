// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using SibJam.Features.Info.Data;
using SibJam.Features.Info.Data.Configs;
using SibJam.Features.Info.Views;
using UnityEngine;
using Zenject;

namespace SibJam.Features.Info.Factories
{
    public class WindowFactory : IFactory<WindowType, Transform, WindowPresenter>
    {
        private readonly DiContainer _container;
        private readonly InfoConfig _infoConfig;

        public WindowFactory(DiContainer container, InfoConfig infoConfig)
        {
            _container = container;
            _infoConfig = infoConfig;
        }

        public WindowPresenter Create(WindowType type, Transform holder)
        {
            var window = _container.InstantiatePrefabForComponent<WindowPresenter>(
                _infoConfig.GetWindowByType(type));
            window.transform.SetParent(holder);
            window.RectTransform.anchoredPosition = Vector2.zero;
            return window;
        }
    }
}