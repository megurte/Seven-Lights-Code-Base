using System.Collections.Generic;
using Scene;
using UnityEngine;
using Zenject;

namespace Character.Combat
{
    public abstract class AttackBase : MonoBehaviour
    {
        protected AudioService AudioService;

        [Inject]
        protected void SetDependency(AudioService audioService)
        {
            AudioService = audioService;
        }

        public abstract void Attack(StateMachine stateMachine, float attackDamage, List<Collider2D> damagedColliders);
    }
}