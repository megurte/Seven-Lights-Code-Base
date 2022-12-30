using GameLoot;
using UnityEngine;
using Utils;
using Zenject;

namespace Factories
{
    public class LootFactory : MonoBehaviour, IFactory<Loot, Vector3, Loot>
    {
        private DiContainer _diContainer;

        [Inject]
        private void SetDependency(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
        
        public Loot Create(Loot loot, Vector3 position)
        {
            var newLoot = _diContainer.InstantiatePrefabAs<Loot>(loot, position);
            
            return newLoot;
        }
    }
}