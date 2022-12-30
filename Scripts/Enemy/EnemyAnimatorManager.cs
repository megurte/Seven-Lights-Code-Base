using System;
using Character;
using Unity.VisualScripting;
using UnityEngine;

namespace Enemy
{
    public class EnemyAnimatorManager : MonoBehaviour
    {
        private Animator _animator;
        private UnitHealth _unitHealth;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _unitHealth = GetComponent<UnitHealth>();
            _unitHealth.OnHealthChanged += CheckChangedHealth;
        }

        private void OnDisable()
        {
            _unitHealth.OnHealthChanged -= CheckChangedHealth;
        }

        private void CheckChangedHealth(float currentHealth)
        {
            if (currentHealth == 0)
            {
                _animator.SetBool("IsDead", true);
                return;
            }
            
            _animator.SetTrigger("TakeDamage");
        }
    }
}