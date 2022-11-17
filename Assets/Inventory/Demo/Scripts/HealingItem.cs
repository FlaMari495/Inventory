using UnityEngine;

namespace FlMr_Inventory.Demo
{
    [CreateAssetMenu(fileName = "HealingItem", menuName = "Item/HealingItem")]
    public class HealingItem : ItemBase, IUsable, IStoreItem, ICashable, IDeletable
    {
        #region IUsableの要請

        /// <summary>
        /// 回復量
        /// </summary>
        [SerializeField] private int healAmount;

        public bool Check()
        {
            // プレイヤーの体力が満タンの場合は使用不可
            // if(player.Instance.Hp == player.Instance.MaxHp) return false;

            return true;
        }

        public void Use()
        {
            // player.Instance.Hp += heal;

            Debug.Log($"体力を{healAmount}回復した!");
        }

        #endregion


        #region IStoreItemの要請
        /// <summary>
        /// 価格
        /// </summary>
        [SerializeField] private int price;

        public int Price => price;

        public bool CanBuy
        {
            get
            {
                // (例)プレイヤーランクが10以上の場合に購入可能
                // return player.Instance.Rank >= 10;

                return true;
            }
        }
        #endregion

        #region ICashableの要請
        /// <summary>
        /// 買取価格
        /// </summary>
        [SerializeField] private int sellingPrice;

        public int SellingPrice => sellingPrice;
        #endregion

    }
}