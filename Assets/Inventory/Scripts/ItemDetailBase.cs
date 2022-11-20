using UnityEngine;

namespace FlMr_Inventory
{
    public abstract class ItemDetailBase : MonoBehaviour
    {
        /// <summary>
        /// スロットがクリックされた際に呼ばれるコールバックメソッド
        /// </summary>
        /// <param name="itemBag">アイテムバッグ</param>
        /// <param name="item">スロットに入っているアイテム</param>
        /// <param name="numebr">そのアイテムの所持数</param>
        /// <param name="slotObj">スロットのゲームオブジェクト</param>
        protected internal abstract void OnClickCallback
            (ItemBag itemBag,ItemBase item, int numebr, GameObject slotObj);
    }
}