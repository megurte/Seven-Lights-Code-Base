using Character;
using Items;
using UnityEngine;
using Zenject;

namespace GameLoot
{
    public class Loot : MonoBehaviour
    {
        [SerializeField] private Item item;
        [SerializeField] private float obtainTimer = 1;
        private Inventory _playerInventory;
        private bool _isObtainable = default;

        [Inject]
        private void SetDependency(Inventory inventory)
        {
            _playerInventory = inventory;
        }

        private void Update()
        {
            if (obtainTimer > 0)
                obtainTimer -= Time.deltaTime;
            else
                _isObtainable = true;
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            /*if ((other.gameObject.layer & (int)Layers.PlayerLayer) == 0)
            {

            }*/

            if (other.CompareTag("Player") && _isObtainable)
            {
                _playerInventory.OnItemObtain.Invoke(item);
                Destroy(gameObject);
            }
        }
    }
}