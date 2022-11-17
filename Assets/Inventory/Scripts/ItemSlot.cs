using System;
using TMPro;
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
        /// ���̃X���b�g�ɓ����Ă���A�C�e���̌���\������e�L�X�g
        /// </summary>
        [SerializeField] private TextMeshProUGUI numberText;

        /// <summary>
        /// �X���b�g���N���b�N���ꂽ�ۂɕ\�����郁�j���[
        /// </summary>
        [SerializeField] private GameObject menuLayoutPrefab;

        /// <summary>
        /// ���j���[�̕\���ʒu
        /// </summary>
        [SerializeField] private Transform menuLayoutTrn;

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

                numberText.gameObject.SetActive(number > 1);
                numberText.text = number.ToString();
            }
            else
            {
                // �A�C�e������ł���ꍇ
                Item = null;
                icon.sprite = null;
                icon.color = new Color(0, 0, 0, 0);

                numberText.gameObject.SetActive(false);
            }
        }

        public void OnClicked()
        {
            // ���̃X���b�g�ɃA�C�e�������݂��Ă���ꍇ
            if (Item != null)
            {
                // ���j���[��\������
                var menuObj = Instantiate(menuLayoutPrefab, menuLayoutTrn);
                menuObj.GetComponent<ItemSlotMenu>()
                    .Initialize(() => RemoveItemMethod(Item.UniqueId, 1));

                menuObj.transform.SetParent(GetComponentInParent<Canvas>().transform, true);
            }
        }

        /// <summary>
        /// �A�C�e�����폜���郁�\�b�h
        /// (ItemSlotMenu�N���X�ɓn��)
        /// </summary>
        private Func<int, int, bool> RemoveItemMethod { get; set; }

        /// <summary>
        /// ItemSlotMenu�ɕ\�����鍀�ڂ�ݒ肷��
        /// </summary>
        /// <param name="deleteMethod"></param>
        internal void Initialize(Func<int, int, bool> removeItemMethod)
        {
            RemoveItemMethod = removeItemMethod;
        }


    }

}