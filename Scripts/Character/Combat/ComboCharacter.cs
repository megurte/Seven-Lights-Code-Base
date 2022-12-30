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
        private PlayerInputService _inputService;

        [Inject]
        private void SetDependency(PlayerInputService inputService)
        {
            _inputService = inputService;
        }

        private void OnEnable()
        {
            _inputService.AttackButtonPressed += TryAttackPerform;
        }
        
        private void OnDisable()
        {
            _inputService.AttackButtonPressed -= TryAttackPerform;
        }
        
        private void Start()
        {
            _meleeStateMachine = GetComponent<StateMachine>();
            _meleeStateMachine.SetInputService(_inputService);
            _meleeStateMachine.SetNextStateToMain();
        }

        private void TryAttackPerform()
        {
            if (_meleeStateMachine.CurrentState.GetType() == typeof(IdleCombatState))
            {
                _meleeStateMachine.SetNextState(new EntryState());
                _meleeStateMachine.ApplyWeapon(weapon);
            }
        }

        public Collider2D GetHitbox()
        {
            return hitbox;
        }
    }
}