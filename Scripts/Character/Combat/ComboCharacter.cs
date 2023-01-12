using Items;
using UnityEngine;
using Zenject;

namespace Character.Combat
{
    public class ComboCharacter : MonoBehaviour
    {
        [SerializeField] private Collider2D hitbox;
        [SerializeField] private WeaponItem weapon;
        private StateMachine _meleeStateMachine;
        private CharacterMovementController _characterMovement;
        private PlayerInputService _inputService;

        [Inject]
        private void SetDependency(PlayerInputService inputService)
        {
            _inputService = inputService;
        }

        private void Start()
        {
            _meleeStateMachine = GetComponent<StateMachine>();
            _meleeStateMachine.SetInputService(_inputService);
            _meleeStateMachine.SetHitBox(hitbox);
            _meleeStateMachine.SetNextStateToMain();

            _characterMovement = GetComponent<CharacterMovementController>();
            _inputService.AttackButtonPressed += TryAttackPerform;
            _characterMovement.CharacterFlippedXDirection += ActivateHitBox;
        }
        
        private void OnDisable()
        {
            _inputService.AttackButtonPressed -= TryAttackPerform;
            _characterMovement.CharacterFlippedXDirection -= ActivateHitBox;
        }

        private void TryAttackPerform()
        {
            if (_meleeStateMachine.CurrentState.GetType() == typeof(IdleCombatState))
            {
                _meleeStateMachine.SetNextState(new EntryState());
            }
        }

        private void ActivateHitBox(bool isXAxisFlipped)
        {
            if (!isXAxisFlipped)
            {
                _meleeStateMachine.SetHitBox(hitbox);
                // SETACTIVE
                // Debug.Log("Activated right hitbox");
            }
            else
            {
                _meleeStateMachine.SetHitBox(hitbox);
                // SETACTIVE
                // Debug.Log("Activated left hitbox");
            }
        }
    }
}