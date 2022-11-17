using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace FlMr_Inventory
{
    /// <summary>
    /// �A�C�e���X���b�g���N���b�N���ꂽ�ۂɕ\�����郁�j���[
    /// </summary>
    internal class ItemSlotMenu : MonoBehaviour
    {
        /// <summary>
        /// ���j���[���ɕ\������{�^���̃v���n�u
        /// </summary>
        [SerializeField] private GameObject menuButtonPrefab;

        /// <summary>
        /// ���j���[�Ƀ{�^����z�u����
        /// </summary>
        internal void Initialize(ItemBase slotItem, ItemSlotMenuFunctions menuMethods)
        {
            foreach (var menu in menuMethods.MenuItems)
            {
                // �{�^���v���n�u���C���X�^���X��
                var buttonObj = Instantiate(menuButtonPrefab, this.transform);

                // �{�^���ɕ\������e�L�X�g��ύX
                buttonObj.GetComponentInChildren<TextMeshProUGUI>().text = menu.menuName;

                // �{�^���R���|�[�l���g�̎擾
                Button button = buttonObj.GetComponent<Button>();

                // �{�^���������ꂽ�ۂ̋�����ݒ�
                button.onClick.AddListener(() =>
                {
                    menu.function(slotItem);
                    Destroy(this.gameObject);
                });
            }
        }

        /// <summary>
        /// ���t���[���Ă΂�郁�\�b�h
        /// </summary>
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                // �N���b�N�����o���ꂽ�Ƃ�

                // �}�E�X�C�x���g�̐���
                var eventData = new PointerEventData(EventSystem.current)
                { position = Input.mousePosition };

                // ���̕ϐ���Ray���΂������ʂ���������
                var result = new List<RaycastResult>();

                // Ray���΂�
                EventSystem.current.RaycastAll(eventData, result);

                if (!result.Any(r => r.gameObject == this.gameObject))
                {
                    // �J�[�\���ʒu�Ƀ��j���[�����݂��Ȃ������ꍇ�̓��j���[�����
                    Destroy(this.gameObject);
                }
            }
        }

    }
}