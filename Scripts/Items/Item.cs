using Common;
using GameLoot;
using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Items/Item")]
    public class Item : ScriptableObjectBase
    {
        [SerializeField] private string itemName;
        [SerializeField] private string description;
        [SerializeField] private ItemRarity itemRarity;
        [SerializeField] private Sprite icon;

        public string GetName() => itemName;

        public string GetDescription() => description;

        public ItemRarity GetRarity() => itemRarity;

        public Sprite GetIcon() => icon;
    }
}