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
            // id1�̃A�C�e����2�ǉ�
            bag.AddItem(1, 2);
        }

    }
}