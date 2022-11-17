using System.Collections.Generic;
using UnityEngine;

namespace FlMr_Inventory
{
    /// <summary>
    /// インベントリをコントロールするクラス。
    /// 複数のアイテムスロットを保持し、アイテムの出入りを行う。
    /// </summary>
    public class ItemBag : MonoBehaviour
    {
        /// <summary>
        /// 初期のスロット数
        /// </summary>
        [SerializeField] private int slotNumber = 10;

        /// <summary>
        /// スロットオブジェクトのプレハブ
        /// </summary>
        [SerializeField] private GameObject slotPrefab;

        /// <summary>
        /// 全てのスロットオブジェクト
        /// </summary>
        private List<GameObject> AllSlots { get; } = new();

        void Awake()
        {
            for (int i = 0; i < slotNumber; i++)
            {
                //slotNumber の数だけスロットを生成し、ItemBagの子オブジェクトとして配置する
                var slot = Instantiate(slotPrefab, this.transform, false);
                AllSlots.Add(slot);
            }

        }

    }
}