using System;
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
        private List<ItemSlot> AllSlots { get; } = new();

        /// <summary>
        /// ���ݏ������Ă���A�C�e���̏��
        /// </summary>
        private ItemBagData Data { get; set; } = new();

        void Awake()
        {
            for (int i = 0; i < slotNumber; i++)
            {
                //slotNumber �̐������X���b�g�𐶐����AItemBag�̎q�I�u�W�F�N�g�Ƃ��Ĕz�u����
                var slot = Instantiate(slotPrefab, this.transform, false);
                AllSlots.Add(slot.GetComponent<ItemSlot>());
            }

            UpdateItem();
        }

        /// <summary>
        /// �X���b�g�̕\���Ə����A�C�e���̏�����v������
        /// </summary>
        private void UpdateItem()
        {
            // �v���W�F�N�g�ɑ��݂���S�A�C�e��
            ItemBase[] allItems = Resources.LoadAll<ItemBase>("");

            for (int i = 0; i < Data.Ids.Count; i++)
            {
                // �ǉ��������A�C�e����id
                int itemId = Data.Ids[i];

                // �S�A�C�e������itemId�����A�C�e������������
                // �� ��ɏC��
                ItemBase addingItem = Array.Find(allItems, item => item.UniqueId == itemId);

                // �A�C�e����\��
                AllSlots[i].UpdateItem(addingItem, Data.Qty[i]);
            }

            for (int i = Data.Ids.Count; i < slotNumber; i++)
            {
                // �c��͋�
                AllSlots[i].UpdateItem(null, -1);
            }
        }

        /// <summary>
        /// �A�C�e�����o�b�O�ɒǉ�����
        /// </summary>
        /// <param name="itemBase">�ǉ��������A�C�e����ID</param>
        /// <param name="number">�ǉ���������</param>
        /// <returns>�o�b�O�ւ̒ǉ��ɐ���������</returns>
        public bool AddItem(int itemId, int number)
        {
            if (!Data.Ids.Contains(itemId) && Data.Ids.Count == slotNumber)
            {
                // �X���b�g�����܂��Ă����Ԃł́A�������A�C�e���̒ǉ��͏o���Ȃ�
                return false;
            }

            // �A�C�e�����o�b�O�ɒǉ�����
            Data.Add(itemId, number);

            UpdateItem();
            return true;
        }


        /// <summary>
        /// ItemBagData���V���A��������
        /// </summary>
        /// <returns></returns>
        public string ToJson() => JsonUtility.ToJson(Data);


        /// <summary>
        /// �j�ƂȂ�f�[�^
        /// </summary>
        [Serializable]
        private class ItemBagData
        {
            /// <summary>
            /// �������Ă���A�C�e����Id
            /// </summary>
            public List<int> Ids = new List<int>();

            /// <summary>
            /// ������
            /// </summary>
            public List<int> Qty = new List<int>();

            /// <summary>
            /// �o�b�O�ɒǉ�����
            /// </summary>
            /// <param name="id">�ǉ�����A�C�e����id</param>
            /// <param name="number">�ǉ������</param>
            public void Add(int id, int number)
            {
                // �A�C�e���ԍ�=id �̃A�C�e�������Ƀo�b�O���ɑ��݂��邩
                // ���݂���Ȃ牽�Ԗڂ̃X���b�g�ɓ����Ă��邩
                int index = Ids.IndexOf(id);
                if (index < 0)
                {
                    // �������̃A�C�e���̏ꍇ�́A�X���b�g��1�����
                    Ids.Add(id);

                    //���̍X�V
                    Qty.Add(number);
                }
                else
                {
                    // ���ɏ������Ă���A�C�e���̏ꍇ�́A�������݂̂�ǉ�
                    Qty[index] += number;
                }
            }

            /// <summary>
            /// �o�b�O������o��
            /// </summary>
            /// <param name="id">���o�������A�C�e����id</param>
            /// <param name="number">���o����</param>
            public void Remove(int id, int number)
            {
                // �A�C�e���ԍ�=id �̃A�C�e�������Ƀo�b�O���ɑ��݂��邩
                // ���݂���Ȃ牽�Ԗڂ̃X���b�g�ɓ����Ă��邩
                int index = Ids.IndexOf(id);
                if (index < 0)
                {
                    // �������̃A�C�e�����ǂ�o�����Ƃ͏o���Ȃ�
                    throw new Exception($"�A�C�e��(id:{id})�̎��o���Ɏ��s���܂���");
                }
                else
                {
                    if (Qty[index] < number)
                    {
                        // �K�v���������Ă��Ȃ�
                        throw new Exception($"�A�C�e��(id:{id})�̎��o���Ɏ��s���܂���");
                    }
                    else
                    {
                        //���o��
                        Qty[index] -= number;

                        if (Qty[index] == 0)
                        {
                            // 0�ɂȂ����ꍇ�̓��X�g����폜
                            Qty.RemoveAt(index);
                            Ids.RemoveAt(index);
                        }
                    }
                }
            }
        }

    }
}