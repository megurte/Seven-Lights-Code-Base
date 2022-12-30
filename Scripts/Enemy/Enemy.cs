using System;
using Interfaces;
using UnityEngine;
using Character;

namespace Enemy
{
    public class Enemy : Unit, IDamageable
    {
        [SerializeField] private UnitHealth unitHealth;
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void TakeDamage(float value)
        {
            unitHealth.Health -= value;
            //GetComponent<Animator>().SetTrigger();
        }
    }
}