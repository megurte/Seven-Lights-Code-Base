using System;
using System.Collections.Generic;
using Interfaces;
using Items;
using UnityEngine;
using Zenject;
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

        private StateMachine _stateMachine;
        private Collider2D _hitCollider;
        private List<Collider2D> _collidersDamaged;
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
            _hitCollider = GetComponent<ComboCharacter>().GetHitbox();
        }
        
        public override void OnUpdate()
        {
            base.OnUpdate();
            
            _attackPressedTimer -= Time.deltaTime;

            if (Animator.GetFloat("WeaponIsActive") > 0f)
            {
                Attack();
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
            
         // TODO: Move to Attack class
        private void Attack()
        {
            var collidersToDamage = new Collider2D[10];
            var filter = new ContactFilter2D();
            var colliderCount = Physics2D.OverlapCollider(_hitCollider, filter, collidersToDamage);
            filter.useTriggers = true;
            
            for (var colliderIndex = 0; colliderIndex < colliderCount; colliderIndex++)
            {
                if (_collidersDamaged.Contains(collidersToDamage[colliderIndex]))
                    continue;
                
                var damageableTarget = collidersToDamage[colliderIndex].GetComponent<IDamageable>();

                if (damageableTarget == null)
                    continue;
                
                damageableTarget.TakeDamage(AttackDamage);
                Object.Instantiate(Weapon.GetHitEffectPrefab(), collidersToDamage[colliderIndex].transform);
                Debug.Log("Enemy Has Taken: " + AttackDamage + " Damage");
                _collidersDamaged.Add(collidersToDamage[colliderIndex]);
            }
        }
    }
}