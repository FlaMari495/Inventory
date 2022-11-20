using UnityEngine;

namespace FlMr_Inventory.Demo
{
    /// <summary>
    /// ItemDetailの動作確認のためのクラス
    /// </summary>
    public class ItemDetailDemo : ItemDetailBase
    {
        protected internal override void OnClickCallback
            (ItemBag itemBag, ItemBase item, int number, GameObject slotObj)
        {
            Debug.Log($"{itemBag}内の{item.ItemName}がクリックされました。現在{number}個持っています。");
        }
    }
}
