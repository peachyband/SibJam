// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using System;
using Zenject;
using UnityEngine;

namespace SibJam.Bootstrap
{
    public class MainInstaller : MonoInstaller
    {
       
        public override void InstallBindings()
        {

            SignalBusInstaller.Install(Container);
        } 
    }
}