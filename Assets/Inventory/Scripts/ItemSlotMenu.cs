using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
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
        internal void Initialize(UnityAction removeItemMethod)
        {
            // ボタンプレハブをインスタンス化
            var buttonObj = Instantiate(menuButtonPrefab, this.transform);

            // ボタンに表示するテキストを変更
            buttonObj.GetComponentInChildren<TextMeshProUGUI>().text = "Delete";

            // ボタンコンポーネントの取得
            Button button = buttonObj.GetComponent<Button>();

            // ボタンが押された際の挙動を設定
            button.onClick.AddListener(removeItemMethod);
        }

        /// <summary>
        /// テスト用メソッド(後に削除する)
        /// </summary>
        private void Test()
        {
            Debug.Log("Hello World");
        }

    }
}