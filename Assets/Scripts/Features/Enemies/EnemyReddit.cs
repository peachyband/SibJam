using SibJam.Features.Player.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SibJam.Features.Enemies
{
    public sealed class EnemyReddit : EnemyBase
    {

        [SerializeField]
        private Rigidbody2D _rigidbody;
        [SerializeField]
        private Animator _animator;
        [SerializeField]
        private BoxCollider2D _boxCollider;
        [SerializeField]
        private Collider2D _sonarCollider;

        private const float VRAY_LEN = 0.1f;
       

        private Vector2 _vRayPoint;

        private int _dir = 1;

        // Start is called before the first frame update
        void Start()
        {
            _vRayPoint = new Vector2
            (
                _boxCollider.bounds.max.x,
                _boxCollider.bounds.min.y
            );
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            float rayX = _dir == 1
                ? _boxCollider.bounds.max.x 
                : _boxCollider.bounds.min.x;

            _vRayPoint = new Vector2
            (
                rayX,
                _boxCollider.bounds.min.y
            );

            RaycastHit2D hit = 
                Physics2D.Raycast(_vRayPoint, Vector2.down, VRAY_LEN, _config.LayerMask.value);

           
            if (!hit || _sonarCollider.IsTouchingLayers(_config.LayerMask.value))
            {
                
                _dir *= -1;
                Flip();
            }
           

            Vector2 newVelocity = new Vector2(_config.Speed * _dir, _rigidbody.velocity.y);
            _rigidbody.velocity = newVelocity;
        }

        /*private void Update()
        {
            
        }*/

        private void Flip()
        {

            Vector3 newScale = new Vector3
            (
                -transform.localScale.x,
                transform.localScale.y,
                transform.localScale.z
            );
            transform.localScale = newScale;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.white;
            Vector2 from = new Vector2
            (
                _boxCollider.bounds.max.x,
                _boxCollider.bounds.min.y
            );
            Vector2 to = new Vector2(from.x, from.y - VRAY_LEN);

            Gizmos.DrawLine(from, to);
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            var player = other.gameObject.GetComponent<PlayerBase>();
            if (player == null) return;

            if (!(_damageTimer >= COOLDOWN)) return;
            player.TakeDamage(_config.Damage);
            _damageTimer = 0f;
        }


    }
}
