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
        /// �X���b�g���N���b�N���ꂽ�Ƃ��ɌĂ΂�郁�\�b�h
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
        /// �o�b�O��1�A�C�e����������
        /// </summary>
        public void Add()
        {
            itemBag.AddItem(Item.UniqueId, 1);
        }

        /// <summary>
        /// �o�b�O����A�C�e����1��菜��
        /// </summary>
        public void Remove()
        {
            itemBag.RemoveItem(Item.UniqueId, 1);
        }
    }
}
