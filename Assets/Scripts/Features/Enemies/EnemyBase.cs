using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SibJam.Features.Enemies.Configs;

namespace SibJam.Features.Enemies
{
    public abstract class EnemyBase : MonoBehaviour
    {
        [SerializeField]
        protected EnemyConfig _config;

        protected const float COOLDOWN = 1F;
        protected float _damageTimer;


        private void Update()
        {
            _damageTimer += Time.deltaTime;         
        }
    }
}
