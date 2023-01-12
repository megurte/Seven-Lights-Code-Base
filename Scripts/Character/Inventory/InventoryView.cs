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
        [SerializeField] private GameObject content;
        [SerializeField] private InventorySlot slot;
        private InventoryModule _inventoryModule;
        private List<InventorySlot> _inventorySlots;
        
        public readonly UnityEvent<List<Item>> UpdateInventoryView = new UnityEvent<List<Item>>();

        [Inject]
        private void SetDependency(InventoryModule inventoryModule)
        {
            _inventoryModule = inventoryModule;
        }

        private void OnEnable()
        {
            _inventorySlots = new List<InventorySlot>();
            DrawInventory();
            UpdateInventoryView.AddListener(UpdateView);
        }
        
        private void DrawInventory()
        {
            for (var i = 0; i < _inventoryModule.GetMaxInventorySize(); i++)
            {
                _inventorySlots.Add(Instantiate(slot, content.transform));
                _inventorySlots[i].SetEmpty();
                /*var itemSlot = Instantiate(slot, content.transform);
                itemSlot.SetEmpty();
                _inventorySlots.Add(itemSlot);*/
            }
        }

        private void UpdateView(List<Item> inventoryList)
        {
            foreach (var item in inventoryList)
            {
                for (var i = 0; i < _inventorySlots.Count; i++)
                {
                    if (_inventorySlots[i].IsEmpty())
                    {
                        Destroy(_inventorySlots[i]);
                        var itemSlot = Instantiate(item, content.transform);
                        _inventorySlots[i].SetItem(itemSlot);
                    }
                }
            }
        }
    }
}