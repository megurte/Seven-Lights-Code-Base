using Items;
using UnityEngine;
using UnityEngine.UI;

namespace Character.Inventory
{
    public class InventorySlot : MonoBehaviour
    {
        [SerializeField] private Image itemImage;
        public Item ItemData { set; get; }

        public bool IsEmpty()
        {
            return ItemData;
        }

        public void SetEmpty()
        {
            ItemData = null;
            itemImage.color = new Color(255f,255f,255f,0f);
        }
        
        public void SetItem(Item item)
        {
            ItemData = item;
            itemImage.sprite = ItemData.GetIcon();
            itemImage.color = new Color(255f,255f,255f,255f);
        }
    }
}