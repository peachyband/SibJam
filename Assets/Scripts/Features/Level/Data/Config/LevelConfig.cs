// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using System.Collections.Generic;
using SibJam.Features.Level.Views;
using UnityEngine;

namespace SibJam.Features.Level.Data.Config
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "Config/Level config")]
    public class LevelConfig : ScriptableObject
    {
        [SerializeField] private float _pillsTimeout;
        [SerializeField] private float _grassTimeout;
        [SerializeField] private int _collectiblesToGet;
        [SerializeField] private List<CollectibleView> _collectiblePool;
        [SerializeField] private GrassView _grassView;

        public float PillsTimeout => _pillsTimeout;
        public float GrassTimeout => _grassTimeout;
        public int CollectiblesToGet => _collectiblesToGet;
        public List<CollectibleView> CollectiblePool => _collectiblePool;
        public GrassView GrassView => _grassView;
    }
}