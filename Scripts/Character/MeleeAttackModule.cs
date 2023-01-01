using System.Collections.Generic;
using Character.Combat;
using Interfaces;
using Items;
using UnityEngine;

namespace Character
{
    public class MeleeAttackModule : AttackBase
    {
        public override void Attack(StateMachine stateMachine, float attackDamage, List<Collider2D> damagedColliders)
        {
            var collidersToDamage = new Collider2D[10];
            var filter = new ContactFilter2D();
            var hitCollider = stateMachine.Hitbox;
            var weapon = stateMachine.GetWeapon<MeleeWeaponItem>();
            var hitEffectPrefab = weapon.HitEffectPrefab;
            var hitSound = weapon.HitSound;
            var colliderCount = Physics2D.OverlapCollider(hitCollider, filter, collidersToDamage);
            filter.useTriggers = true;
            
            /*if (colliderCount > 0 && hitSound != null)
                hitSound.
                */
            
            for (var colliderIndex = 0; colliderIndex < colliderCount; colliderIndex++)
            {
                if (damagedColliders.Contains(collidersToDamage[colliderIndex]))
                    continue;
                
                var damageableTarget = collidersToDamage[colliderIndex].GetComponent<IDamageable>();

                if (damageableTarget == null)
                    continue;
                
                damageableTarget.TakeDamage(attackDamage);

                if (hitEffectPrefab != null)
                    Instantiate(hitEffectPrefab, collidersToDamage[colliderIndex].transform);

                Debug.Log($"Enemy Has Taken: {attackDamage} Damage");
                damagedColliders.Add(collidersToDamage[colliderIndex]);
            }
        }
    }
}