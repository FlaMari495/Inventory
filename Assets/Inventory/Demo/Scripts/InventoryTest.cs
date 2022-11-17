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
            // id1のアイテムを1つ追加
            bag.AddItem(1, 1);
            Debug.Log(bag.ToJson());

            // id1のアイテムを2個削除
            bag.RemoveItem(1, 2);
            Debug.Log(bag.ToJson());

            // id1のアイテムを1個削除
            bag.RemoveItem(1, 1);
            Debug.Log(bag.ToJson());
        }

    }
}