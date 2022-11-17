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
            // id1�̃A�C�e����1�ǉ�
            bag.AddItem(1, 1);
            Debug.Log(bag.ToJson());

            // id1�̃A�C�e����2�폜
            bag.RemoveItem(1, 2);
            Debug.Log(bag.ToJson());

            // id1�̃A�C�e����1�폜
            bag.RemoveItem(1, 1);
            Debug.Log(bag.ToJson());
        }

    }
}