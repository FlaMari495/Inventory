using System;
using TMPro;
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
        /// このスロットに入っているアイテムの個数を表示するテキスト
        /// </summary>
        [SerializeField] private TextMeshProUGUI numberText;

        /// <summary>
        /// スロットがクリックされた際に表示するメニュー
        /// </summary>
        [SerializeField] private GameObject menuLayoutPrefab;

        /// <summary>
        /// メニューの表示位置
        /// </summary>
        [SerializeField] private Transform menuLayoutTrn;

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

                numberText.gameObject.SetActive(number > 1);
                numberText.text = number.ToString();
            }
            else
            {
                // アイテムが空である場合
                Item = null;
                icon.sprite = null;
                icon.color = new Color(0, 0, 0, 0);

                numberText.gameObject.SetActive(false);
            }
        }

        public void OnClicked()
        {
            // このスロットにアイテムが存在している場合
            if (Item != null)
            {
                // メニューを表示する
                var menuObj = Instantiate(menuLayoutPrefab, menuLayoutTrn);
                menuObj.GetComponent<ItemSlotMenu>()
                    .Initialize(() => RemoveItemMethod(Item.UniqueId, 1));

                menuObj.transform.SetParent(GetComponentInParent<Canvas>().transform, true);
            }
        }

        /// <summary>
        /// アイテムを削除するメソッド
        /// (ItemSlotMenuクラスに渡す)
        /// </summary>
        private Func<int, int, bool> RemoveItemMethod { get; set; }

        /// <summary>
        /// ItemSlotMenuに表示する項目を設定する
        /// </summary>
        /// <param name="deleteMethod"></param>
        internal void Initialize(Func<int, int, bool> removeItemMethod)
        {
            RemoveItemMethod = removeItemMethod;
        }


    }

}