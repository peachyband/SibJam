using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject.SpaceFighter;

namespace SibJam.Features.Enemies.Configs
{
    [CreateAssetMenu(menuName ="Config/Enemy config", fileName = "NewEnemyConfig")]
    public class EnemyConfig : ScriptableObject
    {
        [field: SerializeField]
        public int Health { private set; get; }
        [field:SerializeField]
        public int Damage { private set; get;}
        [field:SerializeField]
        public float Speed { private set; get; }
        [field:SerializeField]
        public LayerMask LayerMask { private set; get; }
    }
}
