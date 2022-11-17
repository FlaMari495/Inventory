using System;
using System.Collections.Generic;

namespace FlMr_Inventory
{
    /// <summary>
    /// �e�A�C�e���ɑ΂��Ăǂ̂悤�ȃ��j���[��\�����邩���߂�N���X
    /// </summary>
    public class ItemSlotMenuFunctions
    {
        /// <summary>
        /// ���j���[�ɕ\�������S����
        /// (���̍��ڑS�Ă��\�������킯�ł͂Ȃ��A�A�C�e���ɍ��������ڂ��I��I�ɕ\�������)
        /// </summary>
        internal List<(string menuName, Action<ItemBase> function)> MenuItems { get; } = new();

        /// <summary>
        /// ���j���[�ɕ\������鍀�ڂ̒ǉ�
        /// </summary>
        /// <param name="function"></param>
        public void AddMenuItem(string name, Action<ItemBase> function)
        {
            MenuItems.Add((name, function));
        }
    }
}