// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using System.Collections.Generic;
using System.Linq;
using SibJam.Features.Info.Views;
using UnityEngine;

namespace SibJam.Features.Info.Data.Configs
{
    [CreateAssetMenu(fileName = "InfoConfig", menuName = "Config/Info config")]
    public class InfoConfig : ScriptableObject
    {
        [SerializeField] private List<WindowData> _windows;

        public WindowPresenter GetWindowByType(WindowType windowType)
        {
            return _windows.First(window => window.Type == windowType).Window;
        }
    }
}
