using UnityEngine;

namespace FlMr_Inventory.Demo
{
    public class InventoryTest : MonoBehaviour
    {
        /// <summary>
        /// ����m�F�̑Ώۂł���ItemBag
        /// </summary>
        [SerializeField] private ItemBag bag;

        void Start()
        {
            // 10��ނ����E�ł���J�o���ɁA15��ނ̃A�C�e����ǉ�����
            for (int i = 0; i < 15; i++)
            {
                //�ǉ��ɐ����������ۂ���\��
                Debug.Log(i + "�Ԗڂ̃A�C�e��:" + bag.AddItem(i, 3));
            }

            //�J�o���ɓ����Ă���A�C�e���̃f�[�^��\��
            Debug.Log(bag.ToJson());
        }

    }
}