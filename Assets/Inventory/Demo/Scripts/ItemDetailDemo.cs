using UnityEngine;

namespace FlMr_Inventory.Demo
{
    /// <summary>
    /// ItemDetail�̓���m�F�̂��߂̃N���X
    /// </summary>
    public class ItemDetailDemo : ItemDetailBase
    {
        protected internal override void OnClickCallback
            (ItemBag itemBag, ItemBase item, int number, GameObject slotObj)
        {
            Debug.Log($"{itemBag}����{item.ItemName}���N���b�N����܂����B����{number}�����Ă��܂��B");
        }
    }
}
