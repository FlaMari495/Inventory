using UnityEngine;

namespace FlMr_Inventory
{
    public abstract class ItemDetailBase : MonoBehaviour
    {
        /// <summary>
        /// �X���b�g���N���b�N���ꂽ�ۂɌĂ΂��R�[���o�b�N���\�b�h
        /// </summary>
        /// <param name="itemBag">�A�C�e���o�b�O</param>
        /// <param name="item">�X���b�g�ɓ����Ă���A�C�e��</param>
        /// <param name="numebr">���̃A�C�e���̏�����</param>
        /// <param name="slotObj">�X���b�g�̃Q�[���I�u�W�F�N�g</param>
        protected internal abstract void OnClickCallback
            (ItemBag itemBag,ItemBase item, int numebr, GameObject slotObj);
    }
}