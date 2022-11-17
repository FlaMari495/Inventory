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
        private Dictionary<Type, List<Func_Name_Pair>> MenuItems { get; } = new();

        /// <summary>
        /// ���j���[�ɕ\������鍀�ڂ̒ǉ�
        /// </summary>
        /// <typeparam name="T">�ǂ̌^�ɑ΂��郁�j���[�ł��邩</typeparam>
        /// <param name="name">���j���[�̖��O</param>
        /// <param name="function">�{�^�����N���b�N���ꂽ�ۂɎ��s����@�\</param>
        public void AddMenuItem<T>(string name, Action<ItemBase> function)
        {
            // �^��������Type�^�𐶐�
            var type = typeof(T);

            // �����̃L�[�� type �����݂��Ȃ��ꍇ�A�V�K�ɍ쐬
            if (!MenuItems.ContainsKey(type)) MenuItems.Add(type, new());

            // �����ɒǉ�
            MenuItems[type].Add(new(name, function));
        }

        /// <summary>
        /// ����A�C�e���ɑΉ����郁�j���[���擾����
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        internal List<Func_Name_Pair> GetMenus(ItemBase item)
        {
            // �A�C�e���̌^���擾
            var itemType = item.GetType();

            // ���ʂ��i�[����ϐ�
            var menus = new List<Func_Name_Pair>();

            // �����̗v�f�Ń��[�v
            foreach (var type_func in MenuItems)
            {
                // �A�C�e���̌^���AKey�ɃL���X�g�s�\�ł���ꍇ��continue
                if (!type_func.Key.IsAssignableFrom(itemType)) continue;

                // ���j���[��ǉ�
                menus.AddRange(type_func.Value);
            }

            return menus;
        }
    }


    /// <summary>
    /// ���j���[���Ƌ@�\�̃y�A��ێ������N���X
    /// </summary>
    internal class Func_Name_Pair
    {
        public Func_Name_Pair(string menuName, Action<ItemBase> function)
        {
            this.menuName = menuName;
            this.function = function;
        }

        public string menuName { get; }
        public Action<ItemBase> function { get; }
    }
}