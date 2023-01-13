using Items;
using UnityEngine;
using UnityEngine.UI;

namespace Character.Inventory
{
    public class InventorySlot : MonoBehaviour
    {
        [SerializeField] private Image itemImage;
        [SerializeField] private GameObject stackText;
        public Item ItemData { set; get; }

        public bool IsEmpty()
        {
            return !ItemData;
        }
        
        public bool IsAbleToStack()
        {
            return ItemData.GetStackSize() > 0;
        }

        public void ShowStackSize(bool show)
        {
            stackText.SetActive(show);
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