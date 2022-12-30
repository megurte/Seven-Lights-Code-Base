using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "New Melee weapon", menuName = "Items/MeleeWeaponItem")]
    public class MeleeWeaponItem : WeaponItem
    {
        public WeaponAttacks attacks;
    }
}