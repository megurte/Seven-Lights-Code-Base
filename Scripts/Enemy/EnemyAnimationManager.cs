using Character;
using UnityEngine;

namespace Enemy
{
    public class EnemyAnimationManager : MonoBehaviour
    {
        private Animator _animator;
        private UnitHealth _unitHealth;
        private SpriteRenderer _spriteRenderer;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _unitHealth = GetComponent<UnitHealth>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
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
                _spriteRenderer.sortingLayerName = "Layer 1"; // TODO: HARDCODE REMOVE
                return;
            }
            
            _animator.SetTrigger("TakeDamage");
        }
    }
}