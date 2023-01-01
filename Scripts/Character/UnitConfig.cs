using Items;
using UnityEngine;

namespace Character
{
    [CreateAssetMenu(fileName = "New unit", menuName = "Unit/Unit")]
    public sealed class UnitConfig : ScriptableObject
    {
        [SerializeField] private string unitName;
        [SerializeField] private int health;
        [SerializeField] private WeaponItem baseWeapon;
        [SerializeField] private Unit prefab;

        public string Name => unitName;
        
        public int Health => health;
        
        public WeaponItem Weapon => baseWeapon;
        
        public Unit Prefab => prefab;
    }
}