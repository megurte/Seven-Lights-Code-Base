using System;
using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "New Melee weapon", menuName = "Items/MeleeWeaponItem")]
    public class MeleeWeaponItem : WeaponItem
    {
        [SerializeField] public WeaponAttackDamage attackDamage;
        [SerializeField] public WeaponAttackDuration attackDuration;
    }

    [Serializable]
    public class WeaponAttackDuration
    {
        [SerializeField] private float attackDuration1;
        [SerializeField] private float attackDuration2;
        [SerializeField] private float attackDuration3;

        public float GetAttackDurationByAttackIndex(int index)
        {
            return index switch
            {
                1 => attackDuration1,
                2 => attackDuration2,
                3 => attackDuration3,
                _ => throw new Exception($"index {index} doesn't exits in this weapon type")
            };
        }
    }
}