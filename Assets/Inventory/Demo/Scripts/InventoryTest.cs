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
            Debug.Log(1 + "�Ԗڂ̃A�C�e��:" + bag.AddItem(1, 1));

            //�J�o���ɓ����Ă���A�C�e���̃f�[�^��\��
            Debug.Log(bag.ToJson());
        }

    }
}