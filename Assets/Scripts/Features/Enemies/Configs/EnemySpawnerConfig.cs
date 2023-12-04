using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SibJam.Features.Enemies.Configs
{
    [CreateAssetMenu(menuName ="Config/EnemySpawner config", fileName = "NewEnemySpawnerConfig")]
    public class EnemySpawnerConfig : ScriptableObject
    {
        [field:SerializeField]
        public EnemyReddit EnemyReddit { get; private set; }
        [field: SerializeField]
        public int[] RedditPerLevelCount { get; private set; }

        [field:SerializeField]
        public Enemy4chan Enemy4chan { get; private set;}
        [field: SerializeField]
        public int[] FChanPerLevelCount { get; private set; }

        
    }
}
