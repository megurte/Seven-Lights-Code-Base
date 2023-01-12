using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    public abstract class WeaponItem : Item
    {
        [SerializeField] private GameObject hitEffect;
        [SerializeField] private List<AudioClip> hitSound;

        public GameObject HitEffectPrefab => hitEffect;

        public AudioClip GetRandomHitSound()
        {
            return hitSound.Count > 0 ? hitSound[Random.Range(0, hitSound.Count - 1)] : null;
        }
    }
}