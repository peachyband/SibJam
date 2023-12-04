// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using System.Collections;
using System.Linq;
using DG.Tweening;
using SibJam.Base;
using SibJam.Features.Player.Models;
using UniRx;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace SibJam.Features.Player.Views
{
    public abstract class PlayerBase : MonoBehaviour
    {
        private static readonly int MaxJumps = 2;
        public bool Invincible => _model.Invincible;

        [SerializeField] private CircleCollider2D _interactionCollider;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Animator _animator;
        [SerializeField] private SpriteRenderer _renderer;
        
        private PlayerModel _model;
        private float _originalGravity;
        private int _jumpCount; 
        
        private bool _isDashing;
        
        private static readonly int Health = Animator.StringToHash("Health");
        private static readonly int JumpPath = Animator.StringToHash("JumpPath");
        private static readonly int Speed = Animator.StringToHash("Speed");

        [Inject]
        protected void Construct(PlayerModel model)
        {
            _model = model;
        }
        
        protected void Awake()
        {
            _originalGravity = _rigidbody.gravityScale;
            
            _model.OnJump += Jump;
            _model.OnDash += MakeDash;
            _model.OnInteract += Interact;
            _model.OnDeath += () => Destroy(gameObject);

            _model
                .OnLevelChange()
                .Where(level => level >= 0)
                .Subscribe(_ =>
                {
                    _animator.runtimeAnimatorController =
                        _model.PlayerSetting.AnimatorController;

                    _audioSource.clip = _model.PlayerSetting.LevelUpSound;
                    _audioSource.Play();
                })
                .AddTo(this);

            _model
                .OnHealthChange()
                .Subscribe()
                .AddTo(this);

            _model
                .OnHealthChange()
                .Subscribe(health => _animator.SetInteger(Health, health))
                .AddTo(this);

        }

        public async void TakeDamage(int damage)
        {
            _audioSource.clip = _model.PlayerSetting.HurtSound;
            _audioSource.Play();
            await _model.TakeDamage(damage);
            _renderer.DOColor(Color.red, 0.1f);
            _renderer.DOColor(Color.white, 0.1f);
        }
        
        private void FixedUpdate()
        {
            if (IsGrounded())
            {
                _jumpCount = MaxJumps;
                _animator.SetInteger(JumpPath, 0);
            }

            if (_rigidbody.velocity.y > 0f)
                _animator.SetInteger(JumpPath, 1);
            else if (_rigidbody.velocity.y < 0f)
            {
                _animator.SetInteger(JumpPath, 2);
                _audioSource.clip = _model.PlayerSetting.FallSound;
                _audioSource.Play();
            }
            
            if (_isDashing) return;
            _rigidbody.velocity = new Vector2(_model.MoveDirection * _model.GetSpeed(),
                _rigidbody.velocity.y);
            transform.localScale = Mathf.Sign(_model.MoveDirection) * Vector2.right + Vector2.up;
            _animator.SetFloat(Speed, Mathf.Abs(_rigidbody.velocity.x));
        }

        private void Jump()
        {
            if (_jumpCount <= 1 && !IsGrounded()) return;
            
            _jumpCount -= 1;
            var direction = Vector2.right * _model.MoveDirection + 
                            Vector2.up * _model.PlayerSetting.JumpForce;
            _rigidbody.AddForce(direction, ForceMode2D.Impulse);
            _audioSource.clip = _model.PlayerSetting.JumpSound;
            _audioSource.Play();
        }

        private void Interact()
        {
            var other = Physics2D.OverlapCircleAll(_interactionCollider.transform.position,
                _interactionCollider.radius);

            if (other == null) return;

            var interaction = other.Select(collision => collision.GetComponent<IInteractable>())
                .First(interaction => interaction != null);

            interaction.Interact();
            _audioSource.clip = _model.PlayerSetting.InteractionSound;
            _audioSource.Play();
        }
        
        private void MakeDash()
        {
            StartCoroutine(Dash());
        }
        
        private IEnumerator Dash()
        {
            if (_model.PlayerSetting.DashTime == 0f) yield break;
            _isDashing = true;
            var direction = _model.MoveDirection;
            _rigidbody.gravityScale = 0f;
            _rigidbody.velocity = new Vector2(direction * _model.PlayerSetting.DashSpeed, 0f);
            _audioSource.clip = _model.PlayerSetting.DashSound;
            _audioSource.Play();
            yield return new WaitForSeconds(_model.PlayerSetting.DashTime);
            _rigidbody.gravityScale = _originalGravity;
            _isDashing = false;
        }

        private bool IsGrounded()
        {
            return Physics2D.OverlapCircle(_groundCheck.position, 0.4f, _groundLayer);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(_groundCheck.position, 0.4f);
        }
    }
}