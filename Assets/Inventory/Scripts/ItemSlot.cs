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
        /// 数量
        /// </summary>
        private int Number { get; set; }

        /// <summary>
        /// このスロットに入っているアイテム
        /// </summary>
        internal ItemBase Item { get; private set; }

        /// <summary>
        /// スロットがクリックされた際に実行するメソッド
        /// [ 引数 ]
        /// ItemBase : スロットに入っているアイテム
        /// int : アイテムの個数
        /// GameObject : このスロットのオブジェクト
        /// </summary>
        private Action<ItemBase, int, GameObject> OnClickCallback { get; set; }

        /// <summary>
        /// このクラスのインスタンスが生成された際に呼ぶメソッド
        /// </summary>
        /// <param name="onClickCallback"></param>
        internal void Initialize(Action<ItemBase, int, GameObject> onClickCallback)
        {
            OnClickCallback = onClickCallback;
        }

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
                Number = number;

                // アイコンの表示
                icon.sprite = item.Icon;
                icon.color = Color.white;

                // 数量の表示
                numberText.gameObject.SetActive(number > 1);
                numberText.text = number.ToString();
            }
            else
            {
                // アイテムが空である場合
                Item = null;
                Number = 0;
                icon.sprite = null;
                icon.color = new Color(0, 0, 0, 0);

                numberText.gameObject.SetActive(false);
            }
        }

        /// <summary>
        /// スロットがクリックされたときに呼ばれるメソッド
        /// </summary>
        public void OnClicked()
        {
            //このスロットにアイテムが存在している場合
            if (Item != null)
            {
                // コールバックメソッドを実行
                OnClickCallback(Item, Number, this.gameObject);
            }
        }
    }

}