using Items;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Character.Combat
{
    public class StateMachine : MonoBehaviour
    {
        public State CurrentState { get; private set; }
        public AttackBase AttackModule { get; private set; }
        public PlayerInputService InputService { get; private set; }
        public Collider2D Hitbox { get; private set; }
        public string customName;
        private State _mainStateType;
        private State _nextState;
        private WeaponItem _weapon;
        private Unit _unit;

        private void Awake()
        {
            SetNextStateToMain();
        }
        
        private void Start()
        {
            _unit = GetComponent<Unit>();
            ApplyWeapon(_unit.Config.Weapon);
        }
        
        private void Update()
        {
            if (_nextState != null)
            {
                SetState(_nextState);
            }

            if (CurrentState != null)
                CurrentState.OnUpdate();
        }

        private void SetState(State newState)
        {
            _nextState = null;
            
            if (CurrentState != null)
            {
                CurrentState.OnExit();
            }
            
            CurrentState = newState;
            CurrentState.OnEnter(this);
        }

        private void LateUpdate()
        {
            if (CurrentState != null)
                CurrentState.OnLateUpdate();
        }

        private void FixedUpdate()
        {
            if (CurrentState != null)
                CurrentState.OnFixedUpdate();
        }

        private void OnValidate()
        {
            if (_mainStateType == null)
            {
                if (customName == "Combat")
                {
                    _mainStateType = new IdleCombatState(); 
                }
            }
        }

        public void SetNextState(State newState)
        {
            if (newState != null)
            {
                _nextState = newState;
            }
        }
        
        public void SetNextStateToMain()
        {
            _nextState = _mainStateType;
        }

        public void SetInputService(PlayerInputService inputService)
        {
            InputService = inputService;
        }
        
        public void SetHitBox(Collider2D hitbox)
        {
            Hitbox = hitbox;
        }
        
        public void ApplyWeapon(WeaponItem weaponItem)
        {
            _weapon = weaponItem;
            Debug.LogWarning($"The weapon {_weapon.GetName()} has been applied");

            if (_weapon.GetType() == typeof(MeleeWeaponItem))
                //AttackModule = gameObject.AddComponent<MeleeAttackModule>();
                AttackModule = GetComponent<MeleeAttackModule>();
        }

        public T GetWeapon<T>() where T : WeaponItem
        {
            if (_weapon.GetType() == typeof(T))
            {
                return (T)_weapon;
            }

            return null;
        } 
    }
}