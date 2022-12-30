using System.Collections.Generic;
using System.Linq;
using Items;
using UnityEngine;
using UnityEngine.Events;

namespace Character
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private List<Item> inventory;
        
        public readonly UnityEvent<Item> OnItemObtain = new UnityEvent<Item>();

        private void Start()
        {
            OnItemObtain.AddListener(ObtainItem);
        }

        private void ObtainItem(Item item)
        {
            inventory.Add(item);
            Debug.Log($"An item {item.GetName()} has been added to inventory");
        }

        public bool CheckForItem(int itemId)
        {
            return inventory.Any(slotItem => itemId == slotItem.GetId());
        }
        
        public void RemoveItem(int itemId)
        {
            foreach (var itemSlot in inventory)
            {
                if (!itemSlot) continue;
                if (itemId != itemSlot.GetId()) continue;
                
                inventory.Remove(itemSlot);
                Debug.LogWarning($"An item with id {itemId} has been removed");
                return;
            }
            
            Debug.LogWarning($"An item with id {itemId} does not found");
        }
    }
}