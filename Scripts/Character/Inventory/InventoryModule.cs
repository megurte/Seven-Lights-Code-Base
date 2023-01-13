using System;
using System.Collections.Generic;
using System.Linq;
using Items;
using UnityEngine;
using UnityEngine.Events;

namespace Character.Inventory
{
    public class InventoryModule : MonoBehaviour
    {
        [SerializeField] private List<Item> inventory;
        [SerializeField] private InventoryView inventoryView;
        [SerializeField] private int inventoryMaxSize;

        public readonly UnityEvent<Item> OnItemObtain = new UnityEvent<Item>();
        public Action<Item> AddUpdateView;
        public Action<Item> RemoveUpdateView;

        private void Start()
        {
            OnItemObtain.AddListener(ObtainItem);
        }

        private void ObtainItem(Item item)
        {
            inventory.Add(item);
            AddUpdateView?.Invoke(item);
            //inventoryView.UpdateInventoryView.Invoke(inventory);
            Debug.Log($"An item {item.GetName()} has been added to inventory");
        }

        public bool CheckForItem(int itemId)
        {
            return inventory.Any(slotItem => itemId == slotItem.GetId());
        }
        
        public void RemoveItem(int itemId)
        {
            foreach (var item in inventory)
            {
                if (!item) continue;
                if (itemId != item.GetId()) continue;
                
                inventory.Remove(item);
                RemoveUpdateView?.Invoke(item);
                //inventoryView.UpdateInventoryView.Invoke(inventory);
                Debug.LogWarning($"An item with id {itemId} has been removed");
                return;
            }
            
            Debug.LogWarning($"An item with id {itemId} does not found");
        }

        public int GetMaxInventorySize() => inventoryMaxSize;
        public List<Item> GetInventoryItems() => inventory;
    }
}