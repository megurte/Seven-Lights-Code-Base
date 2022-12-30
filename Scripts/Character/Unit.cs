using UnityEngine;

namespace Character
{
    public abstract class Unit : MonoBehaviour
    {
        [SerializeField] private UnitConfig unitConfig;

        public UnitConfig GetConfig() => unitConfig;

        private void test()
        {
            
        }
    }
}