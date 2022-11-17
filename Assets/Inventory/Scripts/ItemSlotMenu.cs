using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace FlMr_Inventory
{
    /// <summary>
    /// アイテムスロットがクリックされた際に表示するメニュー
    /// </summary>
    internal class ItemSlotMenu : MonoBehaviour
    {
        /// <summary>
        /// メニュー内に表示するボタンのプレハブ
        /// </summary>
        [SerializeField] private GameObject menuButtonPrefab;

        /// <summary>
        /// メニューにボタンを配置する
        /// </summary>
        internal void Initialize(ItemBase slotItem, ItemSlotMenuFunctions menuMethods)
        {
            foreach (var menu in menuMethods.MenuItems)
            {
                // ボタンプレハブをインスタンス化
                var buttonObj = Instantiate(menuButtonPrefab, this.transform);

                // ボタンに表示するテキストを変更
                buttonObj.GetComponentInChildren<TextMeshProUGUI>().text = menu.menuName;

                // ボタンコンポーネントの取得
                Button button = buttonObj.GetComponent<Button>();

                // ボタンが押された際の挙動を設定
                button.onClick.AddListener(() =>
                {
                    menu.function(slotItem);
                    Destroy(this.gameObject);
                });
            }
        }

        /// <summary>
        /// 毎フレーム呼ばれるメソッド
        /// </summary>
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                // クリックが検出されたとき

                // マウスイベントの生成
                var eventData = new PointerEventData(EventSystem.current)
                { position = Input.mousePosition };

                // この変数にRayを飛ばした結果が代入される
                var result = new List<RaycastResult>();

                // Rayを飛ばす
                EventSystem.current.RaycastAll(eventData, result);

                if (!result.Any(r => r.gameObject == this.gameObject))
                {
                    // カーソル位置にメニューが存在しなかった場合はメニューを閉じる
                    Destroy(this.gameObject);
                }
            }
        }

    }
}