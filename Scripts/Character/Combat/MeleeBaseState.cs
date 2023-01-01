using System;
using System.Collections.Generic;
using Interfaces;
using Items;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Character.Combat
{
    public class MeleeBaseState : State
    {
        protected float Duration;
        protected Animator Animator;
        protected MeleeWeaponItem Weapon;
        protected bool ShouldCombo;
        protected int AttackIndex;
        protected float AttackDamage;

        private List<Collider2D> _collidersDamaged;
        private bool _newState;
        private float _attackPressedTimer = 0;

        public override void OnEnter(StateMachine combatStateMachine)
        {
            base.OnEnter(combatStateMachine);
            
            Animator = GetComponent<Animator>();
            Weapon = combatStateMachine.GetWeapon<MeleeWeaponItem>();
            StateMachineInstance.InputService.AttackButtonPressed += ResumeAttackPressedTimer;
            
            if (Weapon == null)
            {
                throw new Exception("Unexpected weapon type for this state machine");
            }
            
            _collidersDamaged = new List<Collider2D>();
        }
        
        public override void OnUpdate()
        {
            base.OnUpdate();
            
            _attackPressedTimer -= Time.deltaTime;

            if (Animator.GetFloat("WeaponIsActive") > 0f)
            {
                StateMachineInstance.AttackModule.Attack(StateMachineInstance, AttackDamage, _collidersDamaged);
            }

            if (Animator.GetFloat("AttackWindowOpen") > 0f && _attackPressedTimer > 0)
            {
                ShouldCombo = true;
            }
        }
        
        public override void OnExit()
        {
            base.OnExit();

            StateMachineInstance.InputService.AttackButtonPressed -= ResumeAttackPressedTimer;
        }

        private void ResumeAttackPressedTimer()
        {
            _attackPressedTimer = 2;
        }
    }
}