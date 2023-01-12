using System;
using UnityEngine;

namespace Items
{
    [Serializable]
    public class WeaponAttackDamage
    {
        [SerializeField] private float comboAttackDamage1;
        [SerializeField] private float comboAttackDamage2;
        [SerializeField] private float comboAttackDamage3;

        public float GetAttackDamageByAttackIndex(int index)
        {
            return index switch
            {
                1 => comboAttackDamage1,
                2 => comboAttackDamage2,
                3 => comboAttackDamage3,
                _ => throw new Exception($"index {index} doesn't exits in this weapon type")
            };
        }
    }
}