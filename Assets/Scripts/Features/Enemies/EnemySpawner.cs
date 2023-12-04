using SibJam.Features.Enemies.Configs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SibJam.Features.Enemies
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField]
        private EnemySpawnerConfig _config;

        [SerializeField]
        private Transform[] _redditPoints;

        public Vector2 TopRight;
        public Vector2 TopLeft;
        public Vector2 BottomRight;
        public Vector2 BottomLeft;



        private Queue<EnemyBase> _curEnemies = new();
        private int _curLevel = 1;

        private const int MAX_LVL = 3;


        // Start is called before the first frame update
        void Start()
        {
            Spawn();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.L) && _curLevel < MAX_LVL) 
            {
                OnLevelUp();
            }
        }

        private void OnLevelUp()
        {
            DestroyEnemies();

            _curLevel++;

            Spawn();
        }

        private void Spawn()
        {
            SpawnReddit();
        }

        private void SpawnReddit() 
        {
            for (int i = 0;  i < _config.RedditPerLevelCount[_curLevel-1]; i++) 
            {
                //Vector2 rnd = new Vector2(Random.Range(BottomLeft.x, BottomRight.x),
                //   Random.Range(BottomRight.y, TopRight.y));



                Vector2 pos = _redditPoints[i].position; 

                EnemyBase enemy = 
                    Instantiate (_config.EnemyReddit, pos, Quaternion.identity);

                _curEnemies.Enqueue(enemy);

            }
        }
        private void DestroyEnemies() 
        {
            while (_curEnemies.Count > 0)
            { 
                EnemyBase obj = _curEnemies.Dequeue();
                Destroy(obj.gameObject);
            }
        }

       



    }
}
