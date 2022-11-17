using UnityEngine;
using UnityEngine.UI;

namespace FlMr_Inventory
{
    /// <summary>
    /// �������Ă���A�C�e���̃A�C�R����\��
    /// �N���b�N�ŃA�C�e���ɑ΂��ăA�N�V�������s��
    /// �@�\����������N���X
    /// </summary>
    internal class ItemSlot : MonoBehaviour
    {
        /// <summary>
        /// UI�摜�̕\�����i��N���X
        /// �������Ă���A�C�e���̃A�C�R����\������
        /// </summary>
        [SerializeField] private Image icon;

        /// <summary>
        /// ���̃X���b�g�ɓ����Ă���A�C�e��
        /// </summary>
        internal ItemBase Item { get; private set; }

        /// <summary>
        /// �A�C�e���̃A�C�R����\������
        /// </summary>
        /// <param name="item"></param>
        /// <param name="number"></param>
        internal void UpdateItem(ItemBase item, int number)
        {
            if (number > 0 && item != null)
            {
                // �A�C�e������ł͂Ȃ��ꍇ
                Item = item;
                icon.sprite = item.Icon;
                icon.color = Color.white;
            }
            else
            {
                // �A�C�e������ł���ꍇ
                Item = null;
                icon.sprite = null;
                icon.color = new Color(0, 0, 0, 0);
            }
        }
    }

}