using Character.Combat;
using Items;
using UnityEngine;

namespace Character
{
    // FOR SHOWCASE. SHOULD BE REMOVED
    public class ApplyWeapon : MonoBehaviour
    {
        [SerializeField] private WeaponItem weapon;
        [SerializeField] private StateMachine player;

        public void ApplyWeaponFunc()
        {
            if (weapon && player != null)
                player.ApplyWeapon(weapon);
        }
    }
}