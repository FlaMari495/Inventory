using System.Collections.Generic;
using UnityEngine;

namespace FlMr_Inventory
{
    /// <summary>
    /// �C���x���g�����R���g���[������N���X�B
    /// �����̃A�C�e���X���b�g��ێ����A�A�C�e���̏o������s���B
    /// </summary>
    public class ItemBag : MonoBehaviour
    {
        /// <summary>
        /// �����̃X���b�g��
        /// </summary>
        [SerializeField] private int slotNumber = 10;

        /// <summary>
        /// �X���b�g�I�u�W�F�N�g�̃v���n�u
        /// </summary>
        [SerializeField] private GameObject slotPrefab;

        /// <summary>
        /// �S�ẴX���b�g�I�u�W�F�N�g
        /// </summary>
        private List<GameObject> AllSlots { get; } = new();

        void Awake()
        {
            for (int i = 0; i < slotNumber; i++)
            {
                //slotNumber �̐������X���b�g�𐶐����AItemBag�̎q�I�u�W�F�N�g�Ƃ��Ĕz�u����
                var slot = Instantiate(slotPrefab, this.transform, false);
                AllSlots.Add(slot);
            }

        }

    }
}