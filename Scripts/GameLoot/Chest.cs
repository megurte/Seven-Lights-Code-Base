using System.Collections.Generic;
using Character;
using Character.Inventory;
using Factories;
using Interfaces;
using Items;
using NaughtyAttributes;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace GameLoot
{
    public class Chest : MonoBehaviour, IInteractable
    {
        [SerializeField] private bool isOpened;
        [SerializeField] private bool isKeyRequired;
        [SerializeField][ShowIf("isKeyRequired")] 
        private Item key;
        
        [SerializeField] private List<LootSettings> lootSettings = new List<LootSettings>();
        [SerializeField] private Sprite openedSprite;
        private SpriteRenderer _renderer;
        private InventoryModule _inventory;
        private LootFactory _factory;

        [Inject]
        private void SetDependency(LootFactory factory, InventoryModule inventory)
        {
            _factory = factory;
            _inventory = inventory;
        }

        private void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();
        }
        
        public void ReleaseAction()
        {
            if (isOpened) return;

            if (isKeyRequired)
            {
                if (!_inventory.CheckForItem(key.GetId())) return;
                
                _inventory.RemoveItem(key.GetId());
                OpenChest();
            }
            else
            {
                OpenChest();
            }
        }

        private void OpenChest()
        {
            if (openedSprite != null)
                _renderer.sprite = openedSprite;
            
            isOpened = true;
            GenerateLoot();
        }

        private void GenerateLoot()
        {
            foreach (var settings in lootSettings)
            {
                for (var i = 0; i < settings.count; i++)
                {
                    if (settings.chance < Random.Range(0, 1f)) 
                        continue;

                    var position = transform.position;
                    position = new Vector3(position.x + Random.Range(-0.5f, 0.5f),
                        position.y + Random.Range(-0.5f, 0.5f), 0);
                    _factory.Create(settings.loot, position);
                }
            }
        }
    }
}