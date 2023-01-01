using UnityEngine;

namespace Character
{
    public abstract class Unit : MonoBehaviour
    {
        [SerializeField] private UnitConfig unitConfig;

        public UnitConfig Config => unitConfig;
    }
}