using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FlMr_Inventory.Demo
{
    public class ItemDetail : MonoBehaviour
    {
        [SerializeField] private ItemBag itemBag;
        [SerializeField] private Image itemIcon;
        [SerializeField] private TextMeshProUGUI itemNameText;

        private ItemBase Item { get; set; }

        /// <summary>
        /// スロットがクリックされたときに呼ばれるメソッド
        /// </summary>
        /// <param name="item"></param>
        /// <param name="number"></param>
        /// <param name="slotObj"></param>
        public void Show(ItemBase item,int number,GameObject slotObj)
        {
            Item = item;
            itemIcon.sprite = item.Icon;
            itemNameText.text = item.ItemName;
        }

        /// <summary>
        /// バッグに1つアイテムを加える
        /// </summary>
        public void Add()
        {
            itemBag.AddItem(Item.UniqueId, 1);
        }

        /// <summary>
        /// バッグからアイテムを1つ取り除く
        /// </summary>
        public void Remove()
        {
            itemBag.RemoveItem(Item.UniqueId, 1);
        }
    }
}
