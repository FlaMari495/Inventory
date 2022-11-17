using UnityEngine;
using UnityEngine.UI;

namespace FlMr_Inventory
{
    /// <summary>
    /// 所持しているアイテムのアイコンを表示
    /// クリックでアイテムに対してアクションを行う
    /// 機能を実装するクラス
    /// </summary>
    internal class ItemSlot : MonoBehaviour
    {
        /// <summary>
        /// UI画像の表示を司るクラス
        /// 所持しているアイテムのアイコンを表示する
        /// </summary>
        [SerializeField] private Image icon;

        /// <summary>
        /// このスロットに入っているアイテム
        /// </summary>
        internal ItemBase Item { get; private set; }

        /// <summary>
        /// アイテムのアイコンを表示する
        /// </summary>
        /// <param name="item"></param>
        /// <param name="number"></param>
        internal void UpdateItem(ItemBase item, int number)
        {
            if (number > 0 && item != null)
            {
                // アイテムが空ではない場合
                Item = item;
                icon.sprite = item.Icon;
                icon.color = Color.white;
            }
            else
            {
                // アイテムが空である場合
                Item = null;
                icon.sprite = null;
                icon.color = new Color(0, 0, 0, 0);
            }
        }
    }

}