using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
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
        internal void Initialize(UnityAction removeItemMethod)
        {
            // �{�^���v���n�u���C���X�^���X��
            var buttonObj = Instantiate(menuButtonPrefab, this.transform);

            // �{�^���ɕ\������e�L�X�g��ύX
            buttonObj.GetComponentInChildren<TextMeshProUGUI>().text = "Delete";

            // �{�^���R���|�[�l���g�̎擾
            Button button = buttonObj.GetComponent<Button>();

            // �{�^���������ꂽ�ۂ̋�����ݒ�
            button.onClick.AddListener(removeItemMethod);
        }

        /// <summary>
        /// �e�X�g�p���\�b�h(��ɍ폜����)
        /// </summary>
        private void Test()
        {
            Debug.Log("Hello World");
        }

    }
}