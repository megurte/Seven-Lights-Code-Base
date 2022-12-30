using UnityEngine;

namespace Items
{
    public abstract class WeaponItem : Item
    {
        [SerializeField] private GameObject hitEffect;

        public GameObject GetHitEffectPrefab() => hitEffect;
    }
}