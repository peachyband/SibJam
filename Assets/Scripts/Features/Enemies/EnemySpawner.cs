using SibJam.Features.Enemies.Configs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SibJam.Features.Enemies
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField]
        private EnemySpawnerConfig _config;

        [SerializeField]
        private Vector2[] _redditPoints;  


        // Start is called before the first frame update
        void Start()
        {
            Spawn();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.L)) 
            {
                OnLevelUp();
            }
        }

        private void OnLevelUp()
        {

        }

        private void Spawn()
        {
            throw new NotImplementedException();
        }

        private void SpawnReddit() 
        {

        }

       



    }
}
