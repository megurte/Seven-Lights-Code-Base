using System;
using Interfaces;
using UnityEngine;
using Character;

namespace Enemy
{
    // TODO: split to different modules 
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