using System;
using UnityEngine;

namespace Items
{
    [Serializable]
    public class WeaponAttacks
    {
        [SerializeField] private float comboAttackDamage1;
        [SerializeField] private float comboAttackDamage2;
        [SerializeField] private float comboAttackDamage3;

        public float GetAttackDamageByAttackIndex(int index)
        {
            switch (index)
            {
                case 1:
                    return comboAttackDamage1;
                case 2:
                    return comboAttackDamage2;
                case 3:
                    return comboAttackDamage3;
                default:
                    throw new Exception($"index {index} doesn't exits in this weapon type");
            }
        }
    }
}