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
            Debug.Log(1 + "番目のアイテム:" + bag.AddItem(1, 1));

            //カバンに入っているアイテムのデータを表示
            Debug.Log(bag.ToJson());
        }

    }
}