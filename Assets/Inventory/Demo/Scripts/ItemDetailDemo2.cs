using UnityEngine;
using UnityEngine.UI;

namespace FlMr_Inventory.Demo
{
    /// <summary>
    /// ItemDetailの動作確認のためのクラス
    /// アイテムに応じたボタンを表示
    /// </summary>
    public class ItemDetailDemo2 : ItemDetailBase
    {
        [SerializeField] private Button buttonPrefabs;
        [SerializeField] private Transform buttonsTrn;

        protected internal override void OnClickCallback
            (ItemBag itemBag, ItemBase item, int number, GameObject slotObj)
        {
            // 元々あったボタンをすべて削除
            foreach (Transform trn in buttonsTrn)
            {
                Destroy(trn.gameObject);
            }

            // IUsableなアイテムがクリックされたときに表示するボタン
            if (item is IUsable usable)
            {
                var button = Instantiate(buttonPrefabs, buttonsTrn);
            }

            // IDeletableなアイテムがクリックされたときに表示するボタン
            if (item is IDeletable)
            {
                var button = Instantiate(buttonPrefabs, buttonsTrn);
            }
        }
    }
}