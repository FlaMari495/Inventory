using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq;

namespace FlMr_Inventory.Demo
{
    public class ItemDetail : MonoBehaviour
    {
        [SerializeField] private ItemBag itemBag;
        [SerializeField] private Image itemIcon;
        [SerializeField] private TextMeshProUGUI itemNameText;
        private CanvasGroup canvasGroup;

        private ItemBase Item { get; set; }

        public bool IsShow { get; private set; }

        private void Start()
        {
            canvasGroup = this.GetComponent<CanvasGroup>();

            // 初期は非表示
            Hide();
        }

        /// <summary>
        /// 非表示にする
        /// </summary>
        public void Hide()
        {
            // 不透明度0 & クリック不可
            canvasGroup.alpha = 0;
            canvasGroup.blocksRaycasts = false;
            IsShow = false;
        }

        /// <summary>
        /// スロットがクリックされたときに呼ばれるメソッド
        /// </summary>
        /// <param name="item"></param>
        /// <param name="number"></param>
        /// <param name="slotObj"></param>
        public void Show(ItemBase item,int number,GameObject slotObj)
        {
            // 不透明度1 & クリック可
            canvasGroup.alpha = 1;
            canvasGroup.blocksRaycasts = true;
            IsShow = true;

            Item = item;
            itemIcon.sprite = item.Icon;
            itemNameText.text = item.ItemName;
        }

        /// <summary>
        /// バッグに1つアイテムを加える
        /// </summary>
        public void Add()
        {
            itemBag.AddItem(Item.UniqueId, 1);
        }

        /// <summary>
        /// バッグからアイテムを1つ取り除く
        /// </summary>
        public void Remove()
        {
            itemBag.RemoveItem(Item.UniqueId, 1);
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
                    Hide();
                }
            }

            if(IsShow)
            {
                if(itemBag.Find(Item) == 0)
                {
                    Hide();
                }
            }
        }
    }
}
