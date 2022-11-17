using UnityEngine;

namespace FlMr_Inventory.Demo
{
    [CreateAssetMenu(fileName = "HealingItem", menuName = "Item/HealingItem")]
    public class HealingItem : ItemBase, IUsable, IStoreItem, ICashable, IDeletable
    {
        #region IUsable�̗v��

        /// <summary>
        /// �񕜗�
        /// </summary>
        [SerializeField] private int healAmount;

        public bool Check()
        {
            // �v���C���[�̗̑͂����^���̏ꍇ�͎g�p�s��
            // if(player.Instance.Hp == player.Instance.MaxHp) return false;

            return true;
        }

        public void Use()
        {
            // player.Instance.Hp += heal;

            Debug.Log($"�̗͂�{healAmount}�񕜂���!");
        }

        #endregion


        #region IStoreItem�̗v��
        /// <summary>
        /// ���i
        /// </summary>
        [SerializeField] private int price;

        public int Price => price;

        public bool CanBuy
        {
            get
            {
                // (��)�v���C���[�����N��10�ȏ�̏ꍇ�ɍw���\
                // return player.Instance.Rank >= 10;

                return true;
            }
        }
        #endregion

        #region ICashable�̗v��
        /// <summary>
        /// ���承�i
        /// </summary>
        [SerializeField] private int sellingPrice;

        public int SellingPrice => sellingPrice;
        #endregion

    }
}