using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
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
        /// ���̃X���b�g�ɓ����Ă���A�C�e���̌���\������e�L�X�g
        /// </summary>
        [SerializeField] private TextMeshProUGUI numberText;

        /// <summary>
        /// ����
        /// </summary>
        private int Number { get; set; }

        /// <summary>
        /// �X���b�g���N���b�N���ꂽ�ۂɎ��s���郁�\�b�h
        /// [ ���� ]
        /// ItemBase : �X���b�g�ɓ����Ă���A�C�e��
        /// int : �A�C�e���̌�
        /// GameObject : ���̃X���b�g�̃I�u�W�F�N�g
        /// </summary>
        private Action<ItemBase,int,GameObject> OnClickCallback { get; set; }

        /// <summary>
        /// ���̃N���X�̃C���X�^���X���������ꂽ�ۂɌĂԃ��\�b�h
        /// </summary>
        /// <param name="onClickCallback"></param>
        internal void Initialize(Action<ItemBase, int, GameObject> onClickCallback)
        {
            OnClickCallback = onClickCallback;
        }

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
                Number = number;

                // �A�C�R���̕\��
                icon.sprite = item.Icon;
                icon.color = Color.white;

                // ���ʂ̕\��
                numberText.gameObject.SetActive(number > 1);
                numberText.text = number.ToString();
            }
            else
            {
                // �A�C�e������ł���ꍇ
                Item = null;
                Number = 0;
                icon.sprite = null;
                icon.color = new Color(0, 0, 0, 0);

                numberText.gameObject.SetActive(false);
            }
        }

        /// <summary>
        /// �X���b�g���N���b�N���ꂽ�Ƃ��ɌĂ΂�郁�\�b�h
        /// </summary>
        public void OnClicked()
        {
            //���̃X���b�g�ɃA�C�e�������݂��Ă���ꍇ
            if (Item != null)
            {
                // �R�[���o�b�N���\�b�h�����s
                OnClickCallback(Item, Number, this.gameObject);
            }
        }
    }

}