using SibJam.Features.Enemies.Configs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using Zenject;
using UniRx;
using SibJam.Features.Player.Models;
using SibJam.Features.Level.Models;


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

        private PlayerModel _playerModel;
        private LevelModel _levelModel;

        [Inject]
        void Init(PlayerModel playerModel, LevelModel levelModel) 
        {
            _playerModel = playerModel;
            _levelModel = levelModel;
        }

        // Start is called before the first frame update
        void Start()
        {
            _playerModel
                .OnLevelChange()
                .Subscribe(_ => OnLevelUp())
                .AddTo(this);

            //Spawn();
        }

        private void Update()
        {
            /*if (Input.GetKeyDown(KeyCode.L) && _curLevel < MAX_LVL) 
            {
                OnLevelUp();
            }*/
        }

        private void OnLevelUp()
        {
            DestroyEnemies();

            

            Spawn();

            _curLevel++;
        }

        private void Spawn()
        {
            SpawnReddit();
            Spawn4Chan();
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

        private void Spawn4Chan() 
        {
            for (int i = 0; i < _config.FChanPerLevelCount[_curLevel - 1]; i++)
            {
                

                Vector2 pos = _levelModel.GetRandomPositionInside();

                EnemyBase enemy =
                    Instantiate(_config.Enemy4chan, pos, Quaternion.identity);

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
