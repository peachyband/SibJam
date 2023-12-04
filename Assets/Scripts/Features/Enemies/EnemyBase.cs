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

        public void Kill()
        {
            Destroy(gameObject);
        }
    }
}
