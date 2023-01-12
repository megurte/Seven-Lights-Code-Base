using System;
using UnityEngine;
using UnityEngine.Events;

namespace Scene
{
    public class AudioService : MonoBehaviour
    {
        private AudioSource _executor;

        public readonly UnityEvent<AudioClip> OnWeaponSound = new UnityEvent<AudioClip>();

        private void Start()
        {
            _executor = GetComponent<AudioSource>();
            OnWeaponSound.AddListener(PlaySound);
        }

        private void PlaySound(AudioClip sound)
        {
            _executor.PlayOneShot(sound);
        }
    }
}