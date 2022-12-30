using System;
using UnityEngine;

namespace Character
{
    public class UnitHealth : MonoBehaviour
    {
        [SerializeField] private Unit unit;
        private float _health;

        public event Action<float> OnHealthChanged;
        public float MaxHealth { get; set; }
        public float Health
        {
            get => _health;
            set
            {
                _health = Mathf.Clamp(value, 0f, MaxHealth);
                OnHealthChanged?.Invoke(_health);
            }
        }

        private void Awake()
        {
            Initialize();
        }
        
        private void Initialize()
        {
            MaxHealth = unit.GetConfig().GetHealth();
            _health = MaxHealth;
        }
    }
}