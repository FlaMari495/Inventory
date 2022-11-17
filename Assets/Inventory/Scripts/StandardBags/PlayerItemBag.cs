using UnityEngine;

namespace FlMr_Inventory
{
    /// <summary>
    /// プレイヤーの所持アイテム
    /// </summary>
    public class PlayerItemBag : ItemBag
    {
        protected override void AddMenuFunction(ItemSlotMenuFunctions funcs)
        {
            // 使用可能なアイテムに表示するメニュー
            funcs.AddMenuItem<IUsable>("use", item =>
            {
                IUsable usable = item as IUsable;

                // 現在使用可能か判定
                if (usable.Check())
                {
                    // 効果を発動
                    usable.Use();

                    // 1個消費
                    RemoveItem(item.UniqueId, 1);
                }
            });

            // 削除可能なアイテムに表示するメニュー
            funcs.AddMenuItem<IDeletable>("Delete", item => RemoveItem(item.UniqueId, 1));

            // 全てのアイテムに表示するメニュー
            funcs.AddMenuItem<ItemBase>("Description", item => Debug.Log(item.Description));
        }
    }
}