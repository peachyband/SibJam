using SibJam.Features.Player.Views;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SibJam.Features.Enemies
{
    public class Enemy4chan : EnemyBase
    {
        [SerializeField]
        private Rigidbody2D _rigidbody;

        [SerializeField]
        private List<Vector3> _points = new();

        private int _index = 0;

        // Update is called once per frame
        void FixedUpdate()
        {
            _rigidbody.position = Vector3.MoveTowards(_rigidbody.position, 
                _points[_index], _config.Speed * Time.deltaTime);

            if (Vector3.Distance(_rigidbody.position, _points[_index]) < 0.01f)
            {
                //print("Boom");
                _index++;
            }
            //_index++;

            if (_index > _points.Count - 1) 
            {
                _index = 0;
            }
 
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            var player = other.GetComponent<PlayerBase>();
            if (player == null) return;

            if (!(_damageTimer >= COOLDOWN)) return;
            player.TakeDamage(_config.Damage);
            _damageTimer = 0f;
        }
    }
}
