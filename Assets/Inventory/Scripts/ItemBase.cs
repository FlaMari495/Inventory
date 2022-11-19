using UnityEngine;

namespace FlMr_Inventory
{
    [CreateAssetMenu(menuName = "Item/ItemTemp", fileName = "itemTemp")]
    public class ItemBase : ScriptableObject
    {
        [SerializeField] private int uniqueId;
        [SerializeField] private string itemName;
        [SerializeField] private Sprite icon;
        [SerializeField] private string description;

        /// <summary>
        /// �A�C�e���̎�ނ�1:1�Ή����鐮��
        /// (�f�[�^��ۑ�����Ƃ���A�����ʐM�@�\����������ۂɐ^���𔭊�����)
        /// </summary>
        public int UniqueId => uniqueId;

        /// <summary>
        /// �A�C�e����
        /// </summary>
        public string ItemName => itemName;

        /// <summary>
        /// �A�C�e���̃A�C�R��
        /// </summary>
        public Sprite Icon => icon;

        /// <summary>
        /// �v���C���[�ɑ΂���A�C�e���̐���
        /// </summary>
        public string Description => description;
    }
}