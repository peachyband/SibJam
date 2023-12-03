// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace SibJam.Bootstrap
{
    [CreateAssetMenu(fileName = "ConfigInstaller", menuName = "Installer/ConfigInstaller")]
    public class ConfigInstaller : ScriptableObjectInstaller<ConfigInstaller>
    {
        [SerializeField] private List<ScriptableObject> _configs;

        public override void InstallBindings()
        {
            foreach (var config in _configs)
            {
                InstallConfig(config.GetType(), config);
            }
        }
        
        private void InstallConfig(Type contractType, ScriptableObject config)
        {
            Container.BindInterfacesAndSelfTo(contractType)
                .FromScriptableObject(config)
                .AsSingle();
        }
    }
}