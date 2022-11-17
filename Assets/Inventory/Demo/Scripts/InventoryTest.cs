using UnityEngine;

namespace FlMr_Inventory.Demo
{
    public class InventoryTest : MonoBehaviour
    {
        /// <summary>
        /// 動作確認の対象であるItemBag
        /// </summary>
        [SerializeField] private ItemBag bag;

        void Start()
        {
            // id1のアイテムを2つ追加
            bag.AddItem(1, 2);
        }

    }
}