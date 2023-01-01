using UnityEngine;

namespace Items
{
    public abstract class WeaponItem : Item
    {
        [SerializeField] private GameObject hitEffect;
        [SerializeField] private AudioClip hitSound;

        public GameObject HitEffectPrefab => hitEffect;
        public AudioClip HitSound => hitSound;
    }
}