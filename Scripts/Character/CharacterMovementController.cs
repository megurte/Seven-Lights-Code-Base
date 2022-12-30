using System;
using UnityEngine;
using Zenject;

namespace Character
{
    public class CharacterMovementController : MonoBehaviour
    {
        [SerializeField] private float speed;
        private PlayerInputService _inputService;
        private Animator _animator;
        private SpriteRenderer _renderer;
        private Rigidbody2D _rigidbody2D;
        private Vector2 _moveVector;

        [Inject]
        private void SetDependency(PlayerInputService inputService)
        {
            _inputService = inputService;
        }

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _renderer = GetComponent<SpriteRenderer>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (_inputService.GetHorizontalAxisValue() > 0)
            {
                _renderer.flipX = false;
            }
            
            else if (_inputService.GetHorizontalAxisValue() < 0)
            {
                _renderer.flipX = true;
            }

            if (_inputService.IsMovementControlKeysDown())
            {
                MovePlayer();
            }
            else
            {
                _rigidbody2D.velocity = Vector2.zero;
                _animator.SetBool("IsMoving", false);
            }
        }
        
        private void MovePlayer()
        {
            var moveInput = new Vector2(_inputService.GetHorizontalAxisValue(), _inputService.GetVerticalAxisValue());

            _moveVector = moveInput.normalized * speed;
            _rigidbody2D.velocity = _moveVector;
            _animator.SetBool("IsMoving", true);
        }
    }
}
