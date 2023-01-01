using System.Collections.Generic;
using UnityEngine;

namespace Character.Combat
{
    public abstract class AttackBase : MonoBehaviour
    {
        public abstract void Attack(StateMachine stateMachine, float attackDamage, List<Collider2D> damagedColliders);
    }
}