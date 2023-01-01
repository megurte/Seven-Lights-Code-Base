using Character;
using UnityEngine;

namespace Enemy
{
    public class EnemyColliderManager : MonoBehaviour
    {
        [SerializeField] private Collider2D hitbox;
        private UnitHealth _unitHealth;

        private void Start()
        {
            _unitHealth = GetComponent<UnitHealth>();
            _unitHealth.OnHealthChanged += CheckChangedHealth;
        }

        private void OnDisable()
        {
            _unitHealth.OnHealthChanged -= CheckChangedHealth;
        }

        private void CheckChangedHealth(float currentHealth)
        {
            if (currentHealth > 0) return;

            hitbox.enabled = false;
        }
    }
}