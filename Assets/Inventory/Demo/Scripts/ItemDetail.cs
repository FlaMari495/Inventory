using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq;

namespace FlMr_Inventory.Demo
{
    public class ItemDetail : MonoBehaviour
    {
        [SerializeField] private ItemBag itemBag;
        [SerializeField] private Image itemIcon;
        [SerializeField] private TextMeshProUGUI itemNameText;
        private CanvasGroup canvasGroup;

        private ItemBase Item { get; set; }

        public bool IsShow { get; private set; }

        private void Start()
        {
            canvasGroup = this.GetComponent<CanvasGroup>();

            // �����͔�\��
            Hide();
        }

        /// <summary>
        /// ��\���ɂ���
        /// </summary>
        public void Hide()
        {
            // �s�����x0 & �N���b�N�s��
            canvasGroup.alpha = 0;
            canvasGroup.blocksRaycasts = false;
            IsShow = false;
        }

        /// <summary>
        /// �X���b�g���N���b�N���ꂽ�Ƃ��ɌĂ΂�郁�\�b�h
        /// </summary>
        /// <param name="item"></param>
        /// <param name="number"></param>
        /// <param name="slotObj"></param>
        public void Show(ItemBase item,int number,GameObject slotObj)
        {
            // �s�����x1 & �N���b�N��
            canvasGroup.alpha = 1;
            canvasGroup.blocksRaycasts = true;
            IsShow = true;

            Item = item;
            itemIcon.sprite = item.Icon;
            itemNameText.text = item.ItemName;
        }

        /// <summary>
        /// �o�b�O��1�A�C�e����������
        /// </summary>
        public void Add()
        {
            itemBag.AddItem(Item.UniqueId, 1);
        }

        /// <summary>
        /// �o�b�O����A�C�e����1��菜��
        /// </summary>
        public void Remove()
        {
            itemBag.RemoveItem(Item.UniqueId, 1);
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
                    Hide();
                }
            }

            if(IsShow)
            {
                if(itemBag.Find(Item) == 0)
                {
                    Hide();
                }
            }
        }
    }
}
