using UnityEngine;

namespace FlMr_Inventory
{
    /// <summary>
    /// �v���C���[�̏����A�C�e��
    /// </summary>
    public class PlayerItemBag : ItemBag
    {
        protected override void AddMenuFunction(ItemSlotMenuFunctions funcs)
        {
            // �g�p�\�ȃA�C�e���ɕ\�����郁�j���[
            funcs.AddMenuItem<IUsable>("use", item =>
            {
                IUsable usable = item as IUsable;

                // ���ݎg�p�\������
                if (usable.Check())
                {
                    // ���ʂ𔭓�
                    usable.Use();

                    // 1����
                    RemoveItem(item.UniqueId, 1);
                }
            });

            // �폜�\�ȃA�C�e���ɕ\�����郁�j���[
            funcs.AddMenuItem<IDeletable>("Delete", item => RemoveItem(item.UniqueId, 1));

            // �S�ẴA�C�e���ɕ\�����郁�j���[
            funcs.AddMenuItem<ItemBase>("Description", item => Debug.Log(item.Description));
        }
    }
}