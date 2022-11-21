using UnityEngine;
using UnityEngine.UI;

namespace FlMr_Inventory.Demo
{
    /// <summary>
    /// ItemDetail�̓���m�F�̂��߂̃N���X
    /// �A�C�e���ɉ������{�^����\��
    /// </summary>
    public class ItemDetailDemo2 : ItemDetailBase
    {
        [SerializeField] private Button buttonPrefabs;
        [SerializeField] private Transform buttonsTrn;

        protected internal override void OnClickCallback
            (ItemBag itemBag, ItemBase item, int number, GameObject slotObj)
        {
            // ���X�������{�^�������ׂč폜
            foreach (Transform trn in buttonsTrn)
            {
                Destroy(trn.gameObject);
            }

            // IUsable�ȃA�C�e�����N���b�N���ꂽ�Ƃ��ɕ\������{�^��
            if (item is IUsable usable)
            {
                var button = Instantiate(buttonPrefabs, buttonsTrn);
            }

            // IDeletable�ȃA�C�e�����N���b�N���ꂽ�Ƃ��ɕ\������{�^��
            if (item is IDeletable)
            {
                var button = Instantiate(buttonPrefabs, buttonsTrn);
            }
        }
    }
}