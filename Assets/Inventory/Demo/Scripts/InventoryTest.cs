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
            // 10種類が限界であるカバンに、15種類のアイテムを追加する
            for (int i = 0; i < 15; i++)
            {
                //追加に成功したか否かを表示
                Debug.Log(i + "番目のアイテム:" + bag.AddItem(i, 3));
            }

            //カバンに入っているアイテムのデータを表示
            Debug.Log(bag.ToJson());
        }

    }
}