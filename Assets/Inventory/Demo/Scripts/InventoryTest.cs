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
            bag.AddItem(1, 2);
            bag.AddItem(2, 2);
            bag.AddItem(3, 2);
        }

    }
}