using System;
using System.Collections.Generic;
using UnityEngine;

namespace FlMr_Inventory
{
    /// <summary>
    /// インベントリをコントロールするクラス。
    /// 複数のアイテムスロットを保持し、アイテムの出入りを行う。
    /// </summary>
    public class ItemBag : MonoBehaviour
    {
        /// <summary>
        /// 初期のスロット数
        /// </summary>
        [SerializeField] private int slotNumber = 10;

        /// <summary>
        /// スロットオブジェクトのプレハブ
        /// </summary>
        [SerializeField] private GameObject slotPrefab;

        /// <summary>
        /// 全てのスロットオブジェクト
        /// </summary>
        private List<GameObject> AllSlots { get; } = new();

        /// <summary>
        /// 現在所持しているアイテムの情報
        /// </summary>
        private ItemBagData Data { get; set; } = new();

        void Awake()
        {
            for (int i = 0; i < slotNumber; i++)
            {
                //slotNumber の数だけスロットを生成し、ItemBagの子オブジェクトとして配置する
                var slot = Instantiate(slotPrefab, this.transform, false);
                AllSlots.Add(slot);
            }

        }

        /// <summary>
        /// アイテムをバッグに追加する
        /// </summary>
        /// <param name="itemBase">追加したいアイテムのID</param>
        /// <param name="number">追加したい個数</param>
        /// <returns>バッグへの追加に成功したか</returns>
        public bool AddItem(int itemId, int number)
        {
            if (!Data.Ids.Contains(itemId) && Data.Ids.Count == slotNumber)
            {
                // スロットが埋まっている状態では、未所持アイテムの追加は出来ない
                return false;
            }

            // アイテムをバッグに追加する
            Data.Add(itemId, number);
            return true;
        }


        /// <summary>
        /// ItemBagDataをシリアル化する
        /// </summary>
        /// <returns></returns>
        public string ToJson() => JsonUtility.ToJson(Data);


        /// <summary>
        /// 核となるデータ
        /// </summary>
        [Serializable]
        private class ItemBagData
        {
            /// <summary>
            /// 所持しているアイテムのId
            /// </summary>
            public List<int> Ids = new List<int>();

            /// <summary>
            /// 所持数
            /// </summary>
            public List<int> Qty = new List<int>();

            /// <summary>
            /// バッグに追加する
            /// </summary>
            /// <param name="id">追加するアイテムのid</param>
            /// <param name="number">追加する個数</param>
            public void Add(int id, int number)
            {
                // アイテム番号=id のアイテムが既にバッグ内に存在するか
                // 存在するなら何番目のスロットに入っているか
                int index = Ids.IndexOf(id);
                if (index < 0)
                {
                    // 未所持のアイテムの場合は、スロットを1つ消費する
                    Ids.Add(id);

                    //個数の更新
                    Qty.Add(number);
                }
                else
                {
                    // 既に所持しているアイテムの場合は、所持数のみを追加
                    Qty[index] += number;
                }
            }

            /// <summary>
            /// バッグから取り出す
            /// </summary>
            /// <param name="id">取り出したいアイテムのid</param>
            /// <param name="number">取り出す個数</param>
            public void Remove(int id, int number)
            {
                // アイテム番号=id のアイテムが既にバッグ内に存在するか
                // 存在するなら何番目のスロットに入っているか
                int index = Ids.IndexOf(id);
                if (index < 0)
                {
                    // 未所持のアイテムをどり出すことは出来ない
                    throw new Exception($"アイテム(id:{id})の取り出しに失敗しました");
                }
                else
                {
                    if (Qty[index] < number)
                    {
                        // 必要数所持していない
                        throw new Exception($"アイテム(id:{id})の取り出しに失敗しました");
                    }
                    else
                    {
                        //取り出す
                        Qty[index] -= number;

                        if (Qty[index] == 0)
                        {
                            // 0個になった場合はリストから削除
                            Qty.RemoveAt(index);
                            Ids.RemoveAt(index);
                        }
                    }
                }
            }
        }

    }
}