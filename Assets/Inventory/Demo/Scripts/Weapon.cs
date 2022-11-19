using UnityEngine;

namespace FlMr_Inventory.Demo
{
    [CreateAssetMenu(menuName = "Item/Weapon", fileName = "Weapon")]
    public class Weapon : ItemBase, IUsable
    {
        /// <summary>
        /// �U����
        /// </summary>
        [SerializeField] private int atk;

        /// <summary>
        /// �h���
        /// </summary>
        [SerializeField] private int df;

        #region IUsable�̗v��

        public bool Check()
        {
            // �v���C���[�������ł��镐��̐��ɐ���������ꍇ
            // if(player.Instance.Weapons.Count >= 2) return false;

            return true;
        }

        public void Use()
        {
            // player.Instance.Weapons.Add(this);

            Debug.Log($"{ItemName}�𑕔����܂���!");
        }

        #endregion
    }
}