using System;
using System.Collections.Generic;
using Items;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Character.Inventory
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private Transform content;
        [SerializeField] private InventorySlot slotPrefab;
        private InventoryModule _inventoryModule;
        
        [Inject]
        private void SetDependency(InventoryModule inventoryModule)
        {
            _inventoryModule = inventoryModule;
        }

        private void OnEnable()
        {
            DrawInventory();
            _inventoryModule.AddUpdateView += AddUpdateView;
            _inventoryModule.RemoveUpdateView += RemoveUpdateView;
        }
        
        private void DrawInventory()
        {
            var startItems = _inventoryModule.GetInventoryItems();
            
            for (var i = 0; i < _inventoryModule.GetMaxInventorySize(); i++)
            {
                if (i < startItems.Count)
                {
                    var itemSlot = Instantiate(slotPrefab, content.transform);
                    itemSlot.SetItem(startItems[i]);
                }
                else
                {
                    var itemSlot = Instantiate(slotPrefab, content.transform);
                    itemSlot.SetEmpty();
                }
            }
        }
        
        private void AddUpdateView(Item item)
        {
            foreach (Transform childSlot in content)
            {
                var currentSlot = childSlot.GetComponent<InventorySlot>();
                
                if (!currentSlot.IsEmpty()) continue;
                
                currentSlot.SetItem(item);
                return;
            }
        }
        
        private void RemoveUpdateView(Item item)
        {
            foreach (Transform childSlot in content)
            {
                var currentSlot = childSlot.GetComponent<InventorySlot>();

                if (currentSlot.IsEmpty()) continue;

                if (currentSlot.ItemData.GetId() != item.GetId()) continue;
                
                currentSlot.SetEmpty();
                return;
            }
        }
    }
}