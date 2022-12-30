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

        public string GetName() => unitName;
        
        public int GetHealth() => health;
        
        public WeaponItem GetWeapon() => baseWeapon;
        
        public Unit GetPrefab() => prefab;
    }
}